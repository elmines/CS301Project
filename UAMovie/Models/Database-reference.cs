using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle;
using Oracle.ManagedDataAccess.Client;
using UAMovie.Models;


namespace UAMovie.Models
{
    public class DatabaseRef
    {
        public OracleConnection conn { get; set; }
        private String connString {get;set;}
    public DatabaseRef()
        {
            connString = "DATA SOURCE=vrbsky-oracle.ua-net.ua.edu:1521/xe;PERSIST SECURITY INFO=True;USER ID=BDJONES13;Password=123";
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
