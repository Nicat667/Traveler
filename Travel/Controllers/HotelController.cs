using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using Service.ViewModels.Hotel;
using System.Threading.Tasks;

namespace Reservation_Final.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _hotelService.GetAllHotel());
        }
        public async Task<IActionResult> Detail(int id)
        {
            return View(await _hotelService.GetHotelDetail(id));
        }
        public async Task<IActionResult> Filter(FilterVM filter)
        {
            var datas = await _hotelService.HotelFilter(filter);
            return View(datas);
        }
        public async Task<IActionResult> FilterByCity(int id)
        {
            var datas = await _hotelService.HotelFilterByCity(id);
            return View(datas);
        }
    }
}
