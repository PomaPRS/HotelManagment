using System.Net;
using System.Web.Mvc;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRepository<Room> _roomRepo;
        private readonly IModelBuilder<RoomViewModel, Room> _roomBuilder;
        private readonly IModelBuilder<RoomIndexViewModel, RoomFilterModel> _roomIndexBuilder;
        private readonly IModelBuilder<RoomEditModel, Room> _roomEditBuilder;
        private readonly IModelCommand<RoomEditModel, Room> _roomEditCommand;
        private readonly IModelCommand<RoomCreateModel, Room> _roomCreateCommand;

        [Inject]
        public RoomsController(
            IRepository<Room> roomRepo,
            IModelBuilder<RoomViewModel, Room> roomBuilder,
            IModelBuilder<RoomIndexViewModel, RoomFilterModel> roomIndexBuilder,
            IModelBuilder<RoomEditModel, Room> roomEditBuilder,
            IModelCommand<RoomEditModel, Room> roomEditCommand,
            IModelCommand<RoomCreateModel, Room> roomCreateCommand)
        {
            _roomRepo = roomRepo;
            _roomBuilder = roomBuilder;
            _roomIndexBuilder = roomIndexBuilder;
            _roomEditBuilder = roomEditBuilder;
            _roomEditCommand = roomEditCommand;
            _roomCreateCommand = roomCreateCommand;
        }
        
        public ActionResult Index(RoomFilterModel filter)
        {
            var model = _roomIndexBuilder.CreateFrom(filter);
            return View(model);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var room = _roomRepo.Get(id.Value);
            if (room == null)
            {
                return HttpNotFound();
            }
            var model = _roomBuilder.CreateFrom(room);
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new RoomCreateModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var room = _roomCreateCommand.Execute(model);
                return RedirectToAction("Details", new { id = room.Id });
            }
            return View(model);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var room = _roomRepo.Get(id.Value);
            if (room == null)
            {
                return HttpNotFound();
            }
            var model = _roomEditBuilder.CreateFrom(room);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomEditModel model)
        {
            if (ModelState.IsValid)
            {
                var room = _roomEditCommand.Execute(model);
                return RedirectToAction("Details", new { id = room.Id });
            }
            return View(model);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var room = _roomRepo.Get(id.Value);
            if (room == null)
            {
                return HttpNotFound();
            }
            var model = _roomBuilder.CreateFrom(room);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var room = _roomRepo.Get(id);
            _roomRepo.Delete(room);
            _roomRepo.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
