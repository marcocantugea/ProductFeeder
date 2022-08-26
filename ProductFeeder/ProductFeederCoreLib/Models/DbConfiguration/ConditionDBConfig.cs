using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Models.DbConfiguration
{
    public class ConditionDBConfig : IEntityTypeConfiguration<Condition>
    {
        public void Configure(EntityTypeBuilder<Condition> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.conditionDescription).IsRequired().HasMaxLength(50);
            builder.Property(prop => prop.CreationDateTimeStamp).HasDefaultValueSql("current_timestamp");
            builder.HasData(PopulateInitialData());
        }

        private IEnumerable<Condition> PopulateInitialData()
        {
            List<Condition> conditions = new List<Condition>();
            conditions.Add(new Condition()
            {
                Id=1,
                CreationDateTimeStamp=DateTime.Now,
                Active=true,
                conditionDescription="NEW"
            });

            conditions.Add(new Condition()
            {
                Id = 2,
                CreationDateTimeStamp = DateTime.Now,
                Active = true,
                conditionDescription = "REFURBISH"
            });

            return conditions;
        }
    }
}
