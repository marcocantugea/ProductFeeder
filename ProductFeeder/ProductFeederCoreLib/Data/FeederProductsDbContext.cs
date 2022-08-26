using Microsoft.EntityFrameworkCore;
using ProductFeederCoreLib.Models;
using ProductFeederCoreLib.Models.DbConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Data
{
    public class FeederProductsDbContext : DbContext
    {
        public FeederProductsDbContext(DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SuppliersDbConfig());
            builder.ApplyConfiguration(new BrandDbConfig());
            builder.ApplyConfiguration(new ProductsDbConfig());
            builder.ApplyConfiguration(new PricesDbConfig());
            builder.ApplyConfiguration(new ConditionDBConfig());
            builder.ApplyConfiguration(new ShippingDBConfig());
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Price> Prices { get; set; }

        public DbSet<Feed> Feeds { get; set; }

        public DbSet<Condition> Conditions { get; set; }

        public DbSet<Shipping> Shippings { get; set; }


    }
}
