using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlock.Notify.Models.CoinMine
{
    public class UserHashrate
    {
        public string version { get; set; }
        public decimal runtime { get; set; }
        public decimal data { get; set; }
    }
}
