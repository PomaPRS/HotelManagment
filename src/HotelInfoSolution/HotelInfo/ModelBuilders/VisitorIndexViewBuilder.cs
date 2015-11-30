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
    public class VisitorIndexViewBuilder : IModelBuilder<VisitorIndexViewModel, VisitorFilterModel>
    {
        private readonly IRepository<Visitor> _visitorRepo;

        [Inject]
        public VisitorIndexViewBuilder(IRepository<Visitor> visitorRepo)
        {
            _visitorRepo = visitorRepo;
        }

        public VisitorIndexViewModel CreateFrom(VisitorFilterModel filter)
        {
            return new VisitorIndexViewModel()
            {
                Visitors = GetVisitorItems(filter),
                Filter = filter
            };
        }

        public VisitorIndexViewModel Rebuild(VisitorIndexViewModel model)
        {
            model.Visitors = GetVisitorItems(model.Filter);
            return model;
        }

        private List<SelectListItem> GetVisitorItems(VisitorFilterModel filter)
        {
            var visitors = _visitorRepo.GetRange();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                var names = filter.Name.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                foreach (var name in names)
                {
                    visitors = visitors.Where(x =>
                        x.FirstName.Contains(name) ||
                        x.SecondName.Contains(name) ||
                        x.MiddleName.Contains(name));
                }
            }

            switch (filter.SortingType)
            {
                case VisitorSortingType.ByName:
                    visitors = visitors
                        .OrderBy(x => x.FirstName)
                        .ThenBy(x => x.SecondName)
                        .ThenBy(x => x.MiddleName);
                    break;
                case VisitorSortingType.ById:
                default:
                    visitors = visitors.OrderBy(x => x.Id);
                    break;
            }

            int page = filter.Page ?? 1;
            int pageSize = 50;

            var visitorItems = visitors
                .Skip(pageSize*(page-1))
                .Take(pageSize)
                .AsEnumerable()
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = string.Format("{0} {1} {2}", x.FirstName, x.SecondName, x.MiddleName)
                })
                .ToList();
            return visitorItems;
        }
    }
}