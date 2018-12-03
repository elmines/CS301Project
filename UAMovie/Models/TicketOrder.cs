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
                                               + info.ChildDiscount * ChildTickets
                                               + info.SeniorDiscount * SeniorTickets
                                            );

                if (this.Status == "Cancelled")
                {
                    cost -= info.RefundFee;
                    if (cost <= 0.0) cost = 0.0;
                }

                return cost;

            }

        }

        public int ChildTickets { get; set; }
        public int AdultTickets { get; set; }
        public int SeniorTickets { get; set; }
        public String Status { get; set; }

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

    }
    
}
