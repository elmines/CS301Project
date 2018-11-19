using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UAMovie.Models
{
    public class SystemInfo
    {
        public int ID { get; set; }
        public String ManagerPassword { get; set; }
        public Double SeniorDiscount { get; set; }
        public Double ChildDiscount { get; set; }
        public Double RefundFee { get; set; }

    }
}
