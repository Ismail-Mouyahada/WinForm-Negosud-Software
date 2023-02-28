using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class Categorie
    {
        public int Id { get; set; }
        public string? NameCategorie { get; set; }

  //      public ICollection<Produit>? Produit { get; set; }

        public Categorie(int id, string? nameCategorie, ICollection<Produit>? produit)
        {
            Id = id;
            NameCategorie = nameCategorie;
   //         Produit = produit;
        }
    }
}
