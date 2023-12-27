using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

/// <summary>
/// Service contract for retrieving cryptocurrency rates.
/// </summary>
[ServiceContract]
public interface ICryptoRateService
{
    /// <summary>
    /// Retrieves the rate of a specific cryptocurrency.
    /// </summary>
    /// <param name="symbol">The symbol of the desired cryptocurrency.</param>
    /// <returns>A Task representing the asynchronous operation that returns a CryptoRateResponse object.</returns>
    [OperationContract]
    Task<CryptoRateResponse> GetCryptoRate(string symbol);

    /// <summary>
    /// Retrieves all cryptocurrency rates.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation that returns a list of CryptoRateResponse objects.</returns>
    [OperationContract]
    Task<List<CryptoRateResponse>> GetAllCryptoRates();
}

/// <summary>
/// Represents the response containing cryptocurrency rate information.
/// </summary>
[DataContract(Namespace = "http://localhost:5000")]
public class CryptoRateResponse
{
    /// <summary>
    /// Gets or sets the symbol of the cryptocurrency.
    /// </summary>
    [DataMember]
    public string Symbol { get; set; } = "";

    /// <summary>
    /// Gets or sets the price of the cryptocurrency.
    /// </summary>
    [DataMember]
    public decimal Price { get; set; }
}
