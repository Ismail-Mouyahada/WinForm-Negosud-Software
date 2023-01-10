using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

namespace NeosudAPI.Controllers;
public static class InvoiceService
{

    static List<Invoice> Invoices { get; set; }
    static int nextId = 0;
    static InvoiceService()
    {
        Invoices = new List<Invoice>
        {
            new Invoice {InvoiceId = 1 },
            new Invoice {InvoiceId = 2 },

        };
    }
    public static List<Invoice> GetAll() => Invoices;
    public static Invoice? Get(int id) => Invoices.FirstOrDefault(s => s.InvoiceId == id);
    public static void Add(Invoice Invoice)
    {
        Invoice.InvoiceId = nextId++;

        Invoices.Add(Invoice);
    }
    public static void Delete(int id)
    {

        var Invoice = Get(id);
        if (Invoice is null)
            return;

        Invoices.Remove(Invoice);

    }

    public static void Update(Invoice Invoice)
    {
        var Index = Invoices.FindIndex(s => s.InvoiceId == Invoice.InvoiceId);
        if (Index == -1)
            return;

        Invoices[Index] = Invoice;
    }
}