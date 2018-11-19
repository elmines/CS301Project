using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//The reason for the simple naming is because this should include many different classes, unfortunately.

namespace UAMovie.Models.ViewModels
{
    public class TicketOrderViewModel
    {
        public TicketOrder ticketOrder { get; set; }
        public Showing showing { get; set; }
        public CreditCard creditCard { get; set; }
        public SystemInfo systemInfo { get; set; }
    }
}
