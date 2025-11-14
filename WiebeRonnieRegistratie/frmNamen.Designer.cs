namespace WiebeRonnieRegistratie
{
    partial class frmNamen
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
            lstStudenten = new ListBox();
            btnOpenForm = new Button();
            pnlTabData = new TableLayoutPanel();
            SuspendLayout();
            // 
            // lstStudenten
            // 
            lstStudenten.BackColor = SystemColors.ControlDark;
            lstStudenten.Dock = DockStyle.Fill;
            lstStudenten.FormattingEnabled = true;
            lstStudenten.Location = new Point(0, 0);
            lstStudenten.Name = "lstStudenten";
            lstStudenten.Size = new Size(120, 96);
            lstStudenten.TabIndex = 0;
            // 
            // btnOpenForm
            // 
            btnOpenForm.BackColor = SystemColors.ControlDark;
            btnOpenForm.Dock = DockStyle.Fill;
            btnOpenForm.Location = new Point(627, 3);
            btnOpenForm.Name = "btnOpenForm";
            btnOpenForm.Size = new Size(619, 512);
            btnOpenForm.TabIndex = 1;
            btnOpenForm.Text = "Zie de data van de geselecteerde student";
            btnOpenForm.UseVisualStyleBackColor = false;
            // 
            // pnlTabData
            // 
            pnlTabData.ColumnCount = 2;
            pnlTabData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlTabData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlTabData.Dock = DockStyle.Fill;
            pnlTabData.Location = new Point(0, 0);
            pnlTabData.Name = "pnlTabData";
            pnlTabData.RowCount = 2;
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            pnlTabData.Size = new Size(1249, 518);
            pnlTabData.TabIndex = 0;
            // 
            // frmNamen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            //ClientSize = new Size(1165, 525);
            Controls.Add(pnlTabData);
            Name = "frmNamen";
            Text = "Alle studenten";
            ResumeLayout(false);
            //ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel thistableLayoutPanel1;
        private ListBox lstStudenten;
        private Button btnOpenForm;
        private TableLayoutPanel pnlTabData;
    }
}