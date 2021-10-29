using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlock.Notify.APIs
{
    public interface INotificationService
    {
        Task<bool> NotifyIfChange(string walletAddress);
        Task<bool> NotifyIfBlockFound(string token);
    }
}
