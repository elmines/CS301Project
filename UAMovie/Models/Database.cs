using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle;
using Oracle.ManagedDataAccess.Client;
using UAMovie.Models;


namespace UAMovie.Models
{
    public class Database
    {
        public OracleConnection conn { get; set; }
        private String connString {get;set;}
    public Database()
        {
            connString = "DATA SOURCE=vrbsky-oracle.ua-net.ua.edu:1521/xe;PERSIST SECURITY INFO=True;USER ID=BDJONES13;Password=123456789";
            conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();
        }
    public void Dispose()
        {
            conn.Close();
        }
    
    }
}
