using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class Fournisseur
    {
        public int Id { get; set; }
        public string? NomFournisseur { get; set; }
        public string? Tel { get; set; }
        public string? Fix { get; set; }
        public string? Email { get; set; }
        public string? Rue { get; set; }
        public string? Adresse { get; set; }
        public string? Ville { get; set; }
        public string? Region { get; set; }
        public string? Pays { get; set; }
        public string? Reputation { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

        public ICollection<Produit>? Produits { get; set; }

        public Fournisseur(int id, string? nomFournisseur, string? tel, string? fix, string? email, string? rue, string? adresse, string? ville, string? region, string? pays, string? reputation, DateTime dateCreation, DateTime dateModification, ICollection<Produit>? produits)
        {
            Id = id;
            NomFournisseur = nomFournisseur;
            Tel = tel;
            Fix = fix;
            Email = email;
            Rue = rue;
            Adresse = adresse;
            Ville = ville;
            Region = region;
            Pays = pays;
            Reputation = reputation;
            DateCreation = dateCreation;
            DateModification = dateModification;
            Produits = produits;
        }
    }
}
