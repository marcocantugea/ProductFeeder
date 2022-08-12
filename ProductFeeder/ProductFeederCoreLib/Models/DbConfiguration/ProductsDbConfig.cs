using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Models.DbConfiguration
{
    public class ProductsDbConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.CreationDateTimeStamp).HasDefaultValueSql("current_timestamp");
            builder.Property(prop => prop.sku).IsRequired().HasMaxLength(150);
            builder.Property(prop => prop.ShortDescription).IsRequired().HasMaxLength(50);
            builder.Property(prop => prop.LongDescription).HasMaxLength(255);

        }
    }
}
