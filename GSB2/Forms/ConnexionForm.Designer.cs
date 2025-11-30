namespace GSB2
{
    partial class ConnexionForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            textBoxEmail = new TextBox();
            textBoxMdp = new TextBox();
            buttonConnexion = new Button();
            buttonRedirCreat = new Button();
            SuspendLayout();
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(320, 142);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(150, 31);
            textBoxEmail.TabIndex = 0;
            // 
            // textBoxMdp
            // 
            textBoxMdp.Location = new Point(320, 199);
            textBoxMdp.Name = "textBoxMdp";
            textBoxMdp.PasswordChar = '*';
            textBoxMdp.Size = new Size(150, 31);
            textBoxMdp.TabIndex = 1;
            // 
            // buttonConnexion
            // 
            buttonConnexion.Location = new Point(411, 256);
            buttonConnexion.Name = "buttonConnexion";
            buttonConnexion.Size = new Size(129, 39);
            buttonConnexion.TabIndex = 2;
            buttonConnexion.Text = "Connexion";
            buttonConnexion.UseVisualStyleBackColor = true;
            buttonConnexion.Click += buttonConnexion_Click;
            // 
            // buttonRedirCreat
            // 
            buttonRedirCreat.Location = new Point(231, 256);
            buttonRedirCreat.Name = "buttonRedirCreat";
            buttonRedirCreat.Size = new Size(157, 39);
            buttonRedirCreat.TabIndex = 3;
            buttonRedirCreat.Text = "Créer un compte";
            buttonRedirCreat.UseVisualStyleBackColor = true;
            buttonRedirCreat.Click += buttonRedirCreat_Click;
            // 
            // ConnexionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonRedirCreat);
            Controls.Add(buttonConnexion);
            Controls.Add(textBoxMdp);
            Controls.Add(textBoxEmail);
            Name = "ConnexionForm";
            Text = "Connexion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxMdp;
        private System.Windows.Forms.Button buttonConnexion;
        private Button buttonRedirCreat;
    }
}
