using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystemLib;

namespace TicketSystemAPI.Models.Repository
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetComments();
        Task<Comment> GetCommentById(int commentId);
        Task<Comment> CreateComment(Comment Comment);
        Task UpdateComment(Comment comment);
        Task DeleteComment(int commentId);
    }
}
