using System.Net;
using System.Web.Mvc;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.Controllers
{
    public class PositionsController : Controller
    {
        private readonly IRepository<Position> _positionRepo;
        private readonly IModelBuilder<PositionViewModel, Position> _positionBuilder;
        private readonly IModelBuilder<PositionIndexViewModel, PositionFilterModel> _positionIndexBuilder;
        private readonly IModelBuilder<PositionEditModel, Position> _positionEditBuilder;
        private readonly IModelCommand<PositionEditModel, Position> _positionEditCommand;
        private readonly IModelCommand<PositionCreateModel, Position> _positionCreateCommand;

        [Inject]
        public PositionsController(
            IRepository<Position> positionRepo,
            IModelBuilder<PositionViewModel, Position> positionBuilder,
            IModelBuilder<PositionIndexViewModel, PositionFilterModel> positionIndexBuilder,
            IModelBuilder<PositionEditModel, Position> positionEditBuilder,
            IModelCommand<PositionEditModel, Position> positionEditCommand,
            IModelCommand<PositionCreateModel, Position> positionCreateCommand)
        {
            _positionRepo = positionRepo;
            _positionBuilder = positionBuilder;
            _positionIndexBuilder = positionIndexBuilder;
            _positionEditBuilder = positionEditBuilder;
            _positionEditCommand = positionEditCommand;
            _positionCreateCommand = positionCreateCommand;
        }
        
        public ActionResult Index(PositionFilterModel filter)
        {
            var model = _positionIndexBuilder.CreateFrom(filter);
            return View(model);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var position = _positionRepo.Get(id.Value);
            if (position == null)
            {
                return HttpNotFound();
            }
            var model = _positionBuilder.CreateFrom(position);
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new PositionCreateModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PositionCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var position = _positionCreateCommand.Execute(model);
                return RedirectToAction("Details", new { id = position.Id });
            }
            return View(model);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var position = _positionRepo.Get(id.Value);
            if (position == null)
            {
                return HttpNotFound();
            }
            var model = _positionEditBuilder.CreateFrom(position);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PositionEditModel model)
        {
            if (ModelState.IsValid)
            {
                var position = _positionEditCommand.Execute(model);
                return RedirectToAction("Details", new { id = position.Id });
            }
            return View(model);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var position = _positionRepo.Get(id.Value);
            if (position == null)
            {
                return HttpNotFound();
            }
            var model = _positionBuilder.CreateFrom(position);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var position = _positionRepo.Get(id);
            _positionRepo.Delete(position);
            _positionRepo.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
