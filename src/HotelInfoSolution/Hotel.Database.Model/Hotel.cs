using System.Collections.Generic;

namespace Hotel.Database.Model
{
    public class Hotel : IdentityBase
    {
        public string Title { get; set; }
        public string IndividualId { get; set; }
        public string Address { get; set; }

        public ICollection<Worker> Workers { get; set; }
    }
}