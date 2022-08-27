namespace GenClinic
{
    partial class MedcineKashf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedcineKashf));
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmb_MedcinType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_close = new System.Windows.Forms.Button();
            this.bt_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Name.Location = new System.Drawing.Point(12, 18);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Name.Size = new System.Drawing.Size(343, 23);
            this.txt_Name.TabIndex = 5;
            this.txt_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(384, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 19);
            this.label19.TabIndex = 34;
            this.label19.Text = "الإســـم";
            // 
            // cmb_MedcinType
            // 
            this.cmb_MedcinType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_MedcinType.FormattingEnabled = true;
            this.cmb_MedcinType.Location = new System.Drawing.Point(12, 83);
            this.cmb_MedcinType.Name = "cmb_MedcinType";
            this.cmb_MedcinType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_MedcinType.Size = new System.Drawing.Size(343, 24);
            this.cmb_MedcinType.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(382, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 36;
            this.label1.Text = "الجرعة";
            // 
            // bt_close
            // 
            this.bt_close.Image = global::GenClinic.Properties.Resources.Log_Out_24x24;
            this.bt_close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_close.Location = new System.Drawing.Point(86, 133);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(83, 32);
            this.bt_close.TabIndex = 41;
            this.bt_close.Text = "خروج";
            this.bt_close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.Image = global::GenClinic.Properties.Resources.Save_24x24;
            this.bt_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Save.Location = new System.Drawing.Point(175, 133);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(83, 32);
            this.bt_Save.TabIndex = 38;
            this.bt_Save.Text = "حفظ";
            this.bt_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // MedcineKashf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 188);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_MedcinType);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txt_Name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MedcineKashf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة الأدوية";
            this.Load += new System.EventHandler(this.MedcineKashf_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmb_MedcinType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.Button bt_close;
    }
}