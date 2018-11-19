using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UAMovie.Models
{
    public class Review
    {
        public String ID { get; set; }
        public String MovieName { get; set; }
        public String Username { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }
        public int rating { get; set; }
    }
}
