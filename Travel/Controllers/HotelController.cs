using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using Service.ViewModels;
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
            return View(await _hotelService.HotelFilter(filter));
        }
        public async Task<IActionResult> FilterByCity(int id)
        {
            return View(await _hotelService.HotelFilterByCity(id));
        }
        public async Task<IActionResult> Search(SearchVM query)
        {
            return View(await _hotelService.Search(query));
        }
    }
}
