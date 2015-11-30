using System.Collections.Generic;
using System.Web.Mvc;

namespace HotelInfo.Models
{
    public class VisitorViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
    }

    public class VisitorCreateModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
    }

    public class VisitorEditModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
    }

    public enum VisitorSortingType
    {
        ById,
        ByName
    }

    public class VisitorFilterModel
    {
        public int? Page { get; set; }
        public string Name { get; set; }
        public VisitorSortingType SortingType { get; set; }
    }

    public class VisitorIndexViewModel
    {
        public VisitorFilterModel Filter { get; set; }
        public ICollection<SelectListItem> Visitors { get; set; }
    }
}