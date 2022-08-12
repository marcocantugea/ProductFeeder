using ProductFeederCoreLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Models
{
    public class Supplier : IModel
    {
        private int _id;
        private DateTime? _created;
        private DateTime? _deleted;
        private bool _active = true;

        public string SupplierName { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Prefix { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RazonSocial { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RFC { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Email { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<Brand>? brands { get; set; }

        public int Id { get => _id; set => _id=value; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? CreationDateTimeStamp { get => _created; set => _created = value; }

        [JsonIgnore]
        public DateTime? DeletionDateTimeStamp { get => _deleted; set => _deleted = value; }
        [JsonIgnore]
        public bool Active { get =>_active; set => _active=value; }
    }
}
