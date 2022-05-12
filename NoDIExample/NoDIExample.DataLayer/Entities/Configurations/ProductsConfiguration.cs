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
        }
    }
}
