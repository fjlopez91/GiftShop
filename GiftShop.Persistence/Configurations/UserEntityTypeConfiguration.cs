using GiftShop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiftShop.Persistence.Configurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.UserName)
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(e => e.NormalizedUserName)
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(e => e.Email)
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(e => e.NormalizedEmail)
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.FirstName)
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(e => e.LastName)
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(e => e.Status)
                .HasConversion<int>()
                .IsRequired();
            builder.Property(e => e.DateCreated)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(e => e.ConcurrencyStamp).IsConcurrencyToken();

            // Each User can have many UserClaims
            builder.HasMany(e => e.Claims)
                .WithOne(e => e.User)
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

            // Each User can have many UserLogins
            builder.HasMany(e => e.Logins)
                .WithOne(e => e.User)
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            // Each User can have many UserTokens
            builder.HasMany(e => e.Tokens)
                .WithOne(e => e.User)
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        }
    }
}