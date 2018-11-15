﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UAMovie.Models
{
    public class Theater
    {
        public String ID { get; set; }
        public String Name { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String StreetNumber { get; set; }
        public String Street { get; set; }
        public String Zip { get; set; }


        public static Theater[] testData()
        {
            Theater[] data = new Theater[2];
            for (int i = 0; i < data.Length; ++i) data[i] = new Theater();

            data[0].ID = "1"; data[0].Name = "Seedy Theater"; data[0].City = "Nowhere";
            data[0].State = "Mississippi"; data[0].StreetNumber = "1111"; data[0].Street = "Lame St.";
            data[0].Zip = "00000";

            data[1].ID = "1"; data[1].Name = "Cool Theater"; data[1].City = "Somewhere";
            data[1].State = "Nice"; data[1].StreetNumber = "2532"; data[1].Street = "Cool Ct.";
            data[1].Zip = "12345";

            return data;

        }
    }
}
