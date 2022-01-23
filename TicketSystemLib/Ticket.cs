using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystemLib
{
    public class Ticket
    {
        public int ticketId { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public List<Comment> comments { get; set; }
        public User createdBy { get; set; }
        public TicketStatus status { get; set; } = TicketStatus.WAITINGFORREPLY;
        public DateTime createAt { get; set; } = new DateTime();
    }

    public enum TicketStatus
    {
        WAITINGFORREPLY, REPLAYED, CLOSED
    }
}
