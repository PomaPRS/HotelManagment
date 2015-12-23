using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Database.Model
{
    public enum RoomState
    {
        [Display(Name = "Обслуживается")]
        Served,
        [Display(Name = "Ремонт")]
        Repair
    }
}