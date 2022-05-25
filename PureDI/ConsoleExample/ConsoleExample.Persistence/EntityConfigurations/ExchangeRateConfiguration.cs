using ConsoleExample.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleExample.Persistence.EntityConfigurations;
internal class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRate>
{
    public void Configure(EntityTypeBuilder<ExchangeRate> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.CurrencyCode).IsRequired();

        builder.HasIndex(x => x.CurrencyCode).IsUnique();

        builder.Property(x => x.Rate).IsRequired();

        builder.HasData(GetDataSeed());
    }

    private IEnumerable<ExchangeRate> GetDataSeed()
    {
        return new ExchangeRate[]
        {
            new ExchangeRate() { Id = Guid.NewGuid(), CurrencyCode = "USD", Rate = 0.94m },
            new ExchangeRate() { Id = Guid.NewGuid(), CurrencyCode = "EUR", Rate = 1.08m },
            new ExchangeRate() { Id = Guid.NewGuid(), CurrencyCode = "GBP", Rate = 0.58m }
        };
    }
}
