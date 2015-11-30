using System.Collections.Generic;
using System.Web.Mvc;

namespace HotelInfo.Models
{
    public class WorkerViewModel
    {
        public long Id { get; set; }
        public string HotelTitle { get; set; }
        public string IndividualId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string PositionTitle { get; set; }
    }

    public class WorkerEditModel
    {
        public long Id { get; set; }
        public string HotelTitle { get; set; }
        public string IndividualId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string PositionTitle { get; set; }
    }

    public class WorkerCreateModel
    {
        public string HotelTitle { get; set; }
        public string IndividualId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string PositionTitle { get; set; }
    }

    public enum WorkerSortingType
    {
        ById,
        ByName,
        ByHotelName,
        ByPosition,
    }

    public class WorkerFilterModel
    {
        public int? Page { get; set; }
        public string HotelTitle { get; set; }
        public string IndividualId { get; set; }
        public string Name { get; set; }
        public string PositionTitle { get; set; }
        public WorkerSortingType SortingType { get; set; }
    }

    public class WorkerIndexViewModel
    {
        public WorkerFilterModel Filter { get; set; }
        public ICollection<SelectListItem> Workers { get; set; }
    }
}