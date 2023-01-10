using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeosudAPI.Models
{
    public class Region
    {
        public int RegionId { get; set; }
        public string? RegionName { get; set;}
        
        public int CountryId { get; set; }
        public Country? Country { get; set; }

    }
}