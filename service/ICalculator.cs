using System.ServiceModel;

[ServiceContract]
public interface ICalculatorService
{
    [OperationContract]
    int Add(int a, int b);
}