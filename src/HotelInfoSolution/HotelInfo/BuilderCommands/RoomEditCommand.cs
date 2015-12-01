using System.Linq;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.BuilderCommands
{
    public class RoomEditCommand : IModelCommand<RoomEditModel, Room>
    {
        private readonly IRepository<Room> _roomRepo;
        private readonly IRepository<Hotel.Database.Model.Hotel> _hotelRepo;

        [Inject]
        public RoomEditCommand(IRepository<Room> roomRepo, IRepository<Hotel.Database.Model.Hotel> hotelRepo)
        {
            _roomRepo = roomRepo;
            _hotelRepo = hotelRepo;
        }

        public Room Execute(RoomEditModel model)
        {
            var hotel = _hotelRepo.GetRange(x => x.Title == model.HotelTitle).First();
            var room = _roomRepo.Get(model.Id);
            room.Id = model.Id;
            room.Description = model.Description;
            room.CostPerDay = model.CostPerDay;
            room.PlaceCount = model.PlaceCount;
            room.State = model.State;
            room.Number = model.Number;
            room.HotelId = hotel.Id;

            _roomRepo.Update(room);
            _roomRepo.SaveChanges();

            return room;
        }
    }
}