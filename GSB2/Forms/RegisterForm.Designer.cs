namespace GSB2.Forms

{
    partial class RegisterForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur — ne pas modifier
        /// le contenu de cette méthode avec l’éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            labelTitle = new Label();
            labelPrenom = new Label();
            labelNom = new Label();
            labelEmail = new Label();
            labelPassword = new Label();
            txtFirstname = new TextBox();
            txtName = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            buttonCreateAccount = new Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.Location = new Point(114, 33);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(455, 48);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Créer un nouveau compte";
            // 
            // labelPrenom
            // 
            labelPrenom.AutoSize = true;
            labelPrenom.Font = new Font("Segoe UI", 10F);
            labelPrenom.Location = new Point(57, 133);
            labelPrenom.Margin = new Padding(4, 0, 4, 0);
            labelPrenom.Name = "labelPrenom";
            labelPrenom.Size = new Size(84, 28);
            labelPrenom.TabIndex = 1;
            labelPrenom.Text = "Prénom:";
            // 
            // labelNom
            // 
            labelNom.AutoSize = true;
            labelNom.Font = new Font("Segoe UI", 10F);
            labelNom.Location = new Point(57, 217);
            labelNom.Margin = new Padding(4, 0, 4, 0);
            labelNom.Name = "labelNom";
            labelNom.Size = new Size(60, 28);
            labelNom.TabIndex = 2;
            labelNom.Text = "Nom:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 10F);
            labelEmail.Location = new Point(57, 300);
            labelEmail.Margin = new Padding(4, 0, 4, 0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(63, 28);
            labelEmail.TabIndex = 3;
            labelEmail.Text = "Email:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 10F);
            labelPassword.Location = new Point(57, 383);
            labelPassword.Margin = new Padding(4, 0, 4, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(133, 28);
            labelPassword.TabIndex = 4;
            labelPassword.Text = "Mot de passe:";
            // 
            // txtFirstname
            // 
            txtFirstname.Location = new Point(214, 133);
            txtFirstname.Margin = new Padding(4, 5, 4, 5);
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new Size(284, 31);
            txtFirstname.TabIndex = 5;
            // 
            // txtName
            // 
            txtName.Location = new Point(214, 217);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(284, 31);
            txtName.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(214, 300);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(284, 31);
            txtEmail.TabIndex = 7;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(214, 383);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(284, 31);
            txtPassword.TabIndex = 8;
            // 
            // buttonCreateAccount
            // 
            buttonCreateAccount.BackColor = Color.MediumSlateBlue;
            buttonCreateAccount.FlatStyle = FlatStyle.Flat;
            buttonCreateAccount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonCreateAccount.ForeColor = Color.White;
            buttonCreateAccount.Location = new Point(214, 467);
            buttonCreateAccount.Margin = new Padding(4, 5, 4, 5);
            buttonCreateAccount.Name = "buttonCreateAccount";
            buttonCreateAccount.Size = new Size(286, 58);
            buttonCreateAccount.TabIndex = 9;
            buttonCreateAccount.Text = "Créer le compte";
            buttonCreateAccount.UseVisualStyleBackColor = false;
            buttonCreateAccount.Click += buttonCreateAccount_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 583);
            Controls.Add(buttonCreateAccount);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtName);
            Controls.Add(txtFirstname);
            Controls.Add(labelPassword);
            Controls.Add(labelEmail);
            Controls.Add(labelNom);
            Controls.Add(labelPrenom);
            Controls.Add(labelTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Création de compte";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelPrenom;
        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button buttonCreateAccount;
    }
}
