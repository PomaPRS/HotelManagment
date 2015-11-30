using Hotel.Database.Common;
using Hotel.Web.Common;
using HotelInfo.Models;
using Ninject;

namespace HotelInfo.BuilderCommands
{
    public class HotelCreateCommand : IModelCommand<HotelCreateModel, Hotel.Database.Model.Hotel>
    {
        private readonly IRepository<Hotel.Database.Model.Hotel> _hotelRepo;

        [Inject]
        public HotelCreateCommand(IRepository<Hotel.Database.Model.Hotel> hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        public Hotel.Database.Model.Hotel Execute(HotelCreateModel model)
        {
            var hotel = new Hotel.Database.Model.Hotel
            {
                Address = model.Address,
                IndividualId = model.IndividualId,
                Title = model.Title
            };

            _hotelRepo.Add(hotel);
            _hotelRepo.SaveChanges();

            return hotel;
        }
    }
}