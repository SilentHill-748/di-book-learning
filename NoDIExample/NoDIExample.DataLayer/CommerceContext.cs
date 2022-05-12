using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using NoDIExample.DataLayer.Entities;

namespace NoDIExample.DataLayer
{
    public class CommerceContext : DbContext
    {
        public DbSet<Products> Products => Set<Products>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("MSSQL");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
