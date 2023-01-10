using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

namespace NeosudAPI.Controllers;
public static class ProducerService
{
    static List<Producer> Producers { get; set; }
    static int nextId = 0;
    static ProducerService()
    {
        Producers = new List<Producer>
        {
            new Producer {ProducerId = 1,  ProducerName = "NeoSud", Details="Un fournisseur fiable et très recommandé, capacité de retro-stockage." ,RegionId = 1 },
            new Producer {ProducerId = 2,  ProducerName = "PepoSeud", Details="Un fournisseur fiable et très recommandé, capacité de retro-stockage." ,RegionId = 1 },

        };
    }
    public static List<Producer> GetAll() => Producers;
    public static Producer? Get(int id) => Producers.FirstOrDefault(s => s.ProducerId == id);
    public static void Add(Producer Producer)
    {
        Producer.ProducerId = nextId++;
        Producer.ProducerName = "NeoSud";
        Producer.Details = "Un fournisseur fiable et trèsrecommand";
        Producers.Add(Producer);
    }
    public static void Delete(int id){

        var Producer = Get(id);
        if(Producer is null)
        return ;

        Producers.Remove(Producer);

    }

    public static void Update(Producer Producer){
        var Index = Producers.FindIndex(s => s.ProducerId == Producer.ProducerId);
        if(Index == -1)
        return ;

        Producers[Index] = Producer;
    }
}
