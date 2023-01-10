using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeosudAPI.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public decimal OrderPrice { get; set;}

        public int OrderId { get; set; }
        public int BottleId { get; set;}

        public Order? Order { get; set; }
        public Bottle? Bottle { get; set; }
    }
}