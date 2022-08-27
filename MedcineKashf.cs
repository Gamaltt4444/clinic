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
    public partial class MedcineKashf : Form
    {
        //***********************
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTable dataTable;
        
      
        //**************************
        public string stringcon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=GenClinicDB;Data Source=.";
        //*********************************************************======   
        public static bool tempGetSetMedcinFlage=false;
        public bool GetSetMedcinFlage
        {
            set { tempGetSetMedcinFlage = value; }
            get { return tempGetSetMedcinFlage; }
        }
        //==================== 
        public static int tempGetSetMedcinID;
        public int GetSetMedcinID
        {
            set { tempGetSetMedcinID = value; }
            get { return tempGetSetMedcinID; }
        }
        //====================   
        public static int tempMedcinTypeID;
        public int GetSetMedcinTypeID
        {
            set { tempMedcinTypeID = value; }
            get { return tempMedcinTypeID; }
        }
        //====================
        public static int tempGetSetMedcinWayId;
        public int GetSetMedcinWayId
        {
            set { tempGetSetMedcinWayId = value; }
            get { return tempGetSetMedcinWayId; }
        }
        //================
        //**************************
        public MedcineKashf()
        {
            InitializeComponent();
        }
        //=====================
        private void bt_New_Click(object sender, EventArgs e)
        {
            txt_Name.Text = "";
            bt_Save.Enabled = true;
     
        }
        //================================
        private void Fillcmb_MedcinType()
        {
            cmb_MedcinType.DataSource = null;

            //////////////////////////////////////////////////
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT  * FROM MedcinType where (Trash=" + 0 + ") order by  MedcinTypeID";

            //******************
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "categoryTable");
            // for each row in the table, fill the list
            dataTable = dataSet.Tables["categoryTable"];

            /////////////// test
            cmb_MedcinType.DataSource = dataTable;
            cmb_MedcinType.ValueMember = "MedcinTypeID";
            cmb_MedcinType.DisplayMember = "MedcinTypeName";

           con.Close();con.Dispose();;
        }
        //================
       
        private void MedcineKashf_Load(object sender, EventArgs e)
        {
           
            Fillcmb_MedcinType();
            cmb_MedcinType.SelectedIndex = 0;
        }
        //=================================
        
        private int GetMedcinTypeId(string MedcinTypeName)
        {
            int xx = 0;

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM MedcinType WHERE(MedcinTypeName ='" + MedcinTypeName + "')";
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "all");

            // for each row in the table, fill the list
            dataTable = dataSet.Tables["all"];

            if (!(dataTable.Rows.Count == 0))
            {
                //=========================

                DataRow selectedRow = dataTable.Rows[0];
                if (selectedRow["MedcinTypeID"].ToString() != "" && selectedRow["MedcinTypeID"].ToString() != null)
                {
                    xx = int.Parse(selectedRow["MedcinTypeID"].ToString());
                }
               con.Close();con.Dispose();;

            }
            return xx;
        }
        //===========
        private void insertItem_Medcin()
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insert_Medcin_Full";
            //***********************

            SqlParameter param3 = new SqlParameter("@MedcinName ", SqlDbType.NVarChar, 50);
            param3.Value = txt_Name.Text;
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);
            //*****************
            SqlParameter param2 = new SqlParameter("@MedcinTypeID ", SqlDbType.Int);
            param2.Value = GetMedcinTypeId(cmb_MedcinType.Text);
            param2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param2);
            //*****************
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;

            //***********************************

        }
        //==================
      
        private void bt_Save_Click(object sender, EventArgs e)
        {
            
            //********************************           
            
            if ( txt_Name.Text == "" )
            {
                MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //************************************
            if (cmb_MedcinType.Text == "" )//|| GetMedcinTypeId(cmb_MedcinType.Text) == 0)
            {
                MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_MedcinType.Focus();
                return;

            }
            //=============
            insertItem_Medcin();
            bt_Save.Enabled = false;
           
            //=============================
        }
        //===========================================
     

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //--------------------------------------
       
    }
}
