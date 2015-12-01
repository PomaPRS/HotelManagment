using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Extensions;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.ModelBuilders
{
    public class ReservationIndexViewBuilder : IModelBuilder<ReservationIndexViewModel, ReservationFilterModel>
    {
        private readonly IRepository<Reservation> _reservationRepo;

        [Inject]
        public ReservationIndexViewBuilder(IRepository<Reservation> reservationRepo)
        {
            _reservationRepo = reservationRepo;
        }

        public ReservationIndexViewModel CreateFrom(ReservationFilterModel filter)
        {
            return new ReservationIndexViewModel()
            {
                Reservations = GetReservationItems(filter),
                Filter = filter
            };
        }

        public ReservationIndexViewModel Rebuild(ReservationIndexViewModel model)
        {
            model.Reservations = GetReservationItems(model.Filter);
            return model;
        }

        private List<SelectListItem> GetReservationItems(ReservationFilterModel filter)
        {
            var reservations = _reservationRepo.GetRange();
            if (!string.IsNullOrEmpty(filter.HotelTitle))
                reservations = reservations.Where(x => x.Room.Hotel.Title.Contains(filter.HotelTitle));
            if (!string.IsNullOrEmpty(filter.RoomNumber))
                reservations = reservations.Where(x => x.Room.Number.Contains(filter.RoomNumber));
            if (!string.IsNullOrEmpty(filter.VisitorName))
            {
                var names = filter.VisitorName.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList();
                foreach (var name in names)
                {
                    reservations = reservations.Where(x =>
                        x.Visitor.FirstName.Contains(name) ||
                        x.Visitor.SecondName.Contains(name) ||
                        x.Visitor.MiddleName.Contains(name));
                }
            }
            if (filter.FromAdvance != null)
                reservations = reservations.Where(x => x.Advance >= filter.FromAdvance);
            if (filter.ToAdvance != null)
                reservations = reservations.Where(x => x.Advance <= filter.ToAdvance);
            if (filter.FromArrivalDate != null)
                reservations = reservations.Where(x => x.ArrivalDate >= filter.FromArrivalDate);
            if (filter.ToAdvance != null)
                reservations = reservations.Where(x => x.ArrivalDate <= filter.ToArrivalDate);
            if (filter.FromDepartureDate != null)
                reservations = reservations.Where(x => x.DepartureDate >= filter.FromDepartureDate);
            if (filter.ToAdvance != null)
                reservations = reservations.Where(x => x.DepartureDate <= filter.ToDepartureDate);

            switch (filter.SortingType)
            {
                case ReservationSortingType.ByAdvance:
                    reservations = reservations.OrderBy(x => x.Advance);
                    break;
                case ReservationSortingType.ByArrivalDate:
                    reservations = reservations.OrderBy(x => x.ArrivalDate);
                    break;
                case ReservationSortingType.ByDepartureDate:
                    reservations = reservations.OrderBy(x => x.DepartureDate);
                    break;
                case ReservationSortingType.ByHotelTitleAndRoomNumber:
                    reservations = reservations
                        .OrderBy(x => x.Room.Hotel.Title)
                        .ThenBy(x => x.Room.Number);
                    break;
                case ReservationSortingType.ByVisitorName:
                    reservations = reservations
                        .OrderBy(x => x.Visitor.FirstName)
                        .ThenBy(x => x.Visitor.SecondName)
                        .ThenBy(x => x.Visitor.MiddleName);
                    break;
                case ReservationSortingType.ById:
                default:
                    reservations = reservations.OrderBy(x => x.Id);
                    break;
            }

            int page = filter.Page ?? 1;
            int pageSize = 50;

            var reservationItems = reservations
                .Skip(pageSize*(page-1))
                .Take(pageSize)
                .ToList()
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = string.Format("{0}: {1}, {2}", x.Visitor.GetName(), x.Room.Hotel.Title, x.Room.Number)
                })
                .ToList();
            return reservationItems;
        }
    }
}