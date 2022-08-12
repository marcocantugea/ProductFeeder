using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Models.DbConfiguration
{
    public class SuppliersDbConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(prop=> prop.Id);
            builder.Property(prop => prop.CreationDateTimeStamp).HasDefaultValueSql("current_timestamp");
            builder.Property(prop => prop.SupplierName).IsRequired().HasMaxLength(80);
            builder.Property(prop => prop.Prefix).HasMaxLength(3);
            builder.Property(prop => prop.RazonSocial).HasMaxLength(100);
            builder.Property(prop => prop.RFC).HasMaxLength(13);
            builder.Property(prop => prop.Email).HasMaxLength(50);
        }
    }
}
