using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeosudAPI.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Details { get; set; }

        public List<Order>? Orders { get; set; }

        public static implicit operator Supplier(int v)
        {
            throw new NotImplementedException();
        }
    }
}