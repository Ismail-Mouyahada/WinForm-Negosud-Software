using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class Facture
    {
        public int Id { get; set; }
        public string? Reference { get; set; }
        public float FactureTotal { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

        // Foreign keys
        public int? CommandeId { get; set; }
     //   public Commande? Commande { get; set; }

        public Facture(int id, string? reference, float factureTotal, DateTime dateCreation, DateTime dateModification, int? commandeId, Commande? commande)
        {
            Id = id;
            Reference = reference;
            FactureTotal = factureTotal;
            DateCreation = dateCreation;
            DateModification = dateModification;
            CommandeId = commandeId;
       //     Commande = commande;
        }
    }
}
