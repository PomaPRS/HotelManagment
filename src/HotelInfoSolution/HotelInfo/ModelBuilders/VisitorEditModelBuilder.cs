using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;

namespace HotelInfo.ModelBuilders
{
    public class VisitorEditModelBuilder : IModelBuilder<VisitorEditModel, Visitor>
    {
        public VisitorEditModel CreateFrom(Visitor entity)
        {
            return new VisitorEditModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                SecondName = entity.SecondName
            };
        }

        public VisitorEditModel Rebuild(VisitorEditModel model)
        {
            return model;
        }
    }
}