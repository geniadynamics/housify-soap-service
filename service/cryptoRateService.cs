    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class CryptoRateService : ICryptoRateService
    {
        private const string BinanceApiBaseUrl =
            "https://api.binance.com/api/v3/ticker/price?symbol=";

        public async Task<CryptoRateResponse> GetCryptoRate(string symbol)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(
                    BinanceApiBaseUrl + symbol
                );
                var data = JsonConvert.DeserializeObject<dynamic>(response);
                return new CryptoRateResponse
                {
                    Symbol = symbol,
                    Price = data.price
                };
            }
        }
    }