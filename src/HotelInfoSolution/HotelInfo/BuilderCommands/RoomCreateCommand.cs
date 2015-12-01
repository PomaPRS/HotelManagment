using System.Linq;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.BuilderCommands
{
    public class RoomCreateCommand : IModelCommand<RoomCreateModel, Room>
    {
        private readonly IRepository<Room> _roomRepo;
        private readonly IRepository<Hotel.Database.Model.Hotel> _hotelRepo;

        [Inject]
        public RoomCreateCommand(IRepository<Room> roomRepo, IRepository<Hotel.Database.Model.Hotel> hotelRepo)
        {
            _roomRepo = roomRepo;
            _hotelRepo = hotelRepo;
        }

        public Room Execute(RoomCreateModel model)
        {
            var hotel = _hotelRepo.GetRange(x => x.Title == model.HotelTitle).First();
            var room = new Room
            {
                CostPerDay = model.CostPerDay,
                Description = model.Description,
                PlaceCount = model.PlaceCount,
                State = model.State,
                Number = model.Number,
                HotelId = hotel.Id
            };

            _roomRepo.Add(room);
            _roomRepo.SaveChanges();

            return room;
        }
    }
}