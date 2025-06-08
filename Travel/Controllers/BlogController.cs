using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using Service.ViewModels.Blog;
using System.Threading.Tasks;

namespace Reservation_Final.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IActionResult> Index()
        {
            BlogAndCategoryVM blogAndCategoryVM = new BlogAndCategoryVM()
            {
                BlogCategories = await _blogService.GetAllBlogCategories(),
                Blogs = await _blogService.GetAllBlogsWithCategoriesAndImages()
            };
            return View(blogAndCategoryVM);
        }
        
    }
}
