using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystemLib
{
    public class Comment
    {
        public int commentId { get;  set; }
        public Ticket ticket { get; set; }
        public User user { get; set; }
        public string content { get; set; }
        public DateTime createAt { get; set; } = new DateTime();
    }
}
