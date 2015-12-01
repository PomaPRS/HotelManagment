using System.Collections.Generic;

namespace Hotel.Database.Model
{
    public class Room : IdentityBase
    {
        public string Number { get; set; }
        public string Description { get; set; }
        public int PlaceCount { get; set; }
        public double CostPerDay { get; set; }
        public RoomState State { get; set; }
        public long HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}