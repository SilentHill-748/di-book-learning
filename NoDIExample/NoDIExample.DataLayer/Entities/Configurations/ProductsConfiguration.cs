using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoDIExample.DataLayer.Entities.Configurations
{
    internal class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(x => x.Description)
                .IsRequired();
            builder
                .Property(x => x.UnitPrice)
                .HasColumnType("money")
                .IsRequired();
            builder
                .Property(x => x.IsFeatured)
                .HasColumnType("bit")
                .IsRequired();
            builder
                .HasData(GetBaseProducts());
        }

        public List<Products> GetBaseProducts()
        {
            return new List<Products>()
            {
                new Products()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 1",
                    Description = "This is product 1",
                    UnitPrice = 5000,
                    IsFeatured = true
                },
                new Products()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 2",
                    Description = "This is product 2",
                    UnitPrice = 3000,
                    IsFeatured = true
                },
                new Products()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 3",
                    Description = "This is product 3",
                    UnitPrice = 2500,
                    IsFeatured = false
                },
                new Products()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 4",
                    Description = "This is product 4",
                    UnitPrice = 7500,
                    IsFeatured = true
                },
            };
        }
    }
}
