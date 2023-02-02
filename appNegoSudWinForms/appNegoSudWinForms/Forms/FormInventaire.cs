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
       // string urlProducteur = "http://195.154.113.18:8000/api/Producteurs/";
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
                  //  HttpResponseMessage responseProducteur = await client.GetAsync(urlProducteur);
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

                  //  if (responseProducteur.IsSuccessStatusCode)
                  //  {
                  //      string result1 = await responseProducteur.Content.ReadAsStringAsync();
                  //      List<Producteur?> producteurs = JsonConvert.DeserializeObject<List<Producteur?>>(result1);
                  //      dataGridViewProducteur.DataSource = producteurs;
                  //  }
                  //
                  //  else
                  //  {
                  //      Console.WriteLine("Echec de la requête : " + responseProducteur.StatusCode);
                  //  }
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

        private void lblMagasinId_Click(object sender, EventArgs e)
        {

        }
    }
}
