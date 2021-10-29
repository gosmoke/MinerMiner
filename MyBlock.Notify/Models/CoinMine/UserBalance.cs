using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlock.Notify.Models.CoinMine
{
    public class UserBalance
    {
        public string version { get; set; }
        public decimal runtime { get; set; }
        public UserPayment data { get; set; }
    }

    public class UserPayment
    {
        public decimal confirmed { get; set; }
        public decimal unconfirmed { get; set; }
        public decimal orphaned { get; set; }
    }
}
