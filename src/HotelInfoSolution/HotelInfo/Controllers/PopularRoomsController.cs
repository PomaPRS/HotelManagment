using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Database;

namespace HotelInfo.Controllers
{
    public class PopularRoomsController : Controller
    {
        private readonly HotelContext db = new HotelContext();

        // GET: PopularRooms
        public ActionResult Index()
        {
            return View(db.PopularRooms.OrderByDescending(x => x.VisitorCount).ToList());
        }
    }
}