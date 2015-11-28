using System.Collections.Generic;

namespace Hotel.Database.Model
{
    public class Position : IdentityBase
    {
        public string Title { get; set; }

        public ICollection<Worker> Workers { get; set; }
    }
}