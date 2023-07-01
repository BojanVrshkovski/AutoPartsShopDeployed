
using AutoPartsShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShop.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand_PartName>().HasKey(am => new
            {
                am.BrandId,
                am.PartNameId
            });

            modelBuilder.Entity<Brand_PartName>().HasOne(m => m.PartName).WithMany(am => am.Brands_PartNames).HasForeignKey(m => m.PartNameId);

            modelBuilder.Entity<Brand_PartName>().HasOne(m => m.Brand).WithMany(am => am.Brands_PartNames).HasForeignKey(m => m.BrandId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<PartName> PartNames { get; set; }
        public DbSet<Brand_PartName> Brands_PartNames { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Producer> Producers { get; set; }

        //Orders related tables

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> shoppingCartItems { get; set; }
    }
}
