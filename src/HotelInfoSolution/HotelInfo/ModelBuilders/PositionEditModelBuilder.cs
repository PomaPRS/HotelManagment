using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;

namespace HotelInfo.ModelBuilders
{
    public class PositionEditModelBuilder : IModelBuilder<PositionEditModel, Position>
    {
        public PositionEditModel CreateFrom(Position entity)
        {
            return new PositionEditModel
            {
                Id = entity.Id,
                Title = entity.Title
            };
        }

        public PositionEditModel Rebuild(PositionEditModel model)
        {
            return model;
        }
    }
}