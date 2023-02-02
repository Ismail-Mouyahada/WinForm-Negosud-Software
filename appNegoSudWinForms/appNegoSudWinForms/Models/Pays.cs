using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class Pays
    {
        public int Id { get; set; }
        public string? NamePays { get; set; }

        public Pays(int id, string? namePays)
        {
            Id = id;
            NamePays = namePays;
        }
    }
}
