using System.Collections.Generic;
using System.Web.Mvc;
using Hotel.Database.Model;

namespace HotelInfo.Models
{
    public class RoomViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public int PlaceCount { get; set; }
        public double CostPerDay { get; set; }
        public RoomState State { get; set; }
        public string HotelTitle { get; set; }
        public string Number { get; set; }
    }

    public class RoomCreateModel
    {
        public string Description { get; set; }
        public int PlaceCount { get; set; }
        public double CostPerDay { get; set; }
        public RoomState State { get; set; }
        public string HotelTitle { get; set; }
        public string Number { get; set; }
    }

    public class RoomEditModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public int PlaceCount { get; set; }
        public double CostPerDay { get; set; }
        public RoomState State { get; set; }
        public string HotelTitle { get; set; }
        public string Number { get; set; }
    }

    public enum RoomSortingType
    {
        ById,
        ByCost,
        ByPlaceCount,
        ByState
    }

    public class RoomFilterModel
    {
        public int? Page { get; set; }
        public string Description { get; set; }
        public int? FromPlaceCount { get; set; }
        public int? ToPlaceCount { get; set; }
        public double? FromCostPerDay { get; set; }
        public double? ToCostPerDay { get; set; }
        public RoomState? State { get; set; }
        public string HotelTitle { get; set; }
        public string Number { get; set; }
        public RoomSortingType SortingType { get; set; }
    }

    public class RoomIndexViewModel
    {
        public RoomFilterModel Filter { get; set; }
        public ICollection<SelectListItem> Rooms { get; set; }
    }
}