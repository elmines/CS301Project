using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UAMovie.Models
{
    public class TicketOrder : IComparable<TicketOrder>
    {
        public String ID { get; set; }
        public String ShowingID { get; set; }
        public String Username { get; set; }
        public String CardNumber { get; set; }

        public int CompareTo(TicketOrder y)
        {
            return y.monthCode - monthCode;
        }

        public int monthCode
        {
            get
            {
                Database db = new Database();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = db.conn;
                cmd.CommandText = String.Format("SELECT EXTRACT(MONTH FROM StartTime) FROM" +
                    " Showing WHERE ID='{0}'", this.ShowingID);

                OracleDataReader reader = cmd.ExecuteReader();
                reader.Read();

                int monthCode = reader.GetInt32(0);
                reader.Dispose();
                cmd.Dispose();
                db.Dispose();
                return monthCode;
            }
        }

        public double Cost
        {
            get
            {
                double moviePrice = this.MoviePrice;

                SystemInfo info = new SystemInfo();
                info.GetDiscounts();

                double cost = moviePrice * (AdultTickets
                                               + (1.0 - info.ChildDiscount) * ChildTickets
                                               + (1.0 - info.SeniorDiscount) * SeniorTickets
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

        public String Month
        {
            get
            {
                if (monthCode == 1) return "January";
                if (monthCode == 2) return "February";
                if (monthCode == 3) return "March";
                if (monthCode == 4) return "April";
                if (monthCode == 5) return "May";
                if (monthCode == 6) return "June";
                if (monthCode == 7) return "July";
                if (monthCode == 8) return "August";
                if (monthCode == 9) return "September";
                if (monthCode == 10) return "October";
                if (monthCode == 11) return "November";
                if (monthCode == 12) return "December";
                return "December";
            }
        }


    

        public int ChildTickets { get; set; }
        public int AdultTickets { get; set; }
        public int SeniorTickets { get; set; }
        public String Status { get; set; }
        public static void Cancel(String orderID)
        {
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;                                                                                                               //id showingID username cardnumber cost ctick atcik stick status
            String insertQuery = String.Format("Update TicketOrder set Status='Canceled' WHERE ID='{0}'",orderID);
            cmd.CommandText = insertQuery;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            db.Dispose();
        }
        public static TicketOrder Get(String ID)
        {
            TicketOrder ticket = new TicketOrder();
            String readQuery = String.Format("select ID, ShowingID, Username, Cardnumber, Childtickets,adulttickets,seniortickets,status from TicketOrder where ID='{0}'", ID);
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;


            cmd.CommandText = readQuery;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ticket.ID = reader.GetString(0);
                ticket.ShowingID = reader.GetString(1);
                ticket.Username = reader.GetString(2);
                ticket.CardNumber = reader.GetString(3);
                ticket.ChildTickets = reader.GetInt32(4);
                ticket.AdultTickets = reader.GetInt32(5);
                ticket.SeniorTickets = reader.GetInt32(6);
                ticket.Status = reader.GetString(7);
                
            }
            cmd.Dispose();
            db.Dispose();
            return ticket;
        }
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
