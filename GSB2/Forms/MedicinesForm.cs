using GSB2.DAO;
using GSB2.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GSB2.Forms
{
    public partial class MedicinesForm : Form
    {
        private readonly MedicineDAO medicineDAO = new MedicineDAO();
        private readonly Users currentUser;

    // SB: Constructeur du formulaire de gestion des médicaments - initialise les composants et charge la liste des médicaments
      public MedicinesForm(Users user)
        {
     InitializeComponent();
       currentUser = user;
LoadMedicines();

dgvMedicines.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      }

        // SB: Charge la liste de tous les médicaments dans le DataGridView - configure les en-têtes de colonnes et masque les IDs
        private void LoadMedicines()
    {
            try
            {
        var medicines = medicineDAO.GetAll();
      dgvMedicines.DataSource = medicines;

       // Colonnes plus lisibles
      if (dgvMedicines.Columns["Id_medicine"] != null)
  dgvMedicines.Columns["Id_medicine"].Visible = false;
           //dgvMedicines.Columns["Id_medicine"].HeaderText = "ID";
           dgvMedicines.Columns["User"].HeaderText = "Ajouté par";
       dgvMedicines.Columns["Dosage"].HeaderText = "Dosage";
     dgvMedicines.Columns["Name"].HeaderText = "Nom";
           dgvMedicines.Columns["Description"].HeaderText = "Description";
     dgvMedicines.Columns["Molecule"].HeaderText = "Molécule";

 dgvMedicines.Columns["User"].DisplayIndex = 1;

       // Optionnel : cache la colonne Id_users
       if (dgvMedicines.Columns.Contains("Id_users"))
         dgvMedicines.Columns["Id_users"].Visible = false;
          }
    catch (Exception ex)
       {
     MessageBox.Show($"Erreur lors du chargement des médicaments : {ex.Message}");
       }
        }

        // SB: Gère le clic sur le bouton Actualiser - recharge la liste des médicaments depuis la base de données
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
       LoadMedicines();
   }

  // SB: Gère le clic sur le bouton Ajouter - affiche ou masque le panneau d'ajout de médicament
        private void BtnAdd_Click(object sender, EventArgs e)
        {
          groupBoxAdd.Visible = !groupBoxAdd.Visible;
        }

        // SB: Gère le clic sur le bouton Enregistrer - crée un nouveau médicament avec les données saisies et l'associe à l'utilisateur connecté
        private void BtnSave_Click(object sender, EventArgs e)
        {
        try
            {
    Medicine med = new Medicine
      {
    Id_Users = currentUser.Id_Users, // lié à l'utilisateur connecté
 Dosage = txtDosage.Text,
    Names = txtName.Text,
   Description = txtDescription.Text,
        Molecule = txtMolecule.Text
     };

                bool result = medicineDAO.Insert(med);

            if (result)
   {
           MessageBox.Show("✅ Médicament ajouté avec succès !");
   LoadMedicines();
   groupBoxAdd.Visible = false;
  ClearFields();
        }
    else
        {
          MessageBox.Show("❌ Erreur lors de l'ajout du médicament.");
     }
        }
        catch (Exception ex)
 {
      MessageBox.Show($"Erreur : {ex.Message}");
     }
    }

     // SB: Gère le clic sur le bouton Supprimer - supprime le médicament sélectionné après confirmation
     private void BtnDelete_Click(object sender, EventArgs e)
{
      if (dgvMedicines.SelectedRows.Count == 0)
  {
     MessageBox.Show("Veuillez sélectionner un médicament à supprimer.");
         return;
        }

      int id = (int)dgvMedicines.SelectedRows[0].Cells["Id_medicine"].Value;

            if (MessageBox.Show("Voulez-vous vraiment supprimer ce médicament ?", "Confirmation",
          MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
     bool result = medicineDAO.Delete(id);
  if (result)
        {
  MessageBox.Show("🗑️ Médicament supprimé avec succès !");
   LoadMedicines();
      }
        else
      {
  MessageBox.Show("Erreur lors de la suppression.");
                }
            }
      }

     // SB: Réinitialise tous les champs de saisie du formulaire d'ajout de médicament
    private void ClearFields()
 {
       txtDosage.Clear();
            txtName.Clear();
txtDescription.Clear();
   txtMolecule.Clear();
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
