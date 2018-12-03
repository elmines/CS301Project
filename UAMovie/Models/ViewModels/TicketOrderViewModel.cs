using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//The reason for the simple naming is because this s;hould include many different classes, unfortunately.

namespace UAMovie.Models.ViewModels
{
    public class TicketOrderViewModel
    {
        public TicketOrder ticketOrder { get; set; }
        public Showing showing { get; set; }
        public List<Showing> showings { get; set; }
        public CreditCard creditCard { get; set; }
        public List<CreditCard> creditCards { get; set; }
        public SystemInfo systemInfo { get; set; }
        public Theater theater { get; set; }
        public String theaterID { get; set; }
        public String userName { get; set; }
        public String movieName { get; set; }
        public String showingID { get; set; }
        public TicketOrderViewModel()
        {

            ticketOrder = new TicketOrder();
            showing = new Showing();
            creditCard = new CreditCard();
            systemInfo = new SystemInfo();
            showings = new List<Showing>();
            theater = new Theater();
        }

    }
}
