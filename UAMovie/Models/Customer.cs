using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UAMovie.Models
{
    public class Customer
    {
        public String username { get; set; }
        public AccountUser user { get; set; }
        public Customer(String username)
        {
            this.username = username;
        }
        public Customer()
        {

        }
        public void insert()
        {
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            String insertQuery = "INSERT INTO Customer (username) VALUES('" + this.username + "')";
            cmd.CommandText = insertQuery;
            try {
                cmd.ExecuteNonQuery();
            }
            catch 
            {
            }
            cmd.Dispose();
            db.Dispose();
        }
    }
}
