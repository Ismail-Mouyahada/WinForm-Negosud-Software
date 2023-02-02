using appNegoSudWinForms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appNegoSudWinForms.Forms
{
    public partial class FormInventaire : Form
    {
        private string selectedId;
        private string selectedName;

        string urlInventaire = "http://195.154.113.18:8000/api/Inventaires/";
        string urlProduit = "http://195.154.113.18:8000/api/Produits/";
       // string urlFournisseur = "http://195.154.113.18:8000/api/Fournisseurs/";
        string token = Properties.Settings.Default.token;


        public FormInventaire()
        {
            InitializeComponent();
        }

        private async void FormInventaire_Load(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage responseInventaire = await client.GetAsync(urlInventaire);
                    HttpResponseMessage responseProduit = await client.GetAsync(urlProduit);
                  //  HttpResponseMessage responseFournisseur = await client.GetAsync(urlFournisseur);

                    if (responseInventaire.IsSuccessStatusCode)
                    {
                        string result = await responseInventaire.Content.ReadAsStringAsync();
                        List<Inventaire?> inventaires = JsonConvert.DeserializeObject<List<Inventaire?>>(result);
                        dataGridViewInventaire.DataSource = inventaires;
                    }
                    else
                    {
                        Console.WriteLine("Echec de la requête : " + responseInventaire.StatusCode);
                    }

                    if (responseProduit.IsSuccessStatusCode)
                    {
                        string result1 = await responseProduit.Content.ReadAsStringAsync();
                        List<Produit?> produits = JsonConvert.DeserializeObject<List<Produit?>>(result1);
                        dataGridViewProduit.DataSource = produits;
                    }
                  
                    else
                    {
                        Console.WriteLine("Echec de la requête : " + responseProduit.StatusCode);
                    }
                  //
                  //  if (responseFournisseur.IsSuccessStatusCode)
                  //  {
                  //      string result2 = await responseFournisseur.Content.ReadAsStringAsync();
                  //      List<Fournisseur?> fournisseurs = JsonConvert.DeserializeObject<List<Fournisseur?>>(result2);
                  //      dataGridViewFournisseur.DataSource = fournisseurs;
                  //  }
                  //
                  //  else
                  //  {
                  //      Console.WriteLine("Echec de la requête : " + responseFournisseur.StatusCode);
                  //  }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
        }

        private void dataGridViewInventaire_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewInventaire.Rows[rowIndex];
                selectedId = row.Cells[0].Value.ToString();

                textBoxNomInventaire.Text = row.Cells[1].Value.ToString();
                selectedName = textBoxNomInventaire.Text;
                textBoxAppelationInventaire.Text = row.Cells[2].Value.ToString();
                textBoxCouleurInventaire.Text = row.Cells[3].Value.ToString();
                textBoxClassementInventaire.Text = row.Cells[4].Value.ToString();
                textBoxMillesimeInventaire.Text = row.Cells[5].Value.ToString();
                textBoxPositionInventaire.Text = row.Cells[6].Value.ToString();
                textBoxQuantiteStockInventaire.Text = row.Cells[7].Value.ToString();
                textBoxmagasinIdInventaire.Text = row.Cells[10].Value.ToString();
            
                //  selectedName = textBoxNomCategorie.Text;
                // MessageBox.Show("L'ID de la catégorie sélectionnée est : " + selectedId);
            }
            else { }
        }

        private async void btnAddInventaire_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, string>
                        {
                            { "nom", textBoxNomInventaire.Text },
                            { "appelation", textBoxAppelationInventaire.Text },
                            { "couleur", textBoxCouleurInventaire.Text },
                            { "classement", textBoxClassementInventaire.Text },
                            { "millesime", textBoxMillesimeInventaire.Text },
                            { "position", textBoxPositionInventaire.Text },
                            { "quantiteStock", textBoxQuantiteStockInventaire.Text },
                            { "magasinId", textBoxmagasinIdInventaire.Text },
                        };

                    var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.PostAsync(urlInventaire, content);


                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        Inventaire inventaire = JsonConvert.DeserializeObject<Inventaire>(result);

                        string[] row = new string[] { inventaire.Nom, inventaire.Appelation, inventaire.Couleur, inventaire.Classement, inventaire.Millesime, inventaire.Position };

                        MessageBox.Show("L'inventaire '" + textBoxNomInventaire.Text + "' a été ajouté avec succès !", "NeoSud - Confirmation");

                        FormInventaire_Load(sender, e);

                        textBoxNomInventaire.Clear();
                        textBoxAppelationInventaire.Clear();
                        textBoxCouleurInventaire.Clear();
                        textBoxClassementInventaire.Clear();
                        textBoxMillesimeInventaire.Clear();
                        textBoxPositionInventaire.Clear();
                        textBoxQuantiteStockInventaire.Clear();
                        textBoxmagasinIdInventaire.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Echec de la requête : " + response.StatusCode);
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }

        private async void btnEditInventaire_Click(object sender, EventArgs e)
        {
            string urlEdit = urlInventaire + selectedId;

            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, dynamic>
                    {
                        { "id", selectedId },
                        { "nom", textBoxNomInventaire.Text },
                        { "appelation", textBoxAppelationInventaire.Text },
                        { "couleur", textBoxCouleurInventaire.Text },
                        { "classement", textBoxClassementInventaire.Text },
                        { "millesime", textBoxMillesimeInventaire.Text },
                        { "position", textBoxPositionInventaire.Text },
                        { "quantiteStock", textBoxQuantiteStockInventaire.Text },
                        { "magasinId", textBoxmagasinIdInventaire.Text },
                    };


                    string json = JsonConvert.SerializeObject(values);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);


                    HttpResponseMessage response = await client.PutAsync(urlEdit, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("L'inventaire '" + selectedName + "' a été modifié en '" + textBoxNomInventaire.Text + "' avec succès !", "NeoSud - Confirmation");

                        FormInventaire_Load(sender, e);

                        textBoxNomInventaire.Clear();
                        textBoxAppelationInventaire.Clear();
                        textBoxCouleurInventaire.Clear();
                        textBoxClassementInventaire.Clear();
                        textBoxMillesimeInventaire.Clear();
                        textBoxPositionInventaire.Clear();
                        textBoxQuantiteStockInventaire.Clear();
                        textBoxmagasinIdInventaire.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Une erreur s'est produite lors de la modification de l'élément");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }

        private async void btnDeleteInventaire_Click(object sender, EventArgs e)
        {
            // Construction de l'URL pour la requête DELETE
            string urlDelete = urlInventaire + selectedId;

            using (var client = new HttpClient())
            {

                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.DeleteAsync(urlDelete);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("L'inventaire avec l'identifiant '" + selectedId + "' a été supprimé avec succès !", "NeoSud - Confirmation");

                        FormInventaire_Load(sender, e);

                        textBoxNomInventaire.Clear();
                        textBoxAppelationInventaire.Clear();
                        textBoxCouleurInventaire.Clear();
                        textBoxClassementInventaire.Clear();
                        textBoxMillesimeInventaire.Clear();
                        textBoxPositionInventaire.Clear();
                        textBoxQuantiteStockInventaire.Clear();
                        textBoxmagasinIdInventaire.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Une erreur s'est produite lors de la suppression de l'élément");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }

        private void dataGridViewProduit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewProduit.Rows[rowIndex];
                selectedId = row.Cells[0].Value.ToString();

                textBoxSkuProduit.Text = row.Cells[1].Value.ToString();
                textBoxNomProduitProduit.Text = row.Cells[2].Value.ToString();
                selectedName = textBoxNomInventaire.Text;
                textBoxResumeeProduit.Text = row.Cells[3].Value.ToString();
                textBoxDescriptionProduit.Text = row.Cells[4].Value.ToString();
                float prixUnitaire;
                if (float.TryParse(row.Cells[5].Value.ToString(), out prixUnitaire))
                {
                    textBoxPrixUnitaireProduit.Text = prixUnitaire.ToString();
                }
                else
                {
                    // La conversion a échoué, gérez l'erreur selon vos besoins
                }
                float prixCarton;
                if (float.TryParse(row.Cells[6].Value.ToString(), out prixCarton))
                {
                    textBoxPrixCartonProduit.Text = prixCarton.ToString();
                }
                else
                {
                    // La conversion a échoué, gérez l'erreur selon vos besoins
                }
                float tva;
                if (float.TryParse(row.Cells[7].Value.ToString(), out tva))
                {
                    textBoxTvaProduit.Text = tva.ToString();
                }
                else
                {
                    // La conversion a échoué, gérez l'erreur selon vos besoins
                }
                float remise;
                if (float.TryParse(row.Cells[8].Value.ToString(), out remise))
                {
                    textBoxRemiseProduit.Text = remise.ToString();
                }
                else
                {
                    // La conversion a échoué, gérez l'erreur selon vos besoins
                }

                //Manque Image
                textBoxAncienProduit.Text = row.Cells[10].Value.ToString();
                textBoxRegionProduit.Text = row.Cells[11].Value.ToString();
                textBoxCouleurProduit.Text = row.Cells[12].Value.ToString();
                textBoxRaisinsProduit.Text = row.Cells[13].Value.ToString();
                float alcool;
                if (float.TryParse(row.Cells[14].Value.ToString(), out alcool))
                {
                    textBoxAlcoolProduit.Text = alcool.ToString();
                }
                else
                {
                    // La conversion a échoué, gérez l'erreur selon vos besoins
                }
                textBoxAlimentProduit.Text = row.Cells[15].Value.ToString();
                textBoxConservationProduit.Text = row.Cells[16].Value.ToString();
                textBoxExpirationProduit.Text = row.Cells[17].Value.ToString();
                float volume;
                if (float.TryParse(row.Cells[18].Value.ToString(), out volume))
                {
                    textBoxVolumeProduit.Text = volume.ToString();
                }
                else
                {
                    // La conversion a échoué, gérez l'erreur selon vos besoins
                }
                textBoxProducteurIdProduit.Text = row.Cells[21].Value.ToString();
                textBoxCategorieIdProduit.Text = row.Cells[23].Value.ToString();

                //  selectedName = textBoxNomCategorie.Text;
                // MessageBox.Show("L'ID de la catégorie sélectionnée est : " + selectedId);
            }
            else { }
        }

        private async void btnAddProduit_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, string>
                        {
                            { "sKU", textBoxSkuProduit.Text },
                            { "nomProduit", textBoxNomProduitProduit.Text },
                            { "resumee", textBoxResumeeProduit.Text },
                            { "description", textBoxDescriptionProduit.Text },
                            { "prix_unitaire", textBoxPrixUnitaireProduit.Text },
                            { "prix_carton", textBoxPrixCartonProduit.Text },
                            { "tVA", textBoxTvaProduit.Text },
                            { "remise", textBoxRemiseProduit.Text },
                         //   { "imagePrincipal", textBoxmagasinIdInventaire.Text },
                            { "ancien", textBoxAncienProduit.Text },
                            { "region", textBoxRegionProduit.Text },
                            { "couleur", textBoxCouleurProduit.Text },
                            { "raisins", textBoxRaisinsProduit.Text },
                            { "alcool", textBoxAlcoolProduit.Text },
                            { "aliments", textBoxAlimentProduit.Text },
                            { "conservation", textBoxConservationProduit.Text },
                            { "expiration", textBoxExpirationProduit.Text },
                            { "volume", textBoxVolumeProduit.Text },
                            { "producteurId", textBoxProducteurIdProduit.Text },
                            { "categorieId", textBoxCategorieIdProduit.Text },
                        };

                    var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.PostAsync(urlProduit, content);


                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        Produit produit = JsonConvert.DeserializeObject<Produit>(result);

                        string[] row = new string[] { produit.SKU, produit.NomProduit, produit.Resumee, produit.Description, produit.Ancien, produit.Region, produit.Couleur, produit.Raisins, produit.Aliments, produit.Conservation, produit.Expiration };

                        MessageBox.Show("Le produit '" + textBoxNomProduitProduit.Text + "' a été ajouté avec succès !", "NeoSud - Confirmation");

                        FormInventaire_Load(sender, e);

                        textBoxSkuProduit.Clear();
                        textBoxNomProduitProduit.Clear();
                        textBoxResumeeProduit.Clear();
                        textBoxDescriptionProduit.Clear();
                        textBoxPrixUnitaireProduit.Clear();
                        textBoxPrixCartonProduit.Clear();
                        textBoxTvaProduit.Clear();
                        textBoxRemiseProduit.Clear();
                        textBoxAncienProduit.Clear();
                        textBoxRegionProduit.Clear();
                        textBoxCouleurProduit.Clear();
                        textBoxRaisinsProduit.Clear();
                        textBoxAlcoolProduit.Clear();
                        textBoxAlimentProduit.Clear();
                        textBoxConservationProduit.Clear();
                        textBoxExpirationProduit.Clear();
                        textBoxVolumeProduit.Clear();
                        textBoxProducteurIdProduit.Clear();
                        textBoxCategorieIdProduit.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Echec de la requête : " + response.StatusCode);
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }

        private async void btnEditProduit_Click(object sender, EventArgs e)
        {
            string urlEdit = urlProduit + selectedId;

            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, dynamic>
                    {
                        { "id", selectedId },
                         { "sKU", textBoxSkuProduit.Text },
                            { "nomProduit", textBoxNomProduitProduit.Text },
                            { "resumee", textBoxResumeeProduit.Text },
                            { "description", textBoxDescriptionProduit.Text },
                            { "prix_unitaire", textBoxPrixUnitaireProduit.Text },
                            { "prix_carton", textBoxPrixCartonProduit.Text },
                            { "tVA", textBoxTvaProduit.Text },
                            { "remise", textBoxRemiseProduit.Text },
                         //   { "imagePrincipal", textBoxmagasinIdInventaire.Text },
                            { "ancien", textBoxAncienProduit.Text },
                            { "region", textBoxRegionProduit.Text },
                            { "couleur", textBoxCouleurProduit.Text },
                            { "raisins", textBoxRaisinsProduit.Text },
                            { "alcool", textBoxAlcoolProduit.Text },
                            { "aliments", textBoxAlimentProduit.Text },
                            { "conservation", textBoxConservationProduit.Text },
                            { "expiration", textBoxExpirationProduit.Text },
                            { "volume", textBoxVolumeProduit.Text },
                            { "producteurId", textBoxProducteurIdProduit.Text },
                            { "categorieId", textBoxCategorieIdProduit.Text },
                    };


                    string json = JsonConvert.SerializeObject(values);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);


                    HttpResponseMessage response = await client.PutAsync(urlEdit, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Le produit '" + selectedName + "' a été modifié en '" + textBoxNomProduitProduit.Text + "' avec succès !", "NeoSud - Confirmation");

                        FormInventaire_Load(sender, e);

                        textBoxSkuProduit.Clear();
                        textBoxNomProduitProduit.Clear();
                        textBoxResumeeProduit.Clear();
                        textBoxDescriptionProduit.Clear();
                        textBoxPrixUnitaireProduit.Clear();
                        textBoxPrixCartonProduit.Clear();
                        textBoxTvaProduit.Clear();
                        textBoxRemiseProduit.Clear();
                        textBoxAncienProduit.Clear();
                        textBoxRegionProduit.Clear();
                        textBoxCouleurProduit.Clear();
                        textBoxRaisinsProduit.Clear();
                        textBoxAlcoolProduit.Clear();
                        textBoxAlimentProduit.Clear();
                        textBoxConservationProduit.Clear();
                        textBoxExpirationProduit.Clear();
                        textBoxVolumeProduit.Clear();
                        textBoxProducteurIdProduit.Clear();
                        textBoxCategorieIdProduit.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Une erreur s'est produite lors de la modification de l'élément");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }

        private async void btnDeleteProduit_Click(object sender, EventArgs e)
        {
            // Construction de l'URL pour la requête DELETE
            string urlDelete = urlProduit + selectedId;

            using (var client = new HttpClient())
            {

                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.DeleteAsync(urlDelete);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Le produit avec l'identifiant '" + selectedId + "' a été supprimé avec succès !", "NeoSud - Confirmation");

                        FormInventaire_Load(sender, e);

                        textBoxSkuProduit.Clear();
                        textBoxNomProduitProduit.Clear();
                        textBoxResumeeProduit.Clear();
                        textBoxDescriptionProduit.Clear();
                        textBoxPrixUnitaireProduit.Clear();
                        textBoxPrixCartonProduit.Clear();
                        textBoxTvaProduit.Clear();
                        textBoxRemiseProduit.Clear();
                        textBoxAncienProduit.Clear();
                        textBoxRegionProduit.Clear();
                        textBoxCouleurProduit.Clear();
                        textBoxRaisinsProduit.Clear();
                        textBoxAlcoolProduit.Clear();
                        textBoxAlimentProduit.Clear();
                        textBoxConservationProduit.Clear();
                        textBoxExpirationProduit.Clear();
                        textBoxVolumeProduit.Clear();
                        textBoxProducteurIdProduit.Clear();
                        textBoxCategorieIdProduit.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Une erreur s'est produite lors de la suppression de l'élément");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }
    }
}
