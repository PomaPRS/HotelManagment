using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Hotel.Database.Model;

namespace HotelInfo.Models
{
    public class RoomViewModel
    {
        [Display(Name = "Идентификатор")]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Количество мест")]
        public int PlaceCount { get; set; }
        [Required]
        [Display(Name = "Цена за сутки")]
        public double CostPerDay { get; set; }
        [Required]
        [Display(Name = "Состояние")]
        public RoomState State { get; set; }
        [Required]
        [Display(Name = "Название отеля")]
        public string HotelTitle { get; set; }
        [Required]
        [Display(Name = "Номер комнаты")]
        public string Number { get; set; }
    }

    public class RoomCreateModel
    {
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Количество мест")]
        public int PlaceCount { get; set; }
        [Required]
        [Display(Name = "Цена за сутки")]
        public double CostPerDay { get; set; }
        [Required]
        [Display(Name = "Состояние")]
        public RoomState State { get; set; }
        [Required]
        [Display(Name = "Название отеля")]
        public string HotelTitle { get; set; }
        [Required]
        [Display(Name = "Номер комнаты")]
        public string Number { get; set; }
    }

    public class RoomEditModel
    {
        [Display(Name = "Идентификатор")]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Количество мест")]
        public int PlaceCount { get; set; }
        [Required]
        [Display(Name = "Цена за сутки")]
        public double CostPerDay { get; set; }
        [Required]
        [Display(Name = "Состояние")]
        public RoomState State { get; set; }
        [Required]
        [Display(Name = "Название отеля")]
        public string HotelTitle { get; set; }
        [Required]
        [Display(Name = "Номер комнаты")]
        public string Number { get; set; }
    }

    public enum RoomSortingType
    {
        [Display(Name = "По идентификатору")]
        ById,
        [Display(Name = "По цене")]
        ByCost,
        [Display(Name = "По количеству мест")]
        ByPlaceCount,
        [Display(Name = "По состоянию")]
        ByState
    }

    public class RoomFilterModel
    {
        public int? Page { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Количество мест (от)")]
        public int? FromPlaceCount { get; set; }
        [Display(Name = "Количество мест (до)")]
        public int? ToPlaceCount { get; set; }
        [Display(Name = "Цена за сутки (от)")]
        public double? FromCostPerDay { get; set; }
        [Display(Name = "Цена за сутки (до)")]
        public double? ToCostPerDay { get; set; }
        [Display(Name = "Состояние")]
        public RoomState State { get; set; }
        [Display(Name = "Название отеля")]
        public string HotelTitle { get; set; }
        [Display(Name = "Номер комнаты")]
        public string Number { get; set; }
        [Display(Name = "Сортировка")]
        public RoomSortingType SortingType { get; set; }
    }

    public class RoomIndexViewModel
    {
        public RoomFilterModel Filter { get; set; }
        public ICollection<SelectListItem> Rooms { get; set; }
    }
}