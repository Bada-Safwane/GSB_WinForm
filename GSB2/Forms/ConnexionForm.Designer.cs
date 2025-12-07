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
            labelEmail = new Label();
            labelMdp = new Label();
            labelTitre = new Label();
            layout = new TableLayoutPanel();
            buttonsPanel = new FlowLayoutPanel();
            layout.SuspendLayout();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxEmail
            // 
            textBoxEmail.Dock = DockStyle.Top;
            textBoxEmail.Font = new Font("Segoe UI", 11F);
            textBoxEmail.Location = new Point(200, 155);
            textBoxEmail.Margin = new Padding(200, 5, 200, 10);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(400, 37);
            textBoxEmail.TabIndex = 3;
            // 
            // textBoxMdp
            // 
            textBoxMdp.Dock = DockStyle.Top;
            textBoxMdp.Font = new Font("Segoe UI", 11F);
            textBoxMdp.Location = new Point(200, 422);
            textBoxMdp.Margin = new Padding(200, 5, 200, 20);
            textBoxMdp.Name = "textBoxMdp";
            textBoxMdp.PasswordChar = '*';
            textBoxMdp.Size = new Size(400, 37);
            textBoxMdp.TabIndex = 5;
            // 
            // buttonConnexion
            // 
            buttonConnexion.AutoSize = true;
            buttonConnexion.BackColor = Color.FromArgb(58, 131, 217);
            buttonConnexion.FlatAppearance.BorderSize = 0;
            buttonConnexion.FlatStyle = FlatStyle.Flat;
            buttonConnexion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonConnexion.ForeColor = Color.White;
            buttonConnexion.Location = new Point(190, 23);
            buttonConnexion.Name = "buttonConnexion";
            buttonConnexion.Size = new Size(122, 38);
            buttonConnexion.TabIndex = 1;
            buttonConnexion.Text = "Connexion";
            buttonConnexion.UseVisualStyleBackColor = false;
            buttonConnexion.Click += buttonConnexion_Click;
            // 
            // buttonRedirCreat
            // 
            buttonRedirCreat.AutoSize = true;
            buttonRedirCreat.BackColor = Color.FromArgb(230, 230, 230);
            buttonRedirCreat.FlatAppearance.BorderSize = 0;
            buttonRedirCreat.FlatStyle = FlatStyle.Flat;
            buttonRedirCreat.Font = new Font("Segoe UI", 10F);
            buttonRedirCreat.Location = new Point(0, 20);
            buttonRedirCreat.Margin = new Padding(0, 0, 20, 0);
            buttonRedirCreat.Name = "buttonRedirCreat";
            buttonRedirCreat.Size = new Size(167, 38);
            buttonRedirCreat.TabIndex = 0;
            buttonRedirCreat.Text = "Créer un compte";
            buttonRedirCreat.UseVisualStyleBackColor = false;
            buttonRedirCreat.Click += buttonRedirCreat_Click;
            // 
            // labelEmail
            // 
            labelEmail.Dock = DockStyle.Fill;
            labelEmail.Font = new Font("Segoe UI", 11F);
            labelEmail.Location = new Point(3, 120);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(794, 30);
            labelEmail.TabIndex = 2;
            labelEmail.Text = "Adresse email";
            labelEmail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelMdp
            // 
            labelMdp.Dock = DockStyle.Fill;
            labelMdp.Font = new Font("Segoe UI", 11F);
            labelMdp.Location = new Point(3, 202);
            labelMdp.Name = "labelMdp";
            labelMdp.Size = new Size(794, 23);
            labelMdp.TabIndex = 4;
            labelMdp.Text = "Mot de passe";
            labelMdp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTitre
            // 
            labelTitre.Dock = DockStyle.Top;
            labelTitre.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            labelTitre.Location = new Point(0, 40);
            labelTitre.Margin = new Padding(0, 0, 0, 20);
            labelTitre.Name = "labelTitre";
            labelTitre.Size = new Size(800, 60);
            labelTitre.TabIndex = 0;
            labelTitre.Text = "GSB";
            labelTitre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // layout
            // 
            layout.AutoScroll = true;
            layout.ColumnCount = 1;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.Controls.Add(labelTitre, 0, 0);
            layout.Controls.Add(labelEmail, 0, 1);
            layout.Controls.Add(textBoxEmail, 0, 3);
            layout.Controls.Add(labelMdp, 0, 4);
            layout.Controls.Add(textBoxMdp, 0, 5);
            layout.Controls.Add(buttonsPanel, 0, 6);
            layout.Dock = DockStyle.Fill;
            layout.Location = new Point(0, 0);
            layout.Name = "layout";
            layout.Padding = new Padding(0, 40, 0, 0);
            layout.RowCount = 7;
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layout.Size = new Size(800, 437);
            layout.TabIndex = 0;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Anchor = AnchorStyles.None;
            buttonsPanel.AutoSize = true;
            buttonsPanel.Controls.Add(buttonRedirCreat);
            buttonsPanel.Controls.Add(buttonConnexion);
            buttonsPanel.Location = new Point(242, 289);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Padding = new Padding(0, 20, 0, 0);
            buttonsPanel.Size = new Size(315, 64);
            buttonsPanel.TabIndex = 6;
            buttonsPanel.WrapContents = false;
            // 
            // ConnexionForm
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 437);
            Controls.Add(layout);
            Name = "ConnexionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Connexion";
            layout.ResumeLayout(false);
            layout.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            buttonsPanel.PerformLayout();
            ResumeLayout(false);
        }




        #endregion

        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxMdp;
        private System.Windows.Forms.Button buttonConnexion;
        private Button buttonRedirCreat;
        private Label labelEmail;
        private Label labelMdp;
        private Label labelTitre;
        private TableLayoutPanel layout;
        private FlowLayoutPanel buttonsPanel;
    }
}
