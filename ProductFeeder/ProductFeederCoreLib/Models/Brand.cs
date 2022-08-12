using ProductFeederCoreLib.Interfaces;
using ProductFeederRESTfulAPI.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Models
{
    public class Brand : IModel
    {
        private int _id;
        private DateTime? _created;
        private DateTime? _deleted;
        private bool _active = true;
        public string Name { get; set; }
        public string? Prefix { get; set; }

        [ForeignKey("Suppliers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int SupplierId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Supplier? Supplier { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<Product>? products { get; set; }

        public int Id { get => _id; set => _id=value; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? CreationDateTimeStamp { get => _created; set => _created=value; }
        [JsonIgnore]
        public DateTime? DeletionDateTimeStamp { get => _deleted; set => _deleted=value; }
        [JsonIgnore]
        public bool Active { get => _active; set => _active=value; }
    }
}
