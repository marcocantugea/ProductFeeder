using ProductFeederCoreLib.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public IEnumerable<Price>? Prices { get; set; }

        public int Id { get => _id; set => _id=value; }
        public DateTime? CreationDateTimeStamp { get => _created; set => _created=value; }
        public DateTime? DeletionDateTimeStamp { get => _deleted; set => _deleted=value; }
        public bool Active { get => _active; set => _active=true; }
    }
}
