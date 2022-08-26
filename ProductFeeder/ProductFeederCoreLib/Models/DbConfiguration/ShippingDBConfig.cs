using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Models.DbConfiguration
{
    public class ShippingDBConfig : IEntityTypeConfiguration<Shipping>
    {
        public void Configure(EntityTypeBuilder<Shipping> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.ShippingName).IsRequired().HasMaxLength(50);
            builder.HasData(PopulateShipping());
        }

        private IEnumerable<Shipping> PopulateShipping()
        {
            List<Shipping> shippingList = new List<Shipping>();
            shippingList.Add(new Shipping() { 
                Id=1,
                ShippingName="SHIPPING",
                CreationDateTimeStamp=DateTime.Now,
                Active=true
            });

            shippingList.Add(new Shipping()
            {
                Id = 2,
                ShippingName = "ONREQUEST",
                CreationDateTimeStamp = DateTime.Now,
                Active = true
            });

            return shippingList;
        }
    }
}
