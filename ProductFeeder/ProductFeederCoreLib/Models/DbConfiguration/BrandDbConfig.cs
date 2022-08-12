using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Models.DbConfiguration
{
    public class BrandDbConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.CreationDateTimeStamp).HasDefaultValueSql("current_timestamp");
            builder.Property(prop => prop.Name).IsRequired().HasMaxLength(50);
            builder.Property(prop => prop.Prefix).HasMaxLength(3);

        }
    }
}
