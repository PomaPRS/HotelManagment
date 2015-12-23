using System.Linq;
using System.Web.Mvc;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;

namespace HotelInfo.ModelBuilders
{
    public class PositionViewModelBuilder : IModelBuilder<PositionViewModel, Position>
    {
        public PositionViewModel CreateFrom(Position entity)
        {
            var workers = entity.Workers.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = string.Format("{0} {1} {2}", x.FirstName, x.SecondName, x.MiddleName)
            })
            .ToList();

            return new PositionViewModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Workers = workers
            };
        }

        public PositionViewModel Rebuild(PositionViewModel model)
        {
            return model;
        }
    }
}