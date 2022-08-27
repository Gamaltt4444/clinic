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
    public partial class AdddModifyMedcine : Form
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
        public AdddModifyMedcine()
        {
            InitializeComponent();
        }
        //=====================
        private void bt_New_Click(object sender, EventArgs e)
        {
            txt_Name.Text = "";
            txt_Medcin_Code.Text = "";
            bt_Save.Enabled = true;
            bt_Update.Enabled = false;
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
        private void Fill_ListBox_formload()
        {
            listBox1.Items.Clear();
            //==========================            
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;            
            string sql1 = "SELECT * FROM Medcin where (Trash=" + 0 + ") ORDER BY MedcinTypeID ";
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

                listBox1.Items.Add(dataRow["MedcinName"]);


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
            string sql1 = "SELECT * FROM Medcin where (MedcinName like '" + txt_Search.Text + "%') and(Trash=" + 0 + ") ORDER BY MedcinTypeID ";
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

                listBox1.Items.Add(dataRow["MedcinName"]);


            }
            //*****************************
           con.Close();con.Dispose();;
            bt_Update.Enabled = true;

        }
        //=====================
        private void AdddModifyMedcine_Load(object sender, EventArgs e)
        {
            Fill_ListBox_formload();
            Fillcmb_MedcinType();
            cmb_MedcinType.SelectedIndex = 0;
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
            GetSetMedcinFlage = true;
            GetSetMedcinID = int.Parse(selectedRow1["MedcinID"].ToString());
            GetDataFromListBoxById(GetSetMedcinID);
           
            bt_Save.Enabled = false;
        }
        //=================
        private bool Search_Name(string MedcinName)
        {
            string st;
            //=======================================
            SqlConnection con1 = new SqlConnection(stringcon);
            con1.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con1;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Medcin where ( MedcinName = '" + MedcinName + "')and Trash=" + 0 + " ";

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

                st = (string)selectedRow["MedcinName"];


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
        private void GetDataFromListBoxById(int MedcinID)
        {

            string sql1 = "SELECT Medcin.*, MedcinType.MedcinTypeName FROM   Medcin INNER JOIN MedcinType ON Medcin.MedcinTypeID = MedcinType.MedcinTypeID WHERE  (Medcin.MedcinID = " + MedcinID + ") and (Medcin.Trash=" + 0 + ") ";
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
                GetSetMedcinFlage = true;

                txt_Name.Text = selectedRow["MedcinName"].ToString();
                txt_Medcin_Code.Text = selectedRow["MedcinID"].ToString();
                cmb_MedcinType.Text = selectedRow["MedcinTypeName"].ToString();

              
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
                bt_Save.Enabled = false;


            }


        }
        //===============================================
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
        private void Update_Medcin(int MedcinID)
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "update_Medcin_Full";
            //***********************
            SqlParameter param1 = new SqlParameter("@MedcinID ", SqlDbType.Int);
            param1.Value = MedcinID;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
            //*****************
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
        private void update_Medcin_Trash(int MedcinID)
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "update_Medcin_Trash";
            //***********************
            SqlParameter param1 = new SqlParameter("@MedcinID ", SqlDbType.Int);
            param1.Value = MedcinID;
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
            
            //********************************           
            
            if ( txt_Name.Text == "" )
            {
                MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //************************************
            if (GetMedcinTypeId(cmb_MedcinType.Text) == 0)
            {
                MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_MedcinType.Focus();
                return;

            }
            //=============
            insertItem_Medcin();
            bt_Save.Enabled = false;
            bt_Update.Enabled = false;
            //==========
            Fill_ListBox_formload();
            //=============================
        }
        //===========================================
        private void bt_Update_Click(object sender, EventArgs e)
        {
            //=============================
            if (GetSetMedcinFlage == false) return;


            //********************************   
            if (txt_Name.Text == "")
            {
                MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //************************************
            if (GetMedcinTypeId(cmb_MedcinType.Text) == 0)
            {
                MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_MedcinType.Focus();
                return;

            }
            //================
            Update_Medcin(GetSetMedcinID);
            if (checkBox_Delete.Checked == true)
            {
                update_Medcin_Trash(GetSetMedcinID);
            }
            //-----------
            Fill_ListBox_formload();
            //=================
            bt_Save.Enabled = false;
            bt_Update.Enabled = false;
            //==========
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //--------------------------------------
        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            if (txt_Search.Text != "") Fill_ListBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
        //==================
    }
}
