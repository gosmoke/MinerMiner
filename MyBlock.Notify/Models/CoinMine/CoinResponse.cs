using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlock.Notify.Models.CoinMine
{
    public class CoinResponse<T>
    {
        public T gettimesincelastblock { get; set; }
        public T getdashboarddata { get; set; }
        public T getuserbalance { get; set; }
        public T getuserhashrate { get; set; }
        public T getpoolstatus { get; set; }
        public T getuserstatus { get; set; }
    }
}
