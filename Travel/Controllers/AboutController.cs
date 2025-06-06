using Microsoft.AspNetCore.Mvc;

namespace Reservation_Final.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
