using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Management;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace GenClinic
{
    public partial class main : Form
    {
        //***********************
       
       
        public string stringcon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ExKEtaaGiarDB;Data Source=.";
        //********************  

        //===============================
      
        public static bool tempLoginflage=false;
        public static string tempLoginName;//to use name in printing
        public static int tempUeserUeserId;
        //======================
        //========================
        // using System.Management;
        //using System.IO;
        //001D6004CAA7BC302531016F old flashno
  
        //========================================
        public static int adminKind;// if it =1 admin
        public int GetSetadminKind
        {
            set { adminKind = value; }
            get { return adminKind; }
        }
        //===========================================
        //==============
        public static bool bacKupflage=false;
        public bool GetSetbacKupflage
        {
            set { bacKupflage = value; }
            get { return bacKupflage; }
        }
        //======================
        public bool GetSetLoginflage
        {
            set { tempLoginflage = value; }
            get { return tempLoginflage; }
        }
        public string GetSetLoginName
        {
            set { tempLoginName = value; }
            get { return tempLoginName; }
        }
        public int GetSetLoginUeserId
        {
            set { tempUeserUeserId = value; }
            get { return tempUeserUeserId; }
        }
        //====================================
        public main()
        {
            InitializeComponent();
        }
        ////////////////////////////////////////////////////
       
      
   
            
     
  
        //=========================  to make count for  ells order
     
        private void main_Load_1(object sender, EventArgs e)
        {
            this.Hide();        
            
       
            //============================
            //===================
            #region login
            LOGIN login1 = new LOGIN();
            login1.ShowDialog();///

            ////////////////////////////////
            if (GetSetLoginflage == false)
            {
                menuStrip1.Enabled = false;
                // toolStrip1.Enabled = false;
                Application.Exit();
            }
            else
            {
                //=================================                
                this.Show();
                //===================================
            }
            #endregion
            //--------------------------------------
           
          

        }
//==================

       


        private void fgdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About_program aa = new About_program();
            aa.ShowDialog();
        }
        //============================
        private void button1_Click(object sender, EventArgs e)
        {
            Kashf Kashf1 = new Kashf();
            Kashf1.ShowDialog();
        }
        //=============================
        private void تكويدالدواءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdddModifyMedcine AdddModifyMedcine1 = new AdddModifyMedcine();

            AdddModifyMedcine1.ShowDialog();
        }
     //===========================
        private void تكويدصنفلهباركودToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdddModifyGruaa AdddModifyGruaa1 = new AdddModifyGruaa();
            AdddModifyGruaa1.ShowDialog();

        }

        private void تكويدطريقةالعلاجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdddModifyGruaaWay AdddModifyGruaaWay1 = new AdddModifyGruaaWay();
            AdddModifyGruaaWay1.ShowDialog();
        }
        //======================
        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            AddPatient Patient1 = new AddPatient();
            Patient1.ShowDialog();
        }
        //====================
        private void تكويدالأشعةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdddModifyXRay AdddModifyXRay1 = new AdddModifyXRay();
            AdddModifyXRay1.ShowDialog();

        }
        //===============
        private void تكويدالتحاليلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdddModifyTest AdddModifyTest1 = new AdddModifyTest();
            AdddModifyTest1.ShowDialog();

        }
        //===================
        private void كشفجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kashf Kashf1 = new Kashf();
            Kashf1.ShowDialog();
        }
        //======================
        private void نسخإحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup_Restore_Form7 Backup_Restore_Form71 = new Backup_Restore_Form7();
            Backup_Restore_Form71.ShowDialog();
        }
        //===================
        private void إنشاءمستخدمجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeForm EmployeeForm1 = new EmployeeForm();
            EmployeeForm1.ShowDialog();
        }

        private void تغييركلمةالسرلمستخدمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeUserPass changeUserPass1 = new changeUserPass();
            changeUserPass1.ShowDialog();
        }
        //=======================
        private void الأدويةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedcinReport MedcinReport1 = new MedcinReport();
            MedcinReport1.ShowDialog();
        }
        //=================================
        private void الكشفخلالفترةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KashfReportBetweenTwoDates KashfReportBetweenTwoDates1 = new KashfReportBetweenTwoDates();
            KashfReportBetweenTwoDates1.ShowDialog();

        }
        //--------------------
        private void bt_Hagz_Click(object sender, EventArgs e)
        {
            HagzKashf HagzKashf1 = new HagzKashf();

            HagzKashf1.Show();
        }
        //==================
        private void حجزكشفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HagzKashf HagzKashf1 = new HagzKashf();

            HagzKashf1.Show();
        }
        //============================
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AdddModifyTamin AdddModifyTamin1 = new AdddModifyTamin();
            AdddModifyTamin1.ShowDialog();
        }

        private void hgpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HagzReportBetweenTwoDates HagzReportBetweenTwoDates1 = new HagzReportBetweenTwoDates();
            HagzReportBetweenTwoDates1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmNewImage frmNewImage1 = new frmNewImage();
            frmNewImage1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetFileAndPhoto GetFileAndPhoto1 = new GetFileAndPhoto();
            GetFileAndPhoto1.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            rosata rosata1 = new rosata();

            rosata1.Show();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            KashfHagz kashfHagz = new KashfHagz();
            kashfHagz.Show();
        }

        private void الإدارةToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }




        //=====================













        //==================================================================================================================

    }
}
