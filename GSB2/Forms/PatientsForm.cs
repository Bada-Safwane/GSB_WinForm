using GSB2.DAO;
using GSB2.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GSB2.Forms
{
    public partial class PatientsForm : Form
    {
        private readonly PatientDAO patientDAO = new PatientDAO();
        private readonly Users currentUser;

        // SB: Constructeur du formulaire de gestion des patients - initialise les composants et charge la liste des patients
        public PatientsForm(Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadPatients();
            dgvPatients.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        }

        // SB: Charge la liste de tous les patients dans le DataGridView - configure les en-têtes de colonnes et masque l'ID
        private void LoadPatients()
        {
            try
            {
                var patients = patientDAO.GetAllPatients();
                dgvPatients.DataSource = patients;

                if (dgvPatients.Columns["Id"] != null)
                    dgvPatients.Columns["Id"].Visible = false;
                //dgvPatients.Columns["Id"].HeaderText = "ID";
                dgvPatients.Columns["Firstname"].HeaderText = "Prénom";
                dgvPatients.Columns["Name"].HeaderText = "Nom";
                dgvPatients.Columns["Age"].HeaderText = "Âge";
                dgvPatients.Columns["Gender"].HeaderText = "Genre";
                dgvPatients.Columns["Doctor"].HeaderText = "Médecin référent";

                // Déplacer la colonne Doctor à côté de l'ID
                dgvPatients.Columns["Doctor"].DisplayIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des patients : " + ex.Message);
            }
        }

        // SB: Gère le clic sur le bouton Actualiser - recharge la liste des patients depuis la base de données
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadPatients();
        }

        // SB: Gère le clic sur le bouton Ajouter - affiche ou masque le panneau d'ajout de patient
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            groupBoxAdd.Visible = !groupBoxAdd.Visible;
        }

        // SB: Gère le clic sur le bouton Enregistrer - crée un nouveau patient avec les données saisies et l'associe à l'utilisateur connecté
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation des champs vides
                if (string.IsNullOrWhiteSpace(txtFirstname.Text))
                {
                    MessageBox.Show("Veuillez saisir un prénom.", "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFirstname.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Veuillez saisir un nom.", "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAge.Text))
                {
                    MessageBox.Show("Veuillez saisir un âge.", "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAge.Focus();
                    return;
                }

                // Validation de l'âge : doit être un entier valide
                if (!int.TryParse(txtAge.Text.Trim(), out int age))
                {
                    MessageBox.Show("L'âge doit être un nombre entier valide.", "Âge invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAge.Focus();
                    txtAge.SelectAll();
                    return;
                }

                // Validation de la plage d'âge (0-150)
                if (age < 0 || age > 150)
                {
                    MessageBox.Show("L'âge doit être compris entre 0 et 150 ans.", "Âge invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAge.Focus();
                    txtAge.SelectAll();
                    return;
                }

                // Validation du genre
                if (cmbGender.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner un genre.", "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbGender.Focus();
                    return;
                }

                Patients patient = new Patients
                {
                    Id_Users = currentUser.Id_Users, // lié à l'utilisateur connecté
                    Firstname = txtFirstname.Text.Trim(),
                    Name = txtName.Text.Trim(),
                    Age = age,
                    Gender = cmbGender.SelectedItem.ToString()
                };

                bool result = patientDAO.Insert(patient);

                if (result)
                {
                    MessageBox.Show("✅ Patient ajouté avec succès !");
                    LoadPatients();
                    groupBoxAdd.Visible = false;
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("❌ Erreur lors de l'ajout du patient.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        // SB: Gère le clic sur le bouton Supprimer - supprime le patient sélectionné après confirmation
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un patient à supprimer.");
                return;
            }

            int id = (int)dgvPatients.SelectedRows[0].Cells["Id"].Value;

            if (MessageBox.Show("Voulez-vous vraiment supprimer ce patient ?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bool result = patientDAO.DeletePatient(id);
                if (result)
                {
                    MessageBox.Show("🗑️ Patient supprimé avec succès !");
                    LoadPatients();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la suppression.");
                }
            }
        }

        // SB: Réinitialise tous les champs de saisie du formulaire d'ajout de patient
        private void ClearFields()
        {
            txtFirstname.Clear();
            txtName.Clear();
            txtAge.Clear();
            cmbGender.SelectedIndex = -1;
        }

        // SB: Gère le clic sur le bouton Retour - ferme le formulaire actuel et retourne au menu principal
        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm newForm = new MainForm(currentUser);

            // Show the new form
            newForm.Show();
        }
    }
}
