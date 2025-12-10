using System.Drawing;
using System.Windows.Forms;

namespace GSB2.Forms
{
    partial class MedicinesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            lblAppTitle = new Label();
            btnBackToMain = new Button();
            pnlSidebarSpacer = new Panel();
            pnlHeader = new Panel();
            Title_label = new Label();
            pnlHeaderButtons = new Panel();
            BtnDelete = new Button();
            BtnAdd = new Button();
            BtnRefresh = new Button();
            pnlContent = new Panel();
            dgvMedicines = new DataGridView();
            groupBoxAdd = new GroupBox();
            pnlFormRow1 = new Panel();
            labelDosage = new Label();
            txtDosage = new TextBox();
            labelName = new Label();
            txtName = new TextBox();
            pnlFormRow2 = new Panel();
            labelDescription = new Label();
            txtDescription = new TextBox();
            pnlFormRow3 = new Panel();
            labelMolecule = new Label();
            txtMolecule = new TextBox();
            BtnSave = new Button();
            pnlSidebar.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlHeaderButtons.SuspendLayout();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedicines).BeginInit();
            groupBoxAdd.SuspendLayout();
            pnlFormRow1.SuspendLayout();
            pnlFormRow2.SuspendLayout();
            pnlFormRow3.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(41, 50, 65);
            pnlSidebar.Controls.Add(lblAppTitle);
            pnlSidebar.Controls.Add(btnBackToMain);
            pnlSidebar.Controls.Add(pnlSidebarSpacer);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(4, 5, 4, 5);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(357, 1167);
            pnlSidebar.TabIndex = 0;
            // 
            // lblAppTitle
            // 
            lblAppTitle.Dock = DockStyle.Top;
            lblAppTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Location = new Point(0, 100);
            lblAppTitle.Margin = new Padding(4, 0, 4, 0);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(357, 133);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "GSB Manager";
            lblAppTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBackToMain
            // 
            btnBackToMain.BackColor = Color.FromArgb(41, 50, 65);
            btnBackToMain.Cursor = Cursors.Hand;
            btnBackToMain.Dock = DockStyle.Top;
            btnBackToMain.FlatAppearance.BorderSize = 0;
            btnBackToMain.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnBackToMain.FlatStyle = FlatStyle.Flat;
            btnBackToMain.Font = new Font("Segoe UI", 11F);
            btnBackToMain.ForeColor = Color.White;
            btnBackToMain.Location = new Point(0, 0);
            btnBackToMain.Margin = new Padding(4, 5, 4, 5);
            btnBackToMain.Name = "btnBackToMain";
            btnBackToMain.Padding = new Padding(29, 0, 0, 0);
            btnBackToMain.Size = new Size(357, 100);
            btnBackToMain.TabIndex = 1;
            btnBackToMain.Text = "⬅️  Retour au menu";
            btnBackToMain.TextAlign = ContentAlignment.MiddleLeft;
            btnBackToMain.UseVisualStyleBackColor = false;
            btnBackToMain.Click += btnBackToMain_Click;
            // 
            // pnlSidebarSpacer
            // 
            pnlSidebarSpacer.Dock = DockStyle.Fill;
            pnlSidebarSpacer.Location = new Point(0, 0);
            pnlSidebarSpacer.Margin = new Padding(4, 5, 4, 5);
            pnlSidebarSpacer.Name = "pnlSidebarSpacer";
            pnlSidebarSpacer.Size = new Size(357, 1167);
            pnlSidebarSpacer.TabIndex = 2;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(Title_label);
            pnlHeader.Controls.Add(pnlHeaderButtons);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(357, 0);
            pnlHeader.Margin = new Padding(4, 5, 4, 5);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1357, 133);
            pnlHeader.TabIndex = 1;
            // 
            // Title_label
            // 
            Title_label.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            Title_label.ForeColor = Color.FromArgb(41, 50, 65);
            Title_label.Location = new Point(43, 33);
            Title_label.Margin = new Padding(4, 0, 4, 0);
            Title_label.Name = "Title_label";
            Title_label.Size = new Size(500, 67);
            Title_label.TabIndex = 0;
            Title_label.Text = "\U0001f9ea Gestion des médicaments";
            Title_label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlHeaderButtons
            // 
            pnlHeaderButtons.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlHeaderButtons.Controls.Add(BtnDelete);
            pnlHeaderButtons.Controls.Add(BtnAdd);
            pnlHeaderButtons.Controls.Add(BtnRefresh);
            pnlHeaderButtons.Location = new Point(686, 33);
            pnlHeaderButtons.Margin = new Padding(4, 5, 4, 5);
            pnlHeaderButtons.Name = "pnlHeaderButtons";
            pnlHeaderButtons.Size = new Size(643, 67);
            pnlHeaderButtons.TabIndex = 1;
            // 
            // BtnDelete
            // 
            BtnDelete.BackColor = Color.FromArgb(231, 76, 60);
            BtnDelete.Cursor = Cursors.Hand;
            BtnDelete.FlatAppearance.BorderSize = 0;
            BtnDelete.FlatStyle = FlatStyle.Flat;
            BtnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnDelete.ForeColor = Color.White;
            BtnDelete.Location = new Point(0, 0);
            BtnDelete.Margin = new Padding(4, 5, 4, 5);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(200, 67);
            BtnDelete.TabIndex = 0;
            BtnDelete.Text = "🗑️ Supprimer";
            BtnDelete.UseVisualStyleBackColor = false;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnAdd
            // 
            BtnAdd.BackColor = Color.FromArgb(52, 152, 219);
            BtnAdd.Cursor = Cursors.Hand;
            BtnAdd.FlatAppearance.BorderSize = 0;
            BtnAdd.FlatStyle = FlatStyle.Flat;
            BtnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnAdd.ForeColor = Color.White;
            BtnAdd.Location = new Point(221, 0);
            BtnAdd.Margin = new Padding(4, 5, 4, 5);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(200, 67);
            BtnAdd.TabIndex = 1;
            BtnAdd.Text = "➕ Ajouter";
            BtnAdd.UseVisualStyleBackColor = false;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // BtnRefresh
            // 
            BtnRefresh.BackColor = Color.FromArgb(149, 165, 166);
            BtnRefresh.Cursor = Cursors.Hand;
            BtnRefresh.FlatAppearance.BorderSize = 0;
            BtnRefresh.FlatStyle = FlatStyle.Flat;
            BtnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnRefresh.ForeColor = Color.White;
            BtnRefresh.Location = new Point(443, 0);
            BtnRefresh.Margin = new Padding(4, 5, 4, 5);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(200, 67);
            BtnRefresh.TabIndex = 2;
            BtnRefresh.Text = "🔄 Rafraîchir";
            BtnRefresh.UseVisualStyleBackColor = false;
            BtnRefresh.Click += BtnRefresh_Click;
            // 
            // pnlContent
            // 
            pnlContent.AutoScroll = true;
            pnlContent.BackColor = Color.FromArgb(245, 247, 250);
            pnlContent.Controls.Add(dgvMedicines);
            pnlContent.Controls.Add(groupBoxAdd);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(357, 133);
            pnlContent.Margin = new Padding(4, 5, 4, 5);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(43, 50, 43, 50);
            pnlContent.Size = new Size(1357, 1034);
            pnlContent.TabIndex = 2;
            // 
            // dgvMedicines
            // 
            dgvMedicines.AllowUserToAddRows = false;
            dgvMedicines.AllowUserToDeleteRows = false;
            dgvMedicines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicines.BackgroundColor = Color.White;
            dgvMedicines.BorderStyle = BorderStyle.None;
            dgvMedicines.ColumnHeadersHeight = 40;
            dgvMedicines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMedicines.Location = new Point(43, 50);
            dgvMedicines.Margin = new Padding(4, 5, 4, 5);
            dgvMedicines.Name = "dgvMedicines";
            dgvMedicines.ReadOnly = true;
            dgvMedicines.RowHeadersVisible = false;
            dgvMedicines.RowHeadersWidth = 62;
            dgvMedicines.RowTemplate.Height = 35;
            dgvMedicines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicines.Size = new Size(1271, 583);
            dgvMedicines.TabIndex = 0;
            // 
            // groupBoxAdd
            // 
            groupBoxAdd.BackColor = Color.White;
            groupBoxAdd.Controls.Add(pnlFormRow1);
            groupBoxAdd.Controls.Add(pnlFormRow2);
            groupBoxAdd.Controls.Add(pnlFormRow3);
            groupBoxAdd.Controls.Add(BtnSave);
            groupBoxAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxAdd.ForeColor = Color.FromArgb(41, 50, 65);
            groupBoxAdd.Location = new Point(43, 667);
            groupBoxAdd.Margin = new Padding(4, 5, 4, 5);
            groupBoxAdd.Name = "groupBoxAdd";
            groupBoxAdd.Padding = new Padding(29, 33, 29, 33);
            groupBoxAdd.Size = new Size(1271, 350);
            groupBoxAdd.TabIndex = 1;
            groupBoxAdd.TabStop = false;
            groupBoxAdd.Text = "📝 Ajouter / Modifier un médicament";
            groupBoxAdd.Visible = false;
            // 
            // pnlFormRow1
            // 
            pnlFormRow1.Controls.Add(labelDosage);
            pnlFormRow1.Controls.Add(txtDosage);
            pnlFormRow1.Controls.Add(labelName);
            pnlFormRow1.Controls.Add(txtName);
            pnlFormRow1.Location = new Point(43, 67);
            pnlFormRow1.Margin = new Padding(4, 5, 4, 5);
            pnlFormRow1.Name = "pnlFormRow1";
            pnlFormRow1.Size = new Size(1186, 58);
            pnlFormRow1.TabIndex = 0;
            // 
            // labelDosage
            // 
            labelDosage.Font = new Font("Segoe UI", 9F);
            labelDosage.Location = new Point(0, 13);
            labelDosage.Margin = new Padding(4, 0, 4, 0);
            labelDosage.Name = "labelDosage";
            labelDosage.Size = new Size(114, 38);
            labelDosage.TabIndex = 0;
            labelDosage.Text = "Dosage";
            labelDosage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDosage
            // 
            txtDosage.BorderStyle = BorderStyle.FixedSingle;
            txtDosage.Font = new Font("Segoe UI", 10F);
            txtDosage.Location = new Point(129, 8);
            txtDosage.Margin = new Padding(4, 5, 4, 5);
            txtDosage.Name = "txtDosage";
            txtDosage.Size = new Size(399, 34);
            txtDosage.TabIndex = 1;
            // 
            // labelName
            // 
            labelName.Font = new Font("Segoe UI", 9F);
            labelName.Location = new Point(586, 13);
            labelName.Margin = new Padding(4, 0, 4, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(114, 38);
            labelName.TabIndex = 2;
            labelName.Text = "Nom";
            labelName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(714, 8);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(399, 34);
            txtName.TabIndex = 3;
            // 
            // pnlFormRow2
            // 
            pnlFormRow2.Controls.Add(labelDescription);
            pnlFormRow2.Controls.Add(txtDescription);
            pnlFormRow2.Location = new Point(43, 150);
            pnlFormRow2.Margin = new Padding(4, 5, 4, 5);
            pnlFormRow2.Name = "pnlFormRow2";
            pnlFormRow2.Size = new Size(1186, 58);
            pnlFormRow2.TabIndex = 1;
            // 
            // labelDescription
            // 
            labelDescription.Font = new Font("Segoe UI", 9F);
            labelDescription.Location = new Point(0, 13);
            labelDescription.Margin = new Padding(4, 0, 4, 0);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(114, 38);
            labelDescription.TabIndex = 0;
            labelDescription.Text = "Description";
            labelDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(129, 8);
            txtDescription.Margin = new Padding(4, 5, 4, 5);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(985, 34);
            txtDescription.TabIndex = 1;
            // 
            // pnlFormRow3
            // 
            pnlFormRow3.Controls.Add(labelMolecule);
            pnlFormRow3.Controls.Add(txtMolecule);
            pnlFormRow3.Location = new Point(43, 233);
            pnlFormRow3.Margin = new Padding(4, 5, 4, 5);
            pnlFormRow3.Name = "pnlFormRow3";
            pnlFormRow3.Size = new Size(571, 58);
            pnlFormRow3.TabIndex = 2;
            // 
            // labelMolecule
            // 
            labelMolecule.Font = new Font("Segoe UI", 9F);
            labelMolecule.Location = new Point(0, 13);
            labelMolecule.Margin = new Padding(4, 0, 4, 0);
            labelMolecule.Name = "labelMolecule";
            labelMolecule.Size = new Size(114, 38);
            labelMolecule.TabIndex = 0;
            labelMolecule.Text = "Molécule";
            labelMolecule.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMolecule
            // 
            txtMolecule.BorderStyle = BorderStyle.FixedSingle;
            txtMolecule.Font = new Font("Segoe UI", 10F);
            txtMolecule.Location = new Point(129, 8);
            txtMolecule.Margin = new Padding(4, 5, 4, 5);
            txtMolecule.Name = "txtMolecule";
            txtMolecule.Size = new Size(399, 34);
            txtMolecule.TabIndex = 1;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.FromArgb(46, 204, 113);
            BtnSave.Cursor = Cursors.Hand;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(1000, 242);
            BtnSave.Margin = new Padding(4, 5, 4, 5);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(229, 67);
            BtnSave.TabIndex = 3;
            BtnSave.Text = "💾 Enregistrer";
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // MedicinesForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1714, 1167);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1705, 1126);
            Name = "MedicinesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GSB Manager - Gestion des médicaments";
            pnlSidebar.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeaderButtons.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMedicines).EndInit();
            groupBoxAdd.ResumeLayout(false);
            pnlFormRow1.ResumeLayout(false);
            pnlFormRow1.PerformLayout();
            pnlFormRow2.ResumeLayout(false);
            pnlFormRow2.PerformLayout();
            pnlFormRow3.ResumeLayout(false);
            pnlFormRow3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // Sidebar
        private Panel pnlSidebar;
        private Label lblAppTitle;
        private Button btnBackToMain;
        private Panel pnlSidebarSpacer;

        // Header
        private Panel pnlHeader;
        private Label Title_label;
        private Panel pnlHeaderButtons;
        private Button BtnRefresh;
        private Button BtnAdd;
        private Button BtnDelete;

        // Content
        private Panel pnlContent;
        private DataGridView dgvMedicines;
        private GroupBox groupBoxAdd;
        private Panel pnlFormRow1;
        private Panel pnlFormRow2;
        private Panel pnlFormRow3;
        private Label labelDosage;
        private TextBox txtDosage;
        private Label labelName;
        private TextBox txtName;
        private Label labelDescription;
        private TextBox txtDescription;
        private Label labelMolecule;
        private TextBox txtMolecule;
        private Button BtnSave;
    }
}