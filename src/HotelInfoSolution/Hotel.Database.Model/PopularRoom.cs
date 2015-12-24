namespace Hotel.Database.Model
{
    public class PopularRoom : IdentityBase
    {
        public string HotelTitle { get; set; }
        public string RoomNumber { get; set; }
        public int VisitorCount { get; set; }
    }
}