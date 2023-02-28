using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class Commande
    {
        public int Id { get; set; }
        public string? Statut { get; set; }
        public float Remise { get; set; }
        public DateTime? DateCommande { get; set; }
        public DateTime DateModification { get; set; }

        public int? UtilisateurId { get; set; }
   //     public Utilisateur? Utilisateur { get; set; }

    //    public ICollection<ElemCommande> ElemCommandes { get; } = new List<ElemCommande>();

        public Commande(int id, string? statut, float remise, DateTime? dateCommande, DateTime dateModification, int? utilisateurId, Utilisateur? utilisateur, ICollection<ElemCommande> elemCommandes)
        {
            Id = id;
            Statut = statut;
            Remise = remise;
            DateCommande = dateCommande;
            DateModification = dateModification;
            UtilisateurId = utilisateurId;
       //     Utilisateur = utilisateur;
     //       ElemCommandes = elemCommandes;
        }
    }
}
