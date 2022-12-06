using GiftShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiftShop.Persistence.Configurations
{
    public class UserTokensEntityTypeConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable("UserTokens");
            // Composite primary key consisting of the UserId, LoginProvider and Name
            builder.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            // Limit the size of the composite key columns due to common DB restrictions
            builder.Property(t => t.LoginProvider).HasMaxLength(128);
            builder.Property(t => t.Name).HasMaxLength(128);
        }
    }
}