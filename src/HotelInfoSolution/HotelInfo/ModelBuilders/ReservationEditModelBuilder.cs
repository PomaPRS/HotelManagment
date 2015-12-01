using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Extensions;
using HotelInfo.Models;

namespace HotelInfo.ModelBuilders
{
    public class ReservationEditModelBuilder : IModelBuilder<ReservationEditModel, Reservation>
    {
        public ReservationEditModel CreateFrom(Reservation entity)
        {
            return new ReservationEditModel
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

        public ReservationEditModel Rebuild(ReservationEditModel model)
        {
            return model;
        }
    }
}