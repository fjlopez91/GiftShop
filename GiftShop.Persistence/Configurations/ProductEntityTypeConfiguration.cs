using GiftShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiftShop.Persistence.Configurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Description)
                .HasMaxLength(100);            
            builder.Property(x => x.Company)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Price)
                .HasPrecision(18, 2)
                .IsRequired();

            // Each Product can have many Photos
            builder.HasMany(x => x.Photos)
                .WithOne(x => x.Product)
                .HasForeignKey(p => p.ProductId);
        }
    }
}