using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class Adresse
    {
        public int Id { get; set; }
        public string? Rue { get; set; }
        public string? AdressePrincipal { get; set; }
        public string? AdresseComplet { get; set; }
        public string? Ville { get; set; }
        public string? CodePostal { get; set; }
        public string? Region { get; set; }
        public string? Pays { get; set; }
        public string? typeAdresse { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

        public int? UtilisateurId { get; set; }
        public Utilisateur? Utilisateur { get; set; }

        public Adresse(int id, string? rue, string? adressePrincipal, string? adresseComplet, string? ville, string? codePostal, string? region, string? pays, string? typeAdresse, DateTime dateCreation, DateTime dateModification, int? utilisateurId, Utilisateur? utilisateur)
        {
            Id = id;
            Rue = rue;
            AdressePrincipal = adressePrincipal;
            AdresseComplet = adresseComplet;
            Ville = ville;
            CodePostal = codePostal;
            Region = region;
            Pays = pays;
            this.typeAdresse = typeAdresse;
            DateCreation = dateCreation;
            DateModification = dateModification;
            UtilisateurId = utilisateurId;
            Utilisateur = utilisateur;
        }
    }
}
