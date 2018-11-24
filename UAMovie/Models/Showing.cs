using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UAMovie.Models
{
    public class Showing
    {
        public String ID { get; set; }
        public String MovieName { get; set; }
        public String TheaterID { get; set; }
        public DateTime StartTime { get; set; }

        public static Showing[] testData()
        {
            Showing s = new Showing();
            s.ID = "12345"; s.MovieName = "The Rise and Fall of Ben Jones";
            s.TheaterID = "6789"; s.StartTime = DateTime.Now;

            return new Showing[] { s };
        }
    }

}
