using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

/// <summary>
/// Service class for retrieving cryptocurrency rates from the Binance API and interacting with a database.
/// </summary>
public class CryptoRateService : ICryptoRateService
{
    // Base URL for the Binance API to obtain cryptocurrency rate information.
    private const string BinanceApiBaseUrl = "https://api.binance.com/api/v3/ticker/price?symbol=";

    /// <summary>
    /// Retrieves the rate of a specific cryptocurrency from the Binance API and stores it in the database.
    /// </summary>
    /// <param name="symbol">The symbol of the desired cryptocurrency.</param>
    /// <returns>A CryptoRateResponse object containing the symbol and price of the cryptocurrency.</returns>
    public async Task<CryptoRateResponse> GetCryptoRate(string symbol)
    {
        // Creates an instance of HttpClient to make the call to the Binance API.
        using (var httpClient = new HttpClient())
        {
            // Gets the API response in JSON format.
            var response = await httpClient.GetStringAsync(BinanceApiBaseUrl + symbol);

            // Deserializes the JSON response into a dynamic object.
            var data = JsonConvert.DeserializeObject<dynamic>(response);

            // Inserts the information into the database.
            await Data.DataBase.CmdExecuteNonQueryAsync(
                $"INSERT INTO public.binance_data (symbol, price) " +
                $"VALUES ('{symbol}', {data.price})"
            );

            // Returns a CryptoRateResponse object with the symbol and price.
            return new CryptoRateResponse
            {
                Symbol = symbol,
                Price = data.price
            };
        }
    }

    /// <summary>
    /// Retrieves all cryptocurrency rates stored in the database.
    /// </summary>
    /// <returns>A list of CryptoRateResponse objects containing symbols and prices of all stored cryptocurrencies.</returns>
    public async Task<List<CryptoRateResponse>> GetAllCryptoRates()
    {
        var cryptoRates = new List<CryptoRateResponse>();

        // Executes the query to obtain all rates from the database.
        var queryResult = await Data.DataBase.CmdExecuteQueryAsync(
            $"SELECT symbol, price FROM public.binance_data");

        // If there are query results, iterates over each row and adds it to the list.
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

        // Returns the list of cryptocurrency rates.
        return cryptoRates;
    }
}
