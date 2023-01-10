using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

namespace NeosudAPI.Services
{


    public static class BottleService
    {


        

        static List<Bottle> Bottles { get; set; }
        static int nextId = 0;
        static BottleService()
        {
            Bottles = new List<Bottle>
        {
            new Bottle {BottleId = 1, AlchoholPercentage = 5.6f , CurrentPrice=15.5f,FullName="Blanc de NeoSud",Picture="www.png.com",Label="Doux, Apero, Alcolisé",Volume=1 ,YearProduced=1995},
            new Bottle {BottleId = 2, AlchoholPercentage = 5.6f , CurrentPrice=15.5f,FullName="Blanc de NeoSud",Picture="www.png.com",Label="Doux, Apero, Alcolisé",Volume=1 ,YearProduced=1995},

        };
        }
        public static List<Bottle> GetAll() => Bottles;
        public static Bottle? Get(int id) => Bottles.FirstOrDefault(s => s.BottleId == id);
        public static void Add(Bottle Bottle)
        {
            Bottle.BottleId = nextId++;
            Bottle.CurrentPrice = nextId++ * 3;
            Bottle.AlchoholPercentage = nextId;
            Bottle.FullName = "Blanc de NeoSud";
            Bottle.Picture = "www.png.com";
            Bottle.Volume = 1;
            Bottle.YearProduced = 1995;

            Bottles.Add(Bottle);
        }
        public static void Delete(int id)
        {

            var Bottle = Get(id);
            if (Bottle is null)
                return;

            Bottles.Remove(Bottle);

        }

        public static void Update(Bottle Bottle)
        {
            var Index = Bottles.FindIndex(s => s.BottleId == Bottle.BottleId);
            if (Index == -1)
                return;

            Bottles[Index] = Bottle;
        }
    }

}