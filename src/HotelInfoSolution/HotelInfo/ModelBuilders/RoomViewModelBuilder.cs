using System.Linq;
using System.Web.Mvc;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;

namespace HotelInfo.ModelBuilders
{
    public class RoomViewModelBuilder : IModelBuilder<RoomViewModel, Room>
    {
        public RoomViewModel CreateFrom(Room entity)
        {
            var reservation = entity.Reservations
                .Select(x => new SelectListItem()
                {
                    Text = string.Format("{0}: {1}", x.Room.Hotel.Title, x.Room.Number),
                    Value = x.Id.ToString()
                })
                .ToList();

            return new RoomViewModel()
            {
                Id = entity.Id,
                Number = entity.Number,
                State = entity.State,
                CostPerDay = entity.CostPerDay,
                Description = entity.Description,
                PlaceCount = entity.PlaceCount,
                HotelTitle = entity.Hotel.Title,
                Reservations = reservation
            };
        }

        public RoomViewModel Rebuild(RoomViewModel model)
        {
            return model;
        }
    }
}