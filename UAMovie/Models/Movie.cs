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
        public int Duration { get; set; }
        public String Genre { get; set; }

        public static Movie[] testData()
        {
            Movie m = new Movie();
            m.Name = "The Rise and Fall of Ben Jones";
            m.AgeRating = "G";
            m.ReleaseDate = "August 22, 2016";
            m.Synopsis = "Benjamin strives to find his way in a world where algorithms aren't all we need for computing.";
            m.Price = 100.0f;
            m.Duration = 480;
            m.Genre = "Romantic Comedy";

            return new Movie[] { m };
        }
    }
}
