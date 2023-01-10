using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeosudAPI.Models
{
    public class CustomerOrderItem
    {
        public int CustomerOrderItemId { get; set; }
        public decimal OrderPrice { get; set; }
        public int Quantity { get; set; }

        public int BottleId { get; set; }
        public int CustomerOrderId { get; set; }

        public Bottle? Bottle { get; set; }
        public CustomerOrder? CustomerOrder { get; set; }
    }
}