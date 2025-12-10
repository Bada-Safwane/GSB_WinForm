using GSB2.Forms;

namespace GSB2.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            lblAppTitle = new Label();
            BtnPatients = new Button();
            BtnPrescriptions = new Button();
            BtnMedicines = new Button();
            pnlSidebarSpacer = new Panel();
            pnlHeader = new Panel();
            pnlUserInfo = new Panel();
            Firstname_label = new Label();
            Role_label = new Label();
            Email_label = new Label();
            Logout_button = new Button();
            pnlContent = new Panel();
            dgvUsers = new DataGridView();
            gbModifyUser = new GroupBox();
            lblNom = new Label();
            lblPrenom = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            lblRole = new Label();
            txtNom = new TextBox();
            txtPrenom = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            chkRole = new CheckBox();
            btnSaveUser = new Button();
            btnNewUser = new Button();
            btnDeleteUser = new Button();
            pnlSidebar.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlUserInfo.SuspendLayout();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            gbModifyUser.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(41, 50, 65);
            pnlSidebar.Controls.Add(lblAppTitle);
            pnlSidebar.Controls.Add(BtnPatients);
            pnlSidebar.Controls.Add(BtnPrescriptions);
            pnlSidebar.Controls.Add(BtnMedicines);
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
            lblAppTitle.Location = new Point(0, 300);
            lblAppTitle.Margin = new Padding(4, 0, 4, 0);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(357, 133);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "GSB Manager";
            lblAppTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnPatients
            // 
            BtnPatients.BackColor = Color.FromArgb(41, 50, 65);
            BtnPatients.Cursor = Cursors.Hand;
            BtnPatients.Dock = DockStyle.Top;
            BtnPatients.FlatAppearance.BorderSize = 0;
            BtnPatients.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            BtnPatients.FlatStyle = FlatStyle.Flat;
            BtnPatients.Font = new Font("Segoe UI", 11F);
            BtnPatients.ForeColor = Color.White;
            BtnPatients.ImageAlign = ContentAlignment.MiddleLeft;
            BtnPatients.Location = new Point(0, 200);
            BtnPatients.Margin = new Padding(4, 5, 4, 5);
            BtnPatients.Name = "BtnPatients";
            BtnPatients.Padding = new Padding(29, 0, 0, 0);
            BtnPatients.Size = new Size(357, 100);
            BtnPatients.TabIndex = 1;
            BtnPatients.Text = "👩‍⚕️  Patients";
            BtnPatients.TextAlign = ContentAlignment.MiddleLeft;
            BtnPatients.UseVisualStyleBackColor = false;
            BtnPatients.Click += BtnPatients_Click;
            // 
            // BtnPrescriptions
            // 
            BtnPrescriptions.BackColor = Color.FromArgb(41, 50, 65);
            BtnPrescriptions.Cursor = Cursors.Hand;
            BtnPrescriptions.Dock = DockStyle.Top;
            BtnPrescriptions.FlatAppearance.BorderSize = 0;
            BtnPrescriptions.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            BtnPrescriptions.FlatStyle = FlatStyle.Flat;
            BtnPrescriptions.Font = new Font("Segoe UI", 11F);
            BtnPrescriptions.ForeColor = Color.White;
            BtnPrescriptions.Location = new Point(0, 100);
            BtnPrescriptions.Margin = new Padding(4, 5, 4, 5);
            BtnPrescriptions.Name = "BtnPrescriptions";
            BtnPrescriptions.Padding = new Padding(29, 0, 0, 0);
            BtnPrescriptions.Size = new Size(357, 100);
            BtnPrescriptions.TabIndex = 2;
            BtnPrescriptions.Text = "💊  Prescriptions";
            BtnPrescriptions.TextAlign = ContentAlignment.MiddleLeft;
            BtnPrescriptions.UseVisualStyleBackColor = false;
            BtnPrescriptions.Click += BtnPrescriptions_Click;
            // 
            // BtnMedicines
            // 
            BtnMedicines.BackColor = Color.FromArgb(41, 50, 65);
            BtnMedicines.Cursor = Cursors.Hand;
            BtnMedicines.Dock = DockStyle.Top;
            BtnMedicines.FlatAppearance.BorderSize = 0;
            BtnMedicines.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            BtnMedicines.FlatStyle = FlatStyle.Flat;
            BtnMedicines.Font = new Font("Segoe UI", 11F);
            BtnMedicines.ForeColor = Color.White;
            BtnMedicines.Location = new Point(0, 0);
            BtnMedicines.Margin = new Padding(4, 5, 4, 5);
            BtnMedicines.Name = "BtnMedicines";
            BtnMedicines.Padding = new Padding(29, 0, 0, 0);
            BtnMedicines.Size = new Size(357, 100);
            BtnMedicines.TabIndex = 3;
            BtnMedicines.Text = "\U0001f9ea  Médicaments";
            BtnMedicines.TextAlign = ContentAlignment.MiddleLeft;
            BtnMedicines.UseVisualStyleBackColor = false;
            BtnMedicines.Click += BtnMedicines_Click;
            // 
            // pnlSidebarSpacer
            // 
            pnlSidebarSpacer.Dock = DockStyle.Fill;
            pnlSidebarSpacer.Location = new Point(0, 0);
            pnlSidebarSpacer.Margin = new Padding(4, 5, 4, 5);
            pnlSidebarSpacer.Name = "pnlSidebarSpacer";
            pnlSidebarSpacer.Size = new Size(357, 1167);
            pnlSidebarSpacer.TabIndex = 4;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(pnlUserInfo);
            pnlHeader.Controls.Add(Logout_button);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(357, 0);
            pnlHeader.Margin = new Padding(4, 5, 4, 5);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1357, 133);
            pnlHeader.TabIndex = 1;
            // 
            // pnlUserInfo
            // 
            pnlUserInfo.Controls.Add(Firstname_label);
            pnlUserInfo.Controls.Add(Role_label);
            pnlUserInfo.Controls.Add(Email_label);
            pnlUserInfo.Location = new Point(43, 25);
            pnlUserInfo.Margin = new Padding(4, 5, 4, 5);
            pnlUserInfo.Name = "pnlUserInfo";
            pnlUserInfo.Size = new Size(714, 83);
            pnlUserInfo.TabIndex = 0;
            // 
            // Firstname_label
            // 
            Firstname_label.AutoSize = true;
            Firstname_label.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            Firstname_label.ForeColor = Color.FromArgb(41, 50, 65);
            Firstname_label.Location = new Point(0, 0);
            Firstname_label.Margin = new Padding(4, 0, 4, 0);
            Firstname_label.Name = "Firstname_label";
            Firstname_label.Size = new Size(222, 38);
            Firstname_label.TabIndex = 0;
            Firstname_label.Text = "Firstname_label";
            // 
            // Role_label
            // 
            Role_label.AutoSize = true;
            Role_label.Font = new Font("Segoe UI", 9F);
            Role_label.ForeColor = Color.FromArgb(52, 152, 219);
            Role_label.Location = new Point(3, 47);
            Role_label.Margin = new Padding(4, 0, 4, 0);
            Role_label.Name = "Role_label";
            Role_label.Size = new Size(46, 25);
            Role_label.TabIndex = 1;
            Role_label.Text = "Role";
            // 
            // Email_label
            // 
            Email_label.AutoSize = true;
            Email_label.Font = new Font("Segoe UI", 9F);
            Email_label.ForeColor = Color.Gray;
            Email_label.Location = new Point(194, 47);
            Email_label.Margin = new Padding(4, 0, 4, 0);
            Email_label.Name = "Email_label";
            Email_label.Size = new Size(54, 25);
            Email_label.TabIndex = 2;
            Email_label.Text = "Email";
            // 
            // Logout_button
            // 
            Logout_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Logout_button.BackColor = Color.FromArgb(231, 76, 60);
            Logout_button.Cursor = Cursors.Hand;
            Logout_button.FlatAppearance.BorderSize = 0;
            Logout_button.FlatStyle = FlatStyle.Flat;
            Logout_button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Logout_button.ForeColor = Color.White;
            Logout_button.Location = new Point(1129, 33);
            Logout_button.Margin = new Padding(4, 5, 4, 5);
            Logout_button.Name = "Logout_button";
            Logout_button.Size = new Size(200, 67);
            Logout_button.TabIndex = 1;
            Logout_button.Text = "🚪 Déconnexion";
            Logout_button.UseVisualStyleBackColor = false;
            Logout_button.Click += Logout_button_Click;
            // 
            // pnlContent
            // 
            pnlContent.AutoScroll = true;
            pnlContent.BackColor = Color.FromArgb(245, 247, 250);
            pnlContent.Controls.Add(dgvUsers);
            pnlContent.Controls.Add(gbModifyUser);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(357, 133);
            pnlContent.Margin = new Padding(4, 5, 4, 5);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(43, 50, 43, 50);
            pnlContent.Size = new Size(1357, 1034);
            pnlContent.TabIndex = 2;
            // 
            // dgvUsers
            // 
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.ColumnHeadersHeight = 40;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUsers.Location = new Point(43, 50);
            dgvUsers.Margin = new Padding(4, 5, 4, 5);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1271, 467);
            dgvUsers.TabIndex = 0;
            dgvUsers.Visible = false;
            dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;
            // 
            // gbModifyUser
            // 
            gbModifyUser.BackColor = Color.White;
            gbModifyUser.Controls.Add(lblNom);
            gbModifyUser.Controls.Add(lblPrenom);
            gbModifyUser.Controls.Add(lblEmail);
            gbModifyUser.Controls.Add(lblPassword);
            gbModifyUser.Controls.Add(lblRole);
            gbModifyUser.Controls.Add(txtNom);
            gbModifyUser.Controls.Add(txtPrenom);
            gbModifyUser.Controls.Add(txtEmail);
            gbModifyUser.Controls.Add(txtPassword);
            gbModifyUser.Controls.Add(chkRole);
            gbModifyUser.Controls.Add(btnSaveUser);
            gbModifyUser.Controls.Add(btnNewUser);
            gbModifyUser.Controls.Add(btnDeleteUser);
            gbModifyUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbModifyUser.ForeColor = Color.FromArgb(41, 50, 65);
            gbModifyUser.Location = new Point(43, 550);
            gbModifyUser.Margin = new Padding(4, 5, 4, 5);
            gbModifyUser.Name = "gbModifyUser";
            gbModifyUser.Padding = new Padding(29, 33, 29, 33);
            gbModifyUser.Size = new Size(1271, 417);
            gbModifyUser.TabIndex = 1;
            gbModifyUser.TabStop = false;
            gbModifyUser.Text = "📝 Gestion des utilisateurs";
            // 
            // lblNom
            // 
            lblNom.Font = new Font("Segoe UI", 9F);
            lblNom.Location = new Point(43, 67);
            lblNom.Margin = new Padding(4, 0, 4, 0);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(143, 38);
            lblNom.TabIndex = 0;
            lblNom.Text = "Nom";
            // 
            // lblPrenom
            // 
            lblPrenom.Font = new Font("Segoe UI", 9F);
            lblPrenom.Location = new Point(43, 150);
            lblPrenom.Margin = new Padding(4, 0, 4, 0);
            lblPrenom.Name = "lblPrenom";
            lblPrenom.Size = new Size(143, 38);
            lblPrenom.TabIndex = 1;
            lblPrenom.Text = "Prénom";
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.Location = new Point(43, 233);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(143, 38);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Segoe UI", 9F);
            lblPassword.Location = new Point(643, 67);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(143, 38);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Mot de passe";
            // 
            // lblRole
            // 
            lblRole.Font = new Font("Segoe UI", 9F);
            lblRole.Location = new Point(643, 150);
            lblRole.Margin = new Padding(4, 0, 4, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(171, 38);
            lblRole.TabIndex = 4;
            lblRole.Text = "Administrateur";
            // 
            // txtNom
            // 
            txtNom.BorderStyle = BorderStyle.FixedSingle;
            txtNom.Font = new Font("Segoe UI", 10F);
            txtNom.Location = new Point(194, 67);
            txtNom.Margin = new Padding(4, 5, 4, 5);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(399, 34);
            txtNom.TabIndex = 5;
            // 
            // txtPrenom
            // 
            txtPrenom.BorderStyle = BorderStyle.FixedSingle;
            txtPrenom.Font = new Font("Segoe UI", 10F);
            txtPrenom.Location = new Point(194, 150);
            txtPrenom.Margin = new Padding(4, 5, 4, 5);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(399, 34);
            txtPrenom.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(194, 233);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(399, 34);
            txtEmail.TabIndex = 7;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(814, 67);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(399, 34);
            txtPassword.TabIndex = 8;
            // 
            // chkRole
            // 
            chkRole.Font = new Font("Segoe UI", 9F);
            chkRole.Location = new Point(814, 150);
            chkRole.Margin = new Padding(4, 5, 4, 5);
            chkRole.Name = "chkRole";
            chkRole.Size = new Size(29, 40);
            chkRole.TabIndex = 9;
            // 
            // btnSaveUser
            // 
            btnSaveUser.BackColor = Color.FromArgb(46, 204, 113);
            btnSaveUser.Cursor = Cursors.Hand;
            btnSaveUser.FlatAppearance.BorderSize = 0;
            btnSaveUser.FlatStyle = FlatStyle.Flat;
            btnSaveUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveUser.ForeColor = Color.White;
            btnSaveUser.Location = new Point(643, 317);
            btnSaveUser.Margin = new Padding(4, 5, 4, 5);
            btnSaveUser.Name = "btnSaveUser";
            btnSaveUser.Size = new Size(229, 67);
            btnSaveUser.TabIndex = 10;
            btnSaveUser.Text = "💾 Enregistrer";
            btnSaveUser.UseVisualStyleBackColor = false;
            btnSaveUser.Click += BtnSaveUser_Click;
            // 
            // btnNewUser
            // 
            btnNewUser.BackColor = Color.FromArgb(52, 152, 219);
            btnNewUser.Cursor = Cursors.Hand;
            btnNewUser.FlatAppearance.BorderSize = 0;
            btnNewUser.FlatStyle = FlatStyle.Flat;
            btnNewUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNewUser.ForeColor = Color.White;
            btnNewUser.Location = new Point(900, 317);
            btnNewUser.Margin = new Padding(4, 5, 4, 5);
            btnNewUser.Name = "btnNewUser";
            btnNewUser.Size = new Size(229, 67);
            btnNewUser.TabIndex = 11;
            btnNewUser.Text = "➕ Nouveau";
            btnNewUser.UseVisualStyleBackColor = false;
            btnNewUser.Click += BtnNewUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = Color.FromArgb(231, 76, 60);
            btnDeleteUser.Cursor = Cursors.Hand;
            btnDeleteUser.FlatAppearance.BorderSize = 0;
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(386, 317);
            btnDeleteUser.Margin = new Padding(4, 5, 4, 5);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(229, 67);
            btnDeleteUser.TabIndex = 12;
            btnDeleteUser.Text = "🗑️ Supprimer";
            btnDeleteUser.UseVisualStyleBackColor = false;
            btnDeleteUser.Click += BtnDeleteUser_Click;
            // 
            // MainForm
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
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GSB Manager - Espace Utilisateur";
            pnlSidebar.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlUserInfo.ResumeLayout(false);
            pnlUserInfo.PerformLayout();
            pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            gbModifyUser.ResumeLayout(false);
            gbModifyUser.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // Sidebar
        private Panel pnlSidebar;
        private Label lblAppTitle;
        private Button BtnPatients;
        private Button BtnPrescriptions;
        private Button BtnMedicines;
        private Panel pnlSidebarSpacer;

        // Header
        private Panel pnlHeader;
        private Panel pnlUserInfo;
        private Label Firstname_label;
        private Label Role_label;
        private Label Email_label;
        private Button Logout_button;

        // Content
        private Panel pnlContent;
        private DataGridView dgvUsers;
        private GroupBox gbModifyUser;
        private TextBox txtNom;
        private TextBox txtPrenom;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private CheckBox chkRole;
        private Button btnSaveUser;
        private Button btnNewUser;
        private Button btnDeleteUser;
        private Label lblNom;
        private Label lblPrenom;
        private Label lblEmail;
        private Label lblPassword;
        private Label lblRole;
    }
}