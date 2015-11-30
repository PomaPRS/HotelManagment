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
    public class WorkerIndexViewBuilder : IModelBuilder<WorkerIndexViewModel, WorkerFilterModel>
    {
        private readonly IRepository<Worker> _workerRepo;

        [Inject]
        public WorkerIndexViewBuilder(IRepository<Worker> workerRepo)
        {
            _workerRepo = workerRepo;
        }

        public WorkerIndexViewModel CreateFrom(WorkerFilterModel filter)
        {
            return new WorkerIndexViewModel()
            {
                Workers = GetWorkerItems(filter),
                Filter = filter
            };
        }

        public WorkerIndexViewModel Rebuild(WorkerIndexViewModel model)
        {
            model.Workers = GetWorkerItems(model.Filter);
            return model;
        }

        private List<SelectListItem> GetWorkerItems(WorkerFilterModel filter)
        {
            var workers = _workerRepo.GetRange();
            if (!string.IsNullOrEmpty(filter.HotelTitle))
                workers = workers.Where(x => x.Hotel.Title.Contains(filter.HotelTitle));
            if (!string.IsNullOrEmpty(filter.PositionTitle))
                workers = workers.Where(x => x.Position.Title.Contains(filter.PositionTitle));
            if (!string.IsNullOrEmpty(filter.IndividualId))
                workers = workers.Where(x => x.IndividualId == filter.IndividualId);
            if (!string.IsNullOrEmpty(filter.Name))
            {
                var names = filter.Name.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                foreach (var name in names)
                {
                    workers = workers.Where(x =>
                        x.FirstName.Contains(name) ||
                        x.SecondName.Contains(name) ||
                        x.MiddleName.Contains(name));
                }
            }

            switch (filter.SortingType)
            {
                case WorkerSortingType.ByName:
                    workers = workers
                        .OrderBy(x => x.FirstName)
                        .ThenBy(x => x.SecondName)
                        .ThenBy(x => x.MiddleName);
                    break;
                case WorkerSortingType.ByHotelName:
                    workers = workers.OrderBy(x => x.Hotel.Title);
                    break;
                case WorkerSortingType.ByPosition:
                    workers = workers.OrderBy(x => x.Position.Title);
                    break;
                case WorkerSortingType.ById:
                default:
                    workers = workers.OrderBy(x => x.Id);
                    break;
            }

            int page = filter.Page ?? 1;
            int pageSize = 50;

            var workerItems = workers
                .Skip(pageSize*(page-1))
                .Take(pageSize)
                .AsEnumerable()
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = string.Format("{0} {1} {2}", x.FirstName, x.SecondName, x.MiddleName)
                })
                .ToList();
            return workerItems;
        }
    }
}