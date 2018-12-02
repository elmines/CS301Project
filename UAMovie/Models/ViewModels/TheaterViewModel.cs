using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAMovie.Models;
using Oracle.ManagedDataAccess.Client;

namespace UAMovie.Models.ViewModels
{
    public class TheaterViewModel
    {
        public Customer customer { get; set; }
        public Theater theater { get; set; }
        public List<Theater> preferredTheaters { get; set; }
        public List<Theater> foundTheaters { get; set; }
        public String errorText { get; set; }
        public String searchName { get; set; }

        public void GetPreferredTheaters()// puts the preffered theaters in the list.
        {
            //establish connection
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            preferredTheaters = new List<Theater>();

            //TODO: CHANGE THE QUERY TO JOIN ON PREFERREDTHEATERS

            //establish query
            String readQuery = "SELECT * FROM Theater";
            cmd.CommandText = readQuery;
            OracleDataReader reader = cmd.ExecuteReader();

           
            while (reader.Read())//gets a row or exits the loop if no more
            {
                Theater tempTheater = new Theater();
                tempTheater.ID = reader.GetString(0);
                tempTheater.Name = reader.GetString(1);
                tempTheater.State = reader.GetString(2);
                tempTheater.City = reader.GetString(3);
                tempTheater.StreetNumber = reader.GetString(4);
                tempTheater.Street = reader.GetString(5);
                tempTheater.Zip = reader.GetString(6);
                preferredTheaters.Add(tempTheater);
            }

            cmd.Dispose();
            db.Dispose();
        }
    }
}
