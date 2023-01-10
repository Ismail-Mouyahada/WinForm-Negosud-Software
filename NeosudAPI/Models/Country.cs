using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeosudAPI.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string? CountryName { get; set; }

        public List<Bottle>? Bottles { get; set; }
        public List<Store>? Stores { get; set;}
        public List<City>? Cities { get; set; }
 
    }
}