using GSB2.DAO;
using GSB2.Models;
using GSB2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GSB2.Forms
{
    public partial class PrescriptionsForm : Form
    {
        private readonly PrescriptionDAO prescriptionDAO = new PrescriptionDAO();
        private readonly PatientDAO patientDAO = new PatientDAO();
        private readonly MedicineDAO medicineDAO = new MedicineDAO();
        private readonly Users currentUser;

        private int? editingPrescriptionId = null;

        public PrescriptionsForm(Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadPatients();
            LoadMedicinesGrid();
            LoadPrescriptions();
        }

        private void LoadPatients()
        {
            try
            {
                var patients = patientDAO.GetPatientsForComboBox();
                cmbPatients.DataSource = patients.Select(p => new { Id = p.Id_Patients, FullName = $"{p.Name} {p.Firstname}" }).ToList();
                cmbPatients.DisplayMember = "FullName";
                cmbPatients.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des patients : " + ex.Message);
            }
        }

        private void LoadMedicinesGrid()
        {
            dgvMedicines.Rows.Clear();
            try
            {
                var meds = medicineDAO.GetAllMedicines();
                foreach (var med in meds)
                {
                    dgvMedicines.Rows.Add(false, med.Id_Medicine, med.Names, med.Dosage + "mg", "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des médicaments : " + ex.Message);
            }
        }

        private void LoadPrescriptions()
        {
            dgvPrescriptions.DataSource = prescriptionDAO.GetAllPrescriptions();
            dgvPrescriptions.Columns["Id"].Visible = false;
        }

        private void BtnRefresh_Click(object sender, EventArgs e) => LoadPrescriptions();

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            groupBoxAdd.Visible = !groupBoxAdd.Visible;
            ClearFields();
            editingPrescriptionId = null;
        }

        private void DgvPrescriptions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvPrescriptions.Rows[e.RowIndex];
            editingPrescriptionId = Convert.ToInt32(row.Cells["Id"].Value);
            var presc = prescriptionDAO.GetPrescriptionById(editingPrescriptionId.Value);
            if (presc == null) return;

            cmbPatients.SelectedValue = presc.Id_patients;
            dtpValidity.Value = DateTime.Parse(presc.Validity);

            // Pré-remplir les médicaments et quantités
            var medList = prescriptionDAO.GetMedicinesWithQuantities(editingPrescriptionId.Value);
            foreach (DataGridViewRow dgvRow in dgvMedicines.Rows)
            {
                var medId = Convert.ToInt32(dgvRow.Cells["colId"].Value);
                var match = medList.FirstOrDefault(m => m.Id_medicine == medId);
                if (match != default)
                {
                    dgvRow.Cells["colSelect"].Value = true;
                    dgvRow.Cells["colQuantity"].Value = match.Quantity;
                }
                else
                {
                    dgvRow.Cells["colSelect"].Value = false;
                    dgvRow.Cells["colQuantity"].Value = "";
                }
            }

            groupBoxAdd.Visible = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbPatients.SelectedValue == null) return;
            int idPatient = (int)cmbPatients.SelectedValue;
            string date = dtpValidity.Value.ToString("yyyy-MM-dd");

            var selectedMeds = new List<(int Id_medicine, int Quantity)>();
            foreach (DataGridViewRow row in dgvMedicines.Rows)
            {
                bool selected = Convert.ToBoolean(row.Cells["colSelect"].Value);
                if (!selected) continue;

                int idMed = Convert.ToInt32(row.Cells["colId"].Value);
                if (!int.TryParse(row.Cells["colQuantity"].Value?.ToString(), out int qty) || qty <= 0)
                {
                    MessageBox.Show($"Quantité invalide pour {row.Cells["colName"].Value}");
                    return;
                }
                selectedMeds.Add((idMed, qty));
            }

            if (!selectedMeds.Any())
            {
                MessageBox.Show("Veuillez sélectionner au moins un médicament.");
                return;
            }

            bool success;
            if (editingPrescriptionId.HasValue)
                success = prescriptionDAO.UpdatePrescription(editingPrescriptionId.Value, date, selectedMeds);
            else
                success = prescriptionDAO.CreatePrescriptionWithMedicines(new Prescription(0, currentUser.Id_Users, idPatient, date), selectedMeds);

            if (success)
            {
                MessageBox.Show("✅ Prescription enregistrée !");
                LoadPrescriptions();
                groupBoxAdd.Visible = false;
                ClearFields();
            }
            else
                MessageBox.Show("❌ Erreur lors de l'enregistrement.");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptions.SelectedRows.Count == 0) return;
            int idPresc = Convert.ToInt32(dgvPrescriptions.SelectedRows[0].Cells["Id"].Value);
            if (MessageBox.Show("Confirmer la suppression ?", "Supprimer", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (prescriptionDAO.DeletePrescription(idPresc))
                    LoadPrescriptions();
                else
                    MessageBox.Show("❌ Erreur lors de la suppression.");
            }
        }

        private void BtnExportPdf_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une prescription.");
                return;
            }

            int idPresc = Convert.ToInt32(dgvPrescriptions.SelectedRows[0].Cells["Id"].Value);
            var presc = prescriptionDAO.GetPrescriptionById(idPresc);
            var patient = patientDAO.GetPatientById(presc.Id_patients);
            var meds = prescriptionDAO.GetMedicinesWithQuantities(idPresc)
                                      .Select(m => (medicineDAO.GetById(m.Id_medicine), m.Quantity))
                                      .ToList();
            Console.WriteLine("Prescription loaded:");
            Console.WriteLine("ID patient: " + presc.Id_patients);
            Console.WriteLine("Date: '" + presc.Validity + "'");
            Console.WriteLine("Doctor ID: " + presc.Id_users);

            PdfExporter.ExportPrescription(presc, patient, currentUser, meds);
        }


        private void ClearFields()
        {
            dtpValidity.Value = DateTime.Now;
            foreach (DataGridViewRow row in dgvMedicines.Rows)
            {
                row.Cells["colSelect"].Value = false;
                row.Cells["colQuantity"].Value = "";
            }
        }
    }
}
