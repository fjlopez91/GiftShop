﻿using GiftShop.Domain.Entities;
using GiftShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GiftShop.Persistence.Contexts
{
    public class MyAppDbContext : IdentityDbContext<User, Role, Guid,
        UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Photo> Photos => Set<Photo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyAppDbContext).Assembly);
        }
    }
}