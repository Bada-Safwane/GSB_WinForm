using System;
using System.Drawing;
using System.Windows.Forms;

namespace GSB2.Forms
{
    partial class PatientsForm
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
            dgvPatients = new DataGridView();
            groupBoxAdd = new GroupBox();
            pnlFormRow1 = new Panel();
            labelFirstname = new Label();
            txtFirstname = new TextBox();
            labelName = new Label();
            txtName = new TextBox();
            pnlFormRow2 = new Panel();
            labelAge = new Label();
            txtAge = new TextBox();
            labelGender = new Label();
            cmbGender = new ComboBox();
            BtnSave = new Button();
            pnlSidebar.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlHeaderButtons.SuspendLayout();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            groupBoxAdd.SuspendLayout();
            pnlFormRow1.SuspendLayout();
            pnlFormRow2.SuspendLayout();
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
            Title_label.Text = "👩‍⚕️ Gestion des patients";
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
            pnlContent.Controls.Add(dgvPatients);
            pnlContent.Controls.Add(groupBoxAdd);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(357, 133);
            pnlContent.Margin = new Padding(4, 5, 4, 5);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(43, 50, 43, 50);
            pnlContent.Size = new Size(1357, 1034);
            pnlContent.TabIndex = 2;
            // 
            // dgvPatients
            // 
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.BackgroundColor = Color.White;
            dgvPatients.BorderStyle = BorderStyle.None;
            dgvPatients.ColumnHeadersHeight = 40;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPatients.Location = new Point(43, 50);
            dgvPatients.Margin = new Padding(4, 5, 4, 5);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.ReadOnly = true;
            dgvPatients.RowHeadersVisible = false;
            dgvPatients.RowHeadersWidth = 62;
            dgvPatients.RowTemplate.Height = 35;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new Size(1271, 583);
            dgvPatients.TabIndex = 0;
            // 
            // groupBoxAdd
            // 
            groupBoxAdd.BackColor = Color.White;
            groupBoxAdd.Controls.Add(pnlFormRow1);
            groupBoxAdd.Controls.Add(pnlFormRow2);
            groupBoxAdd.Controls.Add(BtnSave);
            groupBoxAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxAdd.ForeColor = Color.FromArgb(41, 50, 65);
            groupBoxAdd.Location = new Point(43, 667);
            groupBoxAdd.Margin = new Padding(4, 5, 4, 5);
            groupBoxAdd.Name = "groupBoxAdd";
            groupBoxAdd.Padding = new Padding(29, 33, 29, 33);
            groupBoxAdd.Size = new Size(1271, 300);
            groupBoxAdd.TabIndex = 1;
            groupBoxAdd.TabStop = false;
            groupBoxAdd.Text = "📝 Ajouter / Modifier un patient";
            groupBoxAdd.Visible = false;
            // 
            // pnlFormRow1
            // 
            pnlFormRow1.Controls.Add(labelFirstname);
            pnlFormRow1.Controls.Add(txtFirstname);
            pnlFormRow1.Controls.Add(labelName);
            pnlFormRow1.Controls.Add(txtName);
            pnlFormRow1.Location = new Point(43, 67);
            pnlFormRow1.Margin = new Padding(4, 5, 4, 5);
            pnlFormRow1.Name = "pnlFormRow1";
            pnlFormRow1.Size = new Size(1186, 58);
            pnlFormRow1.TabIndex = 0;
            // 
            // labelFirstname
            // 
            labelFirstname.Font = new Font("Segoe UI", 9F);
            labelFirstname.Location = new Point(0, 13);
            labelFirstname.Margin = new Padding(4, 0, 4, 0);
            labelFirstname.Name = "labelFirstname";
            labelFirstname.Size = new Size(114, 38);
            labelFirstname.TabIndex = 0;
            labelFirstname.Text = "Prénom";
            labelFirstname.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtFirstname
            // 
            txtFirstname.BorderStyle = BorderStyle.FixedSingle;
            txtFirstname.Font = new Font("Segoe UI", 10F);
            txtFirstname.Location = new Point(129, 8);
            txtFirstname.Margin = new Padding(4, 5, 4, 5);
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new Size(399, 34);
            txtFirstname.TabIndex = 1;
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
            pnlFormRow2.Controls.Add(labelAge);
            pnlFormRow2.Controls.Add(txtAge);
            pnlFormRow2.Controls.Add(labelGender);
            pnlFormRow2.Controls.Add(cmbGender);
            pnlFormRow2.Location = new Point(43, 150);
            pnlFormRow2.Margin = new Padding(4, 5, 4, 5);
            pnlFormRow2.Name = "pnlFormRow2";
            pnlFormRow2.Size = new Size(714, 58);
            pnlFormRow2.TabIndex = 1;
            // 
            // labelAge
            // 
            labelAge.Font = new Font("Segoe UI", 9F);
            labelAge.Location = new Point(0, 13);
            labelAge.Margin = new Padding(4, 0, 4, 0);
            labelAge.Name = "labelAge";
            labelAge.Size = new Size(114, 38);
            labelAge.TabIndex = 0;
            labelAge.Text = "Âge";
            labelAge.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtAge
            // 
            txtAge.BorderStyle = BorderStyle.FixedSingle;
            txtAge.Font = new Font("Segoe UI", 10F);
            txtAge.Location = new Point(129, 8);
            txtAge.Margin = new Padding(4, 5, 4, 5);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(142, 34);
            txtAge.TabIndex = 1;
            // 
            // labelGender
            // 
            labelGender.Font = new Font("Segoe UI", 9F);
            labelGender.Location = new Point(343, 13);
            labelGender.Margin = new Padding(4, 0, 4, 0);
            labelGender.Name = "labelGender";
            labelGender.Size = new Size(114, 38);
            labelGender.TabIndex = 2;
            labelGender.Text = "Genre";
            labelGender.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.Font = new Font("Segoe UI", 10F);
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "H", "F" });
            cmbGender.Location = new Point(471, 8);
            cmbGender.Margin = new Padding(4, 5, 4, 5);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(213, 36);
            cmbGender.TabIndex = 3;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.FromArgb(46, 204, 113);
            BtnSave.Cursor = Cursors.Hand;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(1000, 217);
            BtnSave.Margin = new Padding(4, 5, 4, 5);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(229, 67);
            BtnSave.TabIndex = 2;
            BtnSave.Text = "💾 Enregistrer";
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // PatientsForm
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
            Name = "PatientsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GSB Manager - Gestion des patients";
            pnlSidebar.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeaderButtons.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            groupBoxAdd.ResumeLayout(false);
            pnlFormRow1.ResumeLayout(false);
            pnlFormRow1.PerformLayout();
            pnlFormRow2.ResumeLayout(false);
            pnlFormRow2.PerformLayout();
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
        private DataGridView dgvPatients;
        private GroupBox groupBoxAdd;
        private Panel pnlFormRow1;
        private Panel pnlFormRow2;
        private Label labelFirstname;
        private TextBox txtFirstname;
        private Label labelName;
        private TextBox txtName;
        private Label labelAge;
        private TextBox txtAge;
        private Label labelGender;
        private ComboBox cmbGender;
        private Button BtnSave;
    }
}