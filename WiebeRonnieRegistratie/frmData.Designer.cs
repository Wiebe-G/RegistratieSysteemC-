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
            this.pnlTabData = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAdres = new System.Windows.Forms.Label();
            this.lblWoonplaats = new System.Windows.Forms.Label();
            this.lblPrestaties = new System.Windows.Forms.Label();
            this.lblCommentaar = new System.Windows.Forms.Label();
            this.pnlTabData.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTabData
            // 
            this.pnlTabData.ColumnCount = 5;
            this.pnlTabData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.41748F));
            this.pnlTabData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.4174767F));
            this.pnlTabData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.4174767F));
            this.pnlTabData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.4174767F));
            this.pnlTabData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.3300972F));
            this.pnlTabData.Controls.Add(this.lblName, 0, 0);
            this.pnlTabData.Controls.Add(this.lblAdres, 1, 0);
            this.pnlTabData.Controls.Add(this.lblWoonplaats, 2, 0);
            this.pnlTabData.Controls.Add(this.lblPrestaties, 3, 0);
            this.pnlTabData.Controls.Add(this.lblCommentaar, 4, 0);
            this.pnlTabData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabData.Location = new System.Drawing.Point(0, 0);
            this.pnlTabData.Name = "pnlTabData";
            this.pnlTabData.RowCount = 3;
            this.pnlTabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlTabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.pnlTabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.pnlTabData.Size = new System.Drawing.Size(1233, 526);
            this.pnlTabData.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(233, 52);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Naam:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAdres
            // 
            this.lblAdres.AutoSize = true;
            this.lblAdres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAdres.Location = new System.Drawing.Point(242, 0);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new System.Drawing.Size(233, 52);
            this.lblAdres.TabIndex = 1;
            this.lblAdres.Text = "Adres:";
            this.lblAdres.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWoonplaats
            // 
            this.lblWoonplaats.AutoSize = true;
            this.lblWoonplaats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWoonplaats.Location = new System.Drawing.Point(481, 0);
            this.lblWoonplaats.Name = "lblWoonplaats";
            this.lblWoonplaats.Size = new System.Drawing.Size(233, 52);
            this.lblWoonplaats.TabIndex = 2;
            this.lblWoonplaats.Text = "Woonplaats:";
            this.lblWoonplaats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrestaties
            // 
            this.lblPrestaties.AutoSize = true;
            this.lblPrestaties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrestaties.Location = new System.Drawing.Point(720, 0);
            this.lblPrestaties.Name = "lblPrestaties";
            this.lblPrestaties.Size = new System.Drawing.Size(233, 52);
            this.lblPrestaties.TabIndex = 3;
            this.lblPrestaties.Text = "Prestaties";
            this.lblPrestaties.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCommentaar
            // 
            this.lblCommentaar.AutoSize = true;
            this.lblCommentaar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCommentaar.Location = new System.Drawing.Point(959, 0);
            this.lblCommentaar.Name = "lblCommentaar";
            this.lblCommentaar.Size = new System.Drawing.Size(271, 52);
            this.lblCommentaar.TabIndex = 4;
            this.lblCommentaar.Text = "Speciaal commentaar: ";
            this.lblCommentaar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1233, 526);
            this.Controls.Add(this.pnlTabData);
            this.Name = "frmData";
            this.Text = "Hier staat de data";
            this.pnlTabData.ResumeLayout(false);
            this.pnlTabData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnlTabData;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAdres;
        private System.Windows.Forms.Label lblWoonplaats;
        private System.Windows.Forms.Label lblPrestaties;
        private System.Windows.Forms.Label lblCommentaar;
    }
}