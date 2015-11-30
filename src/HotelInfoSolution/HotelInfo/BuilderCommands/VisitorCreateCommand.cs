using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.BuilderCommands
{
    public class VisitorCreateCommand : IModelCommand<VisitorCreateModel, Visitor>
    {
        private readonly IRepository<Visitor> _visitorRepo;

        [Inject]
        public VisitorCreateCommand(IRepository<Visitor> visitorRepo)
        {
            _visitorRepo = visitorRepo;
        }

        public Visitor Execute(VisitorCreateModel model)
        {
            var visitor = new Visitor
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                SecondName = model.SecondName
            };

            _visitorRepo.Add(visitor);
            _visitorRepo.SaveChanges();

            return visitor;
        }
    }
}