using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeosudAPI.Models;

namespace NeosudAPI.Controllers;

public static class RegionService
{
    static List<Region> Regions { get; set; }
    static int nextId = 0;
    static RegionService()
    {
        Regions = new List<Region>
        {
            new Region {RegionId = 1,  RegionName = "NeoSud" , CountryId = 1 },
            new Region {RegionId = 2,  RegionName = "PepoSeud",CountryId = 1 },

        };
    }
    public static List<Region> GetAll() => Regions;
    public static Region? Get(int id) => Regions.FirstOrDefault(s => s.RegionId == id);
    public static void Add(Region Region)
    {
        Region.RegionId = nextId++;
        Region.RegionName = "NeoSud";
        Region.CountryId = 1;
        Regions.Add(Region);
    }
    public static void Delete(int id){

        var Region = Get(id);
        if(Region is null)
        return ;

        Regions.Remove(Region);

    }

    public static void Update(Region Region){
        var Index = Regions.FindIndex(s => s.RegionId == Region.RegionId);
        if(Index == -1)
        return ;

        Regions[Index] = Region;
    }
}
