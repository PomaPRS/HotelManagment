using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.ModelBuilders
{
    public class RoomIndexViewBuilder : IModelBuilder<RoomIndexViewModel, RoomFilterModel>
    {
        private readonly IRepository<Room> _roomRepo;

        [Inject]
        public RoomIndexViewBuilder(IRepository<Room> roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public RoomIndexViewModel CreateFrom(RoomFilterModel filter)
        {
            return new RoomIndexViewModel()
            {
                Rooms = GetRoomItems(filter),
                Filter = filter
            };
        }

        public RoomIndexViewModel Rebuild(RoomIndexViewModel model)
        {
            model.Rooms = GetRoomItems(model.Filter);
            return model;
        }

        private List<SelectListItem> GetRoomItems(RoomFilterModel filter)
        {
            var rooms = _roomRepo.GetRange();
            if (filter.FromPlaceCount != null)
                rooms = rooms.Where(x => x.PlaceCount >= filter.FromPlaceCount);
            if (filter.ToPlaceCount != null)
                rooms = rooms.Where(x => x.PlaceCount <= filter.ToPlaceCount);
            if (filter.FromCostPerDay != null)
                rooms = rooms.Where(x => x.CostPerDay >= filter.FromCostPerDay);
            if (filter.ToCostPerDay != null)
                rooms = rooms.Where(x => x.CostPerDay <= filter.ToCostPerDay);
            if (!string.IsNullOrEmpty(filter.Description))
                rooms = rooms.Where(x => x.Description.Contains(filter.Description));
            if (filter.State != null)
                rooms = rooms.Where(x => x.State == filter.State);
            if (!string.IsNullOrEmpty(filter.HotelTitle))
                rooms = rooms.Where(x => x.Hotel.Title == filter.HotelTitle);
            if (!string.IsNullOrEmpty(filter.Number))
                rooms = rooms.Where(x => x.Number == filter.Number);

            switch (filter.SortingType)
            {
                case RoomSortingType.ByCost:
                    rooms = rooms.OrderBy(x => x.CostPerDay);
                    break;
                case RoomSortingType.ByPlaceCount:
                    rooms = rooms.OrderBy(x => x.PlaceCount);
                    break;
                case RoomSortingType.ByState:
                    rooms = rooms.OrderBy(x => x.State);
                    break;
                case RoomSortingType.ById:
                default:
                    rooms = rooms.OrderBy(x => x.Id);
                    break;
            }

            int page = filter.Page ?? 1;
            int pageSize = 50;

            var roomItems = rooms
                .Skip(pageSize*(page-1))
                .Take(pageSize)
                .ToList()
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = string.Format("{0}: {1}", x.Hotel.Title, x.Number)
                })
                .ToList();
            return roomItems;
        }
    }
}