using System.Collections.ObjectModel;

namespace ConsoleExample.Domain
{
    public interface IExcahngeRateProvider
    {
        ReadOnlyDictionary<Currency, decimal> GetExcangeRatesFor(Currency currency);

        void ExchangeRate(Currency currency, decimal rate);
    }
}
