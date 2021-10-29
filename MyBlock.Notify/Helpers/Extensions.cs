using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlock
{
    public static class Extensions
    {
        public static DateTime ConvertUTCToLocal(this int secondsPast)
        {
            DateTime payoutDate = new DateTime(1970, 1, 1).AddSeconds(secondsPast);
            return TimeZoneInfo.ConvertTimeFromUtc(payoutDate, TimeZoneInfo.Local);
        }

        public static DateTime ConvertToTime(this int seconds)
        {
            DateTime now = DateTime.Now.Date;
            return now.AddSeconds(seconds);
        }
    }
}
