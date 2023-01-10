
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace NeosudAPI.Models
{
    public class Bottle
    {
        public int BottleId { get; set;}
        public string? FullName { get; set;}
        public string? Label { get; set;}
        public float Volume { get; set; }
        public int YearProduced { get; set; }
        public string? Picture { get; set; }
        public float AlchoholPercentage { get; set; }
        public float CurrentPrice { get; set; }

        public int ProducerId { get; set; }
        public int CategoryId { get; set; }
        public Producer? Producer { get; set; }
        public Category? Category { get; set; }

        public List<OrderItem>? OrderItems { get; set; }
        public List<CustomerOrderItem>? CustomerOrderItems { get; set; }
        public List<InvoiceItem>? InvoiceItems { get; set; }

        


    }
}