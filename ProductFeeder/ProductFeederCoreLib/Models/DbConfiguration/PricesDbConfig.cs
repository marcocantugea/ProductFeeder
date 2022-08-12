using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Models.DbConfiguration
{
    public class PricesDbConfig : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.CreationDateTimeStamp).HasDefaultValueSql("current_timestamp");
            builder.Property(prop => prop.ListPrice).IsRequired();
            builder.Property(prop => prop.ProductPrice).IsRequired();
            builder.Property(prop => prop.StartPriceDate).IsRequired();
        }
    }
}
