using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlock.Notify.Models.CoinMine
{
    public class Dashboard
    {
        public string version { get; set; }
        public decimal runtime { get; set; }
        public DashboardDetail data { get; set; }
    }

    public class DashboardDetail
    {
        public DashboardOverview raw { get; set; }
        public PersonalDetail personal { get; set; }
        public PoolDetail pool { get; set; }
        public System system { get; set; }
        public Network network { get; set; }
    }

    public class DashboardOverview
    {
        public PersonalHashrate personal { get; set; }
        public Pool pool { get; set; }
        public Network network { get; set; }
    }

    public class PersonalHashrate
    {
        public decimal hashrate { get; set; }
    }

    public class Pool
    {
        public decimal hash { get; set; }
    }

    public class PersonalDetail
    {
        public decimal hashrate { get; set; }
        public decimal avghashrate { get; set; }
        public decimal lasthourhashrate { get; set; }
        public decimal sharerate { get; set; }
        public int sharedifficulty { get; set; }
        public Shares shares { get; set; }
        public Estimates estimates { get; set; }
    }

    public class PoolDetail
    {
        public PoolInfo info { get; set; }
        public decimal esttimeperblock { get; set; }
        public List<Block> blocks { get; set; } = new List<Block>();
    }

    public class PoolInfo
    {
        public string name { get; set; }
        public string currency { get; set; }
    }

    public class Block
    {
        public int id { get; set; }
        public int height { get; set; }
        public string blockhash { get; set; }
        public int confirmations { get; set; }
        public int amount { get; set; }
        public decimal difficulty { get; set; }
        public int time { get; set; }
        public int accounted { get; set; }
        public int account_id { get; set; }
        public string worker_name { get; set; }
        public long shares { get; set; }
        public int share_id { get; set; }
        public long pplns_shares { get; set; }
        public string finder { get; set; }
        public int is_anonymous { get; set; }
        public long estshares { get; set; }
    }

    public class Shares
    {
        public int valid { get; set; }
        public int invalid { get; set; }
        public decimal invalid_percent { get; set; }
        public decimal unpaid { get; set; }

    }

    public class Estimates
    {
        public decimal block { get; set; }
        public decimal fee { get; set; }
        public decimal donation { get; set; }
        public decimal payout { get; set; }
    }

    public class System
    {
        public List<decimal> load { get; set; } = new List<decimal>();
    }

    public class Network
    {
        public decimal hashrate { get; set; }
        public decimal esttimeperblock { get; set; }
        public decimal nextdifficulty { get; set; }
        public int blocksuntildiffchange { get; set; }
    }
}
