namespace Hotel.Database.Model
{
    public class Hotel : IdentityBase
    {
        public string Title { get; set; }
        public string IdividualId { get; set; }
        public string Address { get; set; }
        public long DirectorId { get; set; }
        public Worker Director { get; set; }
    }
}