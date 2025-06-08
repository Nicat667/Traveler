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

        public async Task<IEnumerable<BlogCategoryVM>> GetAllBlogCategories()
        {
            var datas = await _blogRepository.GetCategories();
            return datas.Select(m => new BlogCategoryVM
            {
                Name = m.Name,
                Id = m.Id,
                Count = m.Blogs.Count,
            });
        }

        public async Task<IEnumerable<BlogDetailVM>> GetAllBlogsWithCategoriesAndImages()
        {

            var datas = await _blogRepository.GetAllWithCategories();
            var result = datas.Select(m => new BlogDetailVM
            {
                Id = m.Id,
                Image = m.Image,
                AuthorImage = m.AuthorImage,
                CategoryName = m.BlogCategory.Name,
                Content = string.Join(" ", m.Content.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Take(44)) + " ...",
                Title = m.Title,
                AuthorName = m.AuthorName,
                CreateDate = m.CreateDate.ToString("yyyy-MM-dd HH:mm"),
            });
            return result;
        }

        public async Task<IEnumerable<BlogVM>> GetAllWithCategories()
        {
            var datas = await _blogRepository.GetAllWithCategories();
            return datas.Select(x => new BlogVM
            {
                Image = x.Image,
                Title = x.Title,
                Content = string.Join(" ",x.Content.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Take(46)) + " ...",
                CategoryName = x.BlogCategory.Name,
                IsVisible = x.IsVisible
            });
        }
    }
}
