using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlock.Models
{
    public class Profile
    {
        public Profile()
        {
            miners = new List<Miner>();
            payouts = new List<Payout>();
        }

        public Wallet Wallet { get; set; }
        public List<Miner> miners { get; set; }
        public List<Payout> payouts { get; set; }
    }
}
