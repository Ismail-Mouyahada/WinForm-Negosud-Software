using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class ElemFacture
    {
        public int Id { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

        public int? FactureId { get; set; }
        public Facture? Facture { get; set; }

        public ICollection<Produit>? Produits { get; set; }

        public ElemFacture(int id, DateTime dateCreation, DateTime dateModification, int? factureId, Facture? facture, ICollection<Produit>? produits)
        {
            Id = id;
            DateCreation = dateCreation;
            DateModification = dateModification;
            FactureId = factureId;
            Facture = facture;
            Produits = produits;
        }
    }
}
