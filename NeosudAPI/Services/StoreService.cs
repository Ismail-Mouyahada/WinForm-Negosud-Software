using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

namespace NeosudAPI.Controllers;

public static class StoreService
{
    static List<Store> Stores { get; set; }
    static int nextId = 0;
    static StoreService()
    {
        Stores = new List<Store>
        {
            new Store {StoreId = 1,  StoreName = "NeoSud", Address="12 rue des paillette", Phone = "+33784075061", Mobile ="+33684571546", Email = "contact@neosud.fr",Details="Un fournisseur fiable et très recommandé, capacité de retro-stockage." },
            new Store {StoreId = 2,  StoreName = "PepoSeud",  Address="12 rue des Goulois", Phone = "+33954852061", Mobile ="+3351131546", Email = "contact@peposud.fr",Details="Un fournisseur fiable et très recommandé, capacité de retro-stockage." },

        };
    }
    public static List<Store> GetAll() => Stores;
    public static Store? Get(int id) => Stores.FirstOrDefault(s => s.StoreId == id);
    public static void Add(Store Store)
    {
        Store.StoreId = nextId++;
        Store.StoreName = "NeoSud";
        Store.Address = "12 rue des paillette";
        Store.Phone = "+33784075061";
        Store.Mobile = "+33684571546";
        Store.Email = "contact@neosud.fr";
        Store.Details = "Un fournisseur fiable et trèsrecommand";
        Stores.Add(Store);
    }
    public static void Delete(int id){

        var Store = Get(id);
        if(Store is null)
        return ;

        Stores.Remove(Store);

    }

    public static void Update(Store Store){
        var Index = Stores.FindIndex(s => s.StoreId == Store.StoreId);
        if(Index == -1)
        return ;

        Stores[Index] = Store;
    }
}
