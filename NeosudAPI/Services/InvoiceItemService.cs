using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

namespace NeosudAPI.Controllers;
public static class InvoiceItemService
{

    static List<InvoiceItem> InvoiceItems { get; set; }
    static int nextId = 0;
    static InvoiceItemService()
    {
        InvoiceItems = new List<InvoiceItem>
        {
            new InvoiceItem {InvoiceItemId = 1 },
            new InvoiceItem {InvoiceItemId = 2 },

        };
    }
    public static List<InvoiceItem> GetAll() => InvoiceItems;
    public static InvoiceItem? Get(int id) => InvoiceItems.FirstOrDefault(s => s.InvoiceItemId == id);
    public static void Add(InvoiceItem InvoiceItem)
    {
        InvoiceItem.InvoiceItemId = nextId++;

        InvoiceItems.Add(InvoiceItem);
    }
    public static void Delete(int id)
    {

        var InvoiceItem = Get(id);
        if (InvoiceItem is null)
            return;

        InvoiceItems.Remove(InvoiceItem);

    }

    public static void Update(InvoiceItem InvoiceItem)
    {
        var Index = InvoiceItems.FindIndex(s => s.InvoiceItemId == InvoiceItem.InvoiceItemId);
        if (Index == -1)
            return;

        InvoiceItems[Index] = InvoiceItem;
    }
}