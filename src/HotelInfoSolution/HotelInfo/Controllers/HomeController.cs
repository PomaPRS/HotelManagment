﻿using System.Web.Mvc;

namespace HotelInfo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Hotels");
        }
    }
}