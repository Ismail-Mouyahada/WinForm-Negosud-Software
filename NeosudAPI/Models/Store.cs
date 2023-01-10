using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeosudAPI.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string? StoreName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        public string? Details { get; set; }

        public int CityId { get; set; }
        public City? City { get; set; }

        public List<Order>? Orders { get; set; }
        public List<CustomerOrder>? CustomerOrders { get; set; }
        public List<Inventory>? Inventories { get; set; }
        public List<Invoice>? Invoices { get; set; }


    }
}