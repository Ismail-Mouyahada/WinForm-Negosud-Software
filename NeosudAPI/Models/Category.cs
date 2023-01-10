using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeosudAPI.Models
{
    public class Category
    {
        public int CategoryId { get; set;}
        public string? CategoryName { get; set;}
 
        public List<Bottle>? Bottles { get; set;}

        public static implicit operator Category(int v)
        {
            throw new NotImplementedException();
        }
    }
}