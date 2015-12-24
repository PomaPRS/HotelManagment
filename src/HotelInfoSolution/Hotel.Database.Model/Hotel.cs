using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Database.Model
{
    public class Hotel : IdentityBase
    {
        [MaxLength(50)]
        [Index("HotelTitle_Index", 1, IsUnique = true)]
        public string Title { get; set; }
        [MaxLength(50)]
        [Index("HotelIndividualId_Index", 1, IsUnique = true)]
        public string IndividualId { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}