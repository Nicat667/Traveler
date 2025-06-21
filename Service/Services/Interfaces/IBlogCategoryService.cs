using Service.ViewModels.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IBlogCategoryService
    {
        Task<IEnumerable<BlogCategoryVM>> GetAllBlogCategories();
    }
}
