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
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IEnumerable<BlogVM>> GetAllWithCategories()
        {
            var datas = await _blogRepository.GetAllWithCategories();
            return datas.Select(x => new BlogVM
            {
                Image = x.Image,
                Title = x.Title,
                Content = string.Join(" ",x.Content.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Take(46)) + " ...",
                CreateDate = DateTime.Now,
                AuthorImage = x.AuthorImage,
                AuthorName = x.AuthorName,
                CategoryName = x.BlogCategory.Name
            });
        }
    }
}
