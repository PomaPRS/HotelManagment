using System.Linq;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.BuilderCommands
{
    public class PositionEditCommand : IModelCommand<PositionEditModel, Position>
    {
        private readonly IRepository<Position> _positionRepo;

        [Inject]
        public PositionEditCommand(IRepository<Position> positionRepo)
        {
            _positionRepo = positionRepo;
        }

        public Position Execute(PositionEditModel model)
        {
            var position = _positionRepo.Get(model.Id);
            position.Id = model.Id;
            position.Title = model.Title;

            _positionRepo.Update(position);
            _positionRepo.SaveChanges();

            return position;
        }
    }
}