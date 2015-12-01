using System.Linq;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.BuilderCommands
{
    public class ReservationEditCommand : IModelCommand<ReservationEditModel, Reservation>
    {
        private readonly IRepository<Reservation> _reservationRepo;
        private readonly IRepository<Room> _roomRepo;
        private readonly IRepository<Visitor> _visitorRepo;

        [Inject]
        public ReservationEditCommand(
            IRepository<Reservation> reservationRepo, 
            IRepository<Room> roomRepo, 
            IRepository<Visitor> visitorRepo)
        {
            _reservationRepo = reservationRepo;
            _roomRepo = roomRepo;
            _visitorRepo = visitorRepo;
        }

        public Reservation Execute(ReservationEditModel model)
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

            var reservation = _reservationRepo.Get(model.Id);
            reservation.Id = model.Id;
            reservation.Advance = model.Advance;
            reservation.ArrivalDate = model.ArrivalDate;
            reservation.DepartureDate = model.DepartureDate;
            reservation.RoomId = room.Id;
            reservation.VisitorId = visitor.Id;

            _reservationRepo.Update(reservation);
            _reservationRepo.SaveChanges();

            return reservation;
        }
    }
}