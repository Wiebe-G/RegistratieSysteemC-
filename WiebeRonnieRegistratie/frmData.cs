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
        /*
         * TODO:
         * Knop voor nieuwe rij moet onder de nieuwe rij, niet rij onder de knop
         * Data moet in de nieuwe rij moeten worden gezet en dat moet ook naar de db worden gevoerd
         * 
        */
        private void veranderData_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                TextBox tb = sender as TextBox;
                if (tb == null) return;

                string[] parts = tb.Name.Split('_');
                if (parts.Length < 3 || !int.TryParse(parts[1], out int rowIndex))
                {
                    MessageBox.Show("Ongeldige TextBox naam of rijindex.");
                    return;
                }

                string kolomNaam = parts[2];
                string nieuweWaarde = tb.Text;

                if (rowIndex < 0 || rowIndex >= dataTable.Rows.Count)
                {
                    MessageBox.Show("Rijindex buiten bereik.");
                    return;
                }

                // Check if the row exists in the DataTable
                if (dataTable.Rows.Count <= rowIndex)
                {
                    MessageBox.Show("De rij bestaat niet in de DataTable.");
                    return;
                }

                // Get the ID from the DataRow.  Handle the case where it might be null.
                object idValue = dataTable.Rows[rowIndex]["id"];
                int id = Convert.ToInt32(idValue);


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
                if (idValue == null || idValue == DBNull.Value)
                {
                    MessageBox.Show("De ID voor deze rij is niet ingesteld.  De rij kan niet worden bijgewerkt.", "ID Niet Beschikbaar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop processing if ID is missing.
                }

            }
        }

        private void btnNewRij_Click(object sender, EventArgs e)
        {
            Button btnNieuweRij = new Button();
            btnNieuweRij.Text = "Nieuwe Rij Toevoegen";
            btnNieuweRij.Name = "btnNieuweRij";
            btnNieuweRij.Dock = DockStyle.Top;
            btnNieuweRij.AutoSize = true;

            Control previousButton = pnlTabData.Controls.Find("btnNewRij", true).FirstOrDefault();
            if (previousButton != null)
            {
                pnlTabData.Controls.Remove(previousButton);
                previousButton.Dispose();
            }

            btnNieuweRij.Click += btnNewRij_Click;
            pnlTabData.RowCount++;
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            pnlTabData.Controls.Add(btnNieuweRij, 0, pnlTabData.RowCount - 1);
            pnlTabData.SetColumnSpan(btnNieuweRij, dataTable.Columns.Count);
            // Nieuwe rij toevoegen aan de database
            string insertQuery = "INSERT INTO registratiedata (naam, adres, woonplaats, prestaties, comments) VALUES (@naam, @adres, @woonplaats, @prestaties, @comments); SELECT LAST_INSERT_ID();";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        // Voor nieuwe rijen zijn de velden initieel leeg
                        cmd.Parameters.AddWithValue("@naam", "");
                        cmd.Parameters.AddWithValue("@adres", "");
                        cmd.Parameters.AddWithValue("@woonplaats", "");
                        cmd.Parameters.AddWithValue("@prestaties", "");
                        cmd.Parameters.AddWithValue("@comments", "");

                        // Voer de query uit en haal de nieuwe ID op
                        int newId = Convert.ToInt32(cmd.ExecuteScalar());

                        // Maak een nieuwe DataRow aan en vul deze met de (nog lege) data en de nieuwe ID
                        DataRow newRow = dataTable.NewRow();
                        newRow["id"] = newId; // Stel de nieuwe ID in
                        dataTable.Rows.Add(newRow);

                        int newRowIndex = dataTable.Rows.Count - 1;

                        // Voeg de nieuwe rij visueel toe aan het panel
                        pnlTabData.RowCount++;
                        pnlTabData.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                        for (int j = 1; j < dataTable.Columns.Count; j++)
                        {
                            try
                            {
                                TextBox txtbox = new TextBox
                                {
                                    Name = $"textbox_{newRowIndex}_{j}_{dataTable.Columns[j].ColumnName}",
                                    Text = "",
                                    Dock = DockStyle.Fill,
                                    ReadOnly = false
                                };
                                txtbox.KeyDown += veranderData_KeyDown;
                                pnlTabData.Controls.Add(txtbox, j - 1, newRowIndex + 1);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Fout bij het toevoegen van tekstvak: {ex.Message}", "Fout Tekstvak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        // Verwijder de oude knop en voeg de nieuwe knop toe onder de nieuwe 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fout bij het toevoegen van een nieuwe rij naar de database: {ex.Message}", "Database Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
/* AI
                Button btnNieuweRij = new Button();
                btnNieuweRij.Text = "Nieuwe Rij Toevoegen";
                btnNieuweRij.Name = "btnNieuweRij";
                btnNieuweRij.Dock = DockStyle.Top;
                btnNieuweRij.AutoSize = true;

                Control previousButton = pnlTabData.Controls.Find("btnNewRij", true).FirstOrDefault();
                if (previousButton != null)
                {
                    pnlTabData.Controls.Remove(previousButton);
                    previousButton.Dispose();
                }

                btnNieuweRij.Click += btnNewRij_Click;
                pnlTabData.RowCount++;
                pnlTabData.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                pnlTabData.Controls.Add(btnNieuweRij, 0, pnlTabData.RowCount - 1);
                pnlTabData.SetColumnSpan(btnNieuweRij, dataTable.Columns.Count);

                */