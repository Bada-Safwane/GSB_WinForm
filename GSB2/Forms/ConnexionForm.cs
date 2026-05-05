using GSB2.DAO;
using GSB2.Forms;
using GSB2.Models;
using System;
using System.Windows.Forms;

namespace GSB2
{
    public partial class ConnexionForm : Form
    {
        // SB: Constructeur du formulaire de connexion - initialise les composants et teste la connexion à la base de données
        public ConnexionForm()
        {
            InitializeComponent();

            Database db = new Database();
            try
            {
                var connection = db.GetConnection();
                connection.Open();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion : " + ex.Message);
            }
        }

        // SB: Gère le clic sur le bouton de connexion - vérifie les identifiants et redirige vers MainForm si valides
        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            string email    = textBoxEmail.Text;
            string password = textBoxMdp.Text;

            UserDAO userDao = new UserDAO();
            Users user = userDao.GetUsers(email, password);

            if (user != null)
            {
                MainForm newForm = new MainForm(user);
                newForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Email ou mot de passe incorrect.");
            }
        }

        // SB: Gère le clic sur le bouton de création de compte - redirige vers le formulaire d'inscription
        private void buttonRedirCreat_Click(object sender, EventArgs e)
        {
            RegisterForm newForm = new RegisterForm();
            newForm.Show();
            this.Hide();
        }
    }
}

