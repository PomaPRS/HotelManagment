using System.Linq;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Extensions;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.BuilderCommands
{
    public class ReservationCreateCommand : IModelCommand<ReservationCreateModel, Reservation>
    {
        private readonly IRepository<Reservation> _reservationRepo;
        private readonly IRepository<Room> _roomRepo;
        private readonly IRepository<Visitor> _visitorRepo;

        [Inject]
        public ReservationCreateCommand(
            IRepository<Reservation> reservationRepo, 
            IRepository<Room> roomRepo, 
            IRepository<Visitor> visitorRepo)
        {
            _reservationRepo = reservationRepo;
            _roomRepo = roomRepo;
            _visitorRepo = visitorRepo;
        }

        public Reservation Execute(ReservationCreateModel model)
        {
            var room = _roomRepo.GetRange(x => x.Number == model.RoomNumber && x.Hotel.Title == model.HotelTitle)
                .First();
            var visitors = _visitorRepo.GetRange();
            var names = model.VisitorName.Split(' ').Where(x => !string.IsNullOrEmpty(x));
            foreach (var name in names)
            {
                visitors = visitors.Where(x => x.FirstName.Contains(name) ||
                                               x.SecondName.Contains(name) ||
                                               x.MiddleName.Contains(name));
            }
            var visitor = visitors.First();

            var reservation = new Reservation
            {
                ArrivalDate = model.ArrivalDate,
                DepartureDate = model.DepartureDate,
                Advance = model.Advance,
                RoomId = room.Id,
                VisitorId = visitor.Id
            };

            _reservationRepo.Add(reservation);
            _reservationRepo.SaveChanges();

            return reservation;
        }
    }
}