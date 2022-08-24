using ProductFeederCoreLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public string file { get; set; }
        public int processId { get; set; }
        public int status { get; set; }

        public int Id { get => _id; set => _id=value; }
        public DateTime? CreationDateTimeStamp { get => _dateCreated; set => _dateCreated=value; }
        public DateTime? DeletionDateTimeStamp { get => _dateDeleted; set => _dateDeleted=value; }
        public bool Active { get => _active; set => _active=value; }
    }
}
