using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

namespace NeosudAPI.Controllers;
public static class OrderService
{

    static List<Order> Orders { get; set; }
    static int nextId = 0;
    static OrderService()
    {
        Orders = new List<Order>
        {
            new Order {OrderId = 1,ExpectedDeliveryDate= DateTime.Now, OrderNumber = "1", OrderPrice = 1, TimeCanceled = DateTime.Now, TimeDelivered = DateTime.Now, TimePlaced = DateTime.Now },
            new Order {OrderId = 2,ExpectedDeliveryDate= DateTime.Now, OrderNumber = "1", OrderPrice = 1, TimeCanceled = DateTime.Now, TimeDelivered = DateTime.Now, TimePlaced = DateTime.Now  },

        };
    }
    public static List<Order> GetAll() => Orders;
    public static Order? Get(int id) => Orders.FirstOrDefault(s => s.OrderId == id);
    public static void Add(Order Order)
    {
        Order.OrderId = nextId++;

        Orders.Add(Order);
    }
    public static void Delete(int id)
    {

        var Order = Get(id);
        if (Order is null)
            return;

        Orders.Remove(Order);

    }

    public static void Update(Order Order)
    {
        var Index = Orders.FindIndex(s => s.OrderId == Order.OrderId);
        if (Index == -1)
            return;

        Orders[Index] = Order;
    }
}