using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appNegoSudWinForms.Models
{
    internal class Produit
    {
        public int Id { get; set; }
        public string? SKU { get; set; }
        public string? NomProduit { get; set; }
        public string? Resumee { get; set; }
        public string? Description { get; set; }
        public float? Prix_unitaire { get; set; }
        public float? Prix_carton { get; set; }
        public float? TVA { get; set; }
        public float? Remise { get; set; }
        public string? ImagePrincipal { get; set; }
        public string? Ancien { get; set; }
        public string? Region { get; set; }
        public string? Couleur { get; set; }
        public string? Raisins { get; set; }
        public float? Alcool { get; set; }
        public string? Aliments { get; set; }
        public string? Conservation { get; set; }
        public string? Expiration { get; set; }
        public float Volume { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

        // Foreign keys
        public int? ProducteurId { get; set; }
     //   public Producteur? Producteur { get; set; }
        public int? CategorieId { get; set; }
     //   public Categorie? Categorie { get; set; }

        public Produit(int id, string? sku, string? nomProduit, string? resumee, string? description, float? prix_unitaire, float? prix_carton, float? tva, float? remise, string? imagePrincipal, string? ancien, string? region, string? couleur, string? raisins, float? alcool, string? aliments, string? conservation, string? expiration, float volume, DateTime dateCreation, DateTime dateModification, int? producteurId, Producteur? producteur, int? categorieId, Categorie? categorie)
        {
            Id = id;
            SKU = sku;
            NomProduit = nomProduit;
            Resumee = resumee;
            Description = description;
            Prix_unitaire = prix_unitaire;
            Prix_carton = prix_carton;
            TVA = tva;
            Remise = remise;
            ImagePrincipal = imagePrincipal;
            Ancien = ancien;
            Region = region;
            Couleur = couleur;
            Raisins = raisins;
            Alcool = alcool;
            Aliments = aliments;
            Conservation = conservation;
            Expiration = expiration;
            Volume = volume;
            DateCreation = dateCreation;
            DateModification = dateModification;
            ProducteurId = producteurId;
         //   Producteur = producteur;
            CategorieId = categorieId;
         //   Categorie = categorie;
        }
    }
}
