using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlock.Models
{
    public class Currency
    {
        public string algo { get; set; }
        public int port { get; set; }
        public string name { get; set; }
        public object height { get; set; }
        public object workers { get; set; }
        public object shares { get; set; }
        public decimal hashrate { get; set; }
        public object oldhr { get; set; }
        public decimal newhr { get; set; }
        public string estimate { get; set; }
        [JsonProperty("24h_blocks")]
        public decimal day_blocks { get; set; }
        [JsonProperty("24h_btc")]
        public decimal day_btc { get; set; }
        public int lastblock { get; set; }
        public int timesincelast { get; set; }
        public string bitcointalk { get; set; }
        public string site { get; set; }
        public string twitter { get; set; }
        public string discord { get; set; }
        public string source { get; set; }
        public string explorer { get; set; }
        public string image { get; set; }
        public string error { get; set; }
    }
}
