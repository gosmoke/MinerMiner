using MyBlock.Models;
using MyBlock.Notify.APIs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace MyBlock.Notify
{
    public class NotificationService : INotificationService
    {
        private Payout lastPayout = new Payout();
        public DateTime LastBlockFound { get; set; } = DateTime.Now;
        private IZPoolService ZPoolService = null;

        public NotificationService()
        {
            ZPoolService = new ZPoolService();
        }

        public async Task<bool> NotifyIfChange(string walletAddress)
        {
            bool notify = false;

            var payout = await ZPoolService.GetLastPayoutAsync(walletAddress);
            if (payout.time != lastPayout.time)
            {
                lastPayout = payout;
                notify = true;
            }

            if (notify)
            {
                var payouts = await ZPoolService.GetLast24hourPayoutAsync(walletAddress);

                SendToastMessage(@"C:\Users\aglines\Pictures\LBC_Icon.png", 
                    "LBC Payout", 
                    "Great news!  ZPool has confirmed a new payout!", 
                    $"Received {payout.amount} LBRY Credits. Total today is {payouts.Sum(a => a.Tokens)}.");

                return true;
            }

            return false;
        }

        public async Task<bool> NotifyIfBlockFound(string token)
        {
            DateTime lastBlockFound = await ZPoolService.GetLastBlockTimeAsync(token);
            if (this.LastBlockFound != lastBlockFound)
            {
                this.LastBlockFound = lastBlockFound;

                SendToastMessage(@"C:\Users\aglines\Pictures\LBC_Icon.png",
                    "LBC BLOCK FOUND!",
                    "Fantastic news!  ZPool has found a New Block!",
                    $"Look for LBRY Credits to come your way soon.");

                return true;
            }

            return false;
        }

        private void SendToastMessage(string imageFullPath, string h1, string h2, string p1)
        {
            System.Diagnostics.Process p = System.Diagnostics.Process.GetCurrentProcess();
            string appid = p.Id.ToString();

            var template = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);

            var textNodes = template.GetElementsByTagName("text");

            textNodes[0].AppendChild(template.CreateTextNode(h1));
            textNodes[1].AppendChild(template.CreateTextNode(h2));
            textNodes[2].AppendChild(template.CreateTextNode(p1));

            if (File.Exists(imageFullPath))
            {
                XmlNodeList toastImageElements = template.GetElementsByTagName("image");
                ((XmlElement)toastImageElements[0]).SetAttribute("src", imageFullPath);
            }
            IXmlNode toastNode = template.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");

            var notifier = ToastNotificationManager.CreateToastNotifier(appid);
            var notification = new ToastNotification(template);

            notifier.Show(notification);
        }
    }
}
