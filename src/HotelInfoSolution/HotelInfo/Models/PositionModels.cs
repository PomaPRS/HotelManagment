using System.Collections.Generic;
using System.Web.Mvc;

namespace HotelInfo.Models
{
    public class PositionViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }

    public class PositionCreateModel
    {
        public string Title { get; set; }
    }

    public class PositionEditModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }

    public enum PositionSortingType
    {
        ById,
        ByTitle
    }

    public class PositionFilterModel
    {
        public int? Page { get; set; }
        public string Title { get; set; }
        public PositionSortingType SortingType { get; set; }
    }

    public class PositionIndexViewModel
    {
        public PositionFilterModel Filter { get; set; }
        public ICollection<SelectListItem> Positions { get; set; }
    }
}