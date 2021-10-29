using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlock.Notify.Models.CoinMine
{
    public class PoolStatus
    {
        public string version { get; set; }
        public decimal runtime { get; set; }
        public PoolDetails data { get; set; }
    }

    public class PoolDetails
    {
        public string pool_name { get; set; }
        public decimal hashrate { get; set; }
        public decimal efficiency { get; set; }
        public decimal progress { get; set; }
        public int workers { get; set; }
        public int currentnetworkblock { get; set; }
        public int nextnetworkblock { get; set; }
        public int lastblock { get; set; }
        public decimal networkdiff { get; set; }
        public decimal esttime { get; set; }
        public long estshares { get; set; }
        public int timesincelast { get; set; }
        public decimal nethashrate { get; set; }
    }
}
