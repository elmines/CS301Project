﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace UAMovie.Models
{
    public class Showing
    {
        public String ID { get; set; }
        public String MovieName { get; set; }
        public String TheaterID { get; set; }
        public DateTime StartTime { get; set; }
        public static Showing GetShowing(String ID)
        {
            Database db = new Database();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            //does this handle nulls? TO be determined...
            //does this handle nulls? TO be determined...
            String readQuery = String.Format("select * from showing where showing.ID ='{0}'", ID);
            cmd.CommandText = readQuery;
            OracleDataReader reader = cmd.ExecuteReader();
            Showing showing = new Showing();

            while (reader.Read())//gets a row or exits the loop if no more
            {
                showing.ID = reader.GetString(0);
                showing.MovieName = reader.GetString(1);
                showing.TheaterID = reader.GetString(2);
                showing.StartTime = reader.GetDateTime(3);

            }

            cmd.Dispose();
            db.Dispose();
            return showing;
        }
        public static List<Showing> GetFutureShowings(String movieName, String theaterID)
        {
            List<Showing> showings = new List<Showing>();
            String readQuery = String.Format("select name, starttime,ID from showing right join movie on showing.moviename = movie.name where movie.name = '{0}'AND showing.TheaterID = '{1}' order by movie.name ", movieName,theaterID);
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;

            
            cmd.CommandText = readQuery;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Showing tempShowing = new Showing();
                tempShowing.MovieName = reader.GetString(0);
                tempShowing.StartTime = reader.GetDateTime(1);
                tempShowing.ID = reader.GetString(2);
                showings.Add(tempShowing);
            }
            List<Showing> validShowings = new List<Showing>();
            foreach (Showing showing in showings)
            {
                if (!((showing.StartTime > DateTime.Now.AddDays(7)) || (showing.StartTime <  DateTime.Now)))
                    validShowings.Add(showing);
            }
            cmd.Dispose();
            db.Dispose();
            return validShowings;
        }
    }
    
}
