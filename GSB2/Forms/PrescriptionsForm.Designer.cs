using System.Drawing;
using System.Windows.Forms;

namespace GSB2.Forms
{
    partial class PrescriptionsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
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
            BtnExportPdf = new Button();
            BtnDelete = new Button();
            BtnAdd = new Button();
            BtnRefresh = new Button();
            pnlContent = new Panel();
            dgvPrescriptions = new DataGridView();
            groupBoxAdd = new GroupBox();
            pnlFormLeft = new Panel();
            labelPatient = new Label();
            cmbPatients = new ComboBox();
            labelValidity = new Label();
            dtpValidity = new DateTimePicker();
            pnlFormRight = new Panel();
            labelMedicines = new Label();
            dgvMedicines = new DataGridView();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            BtnSave = new Button();
            pnlSidebar.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlHeaderButtons.SuspendLayout();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrescriptions).BeginInit();
            groupBoxAdd.SuspendLayout();
            pnlFormLeft.SuspendLayout();
            pnlFormRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedicines).BeginInit();
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
            Title_label.Size = new Size(455, 67);
            Title_label.TabIndex = 0;
            Title_label.Text = "💊 Gestion des prescriptions";
            Title_label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlHeaderButtons
            // 
            pnlHeaderButtons.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlHeaderButtons.Controls.Add(BtnExportPdf);
            pnlHeaderButtons.Controls.Add(BtnDelete);
            pnlHeaderButtons.Controls.Add(BtnAdd);
            pnlHeaderButtons.Controls.Add(BtnRefresh);
            pnlHeaderButtons.Location = new Point(486, 33);
            pnlHeaderButtons.Margin = new Padding(4, 5, 4, 5);
            pnlHeaderButtons.Name = "pnlHeaderButtons";
            pnlHeaderButtons.Size = new Size(843, 67);
            pnlHeaderButtons.TabIndex = 1;
            // 
            // BtnExportPdf
            // 
            BtnExportPdf.BackColor = Color.FromArgb(155, 89, 182);
            BtnExportPdf.Cursor = Cursors.Hand;
            BtnExportPdf.FlatAppearance.BorderSize = 0;
            BtnExportPdf.FlatStyle = FlatStyle.Flat;
            BtnExportPdf.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnExportPdf.ForeColor = Color.White;
            BtnExportPdf.Location = new Point(13, 0);
            BtnExportPdf.Margin = new Padding(4, 5, 4, 5);
            BtnExportPdf.Name = "BtnExportPdf";
            BtnExportPdf.Size = new Size(193, 67);
            BtnExportPdf.TabIndex = 0;
            BtnExportPdf.Text = "📄 Export PDF";
            BtnExportPdf.UseVisualStyleBackColor = false;
            BtnExportPdf.Click += BtnExportPdf_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.BackColor = Color.FromArgb(231, 76, 60);
            BtnDelete.Cursor = Cursors.Hand;
            BtnDelete.FlatAppearance.BorderSize = 0;
            BtnDelete.FlatStyle = FlatStyle.Flat;
            BtnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnDelete.ForeColor = Color.White;
            BtnDelete.Location = new Point(225, 0);
            BtnDelete.Margin = new Padding(4, 5, 4, 5);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(193, 67);
            BtnDelete.TabIndex = 1;
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
            BtnAdd.Location = new Point(437, 0);
            BtnAdd.Margin = new Padding(4, 5, 4, 5);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(193, 67);
            BtnAdd.TabIndex = 2;
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
            BtnRefresh.Location = new Point(650, 0);
            BtnRefresh.Margin = new Padding(4, 5, 4, 5);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(193, 67);
            BtnRefresh.TabIndex = 3;
            BtnRefresh.Text = "🔄 Rafraîchir";
            BtnRefresh.UseVisualStyleBackColor = false;
            BtnRefresh.Click += BtnRefresh_Click;
            // 
            // pnlContent
            // 
            pnlContent.AutoScroll = true;
            pnlContent.BackColor = Color.FromArgb(245, 247, 250);
            pnlContent.Controls.Add(dgvPrescriptions);
            pnlContent.Controls.Add(groupBoxAdd);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(357, 133);
            pnlContent.Margin = new Padding(4, 5, 4, 5);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(43, 50, 43, 50);
            pnlContent.Size = new Size(1357, 1034);
            pnlContent.TabIndex = 2;
            // 
            // dgvPrescriptions
            // 
            dgvPrescriptions.AllowUserToAddRows = false;
            dgvPrescriptions.AllowUserToDeleteRows = false;
            dgvPrescriptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrescriptions.BackgroundColor = Color.White;
            dgvPrescriptions.BorderStyle = BorderStyle.None;
            dgvPrescriptions.ColumnHeadersHeight = 40;
            dgvPrescriptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPrescriptions.Location = new Point(43, 50);
            dgvPrescriptions.Margin = new Padding(4, 5, 4, 5);
            dgvPrescriptions.MultiSelect = false;
            dgvPrescriptions.Name = "dgvPrescriptions";
            dgvPrescriptions.ReadOnly = true;
            dgvPrescriptions.RowHeadersVisible = false;
            dgvPrescriptions.RowHeadersWidth = 62;
            dgvPrescriptions.RowTemplate.Height = 35;
            dgvPrescriptions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrescriptions.Size = new Size(1271, 500);
            dgvPrescriptions.TabIndex = 0;
            dgvPrescriptions.CellClick += DgvPrescriptions_CellClick;
            // 
            // groupBoxAdd
            // 
            groupBoxAdd.BackColor = Color.White;
            groupBoxAdd.Controls.Add(pnlFormLeft);
            groupBoxAdd.Controls.Add(pnlFormRight);
            groupBoxAdd.Controls.Add(BtnSave);
            groupBoxAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxAdd.ForeColor = Color.FromArgb(41, 50, 65);
            groupBoxAdd.Location = new Point(43, 583);
            groupBoxAdd.Margin = new Padding(4, 5, 4, 5);
            groupBoxAdd.Name = "groupBoxAdd";
            groupBoxAdd.Padding = new Padding(29, 33, 29, 33);
            groupBoxAdd.Size = new Size(1271, 400);
            groupBoxAdd.TabIndex = 1;
            groupBoxAdd.TabStop = false;
            groupBoxAdd.Text = "📝 Ajouter / Éditer une prescription";
            groupBoxAdd.Visible = false;
            // 
            // pnlFormLeft
            // 
            pnlFormLeft.Controls.Add(labelPatient);
            pnlFormLeft.Controls.Add(cmbPatients);
            pnlFormLeft.Controls.Add(labelValidity);
            pnlFormLeft.Controls.Add(dtpValidity);
            pnlFormLeft.Location = new Point(43, 67);
            pnlFormLeft.Margin = new Padding(4, 5, 4, 5);
            pnlFormLeft.Name = "pnlFormLeft";
            pnlFormLeft.Size = new Size(500, 250);
            pnlFormLeft.TabIndex = 0;
            // 
            // labelPatient
            // 
            labelPatient.Font = new Font("Segoe UI", 9F);
            labelPatient.Location = new Point(0, 13);
            labelPatient.Margin = new Padding(4, 0, 4, 0);
            labelPatient.Name = "labelPatient";
            labelPatient.Size = new Size(114, 38);
            labelPatient.TabIndex = 0;
            labelPatient.Text = "Patient";
            labelPatient.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbPatients
            // 
            cmbPatients.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPatients.Font = new Font("Segoe UI", 10F);
            cmbPatients.FormattingEnabled = true;
            cmbPatients.Location = new Point(129, 8);
            cmbPatients.Margin = new Padding(4, 5, 4, 5);
            cmbPatients.Name = "cmbPatients";
            cmbPatients.Size = new Size(355, 36);
            cmbPatients.TabIndex = 1;
            // 
            // labelValidity
            // 
            labelValidity.Font = new Font("Segoe UI", 9F);
            labelValidity.Location = new Point(0, 97);
            labelValidity.Margin = new Padding(4, 0, 4, 0);
            labelValidity.Name = "labelValidity";
            labelValidity.Size = new Size(114, 38);
            labelValidity.TabIndex = 2;
            labelValidity.Text = "Validité";
            labelValidity.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpValidity
            // 
            dtpValidity.Font = new Font("Segoe UI", 10F);
            dtpValidity.Location = new Point(129, 92);
            dtpValidity.Margin = new Padding(4, 5, 4, 5);
            dtpValidity.Name = "dtpValidity";
            dtpValidity.Size = new Size(355, 34);
            dtpValidity.TabIndex = 3;
            // 
            // pnlFormRight
            // 
            pnlFormRight.Controls.Add(labelMedicines);
            pnlFormRight.Controls.Add(dgvMedicines);
            pnlFormRight.Location = new Point(586, 67);
            pnlFormRight.Margin = new Padding(4, 5, 4, 5);
            pnlFormRight.Name = "pnlFormRight";
            pnlFormRight.Size = new Size(643, 250);
            pnlFormRight.TabIndex = 1;
            // 
            // labelMedicines
            // 
            labelMedicines.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelMedicines.Location = new Point(0, 0);
            labelMedicines.Margin = new Padding(4, 0, 4, 0);
            labelMedicines.Name = "labelMedicines";
            labelMedicines.Size = new Size(214, 33);
            labelMedicines.TabIndex = 0;
            labelMedicines.Text = "Médicaments";
            labelMedicines.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvMedicines
            // 
            dgvMedicines.AllowUserToAddRows = false;
            dgvMedicines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicines.BackgroundColor = Color.White;
            dgvMedicines.ColumnHeadersHeight = 30;
            dgvMedicines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMedicines.Columns.AddRange(new DataGridViewColumn[] { dataGridViewCheckBoxColumn1, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dgvMedicines.Location = new Point(0, 42);
            dgvMedicines.Margin = new Padding(4, 5, 4, 5);
            dgvMedicines.Name = "dgvMedicines";
            dgvMedicines.RowHeadersVisible = false;
            dgvMedicines.RowHeadersWidth = 62;
            dgvMedicines.RowTemplate.Height = 28;
            dgvMedicines.Size = new Size(643, 208);
            dgvMedicines.TabIndex = 1;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.MinimumWidth = 8;
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.MinimumWidth = 8;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.FromArgb(46, 204, 113);
            BtnSave.Cursor = Cursors.Hand;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnSave.ForeColor = Color.White;
            BtnSave.Location = new Point(1000, 317);
            BtnSave.Margin = new Padding(4, 5, 4, 5);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(229, 67);
            BtnSave.TabIndex = 2;
            BtnSave.Text = "💾 Enregistrer";
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // PrescriptionsForm
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
            Name = "PrescriptionsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GSB Manager - Gestion des prescriptions";
            pnlSidebar.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeaderButtons.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPrescriptions).EndInit();
            groupBoxAdd.ResumeLayout(false);
            pnlFormLeft.ResumeLayout(false);
            pnlFormRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMedicines).EndInit();
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
        private Button BtnExportPdf;
        private Button BtnRefresh;
        private Button BtnAdd;
        private Button BtnDelete;

        // Content
        private Panel pnlContent;
        private DataGridView dgvPrescriptions;
        private GroupBox groupBoxAdd;
        private Panel pnlFormLeft;
        private Panel pnlFormRight;
        private Label labelPatient;
        private ComboBox cmbPatients;
        private Label labelValidity;
        private DateTimePicker dtpValidity;
        private Label labelMedicines;
        private DataGridView dgvMedicines;
        private Button BtnSave;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}