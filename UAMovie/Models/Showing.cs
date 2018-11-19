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
    }
}
