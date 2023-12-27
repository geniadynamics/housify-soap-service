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

            await Data.DataBase.CmdExecuteNonQueryAsync(
                $"INSERT INTO public.binance_data (symbol, price) " +
                $"VALUES ('{symbol}', {data.price})"
            );

            return new CryptoRateResponse
            {
                Symbol = symbol,
                Price = data.price
            };
        }
    }
    public async Task<List<CryptoRateResponse>> GetAllCryptoRates()
    {
        var cryptoRates = new List<CryptoRateResponse>();

        // Execute the query to get all rates from the database
        var queryResult = await Data.DataBase.CmdExecuteQueryAsync(
            $"SELECT symbol, price FROM public.binance_data");

        if (queryResult != null)
        {
            foreach (var row in queryResult)
            {
                var symbol = row[0]?.ToString() ?? string.Empty;
                var price = row[1] != null ? Convert.ToDecimal(row[1]) : 0;

                cryptoRates.Add(new CryptoRateResponse
                {
                    Symbol = symbol,
                    Price = price
                });
            }
        }

        return cryptoRates;
    }
}