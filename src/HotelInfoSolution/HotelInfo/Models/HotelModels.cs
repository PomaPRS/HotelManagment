using System.Collections.Generic;
using System.Web.Mvc;
using Hotel.Database.Model;

namespace HotelInfo.Models
{
    public class HotelEditModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string IndividualId { get; set; }
        public string Address { get; set; }
    }

    public class HotelViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string IndividualId { get; set; }
        public string Address { get; set; }

        public ICollection<SelectListItem> Workers { get; set; }
    }

    public class HotelCreateModel
    {
        public string Title { get; set; }
        public string IndividualId { get; set; }
        public string Address { get; set; }
    }

    public enum HotelSortingType
    {
        ById,
        ByTitle,
    }

    public class HotelFilterModel
    {
        public int? Page { get; set; }
        public string Title { get; set; }
        public string IndividualId { get; set; }
        public string Address { get; set; }
        public HotelSortingType SortingType { get; set; }
    }

    public class HotelIndexViewModel
    {
        public HotelFilterModel Filter { get; set; }
        public ICollection<SelectListItem> Hotels { get; set; }
    }
}