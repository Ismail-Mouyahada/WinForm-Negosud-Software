using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class Inventaire
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Appelation { get; set; }
        public string? Couleur { get; set; }
        public string? Classement { get; set; }
        public string? Millesime { get; set; }
        public string? Position { get; set; }
        public int QuantiteStock { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

        public int? MagasinId { get; set; }
        //public Magasin? Magasin { get; set; }

       // public IList<Produit>? Produits { get; set; }

        public Inventaire(int id, string? nom, string? appelation, string? couleur, string? classement, string? millesime, string? position, int quantiteStock, DateTime dateCreation, DateTime dateModification, int? magasinId 
           // Magasin? magasin, IList<Produit>? produits
            )
        {
            Id = id;
            Nom = nom;
            Appelation = appelation;
            Couleur = couleur;
            Classement = classement;
            Millesime = millesime;
            Position = position;
            QuantiteStock = quantiteStock;
            DateCreation = dateCreation;
            DateModification = dateModification;
            MagasinId = magasinId;
           // Magasin = magasin;
           // Produits = produits;
        }
    }
}
