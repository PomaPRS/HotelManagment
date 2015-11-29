using Hotel.Database.Common;
using Hotel.Web.Common;
using HotelInfo.Models;

namespace HotelInfo.BuilderCommands
{
    public class HotelEditCommand : IModelCommand<HotelEditModel>
    {
        private readonly IRepository<Hotel.Database.Model.Hotel> _hotelRepo;

        public HotelEditCommand(IRepository<Hotel.Database.Model.Hotel> hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        public void Execute(HotelEditModel model)
        {
            var hotel = model.Id == 0 ? new Hotel.Database.Model.Hotel() : _hotelRepo.Get(model.Id);
            hotel.Address = model.Address;
            hotel.IndividualId = model.IndividualId;
            hotel.Title = model.Title;

            _hotelRepo.AddOrUpdate(hotel);
            _hotelRepo.SaveChanges();
        }
    }
}