﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAMovie.Models;
using Oracle.ManagedDataAccess.Client;

namespace UAMovie.Models
{
    public class Theater
    {
        public String ID { get; set; }
        public String Name { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String StreetNumber { get; set; }
        public String Street { get; set; }
        public String Zip { get; set; }
        public static Theater GetTheater(String ID)
        {
            Database db = new Database();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            //does this handle nulls? TO be determined...
            //does this handle nulls? TO be determined...
            String readQuery = String.Format("select * from theater where theater.ID ='{0}'", ID);
            cmd.CommandText = readQuery;
            OracleDataReader reader = cmd.ExecuteReader();
            Theater theater = new Theater();
            
            while (reader.Read())//gets a row or exits the loop if no more
            {
                theater.ID = reader.GetString(0);
                theater.Name = reader.GetString(1);
                theater.State = reader.GetString(2);
                theater.City = reader.GetString(3);
                theater.StreetNumber = reader.GetString(4);
                theater.Street = reader.GetString(5);
                theater.Zip = reader.GetString(6);
            }

            cmd.Dispose();
            db.Dispose();
            return theater;
        }

        public static List<Theater> SearchTheaters(String searchName)
        {
            Database db = new Database();
           
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            //does this handle nulls? TO be determined...
            //does this handle nulls? TO be determined...
            String readQuery = String.Format("select * from theater where theater.name like '%{0}%' or theater.city like '%{0}%' or theater.state = '%{0}%'",searchName);
            cmd.CommandText = readQuery;
            OracleDataReader reader = cmd.ExecuteReader();

            List<Theater> list = new List<Theater>();
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
                list.Add(tempTheater);
            }

            cmd.Dispose();
            db.Dispose();
            return list;
        }

        
        public static Theater[] testData()
        {
            Theater[] data = new Theater[2];
            for (int i = 0; i < data.Length; ++i) data[i] = new Theater();

            data[0].ID = "1"; data[0].Name = "Seedy Theater"; data[0].City = "Nowhere";
            data[0].State = "Mississippi"; data[0].StreetNumber = "1111"; data[0].Street = "Lame St.";
            data[0].Zip = "00000";

            data[1].ID = "1"; data[1].Name = "Cool Theater"; data[1].City = "Somewhere";
            data[1].State = "Nice"; data[1].StreetNumber = "2532"; data[1].Street = "Cool Ct.";
            data[1].Zip = "12345";

            return data;

        }
    }
}
