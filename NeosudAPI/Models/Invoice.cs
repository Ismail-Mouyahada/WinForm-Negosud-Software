using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace NeosudAPI.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string? InvoiceNumber { get; set; }
        public decimal InvoiceTotal { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeDue { get; set; }
        public DateTime TimePaid { get; set; }
        public DateTime  InsertTs { get; set; }

        public int StoreId { get; set; }
        public int CustomerOrderId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }

        public Store? Store { get; set; }
        public CustomerOrder? CustomerOrder { get; set; }
        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }

        public List<InvoiceItem>? InvoiceItems { get; set; }



    }
}