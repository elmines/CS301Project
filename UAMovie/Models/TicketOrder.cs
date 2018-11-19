using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UAMovie.Models
{
    public class TicketOrder
    {
        public String ID { get; set; }
        public String ShowingID { get; set; }
        public String Username { get; set; }
        public String CardNumber { get; set; }
        public float Cost { get; set; }
        public int ChildTickets { get; set; }
        public int AdultTickets { get; set; }
        public int SeniorTicket { get; set; }
        public String Status { get; set; }
    }
}
