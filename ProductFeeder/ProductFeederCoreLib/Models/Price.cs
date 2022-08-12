using ProductFeederCoreLib.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductFeederCoreLib.Models
{
    public class Price : IModel
    {
        private int _id;
        private DateTime? _create;
        private DateTime? _delete;
        private bool _active=true;

        //todo: create model for list prices
        public int ListPrice { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime StartPriceDate { get; set; }
        public DateTime? EndPriceDate { get; set; }

        [ForeignKey("Products")]
        public int ProductId { set; get; }

        public int Id { get => _id; set => _id=value; }
        public DateTime? CreationDateTimeStamp { get => _create; set => _create=value; }
        public DateTime? DeletionDateTimeStamp { get => _delete; set => _delete=value; }
        public bool Active { get => _active; set => _active=value; }
    }
}
