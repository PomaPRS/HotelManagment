namespace Hotel.Database.Model
{
    public class Worker : IdentityBase
    {
        public long HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public string IdividualId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public long PositionId { get; set; }
        public Position Position { get; set; }

    }
}