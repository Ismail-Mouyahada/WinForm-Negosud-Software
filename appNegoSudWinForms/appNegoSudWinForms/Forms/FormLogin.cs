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
                    int role = data["role"];
                    if (role == 3)
                    {
                        // Stockage du jeton dans les données d'application
                        Properties.Settings.Default.token = token;
                        Properties.Settings.Default.Save();

                       // MessageBox.Show("Connexion réussie");
                        this.Hide();
                        Form formMain = new FormMainMenu();
                        formMain.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Vous n'êtes pas autorisé à accéder à cette application.");
                    }
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
