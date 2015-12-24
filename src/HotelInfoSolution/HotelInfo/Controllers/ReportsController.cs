using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Database;
using HotelInfo.Models;

namespace HotelInfo.Controllers
{
    public class ReportsController : Controller
    {
        private readonly HotelContext db = new HotelContext();

        // GET: Reports
        public ActionResult Index()
        {
            var model = new ReportIndexModel()
            {
                FreeRoomReport = new FreeRoomReportModel() {From = DateTime.Now.ToString(), To = DateTime.Now.ToString()},
                VisitorCountReport = new VisitorCountReportModel() { From = DateTime.Now.ToString(), To = DateTime.Now.ToString() },
                VisitorHotelReport = new VisitorHotelReportModel()
            };
            return View(model);
        }

        public ActionResult FreeRoomReport(FreeRoomReportModel model)
        {
            var sql =
                "select rm.* from Rooms rm " +
                "where not exists(" +
                "select * from Reservations rs " +
                "where rs.RoomId = rm.Id and " +
                "(rs.ArrivalDate < '{0}' and rs.DepartureDate > '{1}' or " +
                "rs.ArrivalDate < '{0}' and rs.DepartureDate > '{1}' or rs.ArrivalDate >= '{0}' and rs.DepartureDate <= '{1}'));";

            var from = DateTime.Parse(model.From);
            var to = DateTime.Parse(model.To);

            var formatSql = string.Format(sql, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"));
            var rooms = db.Rooms.SqlQuery(formatSql).ToList();
            return View(rooms);
        }

        public ActionResult VisitorHotelReport(VisitorHotelReportModel model)
        {
            var sql =
                "select min(hs.Title) as HotelTitle, min(rm.Number) as RoomNumber, Count(*) as Count from Visitors vs join Reservations rs on vs.Id = rs.VisitorId join Rooms rm on rm.Id = rs.RoomId join Hotels hs on hs.Id = rm.HotelId where vs.FirstName + vs.MiddleName + vs.SecondName like '%{0}%' group by rm.Id; ";

            var formatSql = string.Format(sql, model.VisitorName);
            var items = db.Database.SqlQuery<VisitorHotelItemModel>(formatSql).ToList();
            return View(items);
        }

        public ActionResult VisitorCountReport(VisitorCountReportModel model)
        {
            var sql =
                "select min(ht.Title) as HotelTitle, Count(*) as Count from Reservations rs join Rooms rm on rs.RoomId = rm.Id join Hotels ht on ht.Id = rm.HotelId where rs.ArrivalDate < '{0}' and rs.DepartureDate > '{0}' or rs.ArrivalDate < '{1}' and rs.DepartureDate > '{1}' or rs.ArrivalDate >= '{0}' and rs.DepartureDate <= '{1}' group by ht.Id;";

            var from = DateTime.Parse(model.From);
            var to = DateTime.Parse(model.To);

            var formatSql = string.Format(sql, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"));
            var items = db.Database.SqlQuery<VisitorCountItemModel>(formatSql).ToList();
            return View(items);
        }
    }
}