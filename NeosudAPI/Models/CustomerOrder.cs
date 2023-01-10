using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeosudAPI.Models
{
    public class CustomerOrder
    {
        public int CustomerOrderId { get; set; }
        public int OrderNumber { get; set; }
        public DateOnly ExpectedDeliveryDate { get; set; }
        public DateTime TimePlaced { get; set; }
        public DateTime TimeDue { get; set; }
        public DateTime TimeCancled { get; set; }
        public DateTime TimeDelivered { get; set; }
        public float OrderPrice { get; set; }

        public int StoreId { get; set; }
        public int CustomerId { get; set; }

        public Store? Store { get; set; }
        public Customer? Customer { get; set; }


        public List<CustomerOrderItem>? CustomerOrderItems { get; set; }
        public List<Invoice>? Invoices { get; set; }
        public List<Store>? Stores { get; set; }

    }
}