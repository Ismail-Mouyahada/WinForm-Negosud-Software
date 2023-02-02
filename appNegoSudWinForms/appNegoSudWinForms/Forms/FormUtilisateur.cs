﻿using appNegoSudWinForms.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Documents;

namespace appNegoSudWinForms.Forms
{
    public partial class FormUtilisateur : Form
    {
        private string selectedId;
        private string selectedName;

        string urlUtilisateur = "http://195.154.113.18:8000/api/Utilisateurs/";
        string urlProducteur = "http://195.154.113.18:8000/api/Producteurs/";
        string urlFournisseur = "http://195.154.113.18:8000/api/Fournisseurs/";
        string token = Properties.Settings.Default.token;

        public FormUtilisateur()
        {
            InitializeComponent();
        }

        private async void FormUtilisateur_Load(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage responseUtilisateur = await client.GetAsync(urlUtilisateur);
                    HttpResponseMessage responseProducteur = await client.GetAsync(urlProducteur);
                    HttpResponseMessage responseFournisseur = await client.GetAsync(urlFournisseur);

                    if (responseUtilisateur.IsSuccessStatusCode)
                    {
                        string result = await responseUtilisateur.Content.ReadAsStringAsync();
                        List<Utilisateur?> utilisateurs = JsonConvert.DeserializeObject<List<Utilisateur?>>(result);
                        dataGridViewUtilisateur.DataSource = utilisateurs;
                    }
                    else
                    {
                        Console.WriteLine("Echec de la requête : " + responseUtilisateur.StatusCode);
                    }

                    if (responseProducteur.IsSuccessStatusCode)
                    {
                        string result1 = await responseProducteur.Content.ReadAsStringAsync();
                        List<Producteur?> producteurs = JsonConvert.DeserializeObject<List<Producteur?>>(result1);
                        dataGridViewProducteur.DataSource = producteurs;
                    }

                    else
                    {
                        Console.WriteLine("Echec de la requête : " + responseProducteur.StatusCode);
                    }

                    if (responseFournisseur.IsSuccessStatusCode)
                    {
                        string result2 = await responseFournisseur.Content.ReadAsStringAsync();
                        List<Fournisseur?> fournisseurs = JsonConvert.DeserializeObject<List<Fournisseur?>>(result2);
                        dataGridViewFournisseur.DataSource = fournisseurs;
                    }

                    else
                    {
                        Console.WriteLine("Echec de la requête : " + responseFournisseur.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
        }

        private void dataGridViewUtilisateur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewUtilisateur.Rows[rowIndex];
                selectedId = row.Cells[0].Value.ToString();

                textBoxNomUtilisateurUser.Text = row.Cells[1].Value.ToString();
                textBoxNomUser.Text = row.Cells[2].Value.ToString();
                textBoxPrenomUser.Text = row.Cells[3].Value.ToString();
                textBoxEmailUser.Text = row.Cells[4].Value.ToString();
                textBoxTelephoneUser.Text = row.Cells[5].Value.ToString();
                textBoxMotDePasseUser.Text = row.Cells[6].Value.ToString();
                comboBoxRoleUser.Text = row.Cells[7].Value.ToString();
                //  textBoxMotDePasse.Text = row.Cells[7].Value.ToString();

                string cellValue = row.Cells[8].Value.ToString();
                if (cellValue == "True")
                {
                    checkBoxIsBusinessUser.Checked = true;
                }
                else
                {
                    checkBoxIsBusinessUser.Checked = false;
                }

                textBoxSirenUser.Text = row.Cells[9].Value.ToString();
                
              //  selectedName = textBoxNomCategorie.Text;
                // MessageBox.Show("L'ID de la catégorie sélectionnée est : " + selectedId);
            }
            else { }
        }

        private void dataGridViewProducteur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewProducteur.Rows[rowIndex];
                selectedId = row.Cells[0].Value.ToString();

                textBoxNomProducteurProducer.Text = row.Cells[1].Value.ToString();
                selectedName = textBoxNomProducteurProducer.Text;
                textBoxRaisonSocialProducer.Text = row.Cells[2].Value.ToString();
                textBoxNomProducer.Text = row.Cells[3].Value.ToString();
                textBoxPrenomProducer.Text = row.Cells[4].Value.ToString();
                textBoxTelephoneProducer.Text = row.Cells[5].Value.ToString();
                textBoxFixeProducer.Text = row.Cells[6].Value.ToString();
                textBoxEmailProducer.Text = row.Cells[7].Value.ToString();
                textBoxRueProducer.Text = row.Cells[8].Value.ToString();
                textBoxAdresseProducer.Text = row.Cells[9].Value.ToString();
                textBoxVilleProducer.Text = row.Cells[10].Value.ToString();
                textBoxRegionProducer.Text = row.Cells[11].Value.ToString();
                textBoxPaysProducer.Text = row.Cells[12].Value.ToString();
                textBoxReputationProducer.Text = row.Cells[13].Value.ToString();
                comboBoxFournisseurProducer.Text = row.Cells[16].Value.ToString();
       
            }
            else { }
        }

        private async void btnAddProducer_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, string>
                        {
                            { "nomProducteur", textBoxNomProducteurProducer.Text },
                            { "raisonSocial", textBoxRaisonSocialProducer.Text },
                            { "nom", textBoxNomProducer.Text },
                            { "prenom", textBoxPrenomProducer.Text },
                            { "tel", textBoxTelephoneProducer.Text },
                            { "fix", textBoxFixeProducer.Text },
                            { "email", textBoxEmailProducer.Text },
                            { "rue", textBoxRueProducer.Text },
                            { "adresse", textBoxAdresseProducer.Text },
                            { "ville", textBoxVilleProducer.Text },
                            { "region", textBoxRegionProducer.Text },
                            { "pays", textBoxPaysProducer.Text },
                            { "reputation", textBoxReputationProducer.Text },
                            { "fournisseurId", comboBoxFournisseurProducer.Text },
                        };

                    var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.PostAsync(urlProducteur, content);


                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        Producteur producteur = JsonConvert.DeserializeObject<Producteur>(result);

                        string[] row = new string[] { producteur.NomProducteur, producteur.RaisonSocial, producteur.Nom, producteur.Prenom, producteur.Tel, producteur.Fix, producteur.Email, producteur.Rue, producteur.Adresse, producteur.Ville, producteur.Region, producteur.Reputation };

                        MessageBox.Show("Le producteur '" + textBoxNomProducteurProducer.Text + "' a été ajouté avec succès !", "NeoSud - Confirmation");
                       
                        FormUtilisateur_Load(sender, e);
                       
                        textBoxNomProducteurProducer.Clear();
                        textBoxRaisonSocialProducer.Clear();
                        textBoxNomProducer.Clear();
                        textBoxPrenomProducer.Clear();
                        textBoxTelephoneProducer.Clear();
                        textBoxFixeProducer.Clear();
                        textBoxEmailProducer.Clear();
                        textBoxRueProducer.Clear();
                        textBoxAdresseProducer.Clear();
                        textBoxVilleProducer.Clear();
                        textBoxRegionProducer.Clear();
                        textBoxPaysProducer.Clear();
                        textBoxReputationProducer.Clear();
                        comboBoxFournisseurProducer.SelectedIndex = -1;
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

        private async void btnEditProducer_Click(object sender, EventArgs e)
        {
            string urlEdit = urlProducteur + selectedId;

            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, dynamic>
                    {
                        { "id", selectedId },
                        { "nomProducteur", textBoxNomProducteurProducer.Text },
                        { "raisonSocial", textBoxRaisonSocialProducer.Text },
                        { "nom", textBoxNomProducer.Text },
                        { "prenom", textBoxPrenomProducer.Text },
                        { "tel", textBoxTelephoneProducer.Text },
                        { "fix", textBoxFixeProducer.Text },
                        { "email", textBoxEmailProducer.Text },
                        { "rue", textBoxRueProducer.Text },
                        { "adresse", textBoxAdresseProducer.Text },
                        { "ville", textBoxVilleProducer.Text },
                        { "region", textBoxRegionProducer.Text },
                        { "pays", textBoxPaysProducer.Text },
                        { "reputation", textBoxReputationProducer.Text },
                        { "fournisseurId", comboBoxFournisseurProducer.Text },
                    };


                    string json = JsonConvert.SerializeObject(values);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);


                    HttpResponseMessage response = await client.PutAsync(urlEdit, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Le producteur '" + selectedName + "' a été modifié en '" + textBoxNomProducteurProducer.Text + "' avec succès !", "NeoSud - Confirmation");

                        FormUtilisateur_Load(sender, e);

                        textBoxNomProducteurProducer.Clear();
                        textBoxRaisonSocialProducer.Clear();
                        textBoxNomProducer.Clear();
                        textBoxPrenomProducer.Clear();
                        textBoxTelephoneProducer.Clear();
                        textBoxFixeProducer.Clear();
                        textBoxEmailProducer.Clear();
                        textBoxRueProducer.Clear();
                        textBoxAdresseProducer.Clear();
                        textBoxVilleProducer.Clear();
                        textBoxRegionProducer.Clear();
                        textBoxPaysProducer.Clear();
                        textBoxReputationProducer.Clear();
                        comboBoxFournisseurProducer.SelectedIndex = -1;
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

        private async void btnDeleteProducer_Click(object sender, EventArgs e)
        {
            // Construction de l'URL pour la requête DELETE
            string urlDelete = urlProducteur + selectedId;

            using (var client = new HttpClient())
            {

                try
                {

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.DeleteAsync(urlDelete);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Le producteur avec l'identifiant '" + selectedId + "' a été supprimé avec succès !", "NeoSud - Confirmation");

                        FormUtilisateur_Load(sender, e);

                        textBoxNomProducteurProducer.Clear();
                        textBoxRaisonSocialProducer.Clear();
                        textBoxNomProducer.Clear();
                        textBoxPrenomProducer.Clear();
                        textBoxTelephoneProducer.Clear();
                        textBoxFixeProducer.Clear();
                        textBoxEmailProducer.Clear();
                        textBoxRueProducer.Clear();
                        textBoxAdresseProducer.Clear();
                        textBoxVilleProducer.Clear();
                        textBoxRegionProducer.Clear();
                        textBoxPaysProducer.Clear();
                        textBoxReputationProducer.Clear();
                        comboBoxFournisseurProducer.SelectedIndex = -1;
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

        private void dataGridViewFournisseur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewFournisseur.Rows[rowIndex];
                selectedId = row.Cells[0].Value.ToString();

                textBoxNomFournisseur.Text = row.Cells[1].Value.ToString();
                selectedName = textBoxNomFournisseur.Text;
                textBoxTelephoneFournisseur.Text = row.Cells[2].Value.ToString();
                textBoxFixeFournisseur.Text = row.Cells[3].Value.ToString();
                textBoxEmailFournisseur.Text = row.Cells[4].Value.ToString();
                textBoxRueFournisseur.Text = row.Cells[5].Value.ToString();
                textBoxAdresseFournisseur.Text = row.Cells[6].Value.ToString();
                textBoxVilleFournisseur.Text = row.Cells[7].Value.ToString();
                textBoxRegionFournisseur.Text = row.Cells[8].Value.ToString();
                textBoxPaysFournisseur.Text = row.Cells[9].Value.ToString();
                textBoxReputationFournisseur.Text = row.Cells[10].Value.ToString();
            
            }
            else { }
        }

        private async void btnAddFournisseur_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, string>
                        {
                            { "nomFournisseur", textBoxNomFournisseur.Text },
                            { "tel", textBoxTelephoneFournisseur.Text },
                            { "fix", textBoxFixeFournisseur.Text },
                            { "email", textBoxEmailFournisseur.Text },
                            { "rue", textBoxRueFournisseur.Text },
                            { "adresse", textBoxAdresseFournisseur.Text },
                            { "ville", textBoxVilleFournisseur.Text },
                            { "region", textBoxRegionFournisseur.Text },
                            { "pays", textBoxPaysFournisseur.Text },
                            { "reputation", textBoxReputationFournisseur.Text },
                            //{ "fournisseurId", comboBoxFournisseurProducer.Text },
                        };

                    var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.PostAsync(urlFournisseur, content);


                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        Fournisseur fournisseur = JsonConvert.DeserializeObject<Fournisseur>(result);
                        string[] row = new string[] { fournisseur.NomFournisseur, fournisseur.Tel, fournisseur.Fix, fournisseur.Email, fournisseur.Rue, fournisseur.Adresse, fournisseur.Ville, fournisseur.Region, fournisseur.Reputation };

                        MessageBox.Show("Le fournisseur '" + textBoxNomFournisseur.Text + "' a été ajouté avec succès !", "NeoSud - Confirmation");

                        FormUtilisateur_Load(sender, e);

                       textBoxNomFournisseur.Clear();
                       textBoxTelephoneFournisseur.Clear();
                       textBoxFixeFournisseur.Clear();
                       textBoxEmailFournisseur.Clear();
                       textBoxRueFournisseur.Clear();
                       textBoxAdresseFournisseur.Clear();
                       textBoxVilleFournisseur.Clear();
                       textBoxRegionFournisseur.Clear();
                       textBoxPaysFournisseur.Clear();
                       textBoxReputationFournisseur.Clear();
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

        private async void btnEditFournisseur_Click(object sender, EventArgs e)
        {
            string urlEdit = urlFournisseur + selectedId;

            using (var client = new HttpClient())
            {

                try
                {

                    var values = new Dictionary<string, dynamic>
                    {
                        { "id", selectedId },
                        { "nomFournisseur", textBoxNomFournisseur.Text },
                        { "tel", textBoxTelephoneFournisseur.Text },
                        { "fix", textBoxFixeFournisseur.Text },
                        { "email", textBoxEmailFournisseur.Text },
                        { "rue", textBoxRueFournisseur.Text },
                        { "adresse", textBoxAdresseFournisseur.Text },
                        { "ville", textBoxVilleFournisseur.Text },
                        { "region", textBoxRegionFournisseur.Text },
                        { "pays", textBoxPaysFournisseur.Text },
                        { "reputation", textBoxReputationFournisseur.Text },
                        //{ "fournisseurId", comboBoxFournisseurProducer.Text },
                    };


                    string json = JsonConvert.SerializeObject(values);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);


                    HttpResponseMessage response = await client.PutAsync(urlEdit, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Le fournisseur '" + selectedName + "' a été modifié en '" + textBoxNomFournisseur.Text + "' avec succès !", "NeoSud - Confirmation");

                        FormUtilisateur_Load(sender, e);

                        textBoxNomFournisseur.Clear();
                        textBoxTelephoneFournisseur.Clear();
                        textBoxFixeFournisseur.Clear();
                        textBoxEmailFournisseur.Clear();
                        textBoxRueFournisseur.Clear();
                        textBoxAdresseFournisseur.Clear();
                        textBoxVilleFournisseur.Clear();
                        textBoxRegionFournisseur.Clear();
                        textBoxPaysFournisseur.Clear();
                        textBoxReputationFournisseur.Clear();
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

        private async void btnDeleteFournisseur_Click(object sender, EventArgs e)
        {
            // Construction de l'URL pour la requête DELETE
            string urlDelete = urlFournisseur + selectedId;

            using (var client = new HttpClient())
            {

                try
                {

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    HttpResponseMessage response = await client.DeleteAsync(urlDelete);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Le fournisseur avec l'identifiant '" + selectedId + "' a été supprimé avec succès !", "NeoSud - Confirmation");

                        FormUtilisateur_Load(sender, e);

                        textBoxNomFournisseur.Clear();
                        textBoxTelephoneFournisseur.Clear();
                        textBoxFixeFournisseur.Clear();
                        textBoxEmailFournisseur.Clear();
                        textBoxRueFournisseur.Clear();
                        textBoxAdresseFournisseur.Clear();
                        textBoxVilleFournisseur.Clear();
                        textBoxRegionFournisseur.Clear();
                        textBoxPaysFournisseur.Clear();
                        textBoxReputationFournisseur.Clear();
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

        private void tabPageUtilisateur_Click(object sender, EventArgs e)
        {

        }

        private void tabPageProducteur_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxFournisseurProducer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblFournisseurProducer_Click(object sender, EventArgs e)
        {

        }

        private void textBoxReputationProducer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPaysProducer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxRegionProducer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxVilleProducer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAdresseProducer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEmailProducer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFixeProducer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxRueProducer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTelephoneProducer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPrenomProducer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNomProducer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNomProducteurProducer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxRaisonSocialProducer_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblReputationProducer_Click(object sender, EventArgs e)
        {

        }

        private void lblPays_Click(object sender, EventArgs e)
        {

        }

        private void lblRegionProducer_Click(object sender, EventArgs e)
        {

        }

        private void lblVilleProducer_Click(object sender, EventArgs e)
        {

        }

        private void lblEmailProducer_Click(object sender, EventArgs e)
        {

        }

        private void lblFixeProducer_Click(object sender, EventArgs e)
        {

        }

        private void lblAdresseProducer_Click(object sender, EventArgs e)
        {

        }

        private void lblRueProducer_Click(object sender, EventArgs e)
        {

        }

        private void lblTelephoneProducer_Click(object sender, EventArgs e)
        {

        }

        private void lblPrenomProducer_Click(object sender, EventArgs e)
        {

        }

        private void lblNomProducer_Click(object sender, EventArgs e)
        {

        }

        private void lblNomProducteurProducer_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void lblProducteur_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void lblRaisonSocialProducer_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewProducteur_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblSirenUser_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSirenUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxMotDePasseUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTelephoneUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEmailUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPrenomUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNomUtilisateurUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNomUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblIsBusinessUser_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxRoleUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxIsBusinessUser_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblRoleUser_Click(object sender, EventArgs e)
        {

        }

        private void lblMotDePasseUser_Click(object sender, EventArgs e)
        {

        }

        private void lblTelephoneUser_Click(object sender, EventArgs e)
        {

        }

        private void lblEmailUser_Click(object sender, EventArgs e)
        {

        }

        private void lblPrenomUser_Click(object sender, EventArgs e)
        {

        }

        private void lblNomUtilisateurUser_Click(object sender, EventArgs e)
        {

        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void lblNomPage_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCategorie_Click(object sender, EventArgs e)
        {

        }

        private void lblNomUser_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewUtilisateur_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPageFournisseur_Click(object sender, EventArgs e)
        {

        }

        private void textBoxReputationFournisseur_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPaysFournisseur_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxRegionFournisseur_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxVilleFournisseur_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAdresseFournisseur_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEmailFournisseur_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFixeFournisseur_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxRueFournisseur_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTelephoneFournisseur_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNomFournisseur_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblReputationFournisseur_Click(object sender, EventArgs e)
        {

        }

        private void lblPaysFournisseur_Click(object sender, EventArgs e)
        {

        }

        private void lblRegion_Click(object sender, EventArgs e)
        {

        }

        private void lblVilleFournisseur_Click(object sender, EventArgs e)
        {

        }

        private void lblEmailFournisseur_Click(object sender, EventArgs e)
        {

        }

        private void lblFixeFournisseur_Click(object sender, EventArgs e)
        {

        }

        private void lblAdresseFournisseur_Click(object sender, EventArgs e)
        {

        }

        private void lblRueFournisseur_Click(object sender, EventArgs e)
        {

        }

        private void lblTelephoneFournisseur_Click(object sender, EventArgs e)
        {

        }

        private void lblNomFournisseur_Click(object sender, EventArgs e)
        {

        }

        private void lblFournisseur_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewFournisseur_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}