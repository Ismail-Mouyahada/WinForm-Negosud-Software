using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

namespace NeosudAPI.Services;
public static class CustomerOrderItemService
{

    static List<CustomerOrderItem> CustomerOrderItems { get; set; }
    static int nextId = 0;
    static CustomerOrderItemService()
    {
        CustomerOrderItems = new List<CustomerOrderItem>
        {
            new CustomerOrderItem {CustomerOrderItemId = 1,Quantity=54,OrderPrice = 12.5M,CustomerOrderId   = 1, BottleId = 1  },
            new CustomerOrderItem {CustomerOrderItemId = 2,Quantity=54,OrderPrice = 12.5M,CustomerOrderId   = 1, BottleId = 1  },

        };
    }
    public static List<CustomerOrderItem> GetAll() => CustomerOrderItems;
    public static CustomerOrderItem? Get(int id) => CustomerOrderItems.FirstOrDefault(s => s.CustomerOrderItemId == id);
    public static void Add(CustomerOrderItem CustomerOrderItem)
    {
        CustomerOrderItem.CustomerOrderItemId = nextId++;

        CustomerOrderItems.Add(CustomerOrderItem);
    }
    public static void Delete(int id)
    {

        var CustomerOrderItem = Get(id);
        if (CustomerOrderItem is null)
            return;

        CustomerOrderItems.Remove(CustomerOrderItem);

    }

    public static void Update(CustomerOrderItem CustomerOrderItem)
    {
        var Index = CustomerOrderItems.FindIndex(s => s.CustomerOrderItemId == CustomerOrderItem.CustomerOrderItemId);
        if (Index == -1)
            return;

        CustomerOrderItems[Index] = CustomerOrderItem;
    }
}