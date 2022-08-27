using CsvHelper.Configuration;
using ProductFeederRESTfulAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Mappers
{
    public class ProductDTOCsvMapper :ClassMap<ProductDTO>
    {
        public ProductDTOCsvMapper()
        {
            Map(prop => prop.sku).Name("sku");
            Map(prop => prop.shortDescription).Name("shortDescription");
            Map(prop => prop.longDescription).Name("longDescription");
            Map(prop => prop.brandId).Name("brandId");
            Map(prop => prop.conditionId).Name("conditionId").Optional();
            Map(prop => prop.shippingId).Name("shippingId").Optional();
        }
    }
}
