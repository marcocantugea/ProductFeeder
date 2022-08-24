using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Models.DbConfiguration
{
    public class FeedDbConfig : IEntityTypeConfiguration<Feed>
    {
        public void Configure(EntityTypeBuilder<Feed> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.feedUid).IsRequired().HasMaxLength(32);
            builder.Property(prop => prop.file).IsRequired().HasMaxLength(150);
            builder.Property(prop => prop.processId).IsRequired();
            builder.Property(prop => prop.status).HasDefaultValue(0);

        }
    }
}
