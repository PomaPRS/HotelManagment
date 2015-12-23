using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HotelInfo.Models
{
    public class WorkerViewModel
    {
        [Display(Name = "Идентификатор")]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Название отеля")]
        public string HotelTitle { get; set; }
        [Required]
        [Display(Name = "ИНН")]
        public string IndividualId { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Должность")]
        public string PositionTitle { get; set; }
    }

    public class WorkerEditModel
    {
        [Display(Name = "Идентификатор")]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Название отеля")]
        public string HotelTitle { get; set; }
        [Required]
        [Display(Name = "ИНН")]
        public string IndividualId { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Должность")]
        public string PositionTitle { get; set; }
    }

    public class WorkerCreateModel
    {
        [Required]
        [Display(Name = "Название отеля")]
        public string HotelTitle { get; set; }
        [Required]
        [Display(Name = "ИНН")]
        public string IndividualId { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Должность")]
        public string PositionTitle { get; set; }
    }

    public enum WorkerSortingType
    {
        [Display(Name = "По идентификатору")]
        ById,
        [Display(Name = "По имени (ФИО)")]
        ByName,
        [Display(Name = "По названию отеля")]
        ByHotelName,
        [Display(Name = "По должности")]
        ByPosition,
    }

    public class WorkerFilterModel
    {
        public int? Page { get; set; }
        [Display(Name = "Название отеля")]
        public string HotelTitle { get; set; }
        [Display(Name = "ИНН")]
        public string IndividualId { get; set; }
        [Display(Name = "Имя (ФИО)")]
        public string Name { get; set; }
        [Display(Name = "Должность")]
        public string PositionTitle { get; set; }
        [Display(Name = "Сортировка")]
        public WorkerSortingType SortingType { get; set; }
    }

    public class WorkerIndexViewModel
    {
        public WorkerFilterModel Filter { get; set; }
        public ICollection<SelectListItem> Workers { get; set; }
    }
}