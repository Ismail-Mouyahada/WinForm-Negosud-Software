using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

namespace NeosudAPI.Controllers;
public static class OrderItemService
{

    static List<OrderItem> OrderItems { get; set; }
    static int nextId = 0;
    static OrderItemService()
    {
        OrderItems = new List<OrderItem>
        {
            new OrderItem {OrderItemId = 1 },
            new OrderItem {OrderItemId = 2 },

        };
    }
    public static List<OrderItem> GetAll() => OrderItems;
    public static OrderItem? Get(int id) => OrderItems.FirstOrDefault(s => s.OrderItemId == id);
    public static void Add(OrderItem OrderItem)
    {
        OrderItem.OrderItemId = nextId++;

        OrderItems.Add(OrderItem);
    }
    public static void Delete(int id)
    {

        var OrderItem = Get(id);
        if (OrderItem is null)
            return;

        OrderItems.Remove(OrderItem);

    }

    public static void Update(OrderItem OrderItem)
    {
        var Index = OrderItems.FindIndex(s => s.OrderItemId == OrderItem.OrderItemId);
        if (Index == -1)
            return;

        OrderItems[Index] = OrderItem;
    }
}