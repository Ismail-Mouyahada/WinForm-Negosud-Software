using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

namespace NeosudAPI.Controllers;
public static class Inventorieservice
{

    static List<Inventory> Inventories { get; set; }
    static int nextId = 0;
    static Inventorieservice()
    {
        Inventories = new List<Inventory>
        {
            new Inventory {InventoryId = 1 },
            new Inventory {InventoryId = 2 },

        };
    }
    public static List<Inventory> GetAll() => Inventories;
    public static Inventory? Get(int id) => Inventories.FirstOrDefault(s => s.InventoryId == id);
    public static void Add(Inventory Inventory)
    {
        Inventory.InventoryId = nextId++;

        Inventories.Add(Inventory);
    }
    public static void Delete(int id)
    {

        var Inventory = Get(id);
        if (Inventory is null)
            return;

        Inventories.Remove(Inventory);

    }

    public static void Update(Inventory Inventory)
    {
        var Index = Inventories.FindIndex(s => s.InventoryId == Inventory.InventoryId);
        if (Index == -1)
            return;

        Inventories[Index] = Inventory;
    }
}