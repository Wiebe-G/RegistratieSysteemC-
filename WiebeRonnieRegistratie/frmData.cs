// frmData.cs (This should be in your main form code file)
using System.Data;
using MySql.Data.MySqlClient;

namespace WiebeRonnieRegistratie
{
    public partial class frmData : Form
    {
        public static string connStr = "Server=localhost;Database=registratie;Uid=root;Pwd=root;";
        private static string query = "USE registratie;SELECT naam, adres, woonplaats, prestaties, comments FROM registratiedata;";
        private DataTable dataTable;

        public frmData() // update 11/4/2025: HET WERKT (gedeeltelijk). de textboxes worden er niet goed ingezet en de labels worden verneukt, maar goed. 
                         // het is een begin
        {// vulDataInPanel(); was voor laaddata();
            InitializeComponent();
            // rows(7);
            laaddata();
            vulDataInPanel();
        }

        private void frmData_Load(object sender, EventArgs e)
        {
            vulDataInPanel();
        }

        private void laaddata()
        {
            ;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {

                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        dataTable = new DataTable();
                        adapter.Fill(dataTable);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fout bij verbinden met database: {ex.Message}");
                    MessageBox.Show($"Fout bij verbinden met database: {ex.Message}", "Databasefout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void vulDataInPanel()
        {
            if (pnlTabData == null)
            {
                MessageBox.Show("Het pnlTabData control is niet gevonden op het formulier.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                pnlTabData.Controls.Clear();
                pnlTabData.RowStyles.Clear();
                pnlTabData.RowCount = 0;
                pnlTabData.ColumnCount = dataTable.Columns.Count;
                pnlTabData.AutoSize = true;
                pnlTabData.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                // === Headers ===
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    Label headerLabel = new Label
                    {
                        Text = dataTable.Columns[j].ColumnName,
                        AutoSize = true,
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                    };
                    pnlTabData.Controls.Add(headerLabel, j, 0); // zet op rij 0
                }

                // === Data ===
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    pnlTabData.RowCount++;
                    pnlTabData.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        try
                        {
                            TextBox txtbox = new TextBox
                            {
                                Name = $"textbox_{i}_{j}_{dataTable.Columns[j].ColumnName}",
                                Text = dataTable.Rows[i][j].ToString(),
                                Dock = DockStyle.Fill,
                                ReadOnly = false
                            };
                            pnlTabData.Controls.Add(txtbox, j, i + 1); // +1 omdat headers op rij 0 staan
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Fout bij het toevoegen van tekstvak: {ex.Message}", "Fout Tekstvak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Geen data gevonden in de database.", "Geen Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}