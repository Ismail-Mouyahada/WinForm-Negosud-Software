using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

namespace NeosudAPI.Services;
public static class CustomerOrderService
{

    static List<CustomerOrder> CustomerOrders { get; set; }
    static int nextId = 0;
    static CustomerOrderService()
    {
        CustomerOrders = new List<CustomerOrder>
        {
            new CustomerOrder {CustomerOrderId = 1, CustomerId = 1 , StoreId = 1, OrderPrice = 1},
            new CustomerOrder {CustomerOrderId = 2, CustomerId = 1 , StoreId = 1, OrderPrice = 1 },

        };
    }
    public static List<CustomerOrder> GetAll() => CustomerOrders;
    public static CustomerOrder? Get(int id) => CustomerOrders.FirstOrDefault(s => s.CustomerOrderId == id);
    public static void Add(CustomerOrder CustomerOrder)
    {
        CustomerOrder.CustomerOrderId = nextId++;

        CustomerOrders.Add(CustomerOrder);
    }
    public static void Delete(int id)
    {

        var CustomerOrder = Get(id);
        if (CustomerOrder is null)
            return;

        CustomerOrders.Remove(CustomerOrder);

    }

    public static void Update(CustomerOrder CustomerOrder)
    {
        var Index = CustomerOrders.FindIndex(s => s.CustomerOrderId == CustomerOrder.CustomerOrderId);
        if (Index == -1)
            return;

        CustomerOrders[Index] = CustomerOrder;
    }
}