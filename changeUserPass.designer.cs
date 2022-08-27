namespace GenClinic
{
    partial class changeUserPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changeUserPass));
            this.label2 = new System.Windows.Forms.Label();
            this.txt_oldPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_USERname = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_new1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_new2 = new System.Windows.Forms.TextBox();
            this.bt_Update = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(247, 147);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = " القديمة";
            this.label2.Visible = false;
            // 
            // txt_oldPass
            // 
            this.txt_oldPass.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_oldPass.Location = new System.Drawing.Point(222, 147);
            this.txt_oldPass.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_oldPass.Name = "txt_oldPass";
            this.txt_oldPass.PasswordChar = '*';
            this.txt_oldPass.Size = new System.Drawing.Size(12, 27);
            this.txt_oldPass.TabIndex = 2;
            this.txt_oldPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_oldPass.UseSystemPasswordChar = true;
            this.txt_oldPass.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(235, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "الإسم";
            // 
            // cmb_USERname
            // 
            this.cmb_USERname.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_USERname.FormattingEnabled = true;
            this.cmb_USERname.Location = new System.Drawing.Point(17, 9);
            this.cmb_USERname.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmb_USERname.Name = "cmb_USERname";
            this.cmb_USERname.Size = new System.Drawing.Size(195, 27);
            this.cmb_USERname.TabIndex = 1;
            this.cmb_USERname.SelectedIndexChanged += new System.EventHandler(this.cmb_USERname_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(219, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "كلمة السرالجديدة";
            // 
            // txt_new1
            // 
            this.txt_new1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_new1.Location = new System.Drawing.Point(20, 57);
            this.txt_new1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_new1.Name = "txt_new1";
            this.txt_new1.PasswordChar = '#';
            this.txt_new1.Size = new System.Drawing.Size(189, 27);
            this.txt_new1.TabIndex = 3;
            this.txt_new1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_new1.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(222, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "إعادة كلمة السر";
            // 
            // txt_new2
            // 
            this.txt_new2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_new2.Location = new System.Drawing.Point(20, 105);
            this.txt_new2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_new2.Name = "txt_new2";
            this.txt_new2.PasswordChar = '#';
            this.txt_new2.Size = new System.Drawing.Size(189, 27);
            this.txt_new2.TabIndex = 4;
            this.txt_new2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_new2.UseSystemPasswordChar = true;
            // 
            // bt_Update
            // 
            this.bt_Update.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Update.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Update.Image = global::GenClinic.Properties.Resources.Save_24x24;
            this.bt_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Update.Location = new System.Drawing.Point(104, 146);
            this.bt_Update.Name = "bt_Update";
            this.bt_Update.Size = new System.Drawing.Size(63, 42);
            this.bt_Update.TabIndex = 48;
            this.bt_Update.Text = "حفظ";
            this.bt_Update.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Update.UseVisualStyleBackColor = false;
            this.bt_Update.Click += new System.EventHandler(this.bt_Update_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::GenClinic.Properties.Resources.Log_Out_24x24;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(18, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 42);
            this.button1.TabIndex = 47;
            this.button1.Text = "خروج";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // changeUserPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(312, 200);
            this.Controls.Add(this.bt_Update);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_new2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_new1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_oldPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_USERname);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "changeUserPass";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تغيير كلمة السر";
            this.Load += new System.EventHandler(this.changeUserPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_oldPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_USERname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_new1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_new2;
        private System.Windows.Forms.Button bt_Update;
        private System.Windows.Forms.Button button1;
    }
}