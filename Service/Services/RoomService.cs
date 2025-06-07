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

        public async Task<IEnumerable<RoomVM>> GetRoomsByHotelId(int hotelId)
        {
            var datas = await _roomRepository.GetRoomsByHotelId(hotelId);

            var grouped = datas
                .GroupBy(r => new { r.Type, r.GuestCapacity, r.BedCount })
                .Select(group =>
                {
                    var room = group.OrderBy(r => r.Price).First(); 

                    return new RoomVM
                    {
                        Area = room.Area,
                        Price = room.Price,
                        BedCount = room.BedCount,
                        GuestCapacity = room.GuestCapacity,
                        HotelId = room.HotelId,
                        MainImage = room.RoomImages.FirstOrDefault(m => m.IsMain == true)?.Name,
                        Type = room.Type.ToString()
                    };
                });

            return grouped;
        }
    }
}
