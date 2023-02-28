using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class Catalogue
    {
        public int Id { get; set; }
        public string? Reference { get; set; }
        public string? Image { get; set; }


        // Forgein Keys
        public int? ProduitId { get; set; }
       // public Produit? Produit { get; set; }

        public Catalogue(int id, string? reference, string? image, int? produitId, Produit? produit)
        {
            Id = id;
            Reference = reference;
            Image = image;
            ProduitId = produitId;
         //   Produit = produit;
        }
    }
}
