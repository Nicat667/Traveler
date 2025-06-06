using Microsoft.AspNetCore.Mvc;

namespace Reservation_Final.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
