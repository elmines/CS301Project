using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;


using UAMovie.Models;
namespace UAMovie.Models.ViewModels
{
    public class CreditCardAccountUserViewModel
    {
        public AccountUser user {get; set;}
        public List<CreditCard> savedCards { get; set; }

        public String selectedCardNumber { get; set; }

        public void loadSavedCards()
        {
            this.savedCards = new List<CreditCard>();
            Database db = new Database();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;

            String query = String.Format("SELECT CardNumber, Holder, ExpirationDate FROM CreditCard" +
                " WHERE Username=\'{0}\' AND SAVED='1'", this.user.Username);
            cmd.CommandText = query;

            OracleDataReader reader = cmd.ExecuteReader();
            this.savedCards = new List<CreditCard>();

            while (reader.Read())
            {
                CreditCard tempCard = new CreditCard();
                tempCard.CardNumber = reader.GetString(0);
                tempCard.Holder = reader.GetString(1);
                tempCard.ExpirationDate = reader.GetString(2);

                this.savedCards.Add(tempCard);
            }
            cmd.Dispose();
            db.Dispose();
        }

    }
} 
