using GSB2.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GSB2.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string firstname = txtFirstname.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(firstname) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Champs manquants",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserDAO dao = new UserDAO();
            bool success = dao.Register(email, password, name, firstname);

            if (success)
            {
                MessageBox.Show("Compte créé avec succès ! Vous pouvez maintenant vous connecter.",
                    "Inscription réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                new MainForm().Show();
            }
        }


    }
}
