using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class ElemCommande
    {
        public int Id { get; set; }
        public int? QuantiteCommande { get; set; }
        public int? SeuilAlerte { get; set; }
        public string? Alerte { get; set; }
        public float TotalCommande { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

        public int? CommandeId { get; set; }
      //  public Commande? Commande { get; set; }

       // public ICollection<Produit>? Produits { get; set; }

        public ElemCommande(int id, int? quantiteCommande, int? seuilAlerte, string? alerte, float totalCommande, DateTime dateCreation, DateTime dateModification, int? commandeId, Commande? commande, ICollection<Produit>? produits)
        {
            Id = id;
            QuantiteCommande = quantiteCommande;
            SeuilAlerte = seuilAlerte;
            Alerte = alerte;
            TotalCommande = totalCommande;
            DateCreation = dateCreation;
            DateModification = dateModification;
            CommandeId = commandeId;
          //  Commande = commande;
          //  Produits = produits;
        }
    }
}
