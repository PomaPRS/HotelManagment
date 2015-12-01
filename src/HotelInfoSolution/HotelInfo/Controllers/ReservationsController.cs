using System.Net;
using System.Web.Mvc;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IRepository<Reservation> _reservationRepo;
        private readonly IModelBuilder<ReservationViewModel, Reservation> _reservationBuilder;
        private readonly IModelBuilder<ReservationIndexViewModel, ReservationFilterModel> _reservationIndexBuilder;
        private readonly IModelBuilder<ReservationEditModel, Reservation> _reservationEditBuilder;
        private readonly IModelCommand<ReservationEditModel, Reservation> _reservationEditCommand;
        private readonly IModelCommand<ReservationCreateModel, Reservation> _reservationCreateCommand;

        [Inject]
        public ReservationsController(
            IRepository<Reservation> reservationRepo,
            IModelBuilder<ReservationViewModel, Reservation> reservationBuilder,
            IModelBuilder<ReservationIndexViewModel, ReservationFilterModel> reservationIndexBuilder,
            IModelBuilder<ReservationEditModel, Reservation> reservationEditBuilder,
            IModelCommand<ReservationEditModel, Reservation> reservationEditCommand,
            IModelCommand<ReservationCreateModel, Reservation> reservationCreateCommand)
        {
            _reservationRepo = reservationRepo;
            _reservationBuilder = reservationBuilder;
            _reservationIndexBuilder = reservationIndexBuilder;
            _reservationEditBuilder = reservationEditBuilder;
            _reservationEditCommand = reservationEditCommand;
            _reservationCreateCommand = reservationCreateCommand;
        }
        
        public ActionResult Index(ReservationFilterModel filter)
        {
            var model = _reservationIndexBuilder.CreateFrom(filter);
            return View(model);
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var reservation = _reservationRepo.Get(id.Value);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            var model = _reservationBuilder.CreateFrom(reservation);
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new ReservationCreateModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var reservation = _reservationCreateCommand.Execute(model);
                return RedirectToAction("Details", new { id = reservation.Id });
            }
            return View(model);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var reservation = _reservationRepo.Get(id.Value);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            var model = _reservationEditBuilder.CreateFrom(reservation);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReservationEditModel model)
        {
            if (ModelState.IsValid)
            {
                var reservation = _reservationEditCommand.Execute(model);
                return RedirectToAction("Details", new { id = reservation.Id });
            }
            return View(model);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var reservation = _reservationRepo.Get(id.Value);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            var model = _reservationBuilder.CreateFrom(reservation);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var reservation = _reservationRepo.Get(id);
            _reservationRepo.Delete(reservation);
            _reservationRepo.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
