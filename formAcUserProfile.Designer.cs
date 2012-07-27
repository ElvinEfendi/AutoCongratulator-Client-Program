namespace Pulsuz_Mesaj
{
    partial class formAcUserProfile
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblUserProfile = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCurrentProfile = new System.Windows.Forms.Button();
            this.gbSign = new System.Windows.Forms.GroupBox();
            this.lblForSign = new System.Windows.Forms.Label();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.gbPassword = new System.Windows.Forms.GroupBox();
            this.lblForPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.gbUsername = new System.Windows.Forms.GroupBox();
            this.lblForUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.gbMobileNumber = new System.Windows.Forms.GroupBox();
            this.cmbMobileNumberPrefix = new System.Windows.Forms.ComboBox();
            this.lblForMobileNumber = new System.Windows.Forms.Label();
            this.txtMobileNumber = new System.Windows.Forms.TextBox();
            this.gbOperator = new System.Windows.Forms.GroupBox();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.lblForOperator = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbSign.SuspendLayout();
            this.gbPassword.SuspendLayout();
            this.gbUsername.SuspendLayout();
            this.gbMobileNumber.SuspendLayout();
            this.gbOperator.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel1.Controls.Add(this.btnDeleteUser);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.lblUserProfile);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnCurrentProfile);
            this.panel1.Controls.Add(this.gbSign);
            this.panel1.Controls.Add(this.gbPassword);
            this.panel1.Controls.Add(this.gbUsername);
            this.panel1.Controls.Add(this.gbMobileNumber);
            this.panel1.Controls.Add(this.gbOperator);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 582);
            this.panel1.TabIndex = 0;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(213, 528);
            this.btnDeleteUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(92, 50);
            this.btnDeleteUser.TabIndex = 9;
            this.btnDeleteUser.Text = "Sistemdən sil";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(313, 528);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 50);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Bağla";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblUserProfile
            // 
            this.lblUserProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUserProfile.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblUserProfile.Location = new System.Drawing.Point(119, 11);
            this.lblUserProfile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserProfile.Name = "lblUserProfile";
            this.lblUserProfile.Size = new System.Drawing.Size(146, 33);
            this.lblUserProfile.TabIndex = 31;
            this.lblUserProfile.Text = "İstifadəçi paneli";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(7, 528);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(99, 50);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Məlumatları yenilə";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCurrentProfile
            // 
            this.btnCurrentProfile.Location = new System.Drawing.Point(112, 528);
            this.btnCurrentProfile.Margin = new System.Windows.Forms.Padding(4);
            this.btnCurrentProfile.Name = "btnCurrentProfile";
            this.btnCurrentProfile.Size = new System.Drawing.Size(95, 50);
            this.btnCurrentProfile.TabIndex = 8;
            this.btnCurrentProfile.Text = "Əvvəlki məlumatlar";
            this.btnCurrentProfile.UseVisualStyleBackColor = true;
            this.btnCurrentProfile.Click += new System.EventHandler(this.btnCurrentProfile_Click);
            // 
            // gbSign
            // 
            this.gbSign.Controls.Add(this.lblForSign);
            this.gbSign.Controls.Add(this.txtSign);
            this.gbSign.Location = new System.Drawing.Point(9, 431);
            this.gbSign.Margin = new System.Windows.Forms.Padding(4);
            this.gbSign.Name = "gbSign";
            this.gbSign.Padding = new System.Windows.Forms.Padding(4);
            this.gbSign.Size = new System.Drawing.Size(365, 90);
            this.gbSign.TabIndex = 28;
            this.gbSign.TabStop = false;
            this.gbSign.Text = "İstifadəçi imzası";
            // 
            // lblForSign
            // 
            this.lblForSign.ForeColor = System.Drawing.Color.Red;
            this.lblForSign.Location = new System.Drawing.Point(9, 53);
            this.lblForSign.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForSign.Name = "lblForSign";
            this.lblForSign.Size = new System.Drawing.Size(337, 33);
            this.lblForSign.TabIndex = 0;
            this.lblForSign.Text = "* Əgər bu xananı doldursanız o zaman imzanız hər bir təbrik mesajının sonuna əlav" +
                "ə ediləcək";
            // 
            // txtSign
            // 
            this.txtSign.Location = new System.Drawing.Point(17, 23);
            this.txtSign.Margin = new System.Windows.Forms.Padding(4);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(173, 22);
            this.txtSign.TabIndex = 6;
            // 
            // gbPassword
            // 
            this.gbPassword.Controls.Add(this.lblForPassword);
            this.gbPassword.Controls.Add(this.txtPassword);
            this.gbPassword.Location = new System.Drawing.Point(9, 332);
            this.gbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.gbPassword.Name = "gbPassword";
            this.gbPassword.Padding = new System.Windows.Forms.Padding(4);
            this.gbPassword.Size = new System.Drawing.Size(365, 91);
            this.gbPassword.TabIndex = 27;
            this.gbPassword.TabStop = false;
            this.gbPassword.Text = "İstifadəçi şifrəsi";
            // 
            // lblForPassword
            // 
            this.lblForPassword.ForeColor = System.Drawing.Color.Red;
            this.lblForPassword.Location = new System.Drawing.Point(9, 53);
            this.lblForPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForPassword.Name = "lblForPassword";
            this.lblForPassword.Size = new System.Drawing.Size(349, 34);
            this.lblForPassword.TabIndex = 0;
            this.lblForPassword.Text = "* Buraya VebMesaj göndərmək üçün daxil etdiyiniz(nömrənizə uyğun) şifrəni yazın";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(17, 23);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(173, 22);
            this.txtPassword.TabIndex = 5;
            // 
            // gbUsername
            // 
            this.gbUsername.Controls.Add(this.lblForUsername);
            this.gbUsername.Controls.Add(this.txtUsername);
            this.gbUsername.Location = new System.Drawing.Point(9, 233);
            this.gbUsername.Margin = new System.Windows.Forms.Padding(4);
            this.gbUsername.Name = "gbUsername";
            this.gbUsername.Padding = new System.Windows.Forms.Padding(4);
            this.gbUsername.Size = new System.Drawing.Size(365, 92);
            this.gbUsername.TabIndex = 26;
            this.gbUsername.TabStop = false;
            this.gbUsername.Text = "İstifadəçi adı";
            // 
            // lblForUsername
            // 
            this.lblForUsername.ForeColor = System.Drawing.Color.Red;
            this.lblForUsername.Location = new System.Drawing.Point(9, 53);
            this.lblForUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForUsername.Name = "lblForUsername";
            this.lblForUsername.Size = new System.Drawing.Size(349, 33);
            this.lblForUsername.TabIndex = 0;
            this.lblForUsername.Text = "* Buraya VebMesaj göndərmək üçün daxil etdiyiniz(nömrənizə uyğun) istifadəçi adın" +
                "ı yazın";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(17, 23);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(173, 22);
            this.txtUsername.TabIndex = 4;
            // 
            // gbMobileNumber
            // 
            this.gbMobileNumber.Controls.Add(this.cmbMobileNumberPrefix);
            this.gbMobileNumber.Controls.Add(this.lblForMobileNumber);
            this.gbMobileNumber.Controls.Add(this.txtMobileNumber);
            this.gbMobileNumber.Location = new System.Drawing.Point(9, 135);
            this.gbMobileNumber.Margin = new System.Windows.Forms.Padding(4);
            this.gbMobileNumber.Name = "gbMobileNumber";
            this.gbMobileNumber.Padding = new System.Windows.Forms.Padding(4);
            this.gbMobileNumber.Size = new System.Drawing.Size(365, 90);
            this.gbMobileNumber.TabIndex = 25;
            this.gbMobileNumber.TabStop = false;
            this.gbMobileNumber.Text = "Mobil telefon nömrəniz";
            // 
            // cmbMobileNumberPrefix
            // 
            this.cmbMobileNumberPrefix.FormattingEnabled = true;
            this.cmbMobileNumberPrefix.Items.AddRange(new object[] {
            "55",
            "50",
            "51"});
            this.cmbMobileNumberPrefix.Location = new System.Drawing.Point(17, 23);
            this.cmbMobileNumberPrefix.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMobileNumberPrefix.Name = "cmbMobileNumberPrefix";
            this.cmbMobileNumberPrefix.Size = new System.Drawing.Size(71, 24);
            this.cmbMobileNumberPrefix.TabIndex = 2;
            // 
            // lblForMobileNumber
            // 
            this.lblForMobileNumber.ForeColor = System.Drawing.Color.Red;
            this.lblForMobileNumber.Location = new System.Drawing.Point(9, 53);
            this.lblForMobileNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForMobileNumber.Name = "lblForMobileNumber";
            this.lblForMobileNumber.Size = new System.Drawing.Size(349, 33);
            this.lblForMobileNumber.TabIndex = 0;
            this.lblForMobileNumber.Text = "* Azercell-dən fərqli olaraq, Bakcell abunəçilərində mesajın göndərən hissəsində " +
                "bu nömrə görünəcək";
            // 
            // txtMobileNumber
            // 
            this.txtMobileNumber.Location = new System.Drawing.Point(95, 23);
            this.txtMobileNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtMobileNumber.Name = "txtMobileNumber";
            this.txtMobileNumber.Size = new System.Drawing.Size(173, 22);
            this.txtMobileNumber.TabIndex = 3;
            // 
            // gbOperator
            // 
            this.gbOperator.Controls.Add(this.cmbOperator);
            this.gbOperator.Controls.Add(this.lblForOperator);
            this.gbOperator.Location = new System.Drawing.Point(9, 48);
            this.gbOperator.Margin = new System.Windows.Forms.Padding(4);
            this.gbOperator.Name = "gbOperator";
            this.gbOperator.Padding = new System.Windows.Forms.Padding(4);
            this.gbOperator.Size = new System.Drawing.Size(365, 80);
            this.gbOperator.TabIndex = 24;
            this.gbOperator.TabStop = false;
            this.gbOperator.Text = "Operator seçin";
            // 
            // cmbOperator
            // 
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Items.AddRange(new object[] {
            "Bakcell",
            "Azercell"});
            this.cmbOperator.Location = new System.Drawing.Point(17, 23);
            this.cmbOperator.Margin = new System.Windows.Forms.Padding(4);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(173, 24);
            this.cmbOperator.TabIndex = 1;
            this.cmbOperator.SelectedIndexChanged += new System.EventHandler(this.cmbOperator_SelectedIndexChanged);
            // 
            // lblForOperator
            // 
            this.lblForOperator.ForeColor = System.Drawing.Color.Red;
            this.lblForOperator.Location = new System.Drawing.Point(9, 53);
            this.lblForOperator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForOperator.Name = "lblForOperator";
            this.lblForOperator.Size = new System.Drawing.Size(349, 25);
            this.lblForOperator.TabIndex = 0;
            this.lblForOperator.Text = "* Burada qeydiyyatda olduğunuz operatoru seçin";
            // 
            // formAcUserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 582);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "formAcUserProfile";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AvtoTəbrik İstifadəçi paneli";
            this.Load += new System.EventHandler(this.formAcUserProfile_Load);
            this.Shown += new System.EventHandler(this.formAcUserProfile_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formAcUserProfile_FormClosing);
            this.panel1.ResumeLayout(false);
            this.gbSign.ResumeLayout(false);
            this.gbSign.PerformLayout();
            this.gbPassword.ResumeLayout(false);
            this.gbPassword.PerformLayout();
            this.gbUsername.ResumeLayout(false);
            this.gbUsername.PerformLayout();
            this.gbMobileNumber.ResumeLayout(false);
            this.gbMobileNumber.PerformLayout();
            this.gbOperator.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblUserProfile;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCurrentProfile;
        private System.Windows.Forms.GroupBox gbSign;
        private System.Windows.Forms.Label lblForSign;
        private System.Windows.Forms.TextBox txtSign;
        private System.Windows.Forms.GroupBox gbPassword;
        private System.Windows.Forms.Label lblForPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.GroupBox gbUsername;
        private System.Windows.Forms.Label lblForUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.GroupBox gbMobileNumber;
        private System.Windows.Forms.Label lblForMobileNumber;
        private System.Windows.Forms.TextBox txtMobileNumber;
        private System.Windows.Forms.GroupBox gbOperator;
        private System.Windows.Forms.ComboBox cmbOperator;
        private System.Windows.Forms.Label lblForOperator;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.ComboBox cmbMobileNumberPrefix;
    }
}