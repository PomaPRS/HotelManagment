using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HotelInfo.Models
{
    public class VisitorViewModel
    {
        [Display(Name = "Идентификатор")]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [Display(Name = "Бронь")]
        public ICollection<SelectListItem> Reservations { get; set; }
    }

    public class VisitorCreateModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
    }

    public class VisitorEditModel
    {
        [Display(Name = "Идентификатор")]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
    }

    public enum VisitorSortingType
    {
        [Display(Name = "По идентификатору")]
        ById,
        [Display(Name = "По имени (ФИО)")]
        ByName
    }

    public class VisitorFilterModel
    {
        public int? Page { get; set; }
        [Display(Name = "Имя (ФИО)")]
        public string Name { get; set; }
        [Display(Name = "Сортировка")]
        public VisitorSortingType SortingType { get; set; }
    }

    public class VisitorIndexViewModel
    {
        public VisitorFilterModel Filter { get; set; }
        public ICollection<SelectListItem> Visitors { get; set; }
    }
}