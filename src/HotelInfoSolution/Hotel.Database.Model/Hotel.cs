using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Database.Model
{
    public class Hotel : IdentityBase
    {
        [Index("Title", 1, IsUnique = true)]
        public string Title { get; set; }
        [Index("IndividualId", 1, IsUnique = true)]
        public string IndividualId { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}