namespace GSB2.Forms
{
    partial class RegisterForm
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
            pnlMain = new Panel();
            pnlCard = new Panel();
            labelTitle = new Label();
            labelSubtitle = new Label();
            pnlForm = new Panel();
            labelPrenom = new Label();
            txtFirstname = new TextBox();
            labelNom = new Label();
            txtName = new TextBox();
            labelEmail = new Label();
            txtEmail = new TextBox();
            labelPassword = new Label();
            txtPassword = new TextBox();
            buttonCreateAccount = new Button();
            btnBackToLogin = new Button();

            pnlMain.SuspendLayout();
            pnlCard.SuspendLayout();
            pnlForm.SuspendLayout();
            SuspendLayout();

            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(245, 247, 250);
            pnlMain.Controls.Add(pnlCard);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(50);
            pnlMain.Size = new Size(600, 700);
            pnlMain.TabIndex = 0;

            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(labelTitle);
            pnlCard.Controls.Add(labelSubtitle);
            pnlCard.Controls.Add(pnlForm);
            pnlCard.Controls.Add(buttonCreateAccount);
            pnlCard.Controls.Add(btnBackToLogin);
            pnlCard.Dock = DockStyle.Fill;
            pnlCard.Location = new Point(50, 50);
            pnlCard.Name = "pnlCard";
            pnlCard.Padding = new Padding(40, 30, 40, 30);
            pnlCard.Size = new Size(500, 600);
            pnlCard.TabIndex = 0;

            // 
            // labelTitle
            // 
            labelTitle.Dock = DockStyle.Top;
            labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(41, 50, 65);
            labelTitle.Location = new Point(40, 30);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(420, 50);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Créer un compte";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // labelSubtitle
            // 
            labelSubtitle.Dock = DockStyle.Top;
            labelSubtitle.Font = new Font("Segoe UI", 10F);
            labelSubtitle.ForeColor = Color.Gray;
            labelSubtitle.Location = new Point(40, 80);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(420, 30);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Rejoignez GSB Manager";
            labelSubtitle.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // pnlForm
            // 
            pnlForm.Controls.Add(labelPrenom);
            pnlForm.Controls.Add(txtFirstname);
            pnlForm.Controls.Add(labelNom);
            pnlForm.Controls.Add(txtName);
            pnlForm.Controls.Add(labelEmail);
            pnlForm.Controls.Add(txtEmail);
            pnlForm.Controls.Add(labelPassword);
            pnlForm.Controls.Add(txtPassword);
            pnlForm.Dock = DockStyle.Top;
            pnlForm.Location = new Point(40, 110);
            pnlForm.Name = "pnlForm";
            pnlForm.Padding = new Padding(0, 30, 0, 0);
            pnlForm.Size = new Size(420, 370);
            pnlForm.TabIndex = 2;

            // 
            // labelPrenom
            // 
            labelPrenom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelPrenom.ForeColor = Color.FromArgb(41, 50, 65);
            labelPrenom.Location = new Point(0, 30);
            labelPrenom.Name = "labelPrenom";
            labelPrenom.Size = new Size(420, 25);
            labelPrenom.TabIndex = 0;
            labelPrenom.Text = "Prénom";

            // 
            // txtFirstname
            // 
            txtFirstname.BorderStyle = BorderStyle.FixedSingle;
            txtFirstname.Font = new Font("Segoe UI", 11F);
            txtFirstname.Location = new Point(0, 60);
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new Size(420, 27);
            txtFirstname.TabIndex = 1;

            // 
            // labelNom
            // 
            labelNom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelNom.ForeColor = Color.FromArgb(41, 50, 65);
            labelNom.Location = new Point(0, 110);
            labelNom.Name = "labelNom";
            labelNom.Size = new Size(420, 25);
            labelNom.TabIndex = 2;
            labelNom.Text = "Nom";

            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 11F);
            txtName.Location = new Point(0, 140);
            txtName.Name = "txtName";
            txtName.Size = new Size(420, 27);
            txtName.TabIndex = 3;

            // 
            // labelEmail
            // 
            labelEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelEmail.ForeColor = Color.FromArgb(41, 50, 65);
            labelEmail.Location = new Point(0, 190);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(420, 25);
            labelEmail.TabIndex = 4;
            labelEmail.Text = "Email";

            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.Location = new Point(0, 220);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(420, 27);
            txtEmail.TabIndex = 5;

            // 
            // labelPassword
            // 
            labelPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelPassword.ForeColor = Color.FromArgb(41, 50, 65);
            labelPassword.Location = new Point(0, 270);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(420, 25);
            labelPassword.TabIndex = 6;
            labelPassword.Text = "Mot de passe";

            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(0, 300);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(420, 27);
            txtPassword.TabIndex = 7;

            // 
            // buttonCreateAccount
            // 
            buttonCreateAccount.BackColor = Color.FromArgb(52, 152, 219);
            buttonCreateAccount.Cursor = Cursors.Hand;
            buttonCreateAccount.FlatAppearance.BorderSize = 0;
            buttonCreateAccount.FlatStyle = FlatStyle.Flat;
            buttonCreateAccount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonCreateAccount.ForeColor = Color.White;
            buttonCreateAccount.Location = new Point(40, 490);
            buttonCreateAccount.Name = "buttonCreateAccount";
            buttonCreateAccount.Size = new Size(420, 50);
            buttonCreateAccount.TabIndex = 3;
            buttonCreateAccount.Text = "✓ Créer le compte";
            buttonCreateAccount.UseVisualStyleBackColor = false;
            buttonCreateAccount.Click += buttonCreateAccount_Click;

            // 
            // btnBackToLogin
            // 
            btnBackToLogin.BackColor = Color.Transparent;
            btnBackToLogin.Cursor = Cursors.Hand;
            btnBackToLogin.FlatAppearance.BorderColor = Color.FromArgb(149, 165, 166);
            btnBackToLogin.FlatAppearance.BorderSize = 1;
            btnBackToLogin.FlatStyle = FlatStyle.Flat;
            btnBackToLogin.Font = new Font("Segoe UI", 10F);
            btnBackToLogin.ForeColor = Color.FromArgb(149, 165, 166);
            btnBackToLogin.Location = new Point(140, 550);
            btnBackToLogin.Name = "btnBackToLogin";
            btnBackToLogin.Size = new Size(220, 40);
            btnBackToLogin.TabIndex = 4;
            btnBackToLogin.Text = "← Retour à la connexion";
            btnBackToLogin.UseVisualStyleBackColor = false;

            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 700);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GSB Manager - Création de compte";
            pnlMain.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Panel pnlCard;
        private Label labelTitle;
        private Label labelSubtitle;
        private Panel pnlForm;
        private Label labelPrenom;
        private TextBox txtFirstname;
        private Label labelNom;
        private TextBox txtName;
        private Label labelEmail;
        private TextBox txtEmail;
        private Label labelPassword;
        private TextBox txtPassword;
        private Button buttonCreateAccount;
        private Button btnBackToLogin;
    }
}