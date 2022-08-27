using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenClinic
{
    public partial class PatientKashf : Form
    {
        //***********************
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTable dataTable;
     
      
        //**************************
        public string stringcon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=GenClinicDB;Data Source=.";
        //*********************************************************======   
        public static bool tempPatiantflage = false;
        public bool GetSetPatiantFlage
        {
            set { tempPatiantflage = value; }
            get { return tempPatiantflage; }
        }
        ////==================== 
        //public static int tempGetSetMedcinID;
        //public int GetSetMedcinID
        //{
        //    set { tempGetSetMedcinID = value; }
        //    get { return tempGetSetMedcinID; }
        //}
        ////====================   PatiantId 
        public static int tempPatiantId;
        public int GetSetPatiantId
        {
            set { tempPatiantId = value; }
            get { return tempPatiantId; }
        }
        //====================
        //public static int tempGetSetMedcinWayId;
        //public int GetSetMedcinWayId
        //{
        //    set { tempGetSetMedcinWayId = value; }
        //    get { return tempGetSetMedcinWayId; }
        //}
        //================
        //**************************
        public PatientKashf()
        {
            InitializeComponent();
        }
        //================
        private void FillcmbTaminTable()
        {
            cmb_Tamine.DataSource = null;

            //////////////////////////////////////////////////
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT  * FROM TaminTable where (Trash=" + 0 + ") order by  TaminID";

            //******************
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "categoryTable");
            // for each row in the table, fill the list
            dataTable = dataSet.Tables["categoryTable"];

            /////////////// test
            cmb_Tamine.DataSource = dataTable;
            cmb_Tamine.ValueMember = "TaminID";
            cmb_Tamine.DisplayMember = "TaminName";

           con.Close();con.Dispose();;
        }
        //===============================================
        private int GetTaminID(string TaminName)
        {
            int xx = 0;

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM TaminTable WHERE(TaminName ='" + TaminName + "')";
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "all");

            // for each row in the table, fill the list
            dataTable = dataSet.Tables["all"];

            if (!(dataTable.Rows.Count == 0))
            {
                //=========================

                DataRow selectedRow = dataTable.Rows[0];
                if (selectedRow["TaminID"].ToString() != "" && selectedRow["TaminID"].ToString() != null)
                {
                    xx = int.Parse(selectedRow["TaminID"].ToString());
                }
               con.Close();con.Dispose();;

            }
            return xx;
        }
        //===========
             
     
        private void PatientKashf_Load(object sender, EventArgs e)
        {
            //--------------
            FillcmbTaminTable();
            cmb_Tamine.SelectedIndex = 0;
            //------------------
           
          
        }
        //=================================
      
        private int insert()
        {
           
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insert_Patiant";
            //***********************

            SqlParameter param1 = new SqlParameter("@PatiantName", SqlDbType.NVarChar, 50);
            param1.Value = txt_Name.Text;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
           //************************************
            SqlParameter param11 = new SqlParameter("@TaminID", SqlDbType.Int);
            param11.Value = GetTaminID(cmb_Tamine.Text);
            param11.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param11);
            //*********************
            SqlParameter param2 = new SqlParameter("@phone", SqlDbType.NVarChar, 50);
            param2.Value = txt_phone.Text;
            param2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param2);
            //*********************
            SqlParameter param3 = new SqlParameter("@Mobile1", SqlDbType.NVarChar, 50);
            param3.Value = txt_Mobile1.Text;
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);
            //*********************
            SqlParameter param4 = new SqlParameter("@Mobile2", SqlDbType.NVarChar, 50);
            param4.Value = txt_mobile2.Text;
            param4.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param4);
            //*********************
            SqlParameter param5 = new SqlParameter("@address", SqlDbType.NVarChar, 200);
            param5.Value =txt_Adrress.Text;
            param5.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param5);
            //*********************
            SqlParameter param6 = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
            param6.Value = txt_mail.Text;
            param6.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param6);
            //*********************
            SqlParameter param7 = new SqlParameter("@facebookid", SqlDbType.NVarChar, 50);
            param7.Value = txt_facebook.Text;
            param7.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param7);
            SqlParameter IDParameter = new SqlParameter("@NewID", SqlDbType.Int);
            IDParameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(IDParameter);
            //**********************
            cmd.ExecuteScalar();
            int id = (int)IDParameter.Value;
           con.Close();con.Dispose();;
            return id;
            //=================

            //***********************************

        }
        //=================
        private bool Search_Name(string PatiantName)
        {
            string st;
            //=======================================
            SqlConnection con1 = new SqlConnection(stringcon);
            con1.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con1;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Patiant WHERE ( PatiantName = '" + PatiantName + "')and Trash=" + 0 + " ";

            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "name");

            // for each row in the table, fill the list
            dataTable = dataSet.Tables["name"];
            //**************************************            

            if (!(dataTable.Rows.Count == 0))
            {

                //========================= 
                DataRow selectedRow = dataTable.Rows[0];

                st = (string)selectedRow["PatiantName"];


                //=============================================
               con1.Close();con1.Dispose();;
                //========

                return true;

            }
            else
            {
               con1.Close();con1.Dispose();;

                return false;


            }




        }
        //====================
    
        private void bt_Save_Click(object sender, EventArgs e)
        {

            //===================
            if (Search_Name(txt_Name.Text) == true)
            {
                MessageBox.Show("من فضلك لقد تم  إدخال هذا من قبل", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //=============*****************************
            if (GetTaminID(cmb_Tamine.Text) == 0)
            {
                MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_Tamine.Focus();
                return;

            }
            //=============*****************           
            
            if ( txt_Name.Text == "" )
            {
                MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
           
            //=============
           insert();
          
         
           
            bt_Save.Enabled = false;
            //=============================
        }
        //===========================================
      

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
        //==================
    }
}
