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
    }
}
