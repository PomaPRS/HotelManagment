using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HotelInfo.Models
{
    public class ReservationViewModel
    {
        public long Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string VisitorName { get; set; }
        public string HotelTitle { get; set; }
        public string RoomNumber { get; set; }
        public double Advance { get; set; }
    }

    public class ReservationCreateModel
    {
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string VisitorName { get; set; }
        public string HotelTitle { get; set; }
        public string RoomNumber { get; set; }
        public double Advance { get; set; }
    }

    public class ReservationEditModel
    {
        public long Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string VisitorName { get; set; }
        public string HotelTitle { get; set; }
        public string RoomNumber { get; set; }
        public double Advance { get; set; }
    }

    public enum ReservationSortingType
    {
        ById,
        ByArrivalDate,
        ByDepartureDate,
        ByVisitorName,
        ByHotelTitleAndRoomNumber,
        ByAdvance
    }

    public class ReservationFilterModel
    {
        public int? Page { get; set; }
        public DateTime? FromArrivalDate { get; set; }
        public DateTime? ToArrivalDate { get; set; }
        public DateTime? FromDepartureDate { get; set; }
        public DateTime? ToDepartureDate { get; set; }
        public string VisitorName { get; set; }
        public string HotelTitle { get; set; }
        public string RoomNumber { get; set; }
        public double? FromAdvance { get; set; }
        public double? ToAdvance { get; set; }
        public ReservationSortingType SortingType { get; set; }
    }

    public class ReservationIndexViewModel
    {
        public ReservationFilterModel Filter { get; set; }
        public ICollection<SelectListItem> Reservations { get; set; }
    }
}