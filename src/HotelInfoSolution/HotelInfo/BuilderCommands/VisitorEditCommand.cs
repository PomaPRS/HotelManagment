using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.BuilderCommands
{
    public class VisitorEditCommand : IModelCommand<VisitorEditModel, Visitor>
    {
        private readonly IRepository<Visitor> _visitorRepo;

        [Inject]
        public VisitorEditCommand(IRepository<Visitor> visitorRepo)
        {
            _visitorRepo = visitorRepo;
        }

        public Visitor Execute(VisitorEditModel model)
        {
            var visitor = _visitorRepo.Get(model.Id);
            visitor.Id = model.Id;
            visitor.FirstName = model.FirstName;
            visitor.MiddleName = model.MiddleName;
            visitor.SecondName = model.SecondName;

            _visitorRepo.Update(visitor);
            _visitorRepo.SaveChanges();

            return visitor;
        }
    }
}