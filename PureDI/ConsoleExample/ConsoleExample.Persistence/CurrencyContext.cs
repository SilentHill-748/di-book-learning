using Microsoft.EntityFrameworkCore;

using ConsoleExample.Domain;

namespace ConsoleExample.Persistence
{
    public class CurrencyContext : DbContext
    {
        private readonly string _connectionString;


        public CurrencyContext(string connectionString)
        {
            ArgumentNullException.ThrowIfNull(connectionString, nameof(connectionString));

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("Connection string should be not empty!");

            _connectionString = connectionString;

            Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        public DbSet<ExchangeRate> ExchangeRates => Set<ExchangeRate>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CurrencyContext).Assembly);
        }
    }
}
