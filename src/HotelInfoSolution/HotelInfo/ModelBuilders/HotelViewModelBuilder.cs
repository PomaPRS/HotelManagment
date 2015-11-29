using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Hotel.Database;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.ModelBuilders
{
    public class HotelViewModelBuilder : IModelBuilder<HotelViewModel, Hotel.Database.Model.Hotel>
    {
        private readonly IRepository<Worker> _workerRepo;

        [Inject]
        public HotelViewModelBuilder(IRepository<Worker> workerRepo)
        {
            _workerRepo = workerRepo;
        }

        public HotelViewModel CreateFrom(Hotel.Database.Model.Hotel entity)
        {
            return new HotelViewModel()
            {
                Id = entity.Id,
                Address = entity.Address,
                IndividualId = entity.IndividualId,
                Title = entity.Title,
                Workers = GetWorkers(entity.Id)
            };
        }

        private ICollection<SelectListItem> GetWorkers(long hotelId)
        {
            return _workerRepo
                .GetRange(x => x.HotelId == hotelId)
                .Select(x => new SelectListItem()
                {
                    Text = string.Format("{0} {1} {2}", x.FirstName, x.SecondName, x.MiddleName),
                    Value = x.Id.ToString()
                })
                .ToList();
        }

        public HotelViewModel Rebuild(HotelViewModel model)
        {
            model.Workers = GetWorkers(model.Id);
            return model;
        }
    }
}