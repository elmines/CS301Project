using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using UAMovie.Models;

namespace UAMovie.Models
{
    public class Review
    {
        public String ID { get; set; }
        public String MovieName { get; set; }
        public String Username { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }
        public int rating { get; set; }



        public bool insert()
        {
            Database db = new Database();

            OracleCommand readCmd = new OracleCommand();
            readCmd.Connection = db.conn;
            readCmd.CommandText = "SELECT MAX(TO_NUMBER(ID))+1 FROM Review HAVING COUNT(ID) > 0";
            OracleDataReader reader = readCmd.ExecuteReader();

            String ReviewID = "1";
            if (reader.HasRows)
            {
                reader.Read();
                ReviewID = (String)reader.GetInt64(0).ToString();
            }
            this.ID = ReviewID;
            readCmd.Dispose();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            String insertQuery = String.Format("INSERT INTO REVIEW (ID, Username, MovieName, Title, Body, Rating) Values ('{0}','{1}','{2}','{3}','{4}',{5})",this.ID,this.Username , this.MovieName,this.Title,this.Body,this.rating);
            cmd.CommandText = insertQuery;
            try
            {
                cmd.ExecuteNonQuery();
                db.Dispose();
                cmd.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                db.Dispose();
                cmd.Dispose();
                throw new Exception("Error inserting into review");
            }      
        }
    }

}
