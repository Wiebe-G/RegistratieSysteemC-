using MySql.Data.MySqlClient;

namespace WiebeRonnieRegistratie

{
    public partial class frmNamen : Form
    {
        public static string connStr = "Server=localhost;Database=registratie;Uid=root;Pwd=root;";
        private static string query = "SELECT id, naam FROM registratiedata;";
        public frmNamen()
        {
            InitializeComponent();
            namenLijst();

        }
        public static void namenLijst()
        {
            frmNamen namenform = new frmNamen();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {

                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // naam en id fetchen uit de db
                        // laat het op basis van id zetten
                        string test = "e";
                        namenform.lstStudenten.Items.Add(test);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Iets is fout gegaan: {ex.Message}");
                }
            }
        }
        public static void openDataForm()
        {
            frmData dataForm = new frmData();
            dataForm.Show();

        }
    }
}
