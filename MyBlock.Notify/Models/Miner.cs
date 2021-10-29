using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlock.Models
{
    public class Miner
    {
        public string version { get; set; }
        public string password { get; set; }
        public string ID { get; set; }
        public string algo { get; set; }
        public int difficulty { get; set; }
        public int subscribe { get; set; }
        public decimal accepted { get; set; }
        public decimal rejected { get; set; }
    }
}
