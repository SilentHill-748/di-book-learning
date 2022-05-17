using Microsoft.EntityFrameworkCore;

using DIExample.Domain.Entities;

namespace DIExample.Data
{
    public class CommerceContext : DbContext
    {
        private readonly string _connectionString;


        public CommerceContext(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException($"Parameter \'{nameof(connectionString)}\' was be null or empty!");

            this._connectionString = connectionString;
        }


        public DbSet<Product> Products => Set<Product>();



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
