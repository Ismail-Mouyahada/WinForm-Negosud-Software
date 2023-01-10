using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeosudAPI.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string? PostlCode { get; set; }

        public int CountryId { get; set; }

        public Country? Country { get; set; }
        
        public List<Order>? Orders { get; set; }


    }
}