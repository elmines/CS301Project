using System;
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

            try {
            cmd.ExecuteNonQuery();
            }
            catch 
            {
                
            }

            
            cmd.Dispose();
            db.Dispose();
        }
        public bool login()
        {
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            String loginQuery = "Select Username, Password from AccountUser where (Username = '"+this.Username+"'  AND Password = '"+this.Password+"')";
            cmd.CommandText = loginQuery;
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
                return true;
            else
                return false;
        }

        public bool isManager()
        {
            //assumes this is a valid accountuser
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            String loginQuery = "Select Username from Manager where (Username = '" + this.Username + "')";
            cmd.CommandText = loginQuery;
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
                return true;
            else
                return false;
        }
    }

    
}
