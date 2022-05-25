namespace ConsoleExample.Domain;

public class CurrencyParser
{
    private IExcahngeRateProvider _excahngeRateProvider;


    public CurrencyParser(IExcahngeRateProvider excahngeRateProvider)
    {
        ArgumentNullException.ThrowIfNull(excahngeRateProvider, nameof(excahngeRateProvider));

        _excahngeRateProvider = excahngeRateProvider;
    }


    public ICommand Parse(Currency currency, decimal rate)
    {
        return new UpdateCurrencyCommand(_excahngeRateProvider, currency, rate);
    }
}
