using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class Producteur
    {
        public int Id { get; set; }
        public string? NomProducteur { get; set; }
        public string? RaisonSocial { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
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

        public int? FournisseurId { get; set; }
        public Fournisseur? Fournisseur { get; set; }

        public Producteur(int id, string? nomProducteur, string? raisonSocial, string? nom, string? prenom, string? tel, string? fix, string? email, string? rue, string? adresse, string? ville, string? region, string? pays, string? reputation, DateTime dateCreation, DateTime dateModification, int? fournisseurId, Fournisseur? fournisseur)
        {
            Id = id;
            NomProducteur = nomProducteur;
            RaisonSocial = raisonSocial;
            Nom = nom;
            Prenom = prenom;
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
            FournisseurId = fournisseurId;
            Fournisseur = fournisseur;
        }
    }
}
