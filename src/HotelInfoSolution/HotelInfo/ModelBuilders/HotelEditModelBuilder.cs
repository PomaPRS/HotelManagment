using Hotel.Web.Common;
using HotelInfo.Models;

namespace HotelInfo.ModelBuilders
{
    public class HotelEditModelBuilder : IModelBuilder<HotelEditModel, Hotel.Database.Model.Hotel>
    {
        public HotelEditModel CreateFrom(Hotel.Database.Model.Hotel entity)
        {
            return new HotelEditModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Address = entity.Address,
                IndividualId = entity.IndividualId,
            };
        }

        public HotelEditModel Rebuild(HotelEditModel model)
        {
            return model;
        }
    }
}