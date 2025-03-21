
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WiebeRonnieRegistratie
{
    public partial class frmData: Form
    {
        public static string connStr = "Server=localhost;Database=registratiedata;Uid=root;Pwd=root;";
        public frmData()
        {
            InitializeComponent();
            laaddata();
        }

        private void laaddata()
        {
            string query = "SELECT naam, adres, woonplaats, prestaties, comments FROM registratiedata";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();


                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fout bij verbinden met database: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
