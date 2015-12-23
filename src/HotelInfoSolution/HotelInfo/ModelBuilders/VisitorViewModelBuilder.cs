using System.Linq;
using System.Web.Mvc;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;

namespace HotelInfo.ModelBuilders
{
    public class VisitorViewModelBuilder : IModelBuilder<VisitorViewModel, Visitor>
    {
        public VisitorViewModel CreateFrom(Visitor entity)
        {
            var reservation = entity.Reservations
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = string.Format("{0}: {1}", x.Room.Hotel.Title, x.Room.Number)
                })
                .ToList();

            return new VisitorViewModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                SecondName = entity.SecondName,
                MiddleName = entity.MiddleName,
                Reservations = reservation
            };
        }

        public VisitorViewModel Rebuild(VisitorViewModel model)
        {
            return model;
        }
    }
}