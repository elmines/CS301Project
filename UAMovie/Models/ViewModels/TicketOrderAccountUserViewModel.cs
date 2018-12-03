using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UAMovie.Models.ViewModels
{
    public class TicketOrderAccountUserViewModel
    {
        public String username { get; set; }
        public List<TicketOrder> orders { get; set; }
        public TicketOrder order { get; set; }
        public List<Showing> showings { get; set; } //Parallel array of Showings
        public Theater theater { get; set; }
        public Showing showing { get; set; }
        public Movie movie { get; set; }
        public String selectedOrderID { get; set; }

        public void loadOrders()
        {
            this.orders = new List<TicketOrder>();
            this.showings = new List<Showing>();
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;

            cmd.CommandText = String.Format("SELECT " +
                "o.ID, o.Status, o.AdultTickets, o.ChildTickets, o.SeniorTickets" +
                ", s.MovieName, s.ID FROM" +
                " TicketOrder o INNER JOIN Showing s ON o.ShowingID=s.ID" +
                " WHERE o.Username=\'{0}\'", this.username);

            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.orders.Add( new TicketOrder
                {
                    ID = reader.GetString(0),
                    Status = reader.GetString(1),
                    AdultTickets = reader.GetInt32(2),
                    ChildTickets = reader.GetInt32(3),
                    SeniorTickets = reader.GetInt32(4),
                    ShowingID = reader.GetString(6)
                });

                this.showings.Add(new Showing
                {
                    MovieName = reader.GetString(5),
                    ID = reader.GetString(6)
                });
            }
        }
    }
}
