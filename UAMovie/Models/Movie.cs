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

        public String durationText {
            get
            {
                int hours = Duration / 60;
                int minutes = Duration % 60;
                if (minutes > 0) return String.Format("{0} hours and {1} minutes", hours, minutes);
                return                  String.Format("{0} hours", hours);
            }
        }

        public bool canReview(String username)
        {
            Boolean canReview = false;
            Database db = new Database();

            //Check if they've seen the movie
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            String queryString = String.Format("SELECT * FROM TicketOrder o" +
                " INNER JOIN Showing s ON o.ShowingID = s.ID" +
                " WHERE                   o.Status<>\'Cancelled\'" +
                "  AND                    s.MovieName = \'{0}\'" +
                "  AND                    o.Username = \'{1}\'" +
                "  AND (SELECT current_timestamp FROM dual) >= s.StartTime",
                this.Name, username);
            cmd.CommandText = queryString;
            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                canReview = true;
                //Check if they've already written a review
                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = db.conn;
                cmd2.CommandText = String.Format("SELECT * FROM Review WHERE MovieName=\'{0}\' AND Username=\'{1}\'",
                                this.Name, username);
                if (cmd2.ExecuteReader().HasRows) canReview = false;
                cmd2.Dispose();
            }

            cmd.Dispose();
            db.Dispose();
            return canReview;
        }

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
