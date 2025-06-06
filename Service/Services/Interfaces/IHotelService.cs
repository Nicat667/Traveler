using Service.ViewModels.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IHotelService
    {
        Task<IEnumerable<HotelVM>> GetAllHotel();
        Task<HotelDetailVM> GetHotelDetail(int id);
    }
}
