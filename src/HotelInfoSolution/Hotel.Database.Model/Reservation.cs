using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Database.Model
{
    public class Reservation : IdentityBase
    {
        [Index("ReservationArrivalDate")]
        public DateTime ArrivalDate { get; set; }
        [Index("ReservationDepartureDate")]
        public DateTime DepartureDate { get; set; }
        public long VisitorId { get; set; }
        public virtual Visitor Visitor { get; set; }
        public long RoomId { get; set; }
        public virtual Room Room { get; set; }
        public double Advance { get; set; }
    }
}