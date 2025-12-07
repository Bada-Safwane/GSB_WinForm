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

        public PatientsForm(Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadPatients();
            dgvPatients.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        }

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

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            groupBoxAdd.Visible = !groupBoxAdd.Visible;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Patients patient = new Patients
                {
                    Id_Users = currentUser.Id_Users, // lié à l'utilisateur connecté
                    Firstname = txtFirstname.Text,
                    Name = txtName.Text,
                    Age = int.Parse(txtAge.Text),
                    Gender = cmbGender.SelectedItem.ToString() ?? "Inconnu"
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
                    MessageBox.Show("❌ Erreur lors de l’ajout du patient.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

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

        private void ClearFields()
        {
            txtFirstname.Clear();
            txtName.Clear();
            txtAge.Clear();
            cmbGender.SelectedIndex = -1;
        }
    }
}
