using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using UAMovie.Models;

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
        public int NowPlaying { get; set; }
        public static Movie Get(String movieName)
        {
            //establish connection
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            //establish query
            String readQuery = "SELECT * FROM Movie where Name='" + movieName + "'";
            cmd.CommandText = readQuery;
            OracleDataReader reader = cmd.ExecuteReader();

            Movie movie = new Movie();
            if (reader.Read())
            {

                movie.Name = reader.GetString(0);
                movie.AgeRating = reader.GetString(1);
                movie.ReleaseDate = reader.GetString(2);
                movie.Synopsis = reader.GetString(3);
                movie.Price = reader.GetFloat(4);
                movie.Duration = reader.GetInt32(5);
                movie.Genre = reader.GetString(6);
                movie.NowPlaying = reader.GetInt32(7);
            }

            cmd.Dispose();
            db.Dispose();
            return movie;
        }
    }
    
}
