using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeosudAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password  { get; set; }
        public DateTime InsertTs { get; set; }
        public bool IsActive { get; set; }

        public List<Employee>? Employees { get; set; }
        public List<Invoice>? Invoices { get; set; }


    }
}