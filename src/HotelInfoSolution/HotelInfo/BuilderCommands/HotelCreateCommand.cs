using System.Linq;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.BuilderCommands
{
    public class HotelCreateCommand : IModelCommand<HotelCreateModel, Hotel.Database.Model.Hotel>
    {
        private readonly IRepository<Hotel.Database.Model.Hotel> _hotelRepo;
        private readonly IRepository<Worker> _workerRepo;
        private readonly IRepository<Position> _positionRepo;

        [Inject]
        public HotelCreateCommand(
            IRepository<Hotel.Database.Model.Hotel> hotelRepo, 
            IRepository<Worker> workerRepo, 
            IRepository<Position> positionRepo)
        {
            _hotelRepo = hotelRepo;
            _workerRepo = workerRepo;
            _positionRepo = positionRepo;
        }

        public Hotel.Database.Model.Hotel Execute(HotelCreateModel model)
        {
            var hotel = new Hotel.Database.Model.Hotel
            {
                Address = model.Address,
                IndividualId = model.IndividualId,
                Title = model.Title
            };

            _hotelRepo.Add(hotel);
            _hotelRepo.SaveChanges();

            if (!string.IsNullOrEmpty(model.Boss.FirstName) &&
                !string.IsNullOrEmpty(model.Boss.SecondName) &&
                !string.IsNullOrEmpty(model.Boss.MiddleName) &&
                !string.IsNullOrEmpty(model.Boss.IndividualId))
            {
                var position = _positionRepo.GetRange(x => x.Title == "Директор").Single();

                var worker = new Worker()
                {
                    FirstName = model.Boss.FirstName,
                    SecondName = model.Boss.SecondName,
                    MiddleName = model.Boss.MiddleName,
                    IndividualId = model.Boss.IndividualId,
                    HotelId = hotel.Id,
                    PositionId = position.Id
                };

                _workerRepo.Add(worker);
                _workerRepo.SaveChanges();
            }

            return hotel;
        }
    }
}