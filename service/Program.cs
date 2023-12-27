using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SoapCore;

/// <summary>
/// Main entry point for the SOAP service application.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

// Adds SoapCore for SOAP service support.
builder.Services.AddSoapCore();

// Registers the CryptoRateService implementation for the ICryptoRateService interface.
builder.Services.AddSingleton<ICryptoRateService, CryptoRateService>();

var app = builder.Build();

// Enables routing in the application.
app.UseRouting();

// Optionally loads variables from a .env file.
utils.EnvironmentVariablesLoader.Load(
    (Environment.GetEnvironmentVariable("SOAP_PROJ_ROOT") ?? "") + "/service/.env"
);

// Database initialization
await Data.DataBase.Init();

#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    // Configures a SOAP endpoint for the ICryptoRateService.
    endpoints.UseSoapEndpoint<ICryptoRateService>(
        "/CryptoRateService.svc",
        new SoapEncoderOptions(),
        SoapSerializer.DataContractSerializer
    );
});
#pragma warning restore ASP0014

// Starts the application.
app.Run();
