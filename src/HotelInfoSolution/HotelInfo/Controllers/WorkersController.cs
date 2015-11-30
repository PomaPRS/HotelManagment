using System.Net;
using System.Web.Mvc;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.Controllers
{
    public class WorkersController : Controller
    {
        private readonly IRepository<Worker> _workerRepo;
        private readonly IModelBuilder<WorkerViewModel, Worker> _workerBuilder;
        private readonly IModelBuilder<WorkerIndexViewModel, WorkerFilterModel> _workerIndexBuilder;
        private readonly IModelBuilder<WorkerEditModel, Worker> _workerEditBuilder;
        private readonly IModelCommand<WorkerEditModel, Worker> _workerEditCommand;
        private readonly IModelCommand<WorkerCreateModel, Worker> _workerCreateCommand;

        [Inject]
        public WorkersController(
            IRepository<Worker> workerRepo, 
            IModelBuilder<WorkerViewModel, Worker> workerBuilder, 
            IModelBuilder<WorkerIndexViewModel, WorkerFilterModel> workerIndexBuilder, 
            IModelBuilder<WorkerEditModel, Worker> workerEditBuilder, 
            IModelCommand<WorkerEditModel, Worker> workerEditCommand, 
            IModelCommand<WorkerCreateModel, Worker> workerCreateCommand)
        {
            _workerRepo = workerRepo;
            _workerBuilder = workerBuilder;
            _workerIndexBuilder = workerIndexBuilder;
            _workerEditBuilder = workerEditBuilder;
            _workerEditCommand = workerEditCommand;
            _workerCreateCommand = workerCreateCommand;
        }

        public ActionResult Index(WorkerFilterModel filter)
        {
            var workerIndexViewModel = _workerIndexBuilder.CreateFrom(filter);
            return View(workerIndexViewModel);
        }
        
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = _workerRepo.Get(id.Value);
            if (worker == null)
            {
                return HttpNotFound();
            }
            var model = _workerBuilder.CreateFrom(worker);
            return View(model);
        }
        
        public ActionResult Create()
        {
            var model = new WorkerCreateModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkerCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var worker = _workerCreateCommand.Execute(model);
                return RedirectToAction("Details", new {id = worker.Id});
            }
            return View(model);
        }
        
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = _workerRepo.Get(id.Value);
            if (worker == null)
            {
                return HttpNotFound();
            }
            var model = _workerEditBuilder.CreateFrom(worker);
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkerEditModel model)
        {
            if (ModelState.IsValid)
            {
                var worker = _workerEditCommand.Execute(model);
                return RedirectToAction("Details", new {id = worker.Id});
            }
            return View(model);
        }
        
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = _workerRepo.Get(id.Value);
            if (worker == null)
            {
                return HttpNotFound();
            }
            var model = _workerBuilder.CreateFrom(worker);
            return View(model);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Worker worker = _workerRepo.Get(id);
            _workerRepo.Delete(worker);
            _workerRepo.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
