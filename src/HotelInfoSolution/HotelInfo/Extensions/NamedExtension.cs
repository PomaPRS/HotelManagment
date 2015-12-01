using Hotel.Database.Model;

namespace HotelInfo.Extensions
{
    public static class NamedExtension
    {
        public static string GetName(this Visitor visitor)
        {
            return string.Format("{0} {1} {2}", visitor.FirstName, visitor.SecondName, visitor.MiddleName);
        }

        public static string GetName(this Worker worker)
        {
            return string.Format("{0} {1} {2}", worker.FirstName, worker.SecondName, worker.MiddleName);
        }

        public static string GetName(this Room room)
        {
            return string.Format("{0}: {1}", room.Hotel.Title, room.Number);
        }
    }
}