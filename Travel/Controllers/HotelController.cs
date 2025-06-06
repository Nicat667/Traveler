using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
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
    }
}
