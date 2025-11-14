// frmData.Designer.cs (This should be in the designer code file, usually nested under frmData.cs)
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
            pnlData1 = new Panel();
            lblPrestaties = new Label();
            lblWoonplaats = new Label();
            lblAdres = new Label();
            lblNaam = new Label();
            lblComment = new Label();
            pnlTabData.SuspendLayout();
            pnlData1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTabData
            // 
            pnlTabData.ColumnCount = 1;
            pnlTabData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlTabData.Controls.Add(pnlData1, 0, 0);
            pnlTabData.Controls.Add(lblComment, 0, 1);
            pnlTabData.Dock = DockStyle.Fill;
            pnlTabData.Location = new Point(0, 0);
            pnlTabData.Name = "pnlTabData";
            pnlTabData.RowCount = 2;
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            pnlTabData.Size = new Size(1233, 526);
            pnlTabData.TabIndex = 0;
            // 
            // pnlData1
            // 
            pnlData1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlData1.Controls.Add(lblPrestaties);
            pnlData1.Controls.Add(lblWoonplaats);
            pnlData1.Controls.Add(lblAdres);
            pnlData1.Controls.Add(lblNaam);
            pnlData1.Location = new Point(3, 3);
            pnlData1.Name = "pnlData1";
            pnlData1.Size = new Size(1227, 257);
            pnlData1.TabIndex = 0;
            // 
            // lblPrestaties
            // 
            lblPrestaties.AutoSize = true;
            lblPrestaties.Location = new Point(587, 200);
            lblPrestaties.Name = "lblPrestaties";
            lblPrestaties.Size = new Size(50, 20);
            lblPrestaties.TabIndex = 3;
            lblPrestaties.Text = "label4";
            // 
            // lblWoonplaats
            // 
            lblWoonplaats.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblWoonplaats.AutoSize = true;
            lblWoonplaats.Location = new Point(587, 153);
            lblWoonplaats.Name = "lblWoonplaats";
            lblWoonplaats.Size = new Size(50, 20);
            lblWoonplaats.TabIndex = 2;
            lblWoonplaats.Text = "label3";
            // 
            // lblAdres
            // 
            lblAdres.AutoSize = true;
            lblAdres.Location = new Point(587, 107);
            lblAdres.Name = "lblAdres";
            lblAdres.Size = new Size(50, 20);
            lblAdres.TabIndex = 1;
            lblAdres.Text = "label2";
            // 
            // lblNaam
            // 
            lblNaam.AutoSize = true;
            lblNaam.Location = new Point(587, 55);
            lblNaam.Name = "lblNaam";
            lblNaam.Size = new Size(50, 20);
            lblNaam.TabIndex = 0;
            lblNaam.Text = "label1";
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.Dock = DockStyle.Top;
            lblComment.Location = new Point(3, 263);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(1227, 20);
            lblComment.TabIndex = 1;
            lblComment.Text = "label5";
            lblComment.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1233, 526);
            Controls.Add(pnlTabData);
            Name = "frmData";
            Text = "Hier staat de data van de student";
            pnlTabData.ResumeLayout(false);
            pnlTabData.PerformLayout();
            pnlData1.ResumeLayout(false);
            pnlData1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel pnlTabData;
        private Panel pnlData1;
        private Label lblPrestaties;
        private Label lblWoonplaats;
        private Label lblAdres;
        private Label lblNaam;
        private Label lblComment;
    }
}