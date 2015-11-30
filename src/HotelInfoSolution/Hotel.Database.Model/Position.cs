using System.Collections.Generic;

namespace Hotel.Database.Model
{
    public class Position : IdentityBase
    {
        public string Title { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}