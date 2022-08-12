using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Interfaces
{
    public interface IModel
    {
        public int Id { get; set; }
        public DateTime? CreationDateTimeStamp { get; set; }
        public DateTime? DeletionDateTimeStamp { get; set; }
        public bool Active { get; set; }

    }
}
