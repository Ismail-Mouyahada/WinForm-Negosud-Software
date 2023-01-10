using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeosudAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? OrderNumber { get; set;}
        public DateTime ExpectedDeliveryDate { get; set; }
        public DateTime TimePlaced { get; set; }
        public DateTime TimeCanceled { get; set; }
        public DateTime TimeDelivered { get; set; }
        public decimal OrderPrice { get; set; }

        public int SupplierId { get; set;}
        public int StoreId { get; set;}
        public int EmployeeId { get; set; }

        public Supplier? Supplier { get; set; }
        public Store? Store { get; set; }
        public Employee? Employee { get; set;}

        public List<OrderItem>? OrderItems { get; set; }



    }
}