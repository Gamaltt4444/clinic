namespace GenClinic
{
    partial class AddPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPatient));
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bt_close = new System.Windows.Forms.Button();
            this.bt_New = new System.Windows.Forms.Button();
            this.bt_Update = new System.Windows.Forms.Button();
            this.bt_Save = new System.Windows.Forms.Button();
            this.checkBox_Delete = new System.Windows.Forms.CheckBox();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_facebook = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_mail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Adrress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_mobile2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Mobile1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.txt_Search_code = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_Tamine = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Name.Location = new System.Drawing.Point(451, 67);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Name.Size = new System.Drawing.Size(268, 26);
            this.txt_Name.TabIndex = 5;
            this.txt_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(756, 69);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 19);
            this.label19.TabIndex = 34;
            this.label19.Text = "الإســــم";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(5, 69);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(247, 394);
            this.listBox1.TabIndex = 37;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // bt_close
            // 
            this.bt_close.Image = global::GenClinic.Properties.Resources.Log_Out_24x24;
            this.bt_close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_close.Location = new System.Drawing.Point(345, 431);
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
            this.bt_New.Location = new System.Drawing.Point(609, 431);
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
            this.bt_Update.Location = new System.Drawing.Point(433, 431);
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
            this.bt_Save.Location = new System.Drawing.Point(521, 431);
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
            this.checkBox_Delete.Location = new System.Drawing.Point(258, 70);
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
            this.txt_Search.Location = new System.Drawing.Point(94, 32);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Search.Size = new System.Drawing.Size(158, 23);
            this.txt_Search.TabIndex = 141;
            this.txt_Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(749, 377);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 19);
            this.label14.TabIndex = 158;
            this.label14.Text = "فيس بوك";
            // 
            // txt_facebook
            // 
            this.txt_facebook.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_facebook.Location = new System.Drawing.Point(332, 377);
            this.txt_facebook.Name = "txt_facebook";
            this.txt_facebook.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_facebook.Size = new System.Drawing.Size(387, 26);
            this.txt_facebook.TabIndex = 152;
            this.txt_facebook.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(723, 325);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 19);
            this.label13.TabIndex = 157;
            this.label13.Text = "بريد إليكترونى";
            // 
            // txt_mail
            // 
            this.txt_mail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mail.Location = new System.Drawing.Point(332, 325);
            this.txt_mail.Name = "txt_mail";
            this.txt_mail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_mail.Size = new System.Drawing.Size(387, 26);
            this.txt_mail.TabIndex = 150;
            this.txt_mail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(756, 273);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 19);
            this.label11.TabIndex = 155;
            this.label11.Text = "العنوان";
            // 
            // txt_Adrress
            // 
            this.txt_Adrress.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Adrress.Location = new System.Drawing.Point(332, 273);
            this.txt_Adrress.Name = "txt_Adrress";
            this.txt_Adrress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Adrress.Size = new System.Drawing.Size(387, 26);
            this.txt_Adrress.TabIndex = 149;
            this.txt_Adrress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(472, 221);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 19);
            this.label9.TabIndex = 154;
            this.label9.Text = "موبايل 2";
            // 
            // txt_mobile2
            // 
            this.txt_mobile2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mobile2.Location = new System.Drawing.Point(332, 221);
            this.txt_mobile2.Name = "txt_mobile2";
            this.txt_mobile2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_mobile2.Size = new System.Drawing.Size(134, 26);
            this.txt_mobile2.TabIndex = 145;
            this.txt_mobile2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(750, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 19);
            this.label10.TabIndex = 153;
            this.label10.Text = "موبايل 1";
            // 
            // txt_Mobile1
            // 
            this.txt_Mobile1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Mobile1.Location = new System.Drawing.Point(544, 221);
            this.txt_Mobile1.Name = "txt_Mobile1";
            this.txt_Mobile1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Mobile1.Size = new System.Drawing.Size(175, 26);
            this.txt_Mobile1.TabIndex = 144;
            this.txt_Mobile1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(759, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 19);
            this.label7.TabIndex = 148;
            this.label7.Text = "تليفون ";
            // 
            // txt_phone
            // 
            this.txt_phone.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_phone.Location = new System.Drawing.Point(332, 169);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_phone.Size = new System.Drawing.Size(387, 26);
            this.txt_phone.TabIndex = 142;
            this.txt_phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(418, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 19);
            this.label1.TabIndex = 159;
            this.label1.Text = "كود";
            // 
            // txt_code
            // 
            this.txt_code.Enabled = false;
            this.txt_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_code.Location = new System.Drawing.Point(332, 67);
            this.txt_code.Name = "txt_code";
            this.txt_code.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_code.Size = new System.Drawing.Size(83, 26);
            this.txt_code.TabIndex = 160;
            this.txt_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Search_code
            // 
            this.txt_Search_code.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search_code.Location = new System.Drawing.Point(12, 32);
            this.txt_Search_code.Name = "txt_Search_code";
            this.txt_Search_code.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Search_code.Size = new System.Drawing.Size(72, 26);
            this.txt_Search_code.TabIndex = 161;
            this.txt_Search_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Search_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Search_code_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 19);
            this.label2.TabIndex = 162;
            this.label2.Text = "كود";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(162, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 163;
            this.label3.Text = "الإســــم";
            // 
            // cmb_Tamine
            // 
            this.cmb_Tamine.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Tamine.FormattingEnabled = true;
            this.cmb_Tamine.Location = new System.Drawing.Point(332, 119);
            this.cmb_Tamine.Name = "cmb_Tamine";
            this.cmb_Tamine.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_Tamine.Size = new System.Drawing.Size(387, 24);
            this.cmb_Tamine.TabIndex = 164;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(760, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 19);
            this.label4.TabIndex = 165;
            this.label4.Text = "التأمين";
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Image = global::GenClinic.Properties.Resources.Remove_48x48;
            this.button1.Location = new System.Drawing.Point(253, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 62);
            this.button1.TabIndex = 194;
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 475);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_Tamine);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Search_code);
            this.Controls.Add(this.txt_code);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt_facebook);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_mail);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_Adrress);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_mobile2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_Mobile1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_phone);
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
            this.Name = "AddPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Patient_Load);
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
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_facebook;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_mail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_Adrress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_mobile2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Mobile1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.TextBox txt_Search_code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_Tamine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}