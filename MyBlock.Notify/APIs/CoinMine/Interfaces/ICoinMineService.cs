using System;
using System.Threading.Tasks;

namespace MyBlock.Notify.APIs
{
    public interface ICoinMineService
    {
        Task<DateTime> GetTimeSinceLastBlockAsync();
        Task<DateTime> GetEstimatedTimeToNextBlockAsync();
        Task<Models.CoinMine.Dashboard> GetDashboardDataAsync();
        Task<Models.CoinMine.UserBalance> GetUserBalanceAsync();
        Task<Models.CoinMine.UserHashrate> GetUserHashrate();
        Task<Models.CoinMine.PoolStatus> GetPoolStatus();
        Task<Models.CoinMine.UserStatus> GetUserStatus();
    }
}
