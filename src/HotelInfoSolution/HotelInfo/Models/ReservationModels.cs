using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HotelInfo.Models
{
    public class ReservationViewModel
    {
        [Display(Name = "Идентификатор")]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Дата заезда")]
        public DateTime ArrivalDate { get; set; }
        [Required]
        [Display(Name = "Дата отъезда")]
        public DateTime DepartureDate { get; set; }
        [Required]
        [Display(Name = "Имя посетителя")]
        public string VisitorName { get; set; }
        [Required]
        [Display(Name = "Название отеля")]
        public string HotelTitle { get; set; }
        [Required]
        [Display(Name = "Номер комнаты")]
        public string RoomNumber { get; set; }
        [Required]
        [Display(Name = "Аванс")]
        public double Advance { get; set; }
    }

    public class ReservationCreateModel
    {
        [Required]
        [Display(Name = "Дата заезда")]
        public DateTime ArrivalDate { get; set; }
        [Required]
        [Display(Name = "Дата отъезда")]
        public DateTime DepartureDate { get; set; }
        [Required]
        [Display(Name = "Имя посетителя")]
        public string VisitorName { get; set; }
        [Required]
        [Display(Name = "Название отеля")]
        public string HotelTitle { get; set; }
        [Required]
        [Display(Name = "Номер комнаты")]
        public string RoomNumber { get; set; }
        [Required]
        [Display(Name = "Аванс")]
        public double Advance { get; set; }
    }

    public class ReservationEditModel
    {
        [Display(Name = "Идентификатор")]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Дата заезда")]
        public DateTime ArrivalDate { get; set; }
        [Required]
        [Display(Name = "Дата отъезда")]
        public DateTime DepartureDate { get; set; }
        [Required]
        [Display(Name = "Имя посетителя")]
        public string VisitorName { get; set; }
        [Required]
        [Display(Name = "Название отеля")]
        public string HotelTitle { get; set; }
        [Required]
        [Display(Name = "Номер комнаты")]
        public string RoomNumber { get; set; }
        [Required]
        [Display(Name = "Аванс")]
        public double Advance { get; set; }
    }

    public enum ReservationSortingType
    {
        [Display(Name = "По идентификатору")]
        ById,
        [Display(Name = "По дате заезда")]
        ByArrivalDate,
        [Display(Name = "По дате отъезда")]
        ByDepartureDate,
        [Display(Name = "По имени посетителя")]
        ByVisitorName,
        [Display(Name = "По названию гостиницы")]
        ByHotelTitleAndRoomNumber,
        [Display(Name = "По авансу")]
        ByAdvance
    }

    public class ReservationFilterModel
    {
        public int? Page { get; set; }
        [Display(Name = "Дата заезда (от)")]
        public DateTime? FromArrivalDate { get; set; }
        [Display(Name = "Дата заезда (до)")]
        public DateTime? ToArrivalDate { get; set; }
        [Display(Name = "Дата отъезда (от)")]
        public DateTime? FromDepartureDate { get; set; }
        [Display(Name = "Дата отъезда (до)")]
        public DateTime? ToDepartureDate { get; set; }
        [Display(Name = "Имя посетителя")]
        public string VisitorName { get; set; }
        [Display(Name = "Название отеля")]
        public string HotelTitle { get; set; }
        [Display(Name = "Номер комнаты")]
        public string RoomNumber { get; set; }
        [Display(Name = "Аванс (от)")]
        public double? FromAdvance { get; set; }
        [Display(Name = "Аванс (до)")]
        public double? ToAdvance { get; set; }
        [Display(Name = "Сортировка")]
        public ReservationSortingType SortingType { get; set; }
    }

    public class ReservationIndexViewModel
    {
        public ReservationFilterModel Filter { get; set; }
        public ICollection<SelectListItem> Reservations { get; set; }
    }
}