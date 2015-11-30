using System;

namespace Hotel.Database.Model
{
    public class Reservation : IdentityBase
    {
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public long VisitorId { get; set; }
        public virtual Visitor Visitor { get; set; }
        public long RoomId { get; set; }
        public virtual Room Room { get; set; }
        public double Advance { get; set; }
    }
}