using ProductFeederCoreLib.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Models
{
    public class Product : IModel
    {
        private int _id;
        private DateTime? _created;
        private DateTime? _deleted;
        private bool _active = true;

        public string sku{ get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? ProductCode { get; set; }
        
        public decimal? BaseCost { get; set; }

        public decimal? unitPrice { get; set; }
        public bool Warranty { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? EAN { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? UPC { get; set; }

        [ForeignKey("Condition")]
        public int? ConditionId;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Condition? Condition { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [ForeignKey("Shipping")]
        public int? ShippingId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Shipping? Shipping { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<Price>? Prices { get; set; }

        public int Id { get => _id; set => _id=value; }
        public DateTime? CreationDateTimeStamp { get => _created; set => _created=value; }

        [JsonIgnore]
        public DateTime? DeletionDateTimeStamp { get => _deleted; set => _deleted=value; }
        [JsonIgnore]
        public bool Active { get => _active; set => _active=true; }
    }
}
