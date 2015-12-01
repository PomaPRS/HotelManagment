using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Extensions;
using HotelInfo.Models;

namespace HotelInfo.ModelBuilders
{
    public class ReservationViewModelBuilder : IModelBuilder<ReservationViewModel, Reservation>
    {
        public ReservationViewModel CreateFrom(Reservation entity)
        {
            return new ReservationViewModel()
            {
                Id = entity.Id,
                Advance = entity.Advance,
                ArrivalDate = entity.ArrivalDate,
                DepartureDate = entity.DepartureDate,
                RoomNumber = entity.Room.Number,
                HotelTitle = entity.Room.Hotel.Title,
                VisitorName = entity.Visitor.GetName(),
            };
        }

        public ReservationViewModel Rebuild(ReservationViewModel model)
        {
            return model;
        }
    }
}