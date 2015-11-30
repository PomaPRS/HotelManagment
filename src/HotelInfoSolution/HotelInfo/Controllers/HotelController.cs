using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel.Database;
using Hotel.Database.Common;
using Hotel.Web.Common;
using HotelInfo.ModelBuilders;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.Controllers
{
    public sealed class HotelController : Controller
    {
        private readonly IRepository<Hotel.Database.Model.Hotel> _hotelRepo;
        private readonly IModelBuilder<HotelViewModel, Hotel.Database.Model.Hotel> _hotelBuilder;
        private readonly IModelBuilder<HotelIndexViewModel, HotelFilterModel> _hotelIndexBuilder;
        private readonly IModelBuilder<HotelEditModel, Hotel.Database.Model.Hotel> _hotelEditBuilder;
        private readonly IModelCommand<HotelEditModel, Hotel.Database.Model.Hotel> _hotelEditCommand;
        private readonly IModelCommand<HotelCreateModel, Hotel.Database.Model.Hotel> _hotelCreateCommand;

        [Inject]
        public HotelController(
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
        
        public ActionResult Details(int id)
        {
            var hotel = _hotelRepo.Get(id);
            if (hotel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _hotelBuilder.CreateFrom(hotel);
            return View(model);
        }
        
        public ActionResult Create()
        {
            var model = new HotelCreateModel();
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Create(HotelCreateModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hotel = _hotelCreateCommand.Execute(model);
                    return RedirectToAction("Details", new {id = hotel.Id});
                }
            }
            catch
            {
                ViewBag.ErrorMessage = "Произошла ошибка при создании";
            }
            return View(model);
        }
        
        public ActionResult Edit(int id)
        {
            var hotel = _hotelRepo.Get(id);
            if (hotel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _hotelEditBuilder.CreateFrom(hotel);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Edit(int id, HotelEditModel model)
        {
            try
            {
                var hotel = _hotelEditCommand.Execute(model);
                return RedirectToAction("Details", new {id = hotel.Id});
            }
            catch
            {
                ViewBag.ErrorMessage = "Произошла ошибка при редактировании";
            }
            return View();
        }
        
        public ActionResult Delete(int id)
        {
            var hotel = _hotelRepo.Get(id);
            if (hotel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _hotelBuilder.CreateFrom(hotel);
            return View(model);
        }
        
        [Route("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                var hotel = _hotelRepo.Get(id);
                _hotelRepo.Delete(hotel);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Произошла ошибка при удалении";
            }
            return View();
        }
    }
}
