using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlock.Models
{
    public class Wallet
    {
        public string currency { get; set; }
        public decimal unsold { get; set; }
        public decimal balance { get; set; }
        public decimal unpaid { get; set; }
        public decimal paid24h { get; set; }
        public decimal total { get; set; }
        public string error { get;set; }

        public decimal totalPaid
        {
            get
            {
                return paid24h + total + unpaid;
            }
        }
    }
}
