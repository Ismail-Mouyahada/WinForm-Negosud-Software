using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class Utilisateur
    {
        public int Id { get; set; }
        public string? NomUtilisateur { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Email { get; set; }
        public string? Tel { get; set; }
        public string? MotDePasse { get; set; }
        public int? Role { get; set; }
        public bool? IsBusiness { get; set; }
        public string? SIREN { get; set; }
        public DateTime? DateInscription { get; set; }
        public DateTime? DateModification { get; set; }

        public Utilisateur(int id, string? nomUtilisateur, string? nom, string? prenom, string? email, string? tel, string? motDePasse, int? role, bool? isBusiness, string? sIREN, DateTime? dateInscription, DateTime? dateModification)
        {
            Id = id;
            NomUtilisateur = nomUtilisateur;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Tel = tel;
            MotDePasse = motDePasse;
            Role = role;
            IsBusiness = isBusiness;
            SIREN = sIREN;
            DateInscription = dateInscription;
            DateModification = dateModification;
        }
    }
}
