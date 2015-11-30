using Hotel.Database.Common;
using Hotel.Web.Common;
using HotelInfo.Models;

namespace HotelInfo.BuilderCommands
{
    public class HotelEditCommand : IModelCommand<HotelEditModel, Hotel.Database.Model.Hotel>
    {
        private readonly IRepository<Hotel.Database.Model.Hotel> _hotelRepo;

        public HotelEditCommand(IRepository<Hotel.Database.Model.Hotel> hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        public Hotel.Database.Model.Hotel Execute(HotelEditModel model)
        {
            var hotel = _hotelRepo.Get(model.Id);
            hotel.Address = model.Address;
            hotel.IndividualId = model.IndividualId;
            hotel.Title = model.Title;

            _hotelRepo.AddOrUpdate(hotel);
            _hotelRepo.SaveChanges();

            return hotel;
        }
    }
}