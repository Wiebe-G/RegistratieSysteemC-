using System.Data;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace WiebeRonnieRegistratie
{
    public partial class frmData : Form
    {
        public static string connStr = "Server=localhost;Database=registratie;Uid=root;Pwd=root;";
        private static string query = "SELECT id, naam, adres, woonplaats, prestaties, comments FROM registratiedata;";
        private DataTable dataTable; // geheugenstructuur voor het opslaan van de data
        private static string bestand = "documentatie.txt"; // bestand voor documentatie

        public frmData() // Constructor
        {
            InitializeComponent();
            laaddata();
            vulDataInPanel();
        }

        // methode voor laden van de data
        private void laaddata()
        {
            ;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open(); // verbinden
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        dataTable = new DataTable();
                        adapter.Fill(dataTable); // datatable vullen met de data uit de db
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fout bij verbinden met database: {ex.Message}", "Databasefout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close(); // connectie sluiten
                }
            }
        }

        // vul de datapanel met rijen uit de db
        private void vulDataInPanel()
        {
            if (pnlTabData == null)
            {
                MessageBox.Show("Het pnlTabData control is niet gevonden op het formulier.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                // wat dit doet, is het haalt onze controls weg, en zet de nieuwe controls erin
                pnlTabData.RowStyles.Clear();
                pnlTabData.RowCount = 0;
                pnlTabData.ColumnCount = dataTable.Columns.Count - 1; // id kolom niet tonen
                pnlTabData.AutoSize = true;
                pnlTabData.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                // Koptekst kolommen
                for (int j = 1; j < dataTable.Columns.Count; j++) // begin vanaf 1 om id 0 over te slaan
                {
                    Label headerLabel = new Label
                    {
                        Text = dataTable.Columns[j].ColumnName,
                        AutoSize = true,
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                    };
                    pnlTabData.Controls.Add(headerLabel, j - 1, 0); // zet op rij 0
                }

                // gegevens toevoegen in textboxes
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

                                Name = $"textbox_{i}_{j}_{dataTable.Columns[j].ColumnName}", // unieke naam
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

        // als je op enter drukt, wordt dit getriggered
        private void veranderData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                TextBox tb = sender as TextBox;
                if (tb == null) return;

                // De TextBox naam is bijvoorbeeld: textbox_2_4_woonplaats
                string[] parts = tb.Name.Split('_');
                if (parts.Length < 3 || !int.TryParse(parts[1], out int rowIndex))
                {
                    MessageBox.Show("Ongeldige TextBox naam of rijindex.");
                    return;
                }

                string kolomNaam = parts[3]; // kolomnaam op index 3
                string nieuweWaarde = tb.Text; // nieuwe waarde die de gebruiker wil, is de input in de textbox

                if (rowIndex < 0 || rowIndex >= dataTable.Rows.Count)
                {
                    MessageBox.Show("Rijindex buiten bereik."); // rijindex niet in bereik, dus te hoge index
                    return;
                }

                // check of de rij in de db staat
                if (dataTable.Rows.Count <= rowIndex)
                {
                    MessageBox.Show("De rij bestaat niet in de DataTable.");
                    return;
                }

                // id ophalen van de db
                object idValue = dataTable.Rows[rowIndex]["id"];
                int id = Convert.ToInt32(idValue);

                // kijken of de input geldig is, voor veiligheid
                // alleen bekende kolomnamen
                List<string> toegestaneKolommen = new List<string> { "naam", "adres", "woonplaats", "prestaties", "comments" };

                if (!toegestaneKolommen.Contains(kolomNaam))
                {
                    MessageBox.Show($"❌ Ongeldige kolomnaam '{kolomNaam}'", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // de query voor updaten van het ding
                string updateQuery = $"UPDATE registratiedata SET {kolomNaam} = @nieuweWaarde WHERE id = @id";

                // ook echt update doorvoeren
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    try
                    {
                        conn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {

                            cmd.Parameters.AddWithValue("@nieuweWaarde", nieuweWaarde);
                            cmd.Parameters.AddWithValue("@id", id);

                            int resultaat = cmd.ExecuteNonQuery();

                            if (resultaat > 0)
                            {
                                /* 
                                 * dit is om te zorgen dat de gebruiker heel erg zeker is dat de naam moet worden veranderd
                                 * het is lelijk, maar goed
                                 */
                                DialogResult dialoog1 = MessageBox.Show("Weet u zeker dat u de naam wil aanpassen?", "bevestiging", MessageBoxButtons.YesNo); // zet hier een knop 'ok' en 'oh nee, sorry'
                                // als er op ok wordt geklikt
                                if (dialoog1 == DialogResult.Yes)
                                {
                                    DialogResult dialoog2 = MessageBox.Show("Weet u het HEEL zeker dat u deze naam wil aanpassen?", "bevestiging", MessageBoxButtons.YesNo); // knop 'ja' en 'eigenlijk toch niet'
                                    if (dialoog2 == DialogResult.Yes)
                                    {
                                        // als er op 'ja' wordt geklikt
                                        DialogResult dialoog3 = MessageBox.Show("Weet u het HEEL HEEL zeker dat deze naam moet worden veranderd?", "bevestiging", MessageBoxButtons.YesNo);
                                        if (dialoog3 == DialogResult.Yes)
                                        {
                                            MessageBox.Show("Ok, we zullen het ook echt aanpassen nu.");
                                            MessageBox.Show($"✅ '{kolomNaam}' bij ID {id} is bijgewerkt.");
                                        }
                                    }
                                }
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
                    finally
                    {
                        conn.Close(); // connectie sluiten
                    }
                }
                if (idValue == null || idValue == DBNull.Value)
                {
                    MessageBox.Show("De ID voor deze rij is niet ingesteld.  De rij kan niet worden bijgewerkt.", "ID Niet Beschikbaar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Als er geen ID is gevonden, stopt het
                }

            }
        }

        private void btnNewRij_Click(object sender, EventArgs e)
        {
            /*
             * documentatie bestand openen in notepad
             * we wouden dit een nieuwe rij laten maken, maar goed
             * het opent nu een textbestand
            */
            Process.Start("notepad.exe", bestand);
        }
    }
}