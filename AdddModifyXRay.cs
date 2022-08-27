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
    public partial class AdddModifyXRay : Form
    {
        //***********************
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTable dataTable;
        private SqlDataAdapter dataAdapter1;
        private DataSet dataSet1;
        private DataTable dataTable1;
        //**************************
        public string stringcon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=GenClinicDB;Data Source=.";
        //*********************************************************======   
        public static bool tempflage = false;
        public bool GetSetFlage
        {
            set { tempflage = value; }
            get { return tempflage; }
        }
        ////==================== 
        //public static int tempGetSetMedcinID;
        //public int GetSetMedcinID
        //{
        //    set { tempGetSetMedcinID = value; }
        //    get { return tempGetSetMedcinID; }
        //}
        ////====================   
        public static int tempID;
        public int GetSetID
        {
            set { tempID = value; }
            get { return tempID; }
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
        public AdddModifyXRay()
        {
            InitializeComponent();
        }
        //=====================
        private void bt_New_Click(object sender, EventArgs e)
        {
            txt_Name.Text = "";
            bt_Save.Enabled = true;
            bt_Update.Enabled = false;
        }
        //================================        
        private void Fill_ListBox_formload()
        {
            listBox1.Items.Clear();
            //==========================            
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string sql1 = "SELECT  * FROM XRays where (Trash=" + 0 + ") order by  XRaysID";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql1;
            //***************************
            dataAdapter1 = new SqlDataAdapter(cmd);
            dataSet1 = new DataSet();
            dataAdapter1.Fill(dataSet1, "all");
            // for each row in the table, fill the list
            dataTable1 = dataSet1.Tables["all"];
            if (dataTable1.Rows.Count == 0)
            {

                return;
            }
            //****************************
            foreach (DataRow dataRow in dataTable1.Rows)
            {

                listBox1.Items.Add(dataRow["XRaysName"]);


            }
            //*****************************
           con.Close();con.Dispose();;
            bt_Update.Enabled = true;

        }
        //================
        private void Fill_ListBox()
        {
            txt_Name.Text = "";
            checkBox_Delete.Checked = false;
            listBox1.Items.Clear();
            //==========================            
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand(); 
            cmd.Connection = con;
            string sql1 = "SELECT  * FROM XRays where (XRaysName like '" + txt_Search.Text + "%' ) and(Trash=" + 0 + ") ORDER BY XRaysName ";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql1;
            //***************************
          
            //-----------------------------------
            dataAdapter1 = new SqlDataAdapter(cmd);
            dataSet1 = new DataSet();
            dataAdapter1.Fill(dataSet1, "all");
            // for each row in the table, fill the list
            dataTable1 = dataSet1.Tables["all"];
            if (dataTable1.Rows.Count == 0)
            {

                return;
            }
            //****************************
            foreach (DataRow dataRow in dataTable1.Rows)
            {

                listBox1.Items.Add(dataRow["XRaysName"]);



            }
            //*****************************
           con.Close();con.Dispose();;
            bt_Update.Enabled = true;

        }
        //=====================
        private void AdddModifyXRay_Load(object sender, EventArgs e)
        {
            Fill_ListBox_formload();
           
          
        }
        //=================================
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                return;
            }
            DataRow selectedRow1 = dataTable1.Rows[listBox1.SelectedIndex];
            //*********************************************
            checkBox_Delete.Checked = false;
            GetSetFlage = true;
            GetSetID = int.Parse(selectedRow1["XRaysID"].ToString());
            GetDataFromListBoxById(GetSetID);
           // bt_Update.Enabled = false;
        }
        //=================
        private bool Search_Name(string XRaysName)
        {
            string st;
            //=======================================
            SqlConnection con1 = new SqlConnection(stringcon);
            con1.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con1;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM XRays WHERE ( XRaysName = '" + XRaysName + "')and Trash=" + 0 + " ";

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

                st = (string)selectedRow["XRaysName"];


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
        private void GetDataFromListBoxById(int XRaysID)
        {

            string sql1 = "SELECT * FROM XRays WHERE  (XRaysID = " + XRaysID + ") and (Trash=" + 0 + ") ";
            //----------------------------------
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql1;
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "prod_id");

            // for each row in the table, fill the list
            dataTable = dataSet.Tables["prod_id"];
            //**************************************            

            if ((dataTable.Rows.Count != 0))
            {
                DataRow selectedRow = dataTable.Rows[0];


                txt_Name.Text = selectedRow["XRaysName"].ToString();

               
               // GetSetMedcinID = MedcinID;
                //===========================

                checkBox_Delete.Checked = false;            

               

                


               con.Close();con.Dispose();;

                //========
                bt_Update.Enabled = true;

            }
            else
            {
               con.Close();con.Dispose();;
                txt_Name.Text = "";
                checkBox_Delete.Checked = false;

                //==============================
                
                bt_Update.Enabled = false;


            }


        }
        //===============================================
    
        //===========
        private void insert()
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insert_XRays";
            //***********************

            SqlParameter param3 = new SqlParameter("@XRaysName", SqlDbType.NVarChar, 50);
            param3.Value = txt_Name.Text;
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);
           
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;

            //***********************************

        }
        //==================
        private void Update(int XRaysID)
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "update_XRays";
            //***********************
            SqlParameter param1 = new SqlParameter("@XRaysID ", SqlDbType.Int);
            param1.Value = XRaysID;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
            //*****************
            SqlParameter param3 = new SqlParameter("@XRaysName", SqlDbType.NVarChar, 50);
            param3.Value = txt_Name.Text;
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);
            //*****************
           
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;

            //***********************************

        }
        //==================
        private void UpdateTrash(int XRaysID)
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "update_XRaysTrash";
            //***********************
            SqlParameter param1 = new SqlParameter("@XRaysID ", SqlDbType.Int);
            param1.Value = XRaysID;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
            //*****************       
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;

            //***********************************

        }
        //==================
        private void bt_Save_Click(object sender, EventArgs e)
        {

            //===================
            if (Search_Name(txt_Name.Text) == true)
            {
                MessageBox.Show("من فضلك لقد تم  إدخال هذا من قبل", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //=============          
            
            if ( txt_Name.Text == "" )
            {
                MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
           
            //=============
            insert();
          
            Fill_ListBox_formload();
            txt_Name.Text = "";
            checkBox_Delete.Checked = false;
            bt_Save.Enabled = false;
            //=============================
        }
        //===========================================
        private void bt_Update_Click(object sender, EventArgs e)
        {
            //=============================
            if (GetSetFlage == false) return;


            //********************************   
            if (txt_Name.Text == "")
            {
                MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        
            //=============
            Update(GetSetID);
            if (checkBox_Delete.Checked == true)
            {
                UpdateTrash(GetSetID);
            }
            //-----------
         
            Fill_ListBox_formload();

            bt_Update.Enabled = false;
            txt_Name.Text = "";
            checkBox_Delete.Checked = false;
            //=================
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //--------------------------------------
        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            if (txt_Search.Text == "")
            {
                bt_Update.Enabled = false;
                txt_Name.Text = "";
                checkBox_Delete.Checked = false;
                return;
                //=================
            }
                Fill_ListBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
        //==================
    }
}
