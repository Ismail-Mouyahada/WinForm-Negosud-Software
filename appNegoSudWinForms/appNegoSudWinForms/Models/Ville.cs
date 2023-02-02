using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class Ville
    {
        public int Id { get; set; }
        public string? NameVille { get; set; }

        public int? RegionId { get; set; }
        public Region? Region { get; set; }

        public Ville(int id, string? nameVille, int? regionId, Region? region)
        {
            Id = id;
            NameVille = nameVille;
            RegionId = regionId;
            Region = region;
        }
    }
}
