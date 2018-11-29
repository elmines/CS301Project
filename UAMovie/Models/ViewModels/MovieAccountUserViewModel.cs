using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAMovie.Models;
using Oracle.ManagedDataAccess.Client;


namespace UAMovie.Models.ViewModels
{
    public class MovieAccountUserViewModel
    {
        public AccountUser user { get; set; }
        public List<Movie> movies { get; set; }

        public Movie movie { get; set; }
        public List<Cast> cast { get; set; }
        public void GetNowPlaying()
        {
            //establish connection
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;



            //establish query
            String readQuery = "SELECT Name FROM Movie where NowShowing =1";
            cmd.CommandText = readQuery;
            OracleDataReader reader = cmd.ExecuteReader();


            while (reader.Read())//gets a row or exits the loop if no more
            {
                Movie tempMovie = new Movie();
                tempMovie.Name = reader.GetString(0);
                movies.Add(tempMovie);
            }

            cmd.Dispose();
            db.Dispose();
        }

        public void GetCast()
        {
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            String readQuery = String.Format("SELECT Actor, Character FROM Cast WHERE MovieName=\'{0}\'", movie.Name);
            cmd.CommandText = readQuery;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Cast tempCast = new Cast();
                tempCast.Actor = reader.GetString(0);
                tempCast.Character = reader.GetString(1);
                cast.Add(tempCast);
            }
            cmd.Dispose();
            db.Dispose();
        }
    }
}
