using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HotelInfo.Models
{
    public class PositionViewModel
    {
        [Display(Name = "Идентификатор")]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }
    }

    public class PositionCreateModel
    {
        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }
    }

    public class PositionEditModel
    {
        [Display(Name = "Идентификатор")]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }
    }

    public enum PositionSortingType
    {
        [Display(Name = "По идентификатору")]
        ById,
        [Display(Name = "По названию")]
        ByTitle,
    }

    public class PositionFilterModel
    {
        public int? Page { get; set; }
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Display(Name = "Сортировка")]
        public PositionSortingType SortingType { get; set; }
    }

    public class PositionIndexViewModel
    {
        public PositionFilterModel Filter { get; set; }
        public ICollection<SelectListItem> Positions { get; set; }
    }
}