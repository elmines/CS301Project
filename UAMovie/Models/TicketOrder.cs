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
        public double Cost { get; set; }
        public int ChildTickets { get; set; }
        public int AdultTickets { get; set; }
        public int SeniorTickets { get; set; }
        public String Status { get; set; }

       public static TicketOrder[] testData()
        {
            TicketOrder[] data = new TicketOrder[2];
            for (int i = 0; i < data.Length; ++i) data[i] = new TicketOrder();

            data[0].ID = "0";
            data[0].ShowingID = "24"; data[0].CardNumber = "1111222233334444";
            data[0].Cost = 40.00; data[0].ChildTickets = 1; data[0].AdultTickets = 3;
            data[0].SeniorTickets = 2; data[0].Status = "Ordered";

            data[1].ID = "1";
            data[1].ShowingID = "265"; data[1].CardNumber = "0000000000000000";
            data[1].Cost = 22.00; data[1].ChildTickets = 1; data[0].AdultTickets = 0;
            data[1].SeniorTickets = 2; data[1].Status = "Cancelled";

            return data;
        }
    }
    
}
