using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlock.Notify.Models.CoinMine
{
    public class UserStatus
    {
        public string version { get; set; }
        public decimal runtime { get; set; }
        public AccountInfo data { get; set; }
    }

    public class AccountInfo
    {
        public string username { get; set; }
        public UserShares shares { get; set; }
        public decimal hashrate { get; set; }
        public decimal sharerate { get; set; }

    }

    public class UserShares
    {
        public int valid { get; set; }
        public int invalid { get; set; }
        public int id { get; set; }
        public decimal donate_percent { get; set; }
        public int is_anonymous { get; set; }
        public string username { get; set; }
        public decimal hashrate { get; set; }
    }
}
