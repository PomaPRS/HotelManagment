using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Hotel.Database.Common;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.ModelBuilders
{
    public class HotelIndexViewBuilder : IModelBuilder<HotelIndexViewModel, HotelFilterModel>
    {
        private readonly IRepository<Hotel.Database.Model.Hotel> _hotelRepo;

        [Inject]
        public HotelIndexViewBuilder(IRepository<Hotel.Database.Model.Hotel> hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        public HotelIndexViewModel CreateFrom(HotelFilterModel filter)
        {
            return new HotelIndexViewModel()
            {
                Hotels = GetHotelItems(filter),
                Filter = filter
            };
        }

        public HotelIndexViewModel Rebuild(HotelIndexViewModel model)
        {
            model.Hotels = GetHotelItems(model.Filter);
            return model;
        }

        private List<SelectListItem> GetHotelItems(HotelFilterModel filter)
        {
            var hotels = _hotelRepo.GetRange();
            if (!string.IsNullOrEmpty(filter.Title))
                hotels = hotels.Where(x => x.Title.Contains(filter.Title));
            if (!string.IsNullOrEmpty(filter.Address))
                hotels = hotels.Where(x => x.Address.Contains(filter.Address));
            if (!string.IsNullOrEmpty(filter.IndividualId))
                hotels = hotels.Where(x => x.IndividualId == filter.IndividualId);

            switch (filter.SortingType)
            {
                case HotelSortingType.ByTitle:
                    hotels = hotels.OrderBy(x => x.Title);
                    break;
                case HotelSortingType.ById:
                default:
                    hotels = hotels.OrderBy(x => x.Id);
                    break;
            }

            int page = filter.Page ?? 1;
            int pageSize = 50;

            var hotelItems = hotels
                .Skip(pageSize*(page-1))
                .Take(pageSize)
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Title
                })
                .ToList();
            return hotelItems;
        }
    }
}