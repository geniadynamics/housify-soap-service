using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();

builder.Services.AddSingleton<ICryptoRateService, CryptoRateService>();

var app = builder.Build();

app.UseRouting();

// Database initialization
await Data.DataBase.Init();

#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<ICryptoRateService>(
        "/CryptoRateService.svc",
        new SoapEncoderOptions(),
        SoapSerializer.DataContractSerializer
    );
});
#pragma warning restore ASP0014

app.Run();