using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeosudAPI.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int StoreId { get; set; }
        public int BottleId { get; set; }

        public Store? Store { get; set; }
        public Bottle? Bottle { get; set; }
    }
}