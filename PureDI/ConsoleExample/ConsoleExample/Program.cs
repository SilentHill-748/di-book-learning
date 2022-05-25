using ConsoleExample.Domain;
using ConsoleExample.Persistence;
using Microsoft.Extensions.Configuration;

string connectionString = LoadConnectionString();

CurrencyParser parser = CreateCurrencyParser(connectionString);

ICommand command = parser.Parse(new Currency("EUR"), 20.05m);

command.Execute();


static string LoadConnectionString()
{
    var configuration = new ConfigurationBuilder()
        .AddJsonStream(GetResourceStream())
        .Build();
    
    return configuration.GetConnectionString("CommerceConnection");
}

static Stream GetResourceStream()
{
    Stream? resourceStream = 
        typeof(Program).Assembly
            .GetManifestResourceStream("ConsoleExample.appsettings.json");

    if (resourceStream is null)
        throw new Exception("appsettings.json file is not found!");

    return resourceStream;
}


// Корень композиции всего приложения.
static CurrencyParser CreateCurrencyParser(string connectionString)
{
    IExcahngeRateProvider exchangeRateProvider =
        new SqlExchangeRateProvider(
            new CurrencyContext(connectionString));

    return new CurrencyParser(exchangeRateProvider);
}