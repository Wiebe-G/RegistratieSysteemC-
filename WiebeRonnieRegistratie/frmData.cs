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
                //super gevaarlijk (haalt de button weg)
                // wat dit doet, is het haalt onze controls weg, en zet de nieuwe controls erin
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
                                //hier wordt er nieuwe textboxes gemaakt in de nieuwe row en in de 1ste kolom wat dan doorgaat naar de laatste kolom
                                Name = $"textbox_{i}_{j}_{dataTable.Columns[j].ColumnName}",
                                //hier pakt hij de text uit de database en vult het in de nieuwe textboxes
                                Text = dataTable.Rows[i][j].ToString(),
                                Dock = DockStyle.Fill,
                                ReadOnly = false // zodat de gebruiker de data ook echt kan aanpassen
                            };

                            txtbox.KeyDown += veranderData_KeyDown; // keydown event, dus dat de data verandert als je op enter drukt

                            pnlTabData.Controls.Add(txtbox, j - 1, i + 1); // +1 omdat headers op rij 0 staan
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

        // onderstaande method is waar de sql query moet komen om de data in de textboxes ook echt aan te passen
        // dit moet op elke textbox worden gezet
        private void veranderData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                // Validate the sender
                TextBox tb = sender as TextBox;
                if (tb == null) return;

                // Parse TextBox name into parts
                string[] parts = tb.Name.Split('_');
                if (parts.Length < 4 || !int.TryParse(parts[1], out int rowIndex))
                {
                    MessageBox.Show("Ongeldige TextBox naam of rijindex.");
                    return;
                }

                string kolomNaam = parts[3];
                string nieuweWaarde = tb.Text;

                // Validate row index and data
                if (rowIndex < 0 || rowIndex >= dataTable.Rows.Count) // Changed <= to >=
                {
                    MessageBox.Show("Rijindex buiten bereik.");
                    return;
                }

                int id;
                try
                {
                    id = Convert.ToInt32(dataTable.Rows[rowIndex]["id"]);
                }
                finally
                {
                    // idk lol
                }


                // Build SQL query
                string query = $"UPDATE registratiedata SET {kolomNaam} = @nieuweWaarde WHERE id = @id";

                // Execute database update
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    try
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nieuweWaarde", nieuweWaarde);
                            cmd.Parameters.AddWithValue("@id", id);

                            int resultaat = cmd.ExecuteNonQuery();
                            if (resultaat > 0)
                            {
                                MessageBox.Show($"✅ '{kolomNaam}' bij ID {id} is bijgewerkt.");
                            }
                            else
                            {
                                MessageBox.Show("Geen wijzigingen doorgevoerd.", "Let op", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
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
            // Step 1: Add a new blank row to `dataTable`
            DataRow newRow = dataTable.NewRow(); // Create a new row based on the schema of `dataTable`
            dataTable.Rows.Add(newRow); // Add it to `dataTable`

            // Step 2: Calculate the new row index based on `dataTable` size
            int newRowIndex = dataTable.Rows.Count - 1; // Last row in `dataTable`

            // Step 3: Dynamically add controls to `pnlTabData`
            for (int j = 1; j < dataTable.Columns.Count; j++) // Skip `id` column
            {
                pnlTabData.RowCount++; // Increment row count in the panel
                pnlTabData.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Add a new row style

                try
                {
                    TextBox txtbox = new TextBox // Create a new TextBox
                    {
                        Name = $"textbox_{newRowIndex}_{j}_", // Name includes new row index
                        Text = "", // Set empty text for the new row
                        Dock = DockStyle.Fill,
                        ReadOnly = false // Allow editing
                    };

                    // Step 4: Attach the KeyDown event to handle updates
                    txtbox.KeyDown += veranderData_KeyDown;

                    // Step 5: Add the TextBox to the panel
                    pnlTabData.Controls.Add(txtbox, j - 1, newRowIndex + 1); // `+1` because headers are in row 0
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fout bij het toevoegen van tekstvak: {ex.Message}", "Fout Tekstvak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}