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
    public class PositionIndexViewBuilder : IModelBuilder<PositionIndexViewModel, PositionFilterModel>
    {
        private readonly IRepository<Position> _positionRepo;

        [Inject]
        public PositionIndexViewBuilder(IRepository<Position> positionRepo)
        {
            _positionRepo = positionRepo;
        }

        public PositionIndexViewModel CreateFrom(PositionFilterModel filter)
        {
            return new PositionIndexViewModel()
            {
                Positions = GetPositionItems(filter),
                Filter = filter
            };
        }

        public PositionIndexViewModel Rebuild(PositionIndexViewModel model)
        {
            model.Positions = GetPositionItems(model.Filter);
            return model;
        }

        private List<SelectListItem> GetPositionItems(PositionFilterModel filter)
        {
            var positions = _positionRepo.GetRange();
            if (!string.IsNullOrEmpty(filter.Title))
                positions = positions.Where(x => x.Title.Contains(filter.Title));

            switch (filter.SortingType)
            {
                case PositionSortingType.ByTitle:
                    positions = positions.OrderBy(x => x.Title);
                    break;
                case PositionSortingType.ById:
                default:
                    positions = positions.OrderBy(x => x.Id);
                    break;
            }

            int page = filter.Page ?? 1;
            int pageSize = 50;

            var positionItems = positions
                .Skip(pageSize*(page-1))
                .Take(pageSize)
                .AsEnumerable()
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Title
                })
                .ToList();
            return positionItems;
        }
    }
}