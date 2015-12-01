using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;

namespace HotelInfo.ModelBuilders
{
    public class RoomViewModelBuilder : IModelBuilder<RoomViewModel, Room>
    {
        public RoomViewModel CreateFrom(Room entity)
        {
            return new RoomViewModel()
            {
                Id = entity.Id,
                Number = entity.Number,
                State = entity.State,
                CostPerDay = entity.CostPerDay,
                Description = entity.Description,
                PlaceCount = entity.PlaceCount,
                HotelTitle = entity.Hotel.Title
            };
        }

        public RoomViewModel Rebuild(RoomViewModel model)
        {
            return model;
        }
    }
}