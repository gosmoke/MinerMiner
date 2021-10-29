using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlock.Models
{
    public class Payout
    {
        public int time { get; set; }
        public string amount { get; set; }
        public string tx { get; set; }

        public DateTime GetDate()
        {
            DateTime payoutDate = new DateTime(1970, 1, 1).AddSeconds(time);
            return TimeZoneInfo.ConvertTimeFromUtc(payoutDate, TimeZoneInfo.Local);
        }

        public decimal Tokens => decimal.Parse(amount);
    }
}
