using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Hotel.Database.Model;

namespace HotelInfo.Models
{
    public class HotelEditModel
    {
        [Display(Name = "Идентификатор")]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "ИНН")]
        public string IndividualId { get; set; }
        [Required]
        [Display(Name = "Адрес")]
        public string Address { get; set; }
    }

    public class HotelViewModel
    {
        [Display(Name = "Идентификатор")]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "ИНН")]
        public string IndividualId { get; set; }
        [Required]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        public ICollection<SelectListItem> Workers { get; set; }
    }

    public class HotelCreateModel
    {
        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "ИНН")]
        public string IndividualId { get; set; }
        [Required]
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        public BossCreateModel Boss { get; set; }
    }

    public class BossCreateModel
    {
        [Display(Name = "ИНН")]
        public string IndividualId { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
    }

    public enum HotelSortingType
    {
        [Display(Name = "По идентификатору")]
        ById,
        [Display(Name = "По названию")]
        ByTitle,
    }

    public class HotelFilterModel
    {
        public int? Page { get; set; }
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Display(Name = "ИНН")]
        public string IndividualId { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Сортировка")]
        public HotelSortingType SortingType { get; set; }
    }

    public class HotelIndexViewModel
    {
        public HotelFilterModel Filter { get; set; }
        public ICollection<SelectListItem> Hotels { get; set; }
    }
}