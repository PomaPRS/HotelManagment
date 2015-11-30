using System.Linq;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.BuilderCommands
{
    public class WorkerEditCommand : IModelCommand<WorkerEditModel, Worker>
    {
        private readonly IRepository<Worker> _workerRepo;
        private readonly IRepository<Hotel.Database.Model.Hotel> _hotelRepo;
        private readonly IRepository<Position> _poritionRepo;

        [Inject]
        public WorkerEditCommand(
            IRepository<Worker> workerRepo, 
            IRepository<Hotel.Database.Model.Hotel> hotelRepo, 
            IRepository<Position> poritionRepo)
        {
            _workerRepo = workerRepo;
            _hotelRepo = hotelRepo;
            _poritionRepo = poritionRepo;
        }

        public Worker Execute(WorkerEditModel model)
        {
            var hotel = _hotelRepo.GetRange(x => x.Title == model.HotelTitle).First();
            var position = _poritionRepo.GetRange(x => x.Title == model.PositionTitle).First();

            var worker = _workerRepo.Get(model.Id);
            worker.Id = model.Id;
            worker.FirstName = model.FirstName;
            worker.MiddleName = model.MiddleName;
            worker.SecondName = model.SecondName;
            worker.IndividualId = model.IndividualId;
            worker.HotelId = hotel.Id;
            worker.PositionId = position.Id;

            _workerRepo.Update(worker);
            _workerRepo.SaveChanges();

            return worker;
        }
    }
}