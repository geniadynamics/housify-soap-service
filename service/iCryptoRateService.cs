using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;
    

[ServiceContract]
public interface ICryptoRateService
{
    [OperationContract]
    Task<CryptoRateResponse> GetCryptoRate(string symbol);
}

[DataContract(Namespace = "http://localhost:5262")]
public class CryptoRateResponse
{
    [DataMember]
    public string Symbol { get; set; } = "";

    [DataMember]
    public decimal Price { get; set; }
}