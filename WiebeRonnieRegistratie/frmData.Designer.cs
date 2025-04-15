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
            btnNewRij = new Button();
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
            pnlTabData.Controls.Add(btnNewRij, 4, 9);
            pnlTabData.Dock = DockStyle.Fill;
            pnlTabData.Location = new Point(0, 0);
            pnlTabData.Name = "pnlTabData";
            pnlTabData.RowCount = 10;
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            pnlTabData.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            pnlTabData.Size = new Size(1233, 526);
            pnlTabData.TabIndex = 0;
            // 
            // btnNewRij
            // 
            btnNewRij.Location = new Point(959, 471);
            btnNewRij.Name = "btnNewRij";
            btnNewRij.Size = new Size(233, 46);
            btnNewRij.TabIndex = 5;
            btnNewRij.Text = "Nieuwe rij toevoegen";
            btnNewRij.UseVisualStyleBackColor = true;
            btnNewRij.Click += btnNewRij_Click;
            // 
            // frmData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1233, 526);
            Controls.Add(pnlTabData);
            Name = "frmData";
            Text = "Hier staat de data";
            pnlTabData.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlTabData;
        private Button btnNewRij;
    }
}