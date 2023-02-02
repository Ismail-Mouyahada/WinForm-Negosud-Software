using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class Region
    {
        public int Id { get; set; }
        public string? NameRegion { get; set; }

        public int? PaysId { get; set; }
        public Pays? Pays { get; set; }

        public Region(int id, string? nameRegion, int? paysId, Pays? pays)
        {
            Id = id;
            NameRegion = nameRegion;
            PaysId = paysId;
            Pays = pays;
        }
    }
}
