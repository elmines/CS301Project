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
        public Boolean Saved { get; set; }


        public static CreditCard[] testData()
        {
            CreditCard[] data = new CreditCard[2];
            for (int i = 0; i < data.Length; ++i) data[i] = new CreditCard();


            data[0].CardNumber = "0000000000000000"; data[0].Holder = "Aibek Musaev";
            data[0].ExpirationDate = "10/2018";

            data[1].CardNumber = "1111111111111111"; data[1].Holder = "Ethan Mines";
            data[1].ExpirationDate = "01/2100";

            return data;
        }
    }
}
