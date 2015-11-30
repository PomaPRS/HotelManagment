using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.ModelBuilders
{
    public class WorkerViewModelBuilder : IModelBuilder<WorkerViewModel, Worker>
    {
        private readonly IRepository<Hotel.Database.Model.Hotel> _hotelRepo;
        private readonly IRepository<Position> _positionRepo;

        [Inject]
        public WorkerViewModelBuilder(
            IRepository<Hotel.Database.Model.Hotel> hotelRepo, 
            IRepository<Position> positionRepo)
        {
            _hotelRepo = hotelRepo;
            _positionRepo = positionRepo;
        }

        public WorkerViewModel CreateFrom(Worker entity)
        {
            return new WorkerViewModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                SecondName = entity.SecondName,
                MiddleName = entity.MiddleName,
                IndividualId = entity.IndividualId,
                PositionTitle = entity.Position.Title,
                HotelTitle = entity.Hotel.Title,
            };
        }

        public WorkerViewModel Rebuild(WorkerViewModel model)
        {
            return model;
        }
    }
}