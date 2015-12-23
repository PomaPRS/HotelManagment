using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Database.Model
{
    public class Worker : IdentityBase
    {
        public long HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        [Index("IndividualId", 1, IsUnique = true)]
        public string IndividualId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public long PositionId { get; set; }
        public virtual Position Position { get; set; }
    }
}