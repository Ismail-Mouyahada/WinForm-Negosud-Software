using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

public static class CityService
{

    static List<City> Citys { get; set; }
    static int nextId = 0;
    static CityService()
    {
        Citys = new List<City>
        {
            new City {CityId = 1, PostlCode="1212" },
            new City {CityId = 2, PostlCode="1212" },

        };
    }
    public static List<City> GetAll() => Citys;
    public static City? Get(int id) => Citys.FirstOrDefault(s => s.CityId == id);
    public static void Add(City City)
    {
        City.CityId = nextId++;
        City.PostlCode = "1212";
        Citys.Add(City);
    }
    public static void Delete(int id)
    {

        var City = Get(id);
        if (City is null)
            return;

        Citys.Remove(City);

    }

    public static void Update(City City)
    {
        var Index = Citys.FindIndex(s => s.CityId == City.CityId);
        if (Index == -1)
            return;

        Citys[Index] = City;
    }
}