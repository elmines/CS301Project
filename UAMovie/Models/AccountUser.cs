﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace UAMovie.Models
{
    public class AccountUser
    {
        public String Username { get; set; }
        public String EmailAddress { get; set; }
        public String Password { get; set; }

        public void insert()
        {
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();    
            cmd.Connection = db.conn;
            String insertQuery = "INSERT INTO AccountUser (username,emailaddress,password) VALUES('" + this.Username + "','" + this.EmailAddress + "','" + this.Password + "')";
            cmd.CommandText = insertQuery;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            db.Dispose();
        }
    }

    
}
