using GSB2.DAO;
using GSB2.Forms;
using GSB2.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GSB2.Forms
{
    public partial class MainForm : Form
    {
        private readonly Users connectedUser;
        private int? selectedUserId = null;

        public MainForm(Users user)
        {
            InitializeComponent();
            connectedUser = user; 
            LoadUserData();
            dvgUsersLoadContent();
        }

        private void LoadUserData()
        {
            // Update the welcome text
            Firstname_label.Text = $"Bienvenue {connectedUser.Firstname} {connectedUser.Name} 👋";

            // Update the role label
            if (!connectedUser.Role)
                Role_label.Text = "Rôle : Médecin / Prescripteur";
            else
                Role_label.Text = "Rôle : Administrateur";

            // Show delete button only for admins
            btnDeleteUser.Visible = connectedUser.Role;

            // Update the email label
            Email_label.Text = $"Email : {connectedUser.Email}";
        }


        private void dvgUsersLoadContent()
        {
            if (connectedUser.Role)
            {
                var Users = new UserDAO();
                dgvUsers.Visible = true;
                dgvUsers.AutoGenerateColumns = true;
                dgvUsers.DataSource = Users.GetAllUsers();

                if (dgvUsers.Columns["Id_users"] != null)
                    dgvUsers.Columns["Id_users"].Visible = false;

                if (dgvUsers.Columns["Password"] != null)
                    dgvUsers.Columns["Password"].Visible = false;

                dgvUsers.Columns["Name"].HeaderText = "Nom";
                dgvUsers.Columns["FirstName"].HeaderText = "Prénom";
                dgvUsers.Columns["Email"].HeaderText = "E-mail";
                dgvUsers.Columns["Role"].HeaderText = "Administrateur ?";
            }
        }

        private void DgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                var row = dgvUsers.SelectedRows[0];
                selectedUserId = Convert.ToInt32(row.Cells["Id_users"].Value);
                txtNom.Text = row.Cells["Name"].Value.ToString();
                txtPrenom.Text = row.Cells["FirstName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                chkRole.Checked = Convert.ToBoolean(row.Cells["Role"].Value);
                txtPassword.Text = "";
            }
        }

        private void BtnNewUser_Click(object sender, EventArgs e)
        {
            selectedUserId = null;
            txtNom.Text = "";
            txtPrenom.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            chkRole.Checked = false;
            dgvUsers.ClearSelection();
        }

        private void BtnSaveUser_Click(object sender, EventArgs e)
        {
            var dao = new UserDAO();

            string email = txtEmail.Text.Trim();
            string name = txtNom.Text.Trim();
            string firstname = txtPrenom.Text.Trim();
            string password = txtPassword.Text.Trim();
            bool role = chkRole.Checked;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(firstname))
            {
                MessageBox.Show("Veuillez remplir tous les champs requis (nom, prénom, email).", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success;
            if (selectedUserId == null)
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Le mot de passe est requis pour créer un utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                success = dao.CreateUser(email, password, name, firstname, role);
            }
            else
            {
                var updatedUser = new Users((int)selectedUserId,
                    firstname, name, email, role);
                success = dao.UpdateUser(updatedUser);
            }

            if (success)
            {
                MessageBox.Show("✅ Enregistrement effectué avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dvgUsersLoadContent();
                BtnNewUser_Click(null, null);
            }
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            if (selectedUserId == null)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur à supprimer.", "Aucun utilisateur sélectionné", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Voulez-vous vraiment supprimer cet utilisateur ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var dao = new UserDAO();
                bool success = dao.DeleteUser((int)selectedUserId);

                if (success)
                {
                    MessageBox.Show("✅ Utilisateur supprimé avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dvgUsersLoadContent();
                    BtnNewUser_Click(null, null); // Réinitialiser le formulaire
                }
            }
        }


        private void Logout_button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez-vous vous déconnecter ?", "Déconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                ConnexionForm loginForm = new ConnexionForm();
                loginForm.Show();
            }
        }

        private void BtnPatients_Click(object sender, EventArgs e)
        {
            PatientsForm f = new PatientsForm(connectedUser);
            f.Show();
        }

        private void BtnPrescriptions_Click(object sender, EventArgs e)
        {
            PrescriptionsForm f = new PrescriptionsForm(connectedUser);
            f.Show();
        }

        private void BtnMedicines_Click(object sender, EventArgs e)
        {
            MedicinesForm f = new MedicinesForm(connectedUser);
            f.Show();
        }
    }
}
