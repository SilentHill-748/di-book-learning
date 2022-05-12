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
            string res = Directory.GetCurrentDirectory();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("MSSQL");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
