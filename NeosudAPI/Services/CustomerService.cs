using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

namespace NeosudAPI.Services;
public static class CustomerService
{

    static List<Customer> Customers { get; set; }
    static int nextId = 0;
    static CustomerService()
    {
        Customers = new List<Customer>
        {
            new Customer {CustomerId = 1,CustomerName="Ali baba",Address = " 13 rue saomé", Email = " ali@gmail.com",Username="Golasa",Password="53d4fs5f43sd5f" },
            new Customer {CustomerId = 2,CustomerName="Ali baba",Address = " 13 rue saomé", Email = " ali@gmail.com",Username="Golasa",Password="53d4fs5f43sd5f" },

        };
    }
    public static List<Customer> GetAll() => Customers;
    public static Customer? Get(int id) => Customers.FirstOrDefault(s => s.CustomerId == id);
    public static void Add(Customer Customer)
    {
        Customer.CustomerId = nextId++;

        Customers.Add(Customer);
    }
    public static void Delete(int id)
    {

        var Customer = Get(id);
        if (Customer is null)
            return;

        Customers.Remove(Customer);

    }

    public static void Update(Customer Customer)
    {
        var Index = Customers.FindIndex(s => s.CustomerId == Customer.CustomerId);
        if (Index == -1)
            return;

        Customers[Index] = Customer;
    }
}