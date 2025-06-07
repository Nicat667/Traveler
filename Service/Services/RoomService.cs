using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<IEnumerable<RoomVM>> GetAllRooms()
        {
            var datas = await _roomRepository.GetAllRooms();
            return datas.Select(r => new RoomVM
            {
                Area = r.Area,
                Price = r.Price,
                BedCount = r.BedCount,
                GuestCapacity = r.GuestCapacity,
                HotelId = r.HotelId,
                MainImage = r.RoomImages.FirstOrDefault(m => m.IsMain == true).Name,
                Type = r.Type.ToString()
            });
        }

        public async Task<RoomDetailVM> GetRoomById(int id)
        {
            var data = await _roomRepository.GetRoomById(id);
            var options = await GetRoomsByHotelId(data.HotelId);
            return new RoomDetailVM
            {
                Area = data.Area,
                Price = data.Price,
                BedCount = data.BedCount,
                GuestCapacity = data.GuestCapacity,
                HotelId = data.HotelId,
                Id = data.Id,
                Images = data.RoomImages,
                Type = data.Type.ToString(),
                Description = data.Description,
                Options = options.Where(r => r.HotelId == data.HotelId && r.Price != data.Price && r.Id != data.Id).ToList()
            };
        }

        public async Task<List<RoomVM>> GetRoomsByHotelId(int hotelId)
        {
            var datas = await _roomRepository.GetRoomsByHotelId(hotelId);

            return datas
                .Select(m => new RoomVM
                {
                    Id = m.Id,
                    Area = m.Area,
                    Price = m.Price,
                    BedCount = m.BedCount,
                    GuestCapacity = m.GuestCapacity,
                    HotelId = m.HotelId,
                    MainImage = m.RoomImages.FirstOrDefault(m => m.IsMain).Name,
                    Type = m.Type.ToString()
                })
                .GroupBy(r => new { r.GuestCapacity, r.BedCount }) 
                .Select(group =>
                {
                    var room = group.First();
                    return room;
                }).ToList();
        }

    }
}
