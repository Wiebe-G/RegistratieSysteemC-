using System;
using System.IO;
using MySql.Data.MySqlClient;


namespace WiebeRonnieRegistratie
{
    public partial class frmInlog : Form
    {
        public static string connStr = "Server=localhost;Database=registratie;Uid=root;Pwd=root;";
        public frmInlog()
        {
            InitializeComponent();
        }

        private void btnInlog_Click(object sender, EventArgs e)
        {
            string gebruikersnaam = txtName.Text.Trim();
            string wachtwoord = txtPassword.Text.Trim();

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                string query = "SELECT * FROM registratie WHERE gebruikersnaam = @gebruikersnaam AND wachtwoord = @wachtwoord";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@gebruikersnaam", gebruikersnaam);
                    cmd.Parameters.AddWithValue("@wachtwoord", wachtwoord);

                    MySqlDataReader lezer = cmd.ExecuteReader();

                    if (lezer.HasRows)
                    {
                        MessageBox.Show("Succesvolle login!");
                        frmData main = new frmData();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Fout bij inloggen, probeer het opnieuw.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout opgetreden: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // wat dit doet, is dat het kijkt of de input enter is
            // als de input enter is, voorkomt het dat een nieuwe regel wordt aangemaakt
            // dan simuleert het een klik op de inlogknop. zie hierboven
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnInlog.PerformClick();
            }
        }
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnInlog.PerformClick();
            }
        }
    }
}
