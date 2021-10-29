using MyBlock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyBlock.Notify.APIs
{
    public class ZPoolService : IZPoolService
    {
        private const string APPLICATION_JSON = "application/json";
        private HttpClient ZPoolClient { get; set; }

        public ZPoolService()
        {
            ZPoolClient = new HttpClient()
            {
                BaseAddress = new Uri("https://www.zpool.ca/api/")
            };

            ZPoolClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(APPLICATION_JSON));
        }

        public async Task<Wallet> GetWalletAsync(string walletAddress)
        {
            var httpResponse = await ZPoolClient.GetAsync($"wallet?address={walletAddress}");
            return await GetIntegrationResponseAsync<Wallet>(httpResponse);
        }

        public async Task<Profile> GetExtendedWalletAsync(string walletAddress)
        {
            var httpResponse = await ZPoolClient.GetAsync($"walletEX?address={walletAddress}");
            return await GetIntegrationResponseAsync<Profile>(httpResponse);
        }

        public async Task<Payout> GetLastPayoutAsync(string walletAddress)
        {
            Payout payout = null;

            var httpResponse = await ZPoolClient.GetAsync($"walletEX?address={walletAddress}");
            Profile profile = await GetIntegrationResponseAsync<Profile>(httpResponse);

            if (profile != null && profile.payouts.Any())
            {
                return profile.payouts.FirstOrDefault();
            }

            return payout;
        }

        public async Task<List<Payout>> GetLast24hourPayoutAsync(string walletAddress)
        {
            List<Payout> payouts = new List<Payout>();

            var httpResponse = await ZPoolClient.GetAsync($"walletEX?address={walletAddress}");
            Profile profile = await GetIntegrationResponseAsync<Profile>(httpResponse);

            if (profile != null && profile.payouts.Any())
            {
                DateTime now = DateTime.Now;

                return profile.payouts.Where(a => a.GetDate() > now.AddHours(-24) && a.GetDate() <= now).ToList();
            }

            return payouts;
        }

        public async Task<Dictionary<string, Currency>> GetCurrenciesAsync()
        {
            Dictionary<string, Currency> currencies = new Dictionary<string, Currency>();

            var httpResponse = await ZPoolClient.GetAsync("currencies");
            currencies = await GetIntegrationResponseAsync<Dictionary<string, Currency>>(httpResponse);

            return currencies;
        }

        public async Task<DateTime> GetLastBlockTimeAsync(string token)
        {
            var currencies = await GetCurrenciesAsync();
            var tokenCurrency = currencies.Where(a => a.Key == token.ToUpper()).SingleOrDefault();
            if (tokenCurrency.Value != null)
            {
                DateTime lastBlockFound = tokenCurrency.Value.timesincelast.ConvertToTime();
                TimeSpan hoursSinceLastBlockFound = lastBlockFound.TimeOfDay;
                var timeLastBlockFound = new TimeSpan(DateTime.Now.Ticks - hoursSinceLastBlockFound.Ticks);
                return new DateTime(timeLastBlockFound.Ticks);
            }

            return DateTime.MinValue;
        }

        private async Task<T> GetIntegrationResponseAsync<T>(HttpResponseMessage httpResponse)
        {
            T response = await JsonSerializer.DeserializeAsync<T>(await httpResponse.Content.ReadAsStreamAsync());
            return response;
        }
    }
}
