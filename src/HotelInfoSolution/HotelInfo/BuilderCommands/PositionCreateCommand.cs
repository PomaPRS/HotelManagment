using System.Linq;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.BuilderCommands
{
    public class PositionCreateCommand : IModelCommand<PositionCreateModel, Position>
    {
        private readonly IRepository<Position> _positionRepo;

        [Inject]
        public PositionCreateCommand(IRepository<Position> positionRepo)
        {
            _positionRepo = positionRepo;
        }

        public Position Execute(PositionCreateModel model)
        {
            var position = new Position
            {
                Title = model.Title
            };

            _positionRepo.Add(position);
            _positionRepo.SaveChanges();

            return position;
        }
    }
}