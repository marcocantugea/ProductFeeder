using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductFeederRESTfulAPI.DTO
{
    public class ProductDTO
    {
        public string sku { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public int brandId { get; set; }

        [JsonIgnore(Condition=JsonIgnoreCondition.WhenWritingDefault)]
        public int? conditionId { get; set; } = 1;
    }
}
