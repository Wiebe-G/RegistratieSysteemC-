namespace WiebeRonnieRegistratie
{
    partial class frmData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTabData = new TableLayoutPanel();
            lblName = new Label();
            lblAdres = new Label();
            lblWoonplaats = new Label();
            lblPrestaties = new Label();
            lblCommentaar = new Label();
            pnlTabData.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTabData
            // 
            pnlTabData.ColumnCount = 5;
            pnlTabData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.41748F));
            pnlTabData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.4174767F));
            pnlTabData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.4174767F));
            pnlTabData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.4174767F));
            pnlTabData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.3300972F));
            pnlTabData.Controls.Add(lblName, 0, 0);
            pnlTabData.Controls.Add(lblAdres, 1, 0);
            pnlTabData.Controls.Add(lblWoonplaats, 2, 0);
            pnlTabData.Controls.Add(lblPrestaties, 3, 0);
            pnlTabData.Controls.Add(lblCommentaar, 4, 0);
            pnlTabData.Dock = DockStyle.Fill;
            pnlTabData.Location = new Point(0, 0);
            pnlTabData.Name = "pnlTabData";
            pnlTabData.RowCount = 3;
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            pnlTabData.Size = new Size(1215, 554);
            pnlTabData.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Dock = DockStyle.Fill;
            lblName.Location = new Point(3, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(229, 55);
            lblName.TabIndex = 0;
            lblName.Text = "Naam:";
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAdres
            // 
            lblAdres.AutoSize = true;
            lblAdres.Dock = DockStyle.Fill;
            lblAdres.Location = new Point(238, 0);
            lblAdres.Name = "lblAdres";
            lblAdres.Size = new Size(229, 55);
            lblAdres.TabIndex = 1;
            lblAdres.Text = "Adres:";
            lblAdres.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWoonplaats
            // 
            lblWoonplaats.AutoSize = true;
            lblWoonplaats.Dock = DockStyle.Fill;
            lblWoonplaats.Location = new Point(473, 0);
            lblWoonplaats.Name = "lblWoonplaats";
            lblWoonplaats.Size = new Size(229, 55);
            lblWoonplaats.TabIndex = 2;
            lblWoonplaats.Text = "Woonplaats:";
            lblWoonplaats.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPrestaties
            // 
            lblPrestaties.AutoSize = true;
            lblPrestaties.Dock = DockStyle.Fill;
            lblPrestaties.Location = new Point(708, 0);
            lblPrestaties.Name = "lblPrestaties";
            lblPrestaties.Size = new Size(229, 55);
            lblPrestaties.TabIndex = 3;
            lblPrestaties.Text = "Prestaties";
            lblPrestaties.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCommentaar
            // 
            lblCommentaar.AutoSize = true;
            lblCommentaar.Dock = DockStyle.Fill;
            lblCommentaar.Location = new Point(943, 0);
            lblCommentaar.Name = "lblCommentaar";
            lblCommentaar.Size = new Size(269, 55);
            lblCommentaar.TabIndex = 4;
            lblCommentaar.Text = "Speciaal commentaar: ";
            lblCommentaar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1215, 554);
            Controls.Add(pnlTabData);
            Name = "frmData";
            Text = "Hier staat de data";
            pnlTabData.ResumeLayout(false);
            pnlTabData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel pnlTabData;
        private Label lblName;
        private Label lblAdres;
        private Label lblWoonplaats;
        private Label lblPrestaties;
        private Label lblCommentaar;
    }
}