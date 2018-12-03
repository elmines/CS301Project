using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UAMovie.Models
{
    public class CreditCard
    {
        public String CardNumber { get; set; }
        public String UserName { get; set; }
        public String CVV { get; set; }
        public String Holder { get; set; }
        public String ExpirationDate { get; set; }
        public int Saved { get; set; }

        public static CreditCard Get(String CardNumber, String UserName)
        {
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            cmd.CommandText = String.Format("SELECT CardNumber, Username FROM CreditCard" +
                " WHERE CardNumber=\'{0}\' AND Username=\'{1}\'", CardNumber, UserName);
            OracleDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows) return null;

            reader.Read();
            CreditCard queried = new CreditCard
            {
                CardNumber = reader.GetString(0),
                UserName = reader.GetString(1)
            };
            return queried;
        }

        public void dePrefer()
        {
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            String updateText = String.Format("UPDATE CreditCard SET Saved='0'" +
                " WHERE Username=\'{0}\' AND CardNumber=\'{1}\'",this.UserName, this.CardNumber);
            cmd.CommandText = updateText;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            db.Dispose();
        }

        public void insert()
        {
            DatabaseRef db = new DatabaseRef();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            String insertQuery = "INSERT INTO CreditCard (CardNumber,Username,CVV,Holder,ExpirationDate,Saved) VALUES('" + this.CardNumber + this.UserName + this.CVV + this.Holder + this.ExpirationDate + "'" + this.Saved + "')";
            cmd.CommandText = insertQuery;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            db.Dispose();
        }

    }
}
