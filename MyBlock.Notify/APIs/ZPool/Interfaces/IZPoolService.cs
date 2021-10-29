using MyBlock.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlock.Notify.APIs
{
    public interface IZPoolService
    {
        Task<Wallet> GetWalletAsync(string walletAddress);
        Task<Profile> GetExtendedWalletAsync(string walletAddress);
        Task<Payout> GetLastPayoutAsync(string walletAddress);
        Task<List<Payout>> GetLast24hourPayoutAsync(string walletAddress);
        Task<Dictionary<string, Currency>> GetCurrenciesAsync();
        Task<DateTime> GetLastBlockTimeAsync(string token);
    }
}
