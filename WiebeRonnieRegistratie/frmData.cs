using System.Data;
using MySql.Data.MySqlClient;

namespace WiebeRonnieRegistratie
{
    public partial class frmData : Form
    {
        public static string connStr = "Server=localhost;Database=registratie;Uid=root;Pwd=root;";
        private static string query = "SELECT id, naam, adres, woonplaats, prestaties, comments FROM registratiedata;";
        private DataTable dataTable;

        public frmData() // update 11/4/2025: HET WERKT (gedeeltelijk). de textboxes worden er niet goed ingezet en de labels worden verneukt, maar goed. 
                         // het is een begin
        {// vulDataInPanel(); was voor laaddata();
            InitializeComponent();
            laaddata();
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
                //super gevaarlijk
                //pnlTabData.Controls.Clear();
                //super gevaarlijk
                pnlTabData.RowStyles.Clear();
                pnlTabData.RowCount = 0;
                pnlTabData.ColumnCount = dataTable.Columns.Count - 1; // id niet tonen
                pnlTabData.AutoSize = true;
                pnlTabData.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                // === Headers ===
                for (int j = 1; j < dataTable.Columns.Count; j++) // skip id
                {
                    Label headerLabel = new Label
                    {
                        Text = dataTable.Columns[j].ColumnName,
                        AutoSize = true,
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                    };
                    pnlTabData.Controls.Add(headerLabel, j - 1, 0); // zet op rij 0
                }

                // === Data ===
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    pnlTabData.RowCount++;
                    pnlTabData.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                    for (int j = 1; j < dataTable.Columns.Count; j++) // skip id
                    {
                        try
                        {
                            TextBox txtbox = new TextBox
                            {
                                //hier wordt er nieuwe textboxes gemaakt in de nieuwe row en in de 1ste kolom wat dan doorgaat naar de 5de kolom
                                Name = $"textbox_{i}_{j}_{dataTable.Columns[j].ColumnName}",
                                //hier pakt hij de text uit de database en vult het in de nieuwe textboxes
                                Text = dataTable.Rows[i][j].ToString(),
                                Dock = DockStyle.Fill,
                                ReadOnly = false
                            };

                            txtbox.KeyDown += veranderData_KeyDown;

                            pnlTabData.Controls.Add(txtbox, j - 1, i + 1); // +1 omdat headers op rij 0 staan
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show($"Fout bij het toevoegen van tekstvak: {ex.Message}");
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

        // onderstaande method is waar de sql query moet komen om de data in de textboxes ook echt aan te passen
        // dit moet op elke textbox worden gezet
        private void veranderData_KeyDown(object sender, KeyEventArgs e)
        {
            // wat de query moet doen: lees data uit de textbox, 
            // pak die data, en zet het in de database met een update statement
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TextBox tb = sender as TextBox;
                if (tb == null) return;

                // Verwachte naam: textbox_row_col_colName
                string[] parts = tb.Name.Split('_');
                if (parts.Length < 4) return;

                int rowIndex = int.Parse(parts[1]);
                string kolomNaam = parts[3];
                string nieuweWaarde = tb.Text;

                int id = Convert.ToInt32(dataTable.Rows[rowIndex]["id"]);

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    try
                    {
                        conn.Open();
                        //hier wordt het data opgeslagen en dan gestuurd naar de database

                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            cmd.Parameters.AddWithValue("@waarde", nieuweWaarde);
                            cmd.Parameters.AddWithValue("@id", id);
                            int resultaat = cmd.ExecuteNonQuery();
                            //hier laat hij een messagebox zien dat het is bijgewerkt
                            if (resultaat > 0)
                                MessageBox.Show($"✅ '{kolomNaam}' bij ID {id} is bijgewerkt.");
                            else // onmogelijk te triggeren :thumbsup:
                                MessageBox.Show("Geen wijzigingen doorgevoerd.", "Let op", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Fout bij updaten: {ex.Message}", "Database Update Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnNewRij_Click(object sender, EventArgs e)
        {
            int newRowIndex = pnlTabData.RowCount; // Add at the bottom

            pnlTabData.RowCount++;
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            for (int j = 1; j < dataTable.Columns.Count; j++) // skip id
            {
                try
                {
                    TextBox txtbox = new TextBox
                    {
                        Name = $"textbox_{newRowIndex}_{j}_",
                        Text = "",
                        Dock = DockStyle.Fill,
                        ReadOnly = false
                    };

                    txtbox.KeyDown += veranderData_KeyDown;

                    pnlTabData.Controls.Add(txtbox, j - 1, newRowIndex); // use newRowIndex directly
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fout bij het toevoegen van tekstvak: {ex.Message}", "Fout Tekstvak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}