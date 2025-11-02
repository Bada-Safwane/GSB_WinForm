using System;
using System.Windows.Forms;
using GSB2.DAO;
using GSB2.Models;

namespace GSB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Test database connection (optional)
            Database db = new Database();
            try
            {
                var connection = db.GetConnection();
                connection.Open();
                MessageBox.Show("Connexion à la base réussie !");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion : " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Optionnel : actions quand l'utilisateur tape son email
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;

            UserDAO userDao = new UserDAO();
            Users user = userDao.GetUsers(email, password);

            if (user != null )
            {
                textBox3.Text = user.Name;
                MessageBox.Show("Connexion réussie !");
            }
            else
            {
                MessageBox.Show("Email ou mot de passe incorrect.");
            }
        }
    }
}
