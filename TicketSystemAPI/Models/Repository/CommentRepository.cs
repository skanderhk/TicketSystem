using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystemLib;

namespace TicketSystemAPI.Models.Repository
{
    public class CommentRepository: ICommentRepository
    {
        private readonly AppDbContext context;
        public CommentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            if (comment.user != comment.ticket.createdBy)
            {
                comment.ticket.status = TicketStatus.REPLAYED;
            } else
            {
                comment.ticket.status = TicketStatus.WAITINGFORREPLY;
            }
            var res = await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task DeleteComment(int userId)
        {
            var res = await context.Comments.FindAsync(userId);
            if (res != null)
            {
                context.Comments.Remove(res);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Comment> GetCommentById(int userId)
        {
            return await context.Comments.FindAsync(userId);
        }

        public async Task<IEnumerable<Comment>> GetComments()
        {
            return await context.Comments.ToListAsync();
        }

        public async Task UpdateComment(Comment comment)
        {
            context.Entry(comment).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
