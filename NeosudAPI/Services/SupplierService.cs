using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

namespace NeosudAPI.Controllers;

public static class SupplierService
{
    static List<Supplier> Suppliers { get; set; }
    static int nextId = 0;
    static SupplierService()
    {
        Suppliers = new List<Supplier>
        {
            new Supplier {SupplierId = 1,  SupplierName = "NeoSud", Address="12 rue des paillette", Phone = "+33784075061", Mobile ="+33684571546", Email = "contact@neosud.fr",Details="Un fournisseur fiable et très recommandé, capacité de retro-stockage." },
            new Supplier {SupplierId = 2,  SupplierName = "PepoSeud",  Address="12 rue des Goulois", Phone = "+33954852061", Mobile ="+3351131546", Email = "contact@peposud.fr",Details="Un fournisseur fiable et très recommandé, capacité de retro-stockage." },

        };
    }
    public static List<Supplier> GetAll() => Suppliers;
    public static Supplier? Get(int id) => Suppliers.FirstOrDefault(s => s.SupplierId == id);
    public static void Add(Supplier Supplier)
    {
        Supplier.SupplierId = nextId++;
        Supplier.SupplierName = "NeoSud";
        Supplier.Address = "12 rue des paillette";
        Supplier.Phone = "+33784075061";
        Supplier.Mobile = "+33684571546";
        Supplier.Email = "contact@neosud.fr";
        Supplier.Details = "Un fournisseur fiable et trèsrecommand";
        Suppliers.Add(Supplier);
    }
    public static void Delete(int id){

        var Supplier = Get(id);
        if(Supplier is null)
        return ;

        Suppliers.Remove(Supplier);

    }

    public static void Update(Supplier Supplier){
        var Index = Suppliers.FindIndex(s => s.SupplierId == Supplier.SupplierId);
        if(Index == -1)
        return ;

        Suppliers[Index] = Supplier;
    }
}
