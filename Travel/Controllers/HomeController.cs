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
        private readonly IBlogService _blogService;
        public HomeController(ICityService cityService, IBlogService blogService)
        {
            _cityService = cityService;
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Cities = await _cityService.GetAllWihHotelsAsync(),
                Blogs = await _blogService.GetAllWithCategories(),
            };
            
            return View(homeVM);
        }

        
    }
}
