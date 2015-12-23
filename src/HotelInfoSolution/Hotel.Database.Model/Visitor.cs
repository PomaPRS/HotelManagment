using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Database.Model
{
    public class Visitor : IdentityBase
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}