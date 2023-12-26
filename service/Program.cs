using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.Services.AddSingleton<ICalculatorService, CalculatorService>();

var app = builder.Build();

app.UseRouting();

#pragma warning disable ASP0014
app.UseEndpoints(e =>
{
    e.UseSoapEndpoint<ICalculatorService>(
        "/CalculatorService.svc",
        new SoapEncoderOptions(),
        SoapSerializer.DataContractSerializer
    );
});
#pragma warning restore ASP0014

app.Run();