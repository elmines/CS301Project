using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UAMovie.Models
{
    public class Movie
    {
        public String Name { get; set; }
        public String AgeRating { get; set; }
        public String ReleaseDate { get; set; }
        public String Synopsis { get; set; }
        public float Price { get; set; }
        public int Duraction { get; set; }
        public String Genre { get; set; }
    }
}
