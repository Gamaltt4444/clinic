namespace GenClinic
{
    partial class Backup_Restore_Form7
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
       

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Backup_Restore_Form7));
            this.btnBackupDB = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bt_Exit = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnBackupDB
            // 
            this.btnBackupDB.Location = new System.Drawing.Point(93, 95);
            this.btnBackupDB.Name = "btnBackupDB";
            this.btnBackupDB.Size = new System.Drawing.Size(166, 53);
            this.btnBackupDB.TabIndex = 12;
            this.btnBackupDB.Text = "نسخ إحتياطى";
            this.btnBackupDB.UseVisualStyleBackColor = true;
            this.btnBackupDB.Click += new System.EventHandler(this.btnBackupDB_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(295, 95);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(166, 53);
            this.btnRestore.TabIndex = 15;
            this.btnRestore.Text = "إسترداد النسخ الإحتياطية";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 192);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(589, 23);
            this.progressBar1.TabIndex = 17;
            // 
            // bt_Exit
            // 
            this.bt_Exit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Exit.Image = global::GenClinic.Properties.Resources.Log_Out_24x24;
            this.bt_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Exit.Location = new System.Drawing.Point(250, 253);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(79, 32);
            this.bt_Exit.TabIndex = 84;
            this.bt_Exit.Text = "خروج";
            this.bt_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_Exit.UseVisualStyleBackColor = true;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // Backup_Restore_Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 306);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBackupDB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Backup_Restore_Form7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Database Backup &  Restore";
            this.Load += new System.EventHandler(this.Backup_Restore_Form7_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBackupDB;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button bt_Exit;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

