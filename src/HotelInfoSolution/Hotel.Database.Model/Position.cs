using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Database.Model
{
    public class Position : IdentityBase
    {
        [Index("Title", 1, IsUnique = true)]
        public string Title { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}