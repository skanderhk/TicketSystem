using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystemLib;

namespace TicketSystemAPI.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;
        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            var res = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task DeleteUser(int userId)
        {
            var res = await context.Users.FindAsync(userId);
            if (res != null)
            {
                context.Users.Remove(res);
                await context.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserById(int userId)
        {
            return await context.Users.FindAsync(userId);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        public async Task UpdateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
