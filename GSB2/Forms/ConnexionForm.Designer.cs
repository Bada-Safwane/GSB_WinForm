namespace GSB2
{
    partial class ConnexionForm
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
            labelTitre = new Label();
            labelSubtitle = new Label();
            pnlForm = new Panel();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelMdp = new Label();
            textBoxMdp = new TextBox();
            buttonConnexion = new Button();
            pnlDivider = new Panel();
            lblOr = new Label();
            buttonRedirCreat = new Button();

            pnlMain.SuspendLayout();
            pnlCard.SuspendLayout();
            pnlForm.SuspendLayout();
            pnlDivider.SuspendLayout();
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
            pnlMain.Size = new Size(600, 650);
            pnlMain.TabIndex = 0;

            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(labelTitre);
            pnlCard.Controls.Add(labelSubtitle);
            pnlCard.Controls.Add(pnlForm);
            pnlCard.Controls.Add(buttonConnexion);
            pnlCard.Controls.Add(pnlDivider);
            pnlCard.Controls.Add(buttonRedirCreat);
            pnlCard.Dock = DockStyle.Fill;
            pnlCard.Location = new Point(50, 50);
            pnlCard.Name = "pnlCard";
            pnlCard.Padding = new Padding(40, 30, 40, 30);
            pnlCard.Size = new Size(500, 550);
            pnlCard.TabIndex = 0;

            // 
            // labelTitre
            // 
            labelTitre.Dock = DockStyle.Top;
            labelTitre.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            labelTitre.ForeColor = Color.FromArgb(41, 50, 65);
            labelTitre.Location = new Point(40, 30);
            labelTitre.Name = "labelTitre";
            labelTitre.Size = new Size(420, 60);
            labelTitre.TabIndex = 0;
            labelTitre.Text = "GSB Manager";
            labelTitre.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // labelSubtitle
            // 
            labelSubtitle.Dock = DockStyle.Top;
            labelSubtitle.Font = new Font("Segoe UI", 10F);
            labelSubtitle.ForeColor = Color.Gray;
            labelSubtitle.Location = new Point(40, 90);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(420, 30);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Connectez-vous à votre compte";
            labelSubtitle.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // pnlForm
            // 
            pnlForm.Controls.Add(labelEmail);
            pnlForm.Controls.Add(textBoxEmail);
            pnlForm.Controls.Add(labelMdp);
            pnlForm.Controls.Add(textBoxMdp);
            pnlForm.Dock = DockStyle.Top;
            pnlForm.Location = new Point(40, 120);
            pnlForm.Name = "pnlForm";
            pnlForm.Padding = new Padding(0, 30, 0, 0);
            pnlForm.Size = new Size(420, 230);
            pnlForm.TabIndex = 2;

            // 
            // labelEmail
            // 
            labelEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelEmail.ForeColor = Color.FromArgb(41, 50, 65);
            labelEmail.Location = new Point(0, 30);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(420, 25);
            labelEmail.TabIndex = 0;
            labelEmail.Text = "Adresse email";

            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 11F);
            textBoxEmail.Location = new Point(0, 60);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(420, 27);
            textBoxEmail.TabIndex = 1;

            // 
            // labelMdp
            // 
            labelMdp.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelMdp.ForeColor = Color.FromArgb(41, 50, 65);
            labelMdp.Location = new Point(0, 120);
            labelMdp.Name = "labelMdp";
            labelMdp.Size = new Size(420, 25);
            labelMdp.TabIndex = 2;
            labelMdp.Text = "Mot de passe";

            // 
            // textBoxMdp
            // 
            textBoxMdp.BorderStyle = BorderStyle.FixedSingle;
            textBoxMdp.Font = new Font("Segoe UI", 11F);
            textBoxMdp.Location = new Point(0, 150);
            textBoxMdp.Name = "textBoxMdp";
            textBoxMdp.PasswordChar = '●';
            textBoxMdp.Size = new Size(420, 27);
            textBoxMdp.TabIndex = 3;

            // 
            // buttonConnexion
            // 
            buttonConnexion.BackColor = Color.FromArgb(52, 152, 219);
            buttonConnexion.Cursor = Cursors.Hand;
            buttonConnexion.FlatAppearance.BorderSize = 0;
            buttonConnexion.FlatStyle = FlatStyle.Flat;
            buttonConnexion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonConnexion.ForeColor = Color.White;
            buttonConnexion.Location = new Point(40, 360);
            buttonConnexion.Name = "buttonConnexion";
            buttonConnexion.Size = new Size(420, 50);
            buttonConnexion.TabIndex = 3;
            buttonConnexion.Text = "→ Se connecter";
            buttonConnexion.UseVisualStyleBackColor = false;
            buttonConnexion.Click += buttonConnexion_Click;

            // 
            // pnlDivider
            // 
            pnlDivider.Controls.Add(lblOr);
            pnlDivider.Location = new Point(40, 425);
            pnlDivider.Name = "pnlDivider";
            pnlDivider.Size = new Size(420, 30);
            pnlDivider.TabIndex = 4;

            // 
            // lblOr
            // 
            lblOr.Dock = DockStyle.Fill;
            lblOr.Font = new Font("Segoe UI", 9F);
            lblOr.ForeColor = Color.Gray;
            lblOr.Location = new Point(0, 0);
            lblOr.Name = "lblOr";
            lblOr.Size = new Size(420, 30);
            lblOr.TabIndex = 0;
            lblOr.Text = "━━━━━━━━  ou  ━━━━━━━━";
            lblOr.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // buttonRedirCreat
            // 
            buttonRedirCreat.BackColor = Color.Transparent;
            buttonRedirCreat.Cursor = Cursors.Hand;
            buttonRedirCreat.FlatAppearance.BorderColor = Color.FromArgb(52, 152, 219);
            buttonRedirCreat.FlatAppearance.BorderSize = 2;
            buttonRedirCreat.FlatStyle = FlatStyle.Flat;
            buttonRedirCreat.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonRedirCreat.ForeColor = Color.FromArgb(52, 152, 219);
            buttonRedirCreat.Location = new Point(40, 465);
            buttonRedirCreat.Name = "buttonRedirCreat";
            buttonRedirCreat.Size = new Size(420, 50);
            buttonRedirCreat.TabIndex = 5;
            buttonRedirCreat.Text = "✓ Créer un nouveau compte";
            buttonRedirCreat.UseVisualStyleBackColor = false;
            buttonRedirCreat.Click += buttonRedirCreat_Click;

            // 
            // ConnexionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 650);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ConnexionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GSB Manager - Connexion";
            pnlMain.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            pnlDivider.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Panel pnlCard;
        private Label labelTitre;
        private Label labelSubtitle;
        private Panel pnlForm;
        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelMdp;
        private TextBox textBoxMdp;
        private Button buttonConnexion;
        private Panel pnlDivider;
        private Label lblOr;
        private Button buttonRedirCreat;
    }
}