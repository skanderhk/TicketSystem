using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystemLib;

namespace TicketSystemAPI.Models.Repository
{
    public class TicketRepository: ITicketRepository
    {
        private readonly AppDbContext context;
        public TicketRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            var res = await context.Tickets.AddAsync(ticket);
            await context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task DeleteTicket(int userId)
        {
            var res = await context.Tickets.FindAsync(userId);
            if (res != null)
            {
                context.Tickets.Remove(res);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Ticket> GetTicketById(int userId)
        {
            return await context.Tickets.FindAsync(userId);
        }

        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            return await context.Tickets.ToListAsync();
        }

        public async Task UpdateTicket(Ticket ticket)
        {
            context.Entry(ticket).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
