using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;

namespace HotelInfo.ModelBuilders
{
    public class PositionViewModelBuilder : IModelBuilder<PositionViewModel, Position>
    {
        public PositionViewModel CreateFrom(Position entity)
        {
            return new PositionViewModel()
            {
                Id = entity.Id,
                Title = entity.Title
            };
        }

        public PositionViewModel Rebuild(PositionViewModel model)
        {
            return model;
        }
    }
}