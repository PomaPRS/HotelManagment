using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;

namespace HotelInfo.ModelBuilders
{
    public class VisitorViewModelBuilder : IModelBuilder<VisitorViewModel, Visitor>
    {
        public VisitorViewModel CreateFrom(Visitor entity)
        {
            return new VisitorViewModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                SecondName = entity.SecondName,
                MiddleName = entity.MiddleName,
            };
        }

        public VisitorViewModel Rebuild(VisitorViewModel model)
        {
            return model;
        }
    }
}