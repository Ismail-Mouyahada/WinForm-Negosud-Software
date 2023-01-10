using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeosudAPI.Models
{
    public class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public int Quantity { get; set; }
        public decimal OrderPrice { get; set; }
        
        public int InvoiceId { get; set; }
        public int CustomerOrderId { get; set; }
        public int BottleId { get; set; }


        public Invoice? Invoice { get; set; }
        public CustomerOrder? CustomerOrder { get; set; }
        public Bottle? Bottle { get; set;}
    }
}