using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UAMovie.Models
{
    public class Customer
    {
        public String Username { get; set; }
        public AccountUser user { get; set; }
        public void insert()
        {
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            String insertQuery = "INSERT INTO Customer (username) VALUES('" + this.Username + "')";
            cmd.CommandText = insertQuery;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            db.Dispose();
        }
    }
}
