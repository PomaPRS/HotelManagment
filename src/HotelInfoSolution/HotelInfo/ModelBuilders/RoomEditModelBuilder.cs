using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;

namespace HotelInfo.ModelBuilders
{
    public class RoomEditModelBuilder : IModelBuilder<RoomEditModel, Room>
    {
        public RoomEditModel CreateFrom(Room entity)
        {
            return new RoomEditModel
            {
                Id = entity.Id,
                Description = entity.Description,
                PlaceCount = entity.PlaceCount,
                State = entity.State,
                CostPerDay = entity.CostPerDay,
                HotelTitle = entity.Hotel.Title,
                Number = entity.Number
            };
        }

        public RoomEditModel Rebuild(RoomEditModel model)
        {
            return model;
        }
    }
}