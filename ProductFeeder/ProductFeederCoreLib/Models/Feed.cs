using ProductFeederCoreLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Models
{
    public class Feed : IModel
    {
        private int _id;
        private DateTime? _dateCreated;
        private DateTime? _dateDeleted;
        private bool _active = true;

        public string feedUid { get; set; }

        [JsonIgnore]
        public string file { get; set; }

        [JsonIgnore]
        public int processId { get; set; }
        public int status { get; set; }

        [JsonIgnore]
        public int Id { get => _id; set => _id=value; }
        public DateTime? CreationDateTimeStamp { get => _dateCreated; set => _dateCreated=value; }

        [JsonIgnore]
        public DateTime? DeletionDateTimeStamp { get => _dateDeleted; set => _dateDeleted=value; }

        [JsonIgnore]
        public bool Active { get => _active; set => _active=value; }
    }
}
