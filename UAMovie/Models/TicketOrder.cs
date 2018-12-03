using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UAMovie.Models
{
    public class TicketOrder
    {
        public String ID { get; set; }
        public String ShowingID { get; set; }
        public String Username { get; set; }
        public String CardNumber { get; set; }

        public double Cost
        {
            get
            {
                double moviePrice = this.MoviePrice;

                SystemInfo info = new SystemInfo();
                info.GetDiscounts();

                double cost = moviePrice * (AdultTickets
                                               + (1.0-info.ChildDiscount) * ChildTickets
                                               + (1.0-info.SeniorDiscount) * SeniorTickets
                                            );

                if (this.Status == "Cancelled")
                {
                    cost -= info.RefundFee;
                    if (cost <= 0.0) cost = 0.0;
                }

                return cost;

            }

        }
        private double MoviePrice
        {
            get
            {
                Database db = new Database();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = db.conn;
                cmd.CommandText = String.Format("SELECT m.Price FROM Showing s " +
                    " INNER JOIN Movie m ON s.MovieName = m.Name" +
                    " WHERE      s.ID = \'{0}\'",
                this.ShowingID);
                OracleDataReader reader = cmd.ExecuteReader();
                reader.Read();
                double cost = reader.GetDouble(0);
                cmd.Dispose();
                db.Dispose();
                return cost;
            }
        }

    

        public int ChildTickets { get; set; }
        public int AdultTickets { get; set; }
        public int SeniorTickets { get; set; }
        public String Status { get; set; }

        public void insert()
        {
            ID = this.getNewID();
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;                                                                                                               //id showingID username cardnumber cost ctick atcik stick status
            String insertQuery = String.Format("INSERT INTO TicketOrder (ID,ShowingID,Username,CardNumber,Cost,ChildTickets,AdultTickets,SeniorTickets,Status) VALUES('{8}','{0}','{1}','{2}',{3},{4},{5},{6},'{7}')",ShowingID,Username,CardNumber,Cost,ChildTickets,AdultTickets,SeniorTickets,"Purchased",ID);
            cmd.CommandText = insertQuery;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            db.Dispose();
        }
        public String getNewID()
        {
            Database db = new Database();

            OracleCommand readCmd = new OracleCommand();
            readCmd.Connection = db.conn;
            readCmd.CommandText = "SELECT MAX(TO_NUMBER(ID))+1 FROM TicketOrder HAVING COUNT(ID) > 0";
            OracleDataReader reader = readCmd.ExecuteReader();

            String OrderID = "1";
            if (reader.HasRows)
            {
                reader.Read();
                OrderID = (String)reader.GetInt64(0).ToString();
            }
            this.ID = OrderID;
            readCmd.Dispose();
            return OrderID;
        }
    }
    
}
