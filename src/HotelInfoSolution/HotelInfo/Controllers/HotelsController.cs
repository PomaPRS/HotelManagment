using System.Net;
using System.Web.Mvc;
using Hotel.Database.Common;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.Controllers
{
    public sealed class HotelsController : Controller
    {
        private readonly IRepository<Hotel.Database.Model.Hotel> _hotelRepo;
        private readonly IModelBuilder<HotelViewModel, Hotel.Database.Model.Hotel> _hotelBuilder;
        private readonly IModelBuilder<HotelIndexViewModel, HotelFilterModel> _hotelIndexBuilder;
        private readonly IModelBuilder<HotelEditModel, Hotel.Database.Model.Hotel> _hotelEditBuilder;
        private readonly IModelCommand<HotelEditModel, Hotel.Database.Model.Hotel> _hotelEditCommand;
        private readonly IModelCommand<HotelCreateModel, Hotel.Database.Model.Hotel> _hotelCreateCommand;

        [Inject]
        public HotelsController(
            IRepository<Hotel.Database.Model.Hotel> hotelRepo, 
            IModelBuilder<HotelViewModel, Hotel.Database.Model.Hotel> hotelBuilder, 
            IModelBuilder<HotelIndexViewModel, HotelFilterModel> hotelIndexBuilder, 
            IModelCommand<HotelEditModel, Hotel.Database.Model.Hotel> hotelEditCommand, 
            IModelCommand<HotelCreateModel, Hotel.Database.Model.Hotel> hotelCreateCommand, 
            IModelBuilder<HotelEditModel, Hotel.Database.Model.Hotel> hotelEditBuilder)
        {
            _hotelRepo = hotelRepo;
            _hotelBuilder = hotelBuilder;
            _hotelIndexBuilder = hotelIndexBuilder;
            _hotelEditCommand = hotelEditCommand;
            _hotelCreateCommand = hotelCreateCommand;
            _hotelEditBuilder = hotelEditBuilder;
        }

        public ActionResult Index(HotelFilterModel filterModel)
        {
            var hotelIndexModel = _hotelIndexBuilder.CreateFrom(filterModel);
            return View(hotelIndexModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var hotel = _hotelRepo.Get(id.Value);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            var model = _hotelBuilder.CreateFrom(hotel);
            return View(model);
        }
        
        public ActionResult Create()
        {
            var model = new HotelCreateModel()
            {
                Boss = new BossCreateModel()
            };
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HotelCreateModel model)
        {
            if (string.IsNullOrEmpty(model.Boss?.FirstName) ||
                string.IsNullOrEmpty(model.Boss.SecondName) ||
                string.IsNullOrEmpty(model.Boss.MiddleName) ||
                string.IsNullOrEmpty(model.Boss.IndividualId))
                return View(model);

            if (ModelState.IsValid)
            {
                var hotel = _hotelCreateCommand.Execute(model);
                return RedirectToAction("Details", new {id = hotel.Id});
            }
            return View(model);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var hotel = _hotelRepo.Get(id.Value);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            var model = _hotelEditBuilder.CreateFrom(hotel);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HotelEditModel model)
        {
            if (ModelState.IsValid)
            {
                var hotel = _hotelEditCommand.Execute(model);
                return RedirectToAction("Details", new {id = hotel.Id});
            }
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var hotel = _hotelRepo.Get(id.Value);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            var model = _hotelBuilder.CreateFrom(hotel);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var hotel = _hotelRepo.Get(id);
            _hotelRepo.Delete(hotel);
            _hotelRepo.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
