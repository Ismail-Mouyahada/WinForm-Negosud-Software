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
    public partial class FormLogin : Form
    {
       // private string token;
        
        public FormLogin()
        {
            InitializeComponent();
        }

        private async void btnConnexion_Click(object sender, EventArgs e)
        {
            // if (textBoxEmail.Text == "")
            // {
            //     MessageBox.Show("Entrer une adresse Email !!", "NeoSud");
            // }
            // else if (textBoxPassword.Text == "")
            // {
            //     MessageBox.Show("Entrer Mot de Passe !!", "NeoSud");
            // }
            // else if (textBoxEmail.Text == "test" && textBoxPassword.Text == "test")
            // {
            //     this.Hide();
            //     Form formMain = new FormMainMenu();
            //     formMain.ShowDialog();
            // }
            // else
            // {
            //     MessageBox.Show("Compte ou mot de passe incorrecte !!", "NeoSud");
            // }

            // URL pour la requête POST de connexion
            

        string url = "http://195.154.113.18:8000/api/Auth";

          

            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                        {
                            { "email", textBoxEmail.Text },
                            { "motDePasse", textBoxPassword.Text }
                        };

                // Encodage des données en JSON
                string json = JsonConvert.SerializeObject(values);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
               //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    // Récupération du jeton dans la réponse
                    string result = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(result);
                    string token = data["access_Token"];

                    // Stockage du jeton dans les données d'application
                    Properties.Settings.Default.token = token;
                    Properties.Settings.Default.Save();

                    //string settingValue = Properties.Settings.Default.token;

                    MessageBox.Show("Connexion réussie");
                    this.Hide();
                    Form formMain = new FormMainMenu();
                    formMain.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Echec de la connexion");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
