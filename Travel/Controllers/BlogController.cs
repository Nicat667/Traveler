using Microsoft.AspNetCore.Mvc;

namespace Reservation_Final.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
