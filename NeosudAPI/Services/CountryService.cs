using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

namespace NeosudAPI.Services;
public static class CountryService
{

    static List<Country> Countrys { get; set; }
    static int nextId = 0;
    static CountryService()
    {
        Countrys = new List<Country>
        {
            new Country {CountryId = 1, CountryName ="France" },
            new Country {CountryId = 2, CountryName ="USA" },

        };
    }
    public static List<Country> GetAll() => Countrys;
    public static Country? Get(int id) => Countrys.FirstOrDefault(s => s.CountryId == id);
    public static void Add(Country Country)
    {
        Country.CountryId = nextId++;
        Country.CountryName = Country.CountryName;

        Countrys.Add(Country);
    }
    public static void Delete(int id)
    {

        var Country = Get(id);
        if (Country is null)
            return;

        Countrys.Remove(Country);

    }

    public static void Update(Country Country)
    {
        var Index = Countrys.FindIndex(s => s.CountryId == Country.CountryId);
        if (Index == -1)
            return;

        Countrys[Index] = Country;
    }
}