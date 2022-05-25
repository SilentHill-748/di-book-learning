namespace ConsoleExample.Domain
{
    public class UpdateCurrencyCommand : ICommand
    {
        private readonly IExcahngeRateProvider _exchangeRateProvider;
        private readonly Currency _currency;
        private readonly decimal _rate;


        public UpdateCurrencyCommand(IExcahngeRateProvider excahngeRateProvider, Currency currency, decimal rate)
        {
            ArgumentNullException.ThrowIfNull(excahngeRateProvider, nameof(excahngeRateProvider));
            ArgumentNullException.ThrowIfNull(currency, nameof(currency));

            _exchangeRateProvider = excahngeRateProvider;
            _currency = currency;
            _rate = rate;
        }


        public void Execute()
        {
            string defaultCurrencyCode = Currency.DollarCurrency.Code;

            decimal currentRate = GetCurrencyRate(_currency);

            Console.WriteLine($"Old: {currentRate:F4} {_currency.Code} = 1 {defaultCurrencyCode}.");

            _exchangeRateProvider.ExchangeRate(_currency, _rate);

            Console.WriteLine($"Updated: {_rate:F4} {_currency.Code} = 1 {defaultCurrencyCode}.");
        }

        private decimal GetCurrencyRate(Currency currency)
        {
            var rates = _exchangeRateProvider.GetExcangeRatesFor(Currency.DollarCurrency);

            return rates[currency];
        }
    }
}
