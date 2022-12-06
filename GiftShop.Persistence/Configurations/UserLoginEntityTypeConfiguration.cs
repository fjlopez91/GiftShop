using GiftShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiftShop.Persistence.Configurations
{
    public class UserLoginEntityTypeConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable("UserLogin");
            builder.HasKey(x => new { x.LoginProvider, x.ProviderKey });

            // Limit the size of the composite key columns due to common DB restrictions
            builder.Property(x => x.LoginProvider).HasMaxLength(128);
            builder.Property(x => x.ProviderKey).HasMaxLength(128);
        }
    }
}