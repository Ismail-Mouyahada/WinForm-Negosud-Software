using appNegoSudWinForms.Models;
using Newtonsoft.Json.Linq;
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
    public partial class FormCommande : Form
    {
        private string selectedId;
        //  private string selectedName;

        string urlCommande = "http://195.154.113.18:8000/api/Commandes/";
        string urlElemCommande = "http://195.154.113.18:8000/api/ElemCommandes/";
        string urlFacture = "http://195.154.113.18:8000/api/Factures/";
        string urlElemFacture = "http://195.154.113.18:8000/api/ElemFactures/";
        string token = Properties.Settings.Default.token;



        public FormCommande()
        {
            InitializeComponent();
        }

        private async void FormCommande_Load(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage responseCommande = await client.GetAsync(urlCommande);
                    HttpResponseMessage responseElemCommande = await client.GetAsync(urlElemCommande);
                    HttpResponseMessage responseFacture = await client.GetAsync(urlFacture);
                    HttpResponseMessage responseElemFacture = await client.GetAsync(urlElemFacture);

                    if (responseCommande.IsSuccessStatusCode)
                    {
                        string result = await responseCommande.Content.ReadAsStringAsync();
                        List<Commande?> commandes = JsonConvert.DeserializeObject<List<Commande?>>(result);
                        dataGridViewCommande.DataSource = commandes;
                    }
                    else
                    {
                        Console.WriteLine("Echec de la requête : " + responseCommande.StatusCode);
                    }

                    if (responseElemCommande.IsSuccessStatusCode)
                    {
                        string result1 = await responseElemCommande.Content.ReadAsStringAsync();
                        List<ElemCommande?> elemcommandes = JsonConvert.DeserializeObject<List<ElemCommande?>>(result1);
                        dataGridViewElemCommande.DataSource = elemcommandes;
                    }
                    else
                    {
                        Console.WriteLine("Echec de la requête : " + responseElemCommande.StatusCode);
                    }
                    
                    if (responseFacture.IsSuccessStatusCode)
                    {
                        string result2 = await responseFacture.Content.ReadAsStringAsync();
                        List<Facture?> factures = JsonConvert.DeserializeObject<List<Facture?>>(result2);
                        dataGridViewFacture.DataSource = factures;
                    }
                    else
                    {
                        Console.WriteLine("Echec de la requête : " + responseFacture.StatusCode);
                    }
                    
                    if (responseElemFacture.IsSuccessStatusCode)
                    {
                        string result3 = await responseElemFacture.Content.ReadAsStringAsync();
                        List<ElemFacture?> elemfatures = JsonConvert.DeserializeObject<List<ElemFacture?>>(result3);
                        dataGridViewElemFacture.DataSource = elemfatures;
                    }
                    else
                    {
                        Console.WriteLine("Echec de la requête : " + responseElemFacture.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
        }

        private void dataGridViewCommande_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewCommande.Rows[rowIndex];
                selectedId = row.Cells[0].Value.ToString();

                textBoxStatutCatalogue.Text = row.Cells[1].Value.ToString();
                //       selectedName = textBoxNomInventaire.Text;
                float remise;
                if (float.TryParse(row.Cells[2].Value.ToString(), out remise))
                {
                    textBoxRemiseCatalogue.Text = remise.ToString();
                }
                else
                {
                    // La conversion a échoué, gérez l'erreur selon vos besoins
                }
            }
            else { }
        }

        private async void btnAddCommande_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, string>
                        {
                            { "statut", textBoxStatutCatalogue.Text },
                            { "remise", textBoxRemiseCatalogue.Text },
                        };

                    var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.PostAsync(urlCommande, content);


                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        Commande commande = JsonConvert.DeserializeObject<Commande>(result);

                        string[] row = new string[] { commande.Statut };

                        MessageBox.Show("La commande a été ajouté avec succès !", "NeoSud - Confirmation");

                        FormCommande_Load(sender, e);

                        textBoxStatutCatalogue.Clear();
                        textBoxRemiseCatalogue.Clear();
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

        private async void btnEditCommande_Click(object sender, EventArgs e)
        {
            string urlEdit = urlCommande + selectedId;

            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, dynamic>
                    {
                        { "id", selectedId },
                        { "statut", textBoxStatutCatalogue.Text },
                        { "remise", textBoxRemiseCatalogue.Text },
                    };


                    string json = JsonConvert.SerializeObject(values);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);


                    HttpResponseMessage response = await client.PutAsync(urlEdit, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("La commande a été modifié avec succès !", "NeoSud - Confirmation");

                        FormCommande_Load(sender, e);

                        textBoxStatutCatalogue.Clear();
                        textBoxRemiseCatalogue.Clear();
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

        private async void btnDeleteCommande_Click(object sender, EventArgs e)
        {
            // Construction de l'URL pour la requête DELETE
            string urlDelete = urlCommande + selectedId;

            using (var client = new HttpClient())
            {

                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.DeleteAsync(urlDelete);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("La commande a été supprimé avec succès !", "NeoSud - Confirmation");

                        FormCommande_Load(sender, e);

                        textBoxStatutCatalogue.Clear();
                        textBoxRemiseCatalogue.Clear();
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

        private void dataGridViewElemCommande_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewElemCommande.Rows[rowIndex];
                selectedId = row.Cells[0].Value.ToString();

                textBoxQuantiteElemCommande.Text = row.Cells[1].Value.ToString();
                textBoxSeuilAlerteElemCommande.Text = row.Cells[2].Value.ToString();
                textBoxAlerteElemCommande.Text = row.Cells[3].Value.ToString();
                textBoxTotalElemCommande.Text = row.Cells[4].Value.ToString();
                textBoxCommandeIdElemCommande.Text = row.Cells[7].Value.ToString();
                float totalCommande;
                if (float.TryParse(row.Cells[5].Value.ToString(), out totalCommande))
                {
                    textBoxTotalElemCommande.Text = totalCommande.ToString();
                }
                else
                {
                    // La conversion a échoué, gérez l'erreur selon vos besoins
                }
            }
            else { }
        }

        private async void btnAddElemCommande_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, string>
                        {
                            { "quantiteCommande", textBoxQuantiteElemCommande.Text },
                            { "seuilAlerte", textBoxSeuilAlerteElemCommande.Text },
                            { "alerte", textBoxAlerteElemCommande.Text },
                            { "totalCommande", textBoxTotalElemCommande.Text },
                            { "commandeId", textBoxCommandeIdElemCommande.Text },
                        };

                    var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.PostAsync(urlElemCommande, content);


                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        ElemCommande elemcommande = JsonConvert.DeserializeObject<ElemCommande>(result);

                        string[] row = new string[] { elemcommande.Alerte };

                        MessageBox.Show("L'Element Commande a été ajouté avec succès !", "NeoSud - Confirmation");

                        FormCommande_Load(sender, e);

                        textBoxQuantiteElemCommande.Clear();
                        textBoxSeuilAlerteElemCommande.Clear();
                        textBoxAlerteElemCommande.Clear();
                        textBoxTotalElemCommande.Clear();
                        textBoxCommandeIdElemCommande.Clear();
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

        private async void btnEditElemCommande_Click(object sender, EventArgs e)
        {
            string urlEdit = urlElemCommande + selectedId;

            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, dynamic>
                    {
                        { "id", selectedId },
                        { "quantiteCommande", textBoxQuantiteElemCommande.Text },
                        { "seuilAlerte", textBoxSeuilAlerteElemCommande.Text },
                        { "alerte", textBoxAlerteElemCommande.Text },
                        { "totalCommande", textBoxTotalElemCommande.Text },
                        { "commandeId", textBoxCommandeIdElemCommande.Text },
                    };


                    string json = JsonConvert.SerializeObject(values);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);


                    HttpResponseMessage response = await client.PutAsync(urlEdit, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("L'Element Commande a été modifié avec succès !", "NeoSud - Confirmation");

                        FormCommande_Load(sender, e);

                        textBoxQuantiteElemCommande.Clear();
                        textBoxSeuilAlerteElemCommande.Clear();
                        textBoxAlerteElemCommande.Clear();
                        textBoxSeuilAlerteElemCommande.Clear();
                        textBoxTotalElemCommande.Clear();
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

        private async void btnDeleteElemCommande_Click(object sender, EventArgs e)
        {
            // Construction de l'URL pour la requête DELETE
            string urlDelete = urlElemCommande + selectedId;

            using (var client = new HttpClient())
            {

                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.DeleteAsync(urlDelete);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("L'Element Commande a été supprimé avec succès !", "NeoSud - Confirmation");

                        FormCommande_Load(sender, e);

                        textBoxStatutCatalogue.Clear();
                        textBoxRemiseCatalogue.Clear();
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

        private void dataGridViewFacture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewFacture.Rows[rowIndex];
                selectedId = row.Cells[0].Value.ToString();

                textBoxReferenceFacture.Text = row.Cells[1].Value.ToString();
                float factureTotal;
                if (float.TryParse(row.Cells[2].Value.ToString(), out factureTotal))
                {
                    textBoxFatureTotalFacture.Text = factureTotal.ToString();
                }
                else
                {
                    // La conversion a échoué, gérez l'erreur selon vos besoins
                }
                textBoxCommandeIdFacture.Text = row.Cells[5].Value.ToString();
            }
            else { }
        }

        private async void btnAddFacture_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, string>
                        {
                            { "reference", textBoxReferenceFacture.Text },
                            { "factureTotal", textBoxFatureTotalFacture.Text },
                            { "commandeId", textBoxCommandeIdFacture.Text },
                        };

                    var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.PostAsync(urlFacture, content);


                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        Facture facture = JsonConvert.DeserializeObject<Facture>(result);

                        string[] row = new string[] { facture.Reference };

                        MessageBox.Show("La Facture a été ajouté avec succès !", "NeoSud - Confirmation");

                        FormCommande_Load(sender, e);

                        textBoxReferenceFacture.Clear();
                        textBoxFatureTotalFacture.Clear();
                        textBoxCommandeIdFacture.Clear(); 
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

        private async void btnEditFacture_Click(object sender, EventArgs e)
        {
            string urlEdit = urlFacture + selectedId;

            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, dynamic>
                    {
                        { "id", selectedId },
                        { "reference", textBoxReferenceFacture.Text },
                        { "factureTotal", textBoxFatureTotalFacture.Text },
                        { "commandeId", textBoxCommandeIdFacture.Text },
                    };


                    string json = JsonConvert.SerializeObject(values);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);


                    HttpResponseMessage response = await client.PutAsync(urlEdit, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("La Facture a été modifié avec succès !", "NeoSud - Confirmation");

                        FormCommande_Load(sender, e);

                        textBoxReferenceFacture.Clear();
                        textBoxFatureTotalFacture.Clear();
                        textBoxCommandeIdFacture.Clear();
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

        private async void btnDeleteFacture_Click(object sender, EventArgs e)
        {
            // Construction de l'URL pour la requête DELETE
            string urlDelete = urlFacture + selectedId;

            using (var client = new HttpClient())
            {

                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.DeleteAsync(urlDelete);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("La Facture a été supprimé avec succès !", "NeoSud - Confirmation");

                        FormCommande_Load(sender, e);

                        textBoxReferenceFacture.Clear();
                        textBoxFatureTotalFacture.Clear();
                        textBoxCommandeIdFacture.Clear();
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
        
        private void dataGridViewElemFacture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewElemFacture.Rows[rowIndex];
                selectedId = row.Cells[0].Value.ToString();

                textBoxProduitIdCatalogue.Text = row.Cells[3].Value.ToString();
            }
            else { }
        }

        private async void btnAddElemFacture_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, string>
                        {
                            { "factureId", textBoxProduitIdCatalogue.Text },
                        };

                    var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.PostAsync(urlElemFacture, content);


                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        ElemFacture elemfacture = JsonConvert.DeserializeObject<ElemFacture>(result);

                        string[] row = new string[] { };

                        MessageBox.Show("L'Element Facture a été ajouté avec succès !", "NeoSud - Confirmation");

                        FormCommande_Load(sender, e);

                        textBoxProduitIdCatalogue.Clear();
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

        private async void btnEditElemFacture_Click(object sender, EventArgs e)
        {
            string urlEdit = urlFacture + selectedId;

            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, dynamic>
                    {
                        { "id", selectedId },
                        { "factureId", textBoxProduitIdCatalogue.Text },
                    };


                    string json = JsonConvert.SerializeObject(values);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);


                    HttpResponseMessage response = await client.PutAsync(urlEdit, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("L'Element Facture a été modifié avec succès !", "NeoSud - Confirmation");

                        FormCommande_Load(sender, e);

                        textBoxProduitIdCatalogue.Clear();
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

        private async void btnDeleteElemFacture_Click(object sender, EventArgs e)
        {
            // Construction de l'URL pour la requête DELETE
            string urlDelete = urlElemFacture + selectedId;

            using (var client = new HttpClient())
            {

                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.DeleteAsync(urlDelete);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("L'Element Facture a été supprimé avec succès !", "NeoSud - Confirmation");

                        FormCommande_Load(sender, e);

                        textBoxProduitIdCatalogue.Clear();
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
