using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeosudAPI.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Details { get; set; }
        public string? ConfirmationCode { get; set; }
        public DateTime ConfirmationTime { get; set; }
        public DateTime InsertTs { get; set; }

        public int StoreId { get; set; }
        public int CustomerOrderId { get; set; }
        public int EmployeeId { get; set; }
        public Store? Store { get; set; }
        public CustomerOrder? CustomerOrder { get; set; }
        public Employee? Employee { get; set; }

        public List<CustomerOrder>? CustomerOrders { get; set; }
        public List<Invoice>? Invoices { get; set; }
    }
}