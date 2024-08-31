namespace TeknikServis.Formlar
{
    partial class FrmNotlarPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotlarPopup));
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.LblIlgiliTarih = new DevExpress.XtraEditors.LabelControl();
            this.LblKayitTarihi = new DevExpress.XtraEditors.LabelControl();
            this.LblId = new DevExpress.XtraEditors.LabelControl();
            this.LblKonu = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(408, 1);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(21, 26);
            this.pictureEdit1.TabIndex = 0;
            this.pictureEdit1.Click += new System.EventHandler(this.pictureEdit1_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(11, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(132, 17);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Not Oluşturma Tarihi";
            // 
            // LblIlgiliTarih
            // 
            this.LblIlgiliTarih.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblIlgiliTarih.Appearance.ForeColor = System.Drawing.Color.White;
            this.LblIlgiliTarih.Appearance.Options.UseFont = true;
            this.LblIlgiliTarih.Appearance.Options.UseForeColor = true;
            this.LblIlgiliTarih.Location = new System.Drawing.Point(259, 10);
            this.LblIlgiliTarih.Name = "LblIlgiliTarih";
            this.LblIlgiliTarih.Size = new System.Drawing.Size(33, 21);
            this.LblIlgiliTarih.TabIndex = 8;
            this.LblIlgiliTarih.Text = "Null";
            // 
            // LblKayitTarihi
            // 
            this.LblKayitTarihi.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblKayitTarihi.Appearance.ForeColor = System.Drawing.Color.White;
            this.LblKayitTarihi.Appearance.Options.UseFont = true;
            this.LblKayitTarihi.Appearance.Options.UseForeColor = true;
            this.LblKayitTarihi.Location = new System.Drawing.Point(165, 12);
            this.LblKayitTarihi.Name = "LblKayitTarihi";
            this.LblKayitTarihi.Size = new System.Drawing.Size(23, 17);
            this.LblKayitTarihi.TabIndex = 9;
            this.LblKayitTarihi.Text = "Null";
            // 
            // LblId
            // 
            this.LblId.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.LblId.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblId.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.LblId.Appearance.Options.UseBackColor = true;
            this.LblId.Appearance.Options.UseFont = true;
            this.LblId.Appearance.Options.UseForeColor = true;
            this.LblId.Enabled = false;
            this.LblId.Location = new System.Drawing.Point(593, 64);
            this.LblId.Name = "LblId";
            this.LblId.Size = new System.Drawing.Size(0, 17);
            this.LblId.TabIndex = 10;
            // 
            // LblKonu
            // 
            this.LblKonu.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblKonu.Appearance.ForeColor = System.Drawing.Color.White;
            this.LblKonu.Appearance.Options.UseFont = true;
            this.LblKonu.Appearance.Options.UseForeColor = true;
            this.LblKonu.Location = new System.Drawing.Point(7, 31);
            this.LblKonu.Name = "LblKonu";
            this.LblKonu.Size = new System.Drawing.Size(33, 21);
            this.LblKonu.TabIndex = 11;
            this.LblKonu.Text = "Null";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.LblKonu);
            this.panel1.Controls.Add(this.LblIlgiliTarih);
            this.panel1.Location = new System.Drawing.Point(13, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 152);
            this.panel1.TabIndex = 13;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBox1.Location = new System.Drawing.Point(2, 60);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(410, 87);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // FrmNotlarPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(441, 249);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblId);
            this.Controls.Add(this.LblKayitTarihi);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.pictureEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNotlarPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNotlarPopup";
            this.Load += new System.EventHandler(this.FrmNotlarPopup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl LblIlgiliTarih;
        private DevExpress.XtraEditors.LabelControl LblKayitTarihi;
        private DevExpress.XtraEditors.LabelControl LblId;
        private DevExpress.XtraEditors.LabelControl LblKonu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}