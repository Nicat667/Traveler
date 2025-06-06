using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using Service.ViewModels;

namespace Travel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICityService _cityService;
        public HomeController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Cities = await _cityService.GetAllWihHotelsAsync(),
            };
            
            return View(homeVM);
        }

        
    }
}
