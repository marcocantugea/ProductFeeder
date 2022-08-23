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
        public string feedUid { get; set; }
        public string file { get; set; }

        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? CreationDateTimeStamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletionDateTimeStamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Active { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
