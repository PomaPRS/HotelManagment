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
        private readonly IModelCommand<HotelEditModel> _hotelCommand;
        private readonly IModelBuilder<HotelIndexViewModel, HotelFilterModel> _hotelIndexBuilder;

        [Inject]
        public HotelController(
            IRepository<Hotel.Database.Model.Hotel> hotelRepo,
            IModelBuilder<HotelViewModel, Hotel.Database.Model.Hotel> hotelBuilder, 
            IModelCommand<HotelEditModel> hotelCommand, 
            IModelBuilder<HotelIndexViewModel, HotelFilterModel> hotelIndexBuilder)
        {
            _hotelBuilder = hotelBuilder;
            _hotelCommand = hotelCommand;
            _hotelIndexBuilder = hotelIndexBuilder;
            _hotelRepo = hotelRepo;
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
            var model = new HotelEditModel();
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Create(HotelEditModel model)
        {
            try
            {
                _hotelCommand.Execute(model);
                return RedirectToAction("Details", new {id = model.Id});
            }
            catch
            {
                ViewBag.ErrorMessage = "Произошла ошибка при создании";
            }
            return View();
        }
        
        public ActionResult Edit(int id)
        {
            var hotel = _hotelRepo.Get(id);
            if (hotel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _hotelBuilder.CreateFrom(hotel);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Edit(int id, HotelEditModel model)
        {
            try
            {
                _hotelCommand.Execute(model);
                return RedirectToAction("Index");
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
