namespace GenClinic
{
    partial class AdddModifyTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdddModifyTest));
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bt_close = new System.Windows.Forms.Button();
            this.bt_New = new System.Windows.Forms.Button();
            this.bt_Update = new System.Windows.Forms.Button();
            this.bt_Save = new System.Windows.Forms.Button();
            this.checkBox_Delete = new System.Windows.Forms.CheckBox();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Name.Location = new System.Drawing.Point(241, 137);
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
            this.label19.Location = new System.Drawing.Point(594, 140);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 19);
            this.label19.TabIndex = 34;
            this.label19.Text = "الإســــم";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(5, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(230, 355);
            this.listBox1.TabIndex = 37;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // bt_close
            // 
            this.bt_close.Image = global::GenClinic.Properties.Resources.Log_Out_24x24;
            this.bt_close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_close.Location = new System.Drawing.Point(262, 295);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(83, 32);
            this.bt_close.TabIndex = 41;
            this.bt_close.Text = "خروج";
            this.bt_close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // bt_New
            // 
            this.bt_New.Image = global::GenClinic.Properties.Resources.New_24x24;
            this.bt_New.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_New.Location = new System.Drawing.Point(526, 295);
            this.bt_New.Name = "bt_New";
            this.bt_New.Size = new System.Drawing.Size(83, 32);
            this.bt_New.TabIndex = 40;
            this.bt_New.Text = "جديد";
            this.bt_New.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_New.UseVisualStyleBackColor = true;
            this.bt_New.Click += new System.EventHandler(this.bt_New_Click);
            // 
            // bt_Update
            // 
            this.bt_Update.Enabled = false;
            this.bt_Update.Image = global::GenClinic.Properties.Resources.Refresh_24x24;
            this.bt_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Update.Location = new System.Drawing.Point(350, 295);
            this.bt_Update.Name = "bt_Update";
            this.bt_Update.Size = new System.Drawing.Size(83, 32);
            this.bt_Update.TabIndex = 39;
            this.bt_Update.Text = "تعديل";
            this.bt_Update.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Update.UseVisualStyleBackColor = true;
            this.bt_Update.Click += new System.EventHandler(this.bt_Update_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.Enabled = false;
            this.bt_Save.Image = global::GenClinic.Properties.Resources.Save_24x24;
            this.bt_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Save.Location = new System.Drawing.Point(438, 295);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(83, 32);
            this.bt_Save.TabIndex = 38;
            this.bt_Save.Text = "حفظ";
            this.bt_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // checkBox_Delete
            // 
            this.checkBox_Delete.AutoSize = true;
            this.checkBox_Delete.Location = new System.Drawing.Point(515, 231);
            this.checkBox_Delete.Name = "checkBox_Delete";
            this.checkBox_Delete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_Delete.Size = new System.Drawing.Size(50, 17);
            this.checkBox_Delete.TabIndex = 140;
            this.checkBox_Delete.Text = "حذف ";
            this.checkBox_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_Delete.UseVisualStyleBackColor = true;
            // 
            // txt_Search
            // 
            this.txt_Search.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search.Location = new System.Drawing.Point(12, 12);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Search.Size = new System.Drawing.Size(223, 23);
            this.txt_Search.TabIndex = 141;
            this.txt_Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Image = global::GenClinic.Properties.Resources.Remove_48x48;
            this.button1.Location = new System.Drawing.Point(241, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 62);
            this.button1.TabIndex = 192;
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdddModifyTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 402);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.checkBox_Delete);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.bt_New);
            this.Controls.Add(this.bt_Update);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txt_Name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AdddModifyTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "التحاليل";
            this.Load += new System.EventHandler(this.AdddModifyTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.Button bt_Update;
        private System.Windows.Forms.Button bt_New;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.CheckBox checkBox_Delete;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Button button1;
    }
}