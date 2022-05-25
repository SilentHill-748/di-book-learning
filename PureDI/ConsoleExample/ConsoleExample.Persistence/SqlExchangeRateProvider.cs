using System.Collections.ObjectModel;

using ConsoleExample.Domain;

namespace ConsoleExample.Persistence
{
    public class SqlExchangeRateProvider : IExcahngeRateProvider
    {
        private readonly CurrencyContext _context;


        public SqlExchangeRateProvider(CurrencyContext currencyContext)
        {
            ArgumentNullException.ThrowIfNull(currencyContext, nameof(currencyContext));

            _context = currencyContext;
        }


        public void ExchangeRate(Currency currency, decimal rate)
        {
            ArgumentNullException.ThrowIfNull(currency, nameof(currency));

            ExchangeRate targetCurrency = 
                _context.ExchangeRates.Single(cur => cur.CurrencyCode.Equals(currency.Code));

            targetCurrency.Rate = rate;

            _context.SaveChanges();
        }

        public ReadOnlyDictionary<Currency, decimal> GetExcangeRatesFor(Currency currency)
        {
            ArgumentNullException.ThrowIfNull(currency);

            var rates = _context.ExchangeRates;

            var rate = rates.Single(excRate => excRate.CurrencyCode.Equals(currency.Code));

            var dictionary = 
                rates.ToDictionary(
                    key => new Currency(key.CurrencyCode), 
                    r => r.Rate / rate.Rate);

            return new ReadOnlyDictionary<Currency, decimal>(dictionary);
        }
    }
}
