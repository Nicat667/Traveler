using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<IEnumerable<HotelVM>> GetAllHotel()
        {
            var datas = await _hotelRepository.GetAllHotel();
            return datas.Select(m => new HotelVM
            {
                Id = m.Id,
                Name = m.Name,
                StarCount = m.StarCount,
                MainImage = m.HotelImages.FirstOrDefault(x=>x.IsMain == true).Name,
                Address = m.Address,
                MinPrice = m.Rooms.Any(r => r.HotelId == m.Id) ? m.Rooms.Where(r => r.HotelId == m.Id).Min(r => r.Price) : 0,
                CommentCount = m.Comments.Where(x=>x.HotelId == m.Id).Count(),
                Rate = m.Comments.Any(c => c.HotelId == m.Id) ? m.Comments.Where(c => c.HotelId == m.Id).Sum(c => c.Rate) / (decimal)m.Comments.Count(c => c.HotelId == m.Id) : 5
            });
        }

        public async Task<HotelDetailVM> GetHotelDetail(int id)
        {
            var data = await _hotelRepository.GetHotelById(id);
            return new HotelDetailVM
            {
                Name = data.Name,
                StarCount = data.StarCount,
                Address = data.Address,
                Images = data.HotelImages.Where(m => m.HotelId == id),
                Comments = data.Comments.Where(m => m.HotelId == id),
                Rate = data.Comments.Any(c => c.HotelId == data.Id) ? data.Comments.Where(c => c.HotelId == data.Id).Sum(c => c.Rate) / (decimal)data.Comments.Count(c => c.HotelId == data.Id) : 5,
                Restaurant = data.Restaurant,
                AirConditioning = data.AirConditioning,
                AirportTransport = data.AirportTransport,
                SpaSauna = data.SpaSauna,
                FitnessCenter = data.FitnessCenter,
                Parking = data.Parking,
                Description = data.Description,
                Rooms = data.Rooms.Where(m => m.HotelId == id).Select(m => new ViewModels.Room.RoomVM
                {
                    HotelId = m.Id,
                    Area = m.Area,
                    BedCount = m.BedCount,
                    GuestCapacity = m.GuestCapacity,
                    MainImage = m.RoomImages.FirstOrDefault(x => x.IsMain == true).Name,
                    Price = m.Price,
                    Type = m.Type.ToString()
                })
            };
        }
    }
}
