using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UAMovie.Models
{
    public class RevStats
    {
        public Int32 monthCode { get; set; }
        public Int32 adultTickets { get; set; }
        public Int32 seniorTickets { get; set;  }
        public Int32 childTickets { get; set; }
        public String movieName { get; set; }
        public String Month
        {
            get
            {
                if (monthCode == 1) return "January";
                if (monthCode == 2) return "February";
                if (monthCode == 3) return "March";
                if (monthCode == 4) return "April";
                if (monthCode == 5) return "May";
                if (monthCode == 6) return "June";
                if (monthCode == 7) return "July";
                if (monthCode == 8) return "August";
                if (monthCode == 9) return "September";
                if (monthCode == 10) return "October";
                if (monthCode == 11) return "November";
                if (monthCode == 12) return "December";
                return "December";
            }
        }
    }
}
