namespace Pulsuz_Mesaj
{
    partial class formFeedBack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formFeedBack));
            this.lblCreator = new System.Windows.Forms.Label();
            this.lblMsn = new System.Windows.Forms.Label();
            this.lblFacebook = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblCreator
            // 
            this.lblCreator.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCreator.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCreator.Location = new System.Drawing.Point(38, 37);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(209, 40);
            this.lblCreator.TabIndex = 1;
            this.lblCreator.Text = "Müəllif: Elvin Əfəndiyev;";
            this.lblCreator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMsn
            // 
            this.lblMsn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMsn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblMsn.Location = new System.Drawing.Point(38, 77);
            this.lblMsn.Name = "lblMsn";
            this.lblMsn.Size = new System.Drawing.Size(209, 40);
            this.lblMsn.TabIndex = 2;
            this.lblMsn.Text = "Msn: hers19@hotmail.com;";
            this.lblMsn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFacebook
            // 
            this.lblFacebook.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFacebook.Location = new System.Drawing.Point(66, 117);
            this.lblFacebook.Name = "lblFacebook";
            this.lblFacebook.Size = new System.Drawing.Size(153, 40);
            this.lblFacebook.TabIndex = 4;
            this.lblFacebook.TabStop = true;
            this.lblFacebook.Text = "Facebook: kliklə.";
            this.lblFacebook.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFacebook.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFacebook_LinkClicked);
            // 
            // formFeedBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(284, 203);
            this.Controls.Add(this.lblFacebook);
            this.Controls.Add(this.lblMsn);
            this.Controls.Add(this.lblCreator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formFeedBack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Əlaqə";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCreator;
        private System.Windows.Forms.Label lblMsn;
        private System.Windows.Forms.LinkLabel lblFacebook;
    }
}