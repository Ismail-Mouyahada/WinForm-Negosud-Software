using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeosudAPI.Models
{
    public class Producer
    {
        public int ProducerId { get; set; }
        public string? ProducerName { get; set; }
        public string? Details { get; set; }

        public int RegionId { get; set;}
        public Region? Region { get; set; }

        public List<Bottle>? Bottles { get; set; }
    }
}