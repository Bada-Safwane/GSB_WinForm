using GSB2.DAO;
using GSB2.Forms;
using GSB2.Models;
using System;
using System.Windows.Forms;

namespace GSB2
{
    public partial class ConnexionForm : Form
    {
        public ConnexionForm()
        {
            InitializeComponent();

            // Test database connection (optional)
            Database db = new Database();
            try
            {
                var connection = db.GetConnection();
                connection.Open();
                // MessageBox.Show("Connexion à la base réussie !");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion : " + ex.Message);
            }
        }



        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string password = textBoxMdp.Text;

            UserDAO userDao = new UserDAO();
            Users user = userDao.GetUsers(email, password);

            if (user != null)
            {
                MessageBox.Show(user.ToString());

                MainForm newForm = new MainForm();

                // Show the new form
                newForm.Show();

                // Close the current form
                this.Hide();
            }
            else
            {
                MessageBox.Show("Email ou mot de passe incorrect.");
            }
        }

        private void buttonRedirCreat_Click(object sender, EventArgs e)
        {
            RegisterForm newForm = new RegisterForm();

            // Show the new form
            newForm.Show();

            // Close the current form
            this.Hide();
        }
    }
}
