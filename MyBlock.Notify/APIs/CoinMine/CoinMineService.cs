using MyBlock.Notify.Models.CoinMine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyBlock.Notify.APIs
{
    public class CoinMineService : ICoinMineService
    {
        private const string APPLICATION_JSON = "application/json";
        private const string API_KEY = "b66bc1e2fd4ff7b0a7a3f88120918cef728a8dfcbbe6be71aab2d3690e764bd3";
        private const string ID = "150981";
        private HttpClient httpClient { get; set; }

        private string exampleRequestUrl = "https://www2.coinmine.pl/lbc/index.php?page=api&action=getuserstatus&" +
            "api_key=b66bc1e2fd4ff7b0a7a3f88120918cef728a8dfcbbe6be71aab2d3690e764bd3&id=150981";
        private string requestString = "index.php?page=api&action={0}&api_key=" + API_KEY;
        private string requestWithIdString = "index.php?page=api&action={0}&api_key=" + API_KEY + "&id=" + ID;

        public CoinMineService()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://www2.coinmine.pl/lbc/")
            };

            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(APPLICATION_JSON));
        }

        public async Task<DateTime> GetTimeSinceLastBlockAsync()
        {
            // in seconds
            string methodRequest = string.Format(requestString, "gettimesincelastblock");

            var httpResponse = await httpClient.GetAsync(methodRequest);
            var response = await GetIntegrationResponseAsync<CoinResponse<LastTimeBlock>>(httpResponse);

            int seconds = response.gettimesincelastblock.data;
            DateTime lastBlockFound = seconds.ConvertToTime();
            TimeSpan hoursSinceLastBlockFound = lastBlockFound.TimeOfDay;
            var timeLastBlockFound = new TimeSpan(DateTime.Now.Ticks - hoursSinceLastBlockFound.Ticks);
            return new DateTime(timeLastBlockFound.Ticks);
        }

        public async Task<DateTime> GetEstimatedTimeToNextBlockAsync()
        {
            // in seconds
            string methodRequest = string.Format(requestString, "getestimatedtime");

            var httpResponse = await httpClient.GetAsync(methodRequest);
            var response = await GetIntegrationResponseAsync<CoinResponse<LastTimeBlock>>(httpResponse);

            int seconds = response.gettimesincelastblock.data;
            DateTime lastBlockFound = seconds.ConvertToTime();
            TimeSpan hoursSinceLastBlockFound = lastBlockFound.TimeOfDay;
            var timeLastBlockFound = new TimeSpan(DateTime.Now.Ticks - hoursSinceLastBlockFound.Ticks);
            return new DateTime(timeLastBlockFound.Ticks);
        }

        public async Task<Dashboard> GetDashboardDataAsync()
        {
            string methodRequest = string.Format(requestString, "getdashboarddata");
            var httpResponse = await httpClient.GetAsync(methodRequest);
            var response = await GetIntegrationResponseAsync<CoinResponse<Dashboard>>(httpResponse);

            return response.getdashboarddata;
        }

        public async Task<UserBalance> GetUserBalanceAsync()
        {
            string methodRequest = string.Format(requestWithIdString, "getuserbalance");
            var httpResponse = await httpClient.GetAsync(methodRequest);
            var response = await GetIntegrationResponseAsync<CoinResponse<UserBalance>>(httpResponse);

            return response.getuserbalance;
        }

        public async Task<UserHashrate> GetUserHashrate()
        {
            string methodRequest = string.Format(requestWithIdString, "getuserhashrate");
            var httpResponse = await httpClient.GetAsync(methodRequest);
            var response = await GetIntegrationResponseAsync<CoinResponse<UserHashrate>>(httpResponse);

            return response.getuserbalance;
        }

        public async Task<PoolStatus> GetPoolStatus()
        {
            string methodRequest = string.Format(requestString, "getpoolstatus");
            var httpResponse = await httpClient.GetAsync(methodRequest);
            var response = await GetIntegrationResponseAsync<CoinResponse<PoolStatus>>(httpResponse);

            return response.getpoolstatus;
        }

        public async Task<UserStatus> GetUserStatus()
        {
            string methodRequest = string.Format(requestWithIdString, "getuserstatus");
            var httpResponse = await httpClient.GetAsync(methodRequest);
            var response = await GetIntegrationResponseAsync<CoinResponse<UserStatus>>(httpResponse);

            return response.getpoolstatus;
        }

        private async Task<T> GetIntegrationResponseAsync<T>(HttpResponseMessage httpResponse)
        {
            T response = await JsonSerializer.DeserializeAsync<T>(await httpResponse.Content.ReadAsStreamAsync());
            return response;
        }
    }
}
