using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task AddComment(CommentVM comment)
        {
            await _commentRepository.CreateAsync(new Domain.Models.Comment
            {
                AuthorName = comment.AuthorName,
                Rate = comment.Rate,
                Message = comment.Message,
                HotelId = comment.HotelId,
                Created = DateTime.Now,
            });
        }
    }
}
