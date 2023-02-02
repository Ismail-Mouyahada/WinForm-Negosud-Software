using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class Magasin
    {
        public int Id { get; set; }
        public string? NomMagasin { get; set; }
        public string? Email { get; set; }
        public string? Tel { get; set; }
        public string? Fix { get; set; }
        public string? Adresse { get; set; }
        public string? Rue { get; set; }
        public string? CodePostal { get; set; }
        public string? Region { get; set; }
        public string? Pays { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

        public int? ProducteurId { get; set; }
        public Producteur? Producteur { get; set; }

        public Magasin(int id, string? nomMagasin, string? email, string? tel, string? fix, string? adresse, string? rue, string? codePostal, string? region, string? pays, DateTime dateCreation, DateTime dateModification, int? producteurId, Producteur? producteur)
        {
            Id = id;
            NomMagasin = nomMagasin;
            Email = email;
            Tel = tel;
            Fix = fix;
            Adresse = adresse;
            Rue = rue;
            CodePostal = codePostal;
            Region = region;
            Pays = pays;
            DateCreation = dateCreation;
            DateModification = dateModification;
            ProducteurId = producteurId;
            Producteur = producteur;
        }
    }
}
