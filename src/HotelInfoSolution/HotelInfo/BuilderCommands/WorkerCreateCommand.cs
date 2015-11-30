using System.Linq;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.BuilderCommands
{
    public class WorkerCreateCommand : IModelCommand<WorkerCreateModel, Worker>
    {
        private readonly IRepository<Worker> _workerRepo;
        private readonly IRepository<Hotel.Database.Model.Hotel> _hotelRepo;
        private readonly IRepository<Position> _poritionRepo;

        [Inject]
        public WorkerCreateCommand(
            IRepository<Worker> workerRepo, 
            IRepository<Hotel.Database.Model.Hotel> hotelRepo, 
            IRepository<Position> poritionRepo)
        {
            _workerRepo = workerRepo;
            _hotelRepo = hotelRepo;
            _poritionRepo = poritionRepo;
        }

        public Worker Execute(WorkerCreateModel model)
        {
            var hotel = _hotelRepo.GetRange(x => x.Title == model.HotelTitle).First();
            var position = _poritionRepo.GetRange(x => x.Title == model.PositionTitle).First();

            var worker = new Worker
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                SecondName = model.SecondName,
                IndividualId = model.IndividualId,
                HotelId = hotel.Id,
                PositionId = position.Id
            };

            _workerRepo.Add(worker);
            _workerRepo.SaveChanges();

            return worker;
        }
    }
}