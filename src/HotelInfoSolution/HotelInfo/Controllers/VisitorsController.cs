using System.Net;
using System.Web.Mvc;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly IRepository<Visitor> _visitorRepo;
        private readonly IModelBuilder<VisitorViewModel, Visitor> _visitorBuilder;
        private readonly IModelBuilder<VisitorIndexViewModel, VisitorFilterModel> _visitorIndexBuilder;
        private readonly IModelBuilder<VisitorEditModel, Visitor> _visitorEditBuilder;
        private readonly IModelCommand<VisitorEditModel, Visitor> _visitorEditCommand;
        private readonly IModelCommand<VisitorCreateModel, Visitor> _visitorCreateCommand;

        [Inject]
        public VisitorsController(
            IRepository<Visitor> visitorRepo,
            IModelBuilder<VisitorViewModel, Visitor> visitorBuilder,
            IModelBuilder<VisitorIndexViewModel, VisitorFilterModel> visitorIndexBuilder,
            IModelBuilder<VisitorEditModel, Visitor> visitorEditBuilder,
            IModelCommand<VisitorEditModel, Visitor> visitorEditCommand,
            IModelCommand<VisitorCreateModel, Visitor> visitorCreateCommand)
        {
            _visitorRepo = visitorRepo;
            _visitorBuilder = visitorBuilder;
            _visitorIndexBuilder = visitorIndexBuilder;
            _visitorEditBuilder = visitorEditBuilder;
            _visitorEditCommand = visitorEditCommand;
            _visitorCreateCommand = visitorCreateCommand;
        }

        public ActionResult Index(VisitorFilterModel filter)
        {
            var visitorIndexViewModel = _visitorIndexBuilder.CreateFrom(filter);
            return View(visitorIndexViewModel);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitor visitor = _visitorRepo.Get(id.Value);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            var model = _visitorBuilder.CreateFrom(visitor);
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new VisitorCreateModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VisitorCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var visitor = _visitorCreateCommand.Execute(model);
                return RedirectToAction("Details", new { id = visitor.Id });
            }
            return View(model);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitor visitor = _visitorRepo.Get(id.Value);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            var model = _visitorEditBuilder.CreateFrom(visitor);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VisitorEditModel model)
        {
            if (ModelState.IsValid)
            {
                var visitor = _visitorEditCommand.Execute(model);
                return RedirectToAction("Details", new { id = visitor.Id });
            }
            return View(model);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitor visitor = _visitorRepo.Get(id.Value);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            var model = _visitorBuilder.CreateFrom(visitor);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Visitor visitor = _visitorRepo.Get(id);
            _visitorRepo.Delete(visitor);
            _visitorRepo.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
