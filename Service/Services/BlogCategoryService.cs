using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BlogCategoryService : IBlogCategoryService
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;
        public BlogCategoryService(IBlogCategoryRepository blogCategoryRepository)
        {
            _blogCategoryRepository = blogCategoryRepository;
        }
        public async Task<IEnumerable<BlogCategoryVM>> GetAllBlogCategories()
        {
            var datas = await _blogCategoryRepository.GetCategories();
            return datas.Select(m => new BlogCategoryVM
            {
                Name = m.Name,
                Id = m.Id,
                Count = m.Blogs.Count,
            });
        }
    }
}
