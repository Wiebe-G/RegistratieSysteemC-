namespace WiebeRonnieRegistratie
{
    partial class frmInlog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTabInlog = new TableLayoutPanel();
            txtName = new TextBox();
            txtPassword = new TextBox();
            btnInlog = new Button();
            pnlTabInlog.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTabInlog
            // 
            pnlTabInlog.ColumnCount = 1;
            pnlTabInlog.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlTabInlog.Controls.Add(txtName, 0, 0);
            pnlTabInlog.Controls.Add(txtPassword, 0, 1);
            pnlTabInlog.Controls.Add(btnInlog, 0, 2);
            pnlTabInlog.Dock = DockStyle.Fill;
            pnlTabInlog.Location = new Point(0, 0);
            pnlTabInlog.Name = "pnlTabInlog";
            pnlTabInlog.RowCount = 3;
            pnlTabInlog.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            pnlTabInlog.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            pnlTabInlog.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            pnlTabInlog.Size = new Size(1261, 529);
            pnlTabInlog.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.BackColor = SystemColors.ButtonFace;
            txtName.Dock = DockStyle.Fill;
            txtName.Location = new Point(3, 3);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Gebruikersnaam";
            txtName.Size = new Size(1255, 170);
            txtName.TabIndex = 0;
            txtName.TextAlign = HorizontalAlignment.Center;
            txtName.KeyDown += txtName_KeyDown;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.ButtonFace;
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Location = new Point(3, 179);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Vul hier uw wachtwoord in";
            txtPassword.Size = new Size(1255, 170);
            txtPassword.TabIndex = 1;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // btnInlog
            // 
            btnInlog.BackColor = SystemColors.ButtonFace;
            btnInlog.Dock = DockStyle.Fill;
            btnInlog.Location = new Point(3, 355);
            btnInlog.Name = "btnInlog";
            btnInlog.Size = new Size(1255, 171);
            btnInlog.TabIndex = 2;
            btnInlog.Text = "Log in";
            btnInlog.UseVisualStyleBackColor = false;
            btnInlog.Click += btnInlog_Click;
            // 
            // frmInlog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1261, 529);
            Controls.Add(pnlTabInlog);
            Name = "frmInlog";
            Text = "Inloggen";
            pnlTabInlog.ResumeLayout(false);
            pnlTabInlog.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel pnlTabInlog;
        private TextBox txtName;
        private TextBox txtPassword;
        private Button btnInlog;
    }
}
