using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace UAMovie.Models
{
    public class SystemInfo
    {
        public int ID { get; set; }
        public String ManagerPassword { get; set; }
        public Double SeniorDiscount { get; set; }
        public Double ChildDiscount { get; set; }
        public Double RefundFee { get; set; }

        public void GetDiscounts()
        {
            Database db = new Database();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = db.conn;
            //does this handle nulls? TO be determined...
            //does this handle nulls? TO be determined...
            String readQuery = String.Format("select SeniorDiscount,ChildDiscount, RefundFee from SystemInfo");
            cmd.CommandText = readQuery;
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())//gets a row or exits the loop if no more
            {
                this.SeniorDiscount = reader.GetDouble(0);
                this.ChildDiscount= reader.GetDouble(1);
                this.RefundFee = reader.GetDouble(2);
            }

            cmd.Dispose();
            db.Dispose();
        }
    }
}
