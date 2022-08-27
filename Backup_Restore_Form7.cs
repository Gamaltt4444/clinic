using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;

using System.Windows.Forms;
using System.Threading;
//using Microsoft.Win32;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace GenClinic
{
    public partial class Backup_Restore_Form7 : Form
    {
        // you must add to refrence Microsoft.SqlServer.ConnectionInfo ,  Microsoft.SqlServer.Management.Sdk.Sfc
        // Microsoft.SqlServer.Smo   ,  Microsoft.SqlServer.SmoExtended
        Server srv;
        ServerConnection conn;

        string databaseName = "GenClinicDB";  // hassan


        public Backup_Restore_Form7()
        {
            InitializeComponent();
        }

        private void Backup_Restore_Form7_Load(object sender, EventArgs e)
        {
           
          
            
            
            
          }
        //===================
        private string todaydate()
        {
            string d, m, y;
            DateTime dt = DateTime.Now;
            d = dt.Day.ToString();
            m = dt.Month.ToString();
            y = dt.Year.ToString();
            return d + "_" + m + "_" + y;
            


        }
       //=========================

    

       

        private void btnBackupDB_Click(object sender, EventArgs e)
        {
            //conn = new ServerConnection(".\\sql2008", "sa", "**********");
            conn = new ServerConnection("."); // mean we use win authontication
            srv = new Server(conn);//hassan
            //=================
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
            {
               
                return;
            }
            string foldername = folderBrowserDialog1.SelectedPath;
            string fileName = @foldername + "\\" + todaydate() + "_Clinic.bak";// hassan
              if (Directory.Exists(fileName))
              {
                   MessageBox.Show("this file is already exist please select another folder");
                   return;
              }
            //====================
          
            Backup bkp = new Backup();

            this.Cursor = Cursors.WaitCursor;
           
            try
            {

                

                bkp.Action = BackupActionType.Database;
                bkp.Database = databaseName;
                bkp.Devices.AddDevice(fileName, DeviceType.File);
                bkp.Incremental = false;
                this.progressBar1.Value = 0;
                this.progressBar1.Maximum = 100;
                this.progressBar1.Value = 10;

                bkp.PercentCompleteNotification = 10;
                bkp.PercentComplete += new PercentCompleteEventHandler(ProgressEventHandler);

                bkp.SqlBackup(srv);
                MessageBox.Show("Database Backed Up To: " + fileName, "Backup is compelete");
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.progressBar1.Value = 0;
            }
        }

        public void ProgressEventHandler(object sender, PercentCompleteEventArgs e)
        {
            this.progressBar1.Value = e.Percent;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            
            //=================
            #region get the databse backup Name and place
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "bak files (*.bak)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
                //txtFileName.Text = openFileDialog1.FileName.ToString();

            }

            #endregion
            //============
            string fileName = openFileDialog1.FileName.ToString(); 
            //===============
            //conn = new ServerConnection(".\\sql2008", "sa", "****************");
            conn = new ServerConnection(".");  // mean we use win authontication                             
            
            srv = new Server(conn);//hassan
            srv.KillAllProcesses(databaseName);
            srv.Refresh();
           
            //====================================
            Restore res = new Restore();

            this.Cursor = Cursors.WaitCursor;
            
            //========================
            #region verify backup is valid or not
            Restore rest = new Restore();
            try
            {
                rest.Devices.AddDevice(fileName, DeviceType.File);
                bool verifySuccessful = rest.SqlVerify(srv);

                if (verifySuccessful == false)
                {
                    MessageBox.Show("Backup NOT Verified! ", "Attention");
                    return;

                }

            }
            catch (SmoException exSMO)
            {
                MessageBox.Show(exSMO.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            #endregion
            //==================================
            try
            {
                
                

                res.Database = databaseName;
                res.Action = RestoreActionType.Database;
                res.Devices.AddDevice(fileName, DeviceType.File);

                this.progressBar1.Value = 0;
                this.progressBar1.Maximum = 100;
                this.progressBar1.Value = 10;

                res.PercentCompleteNotification = 10;
                res.ReplaceDatabase = true;
                res.PercentComplete += new PercentCompleteEventHandler(ProgressEventHandler);
                res.SqlRestore(srv);

                MessageBox.Show("Restore of Database is Complete!", "Restore",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (SmoException exSMO)
            {
                MessageBox.Show(exSMO.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.progressBar1.Value = 0;
            }


            //=====================
            srv.Refresh();

        }

     

    

        delegate void SetMessageCallback(string text);

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
