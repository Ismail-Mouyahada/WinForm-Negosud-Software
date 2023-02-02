using appNegoSudWinForms.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appNegoSudWinForms.Forms
{
    public partial class FormCategorie : Form
    {
        private string selectedId; // Variable qui selectionne ID pour pouvoir etre Modifier / Supprimer
        private string selectedName; // Variable qui selectionne ID pour pouvoir etre Modifier

        string url = "http://195.154.113.18:8000/api/Categories/";
       // string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJzdHJpbmciLCJqdGkiOiI2OTU4NDkzZC1kNTkxLTQyYjctYTdhOS0xZDQzMDBiMDNlZDUiLCJleHAiOjE2NzU3NTQ3NzgsImlzcyI6Imh0dHBzOlxcbG9jYWxob3N0LmNvbSIsImF1ZCI6Imh0dHBzOlxcbG9jYWxob3N0LmNvbSJ9.oyJWt5xpve1431cxZdI9gD9wx7gzC6uw0q6jgRMLyZM";
        string token = Properties.Settings.Default.token;
        public FormCategorie()
        {
            InitializeComponent();
        }

        private async void FormCategorie_Load(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        List<Categorie?> categories = JsonConvert.DeserializeObject<List<Categorie?>>(result);
                        dataGridViewCategorie.DataSource = categories;
                    }

                    else
                    {
                        Console.WriteLine("Echec de la requête : " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
        }

        private async void dataGridViewCategorie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0) { 
            DataGridViewRow row = dataGridViewCategorie.Rows[rowIndex];
            selectedId = row.Cells[0].Value.ToString();
          
            textBoxNomCategorie.Text = row.Cells[1].Value.ToString();
            selectedName = textBoxNomCategorie.Text;
            // MessageBox.Show("L'ID de la catégorie sélectionnée est : " + selectedId);
            } else {}
        }

        private async void btnAddCategorie_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, string>
                        {
                            { "nameCategorie", textBoxNomCategorie.Text },
                        };

                    var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.PostAsync(url, content);


                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        Categorie categorie = JsonConvert.DeserializeObject<Categorie>(result);

                        string[] row = new string[] { categorie.NameCategorie };

                        MessageBox.Show("La catégorie '" + textBoxNomCategorie.Text + "' a été ajouté avec succès !", "NeoSud - Confirmation");
                        FormCategorie_Load(sender, e);
                        textBoxNomCategorie.Clear();
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

        private async void btnEdit_Click(object sender, EventArgs e)
        {

            string urlEdit = url + selectedId;

            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, dynamic>
                    {
                        { "id", selectedId },
                        { "nameCategorie", textBoxNomCategorie.Text },
                    };


                    string json = JsonConvert.SerializeObject(values);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);


                    HttpResponseMessage response = await client.PutAsync(urlEdit, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("La catégorie '" + selectedName + "' a été modifié en '" + textBoxNomCategorie.Text + "' avec succès !", "NeoSud - Confirmation");
                        FormCategorie_Load(sender, e);
                        textBoxNomCategorie.Clear();
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


        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Construction de l'URL pour la requête DELETE
            string urlDelete = url + selectedId;

            using (var client = new HttpClient())
            {

                try
                {

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.DeleteAsync(urlDelete);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("La catégorie avec l'identifiant '" + selectedId + "' a été supprimé avec succès !", "NeoSud - Confirmation");
                        FormCategorie_Load(sender, e);
                        textBoxNomCategorie.Clear();
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
