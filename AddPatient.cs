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
    public partial class AddPatient : Form
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
        public static bool tempPatiantflage = false;
        public bool GetSetPatiantFlage
        {
            set { tempPatiantflage = value; }
            get { return tempPatiantflage; }
        }
       
        ////====================   PatiantId 
        public static int tempPatiantId;
        public int GetSetPatiantId
        {
            set { tempPatiantId = value; }
            get { return tempPatiantId; }
        }
        //====================
       
        //**************************
        public AddPatient()
        {
            InitializeComponent();
        }
        //=====================
        private void bt_New_Click(object sender, EventArgs e)
        {
            empty();
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
            string sql1 = "SELECT  * FROM Patiant where (Trash=" + 0 + ") order by  PatiantName";
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

                listBox1.Items.Add(dataRow["PatiantName"]);


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
            string sql1 = "SELECT * FROM Patiant where (PatiantName like '" + txt_Search.Text + "%' ) and(Trash=" + 0 + ") ORDER BY PatiantName ";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql1;
         
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

                listBox1.Items.Add(dataRow["PatiantName"]);


            }
            //*****************************
           con.Close();con.Dispose();;
            bt_Update.Enabled = true;

        }
        //=====================
        private void Fill_ListBox_code(int PatiantId)
        {
           
            //==========================            
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string sql1 = "SELECT * FROM Patiant where (PatiantId = " + PatiantId + " ) and(Trash=" + 0 + ")  ";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql1;

            dataAdapter1 = new SqlDataAdapter(cmd);
            dataSet1 = new DataSet();
            dataAdapter1.Fill(dataSet1, "all");
            
            dataTable1 = dataSet1.Tables["all"];
            if (dataTable1.Rows.Count == 0)
            {

                return;
            }
            //****************************
            foreach (DataRow dataRow in dataTable1.Rows)
            {

                listBox1.Items.Add(dataRow["PatiantName"]);


            }
            //*****************************
           con.Close();con.Dispose();;
            bt_Update.Enabled = true;

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
        private void Patient_Load(object sender, EventArgs e)
        {
            Fill_ListBox_formload();

            //--------------
            FillcmbTaminTable();
            cmb_Tamine.SelectedIndex = 0;
            //------------------
           
          
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
            GetSetPatiantFlage = true;
            GetSetPatiantId = int.Parse(selectedRow1["PatiantId"].ToString());
            GetDataFromListBoxById(GetSetPatiantId);
            bt_Update.Enabled = true;
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
        private void GetDataFromListBoxById(int PatiantId)
        {

            string sql1 = "SELECT     Patiant.*, TaminTable.TaminName FROM Patiant INNER JOIN TaminTable ON Patiant.TaminID = TaminTable.TaminID WHERE  (PatiantId = " + PatiantId + ") and ( Patiant.Trash=" + 0 + ") ";
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


                txt_Name.Text = selectedRow["PatiantName"].ToString();
                txt_code.Text = selectedRow["PatiantId"].ToString();// 

                cmb_Tamine.Text = selectedRow["TaminName"].ToString();
                
                txt_Adrress.Text = selectedRow["address"].ToString();
                txt_facebook.Text = selectedRow["facebookid"].ToString();
                txt_mail.Text = selectedRow["Email"].ToString();
                txt_Mobile1.Text = selectedRow["Mobile1"].ToString();
                txt_mobile2.Text = selectedRow["Mobile2"].ToString();
                txt_phone.Text = selectedRow["phone"].ToString();
               
                //===========================

                checkBox_Delete.Checked = false;

               

               

                


               con.Close();con.Dispose();;

                //========
                bt_Update.Enabled = true;

            }
            else
            {
               con.Close();con.Dispose();;
                empty();
              

                //==============================
                
                bt_Update.Enabled = false;


            }


        }
        //===============================================
        private void empty()
        {
            txt_Name.Text = "";
            txt_Adrress.Text = "";
            txt_facebook.Text = "";
            txt_mail.Text = "";
            txt_Mobile1.Text = "";
            txt_mobile2.Text = "";
            txt_phone.Text = "";
          
            txt_Search.Text = "";
            txt_code.Text = "";
            txt_Search_code.Text = "";
            checkBox_Delete.Checked = false;
        }
        //===========
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
           //*********************
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
        //==================
        private void update(int PatiantId)
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "update_Patiant";
            //***********************
            SqlParameter param1 = new SqlParameter("@PatiantName", SqlDbType.NVarChar, 50);
            param1.Value = txt_Name.Text;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
            //*********************
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
            param5.Value = txt_Adrress.Text;
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
            //*********************
            SqlParameter param8 = new SqlParameter("@PatiantId", SqlDbType.NVarChar, 50);
            param8.Value = PatiantId;
            param8.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param8);
            //*********************
           
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;

            //***********************************

        }
        //==================
        private void updateTrash(int PatiantId)
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "update_PatiantYrash";
            //***********************
            SqlParameter param8 = new SqlParameter("@PatiantId", SqlDbType.NVarChar, 50);
            param8.Value = PatiantId;
            param8.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param8);
            //*********************     
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
            //============= ***************************           
            
            if ( txt_Name.Text == "" )
            {
                MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


           
            //************************************
            if (GetTaminID(cmb_Tamine.Text) == 0)
            {
                MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_Tamine.Focus();
                return;

            }
            //=============
            txt_code.Text = insert().ToString();
          
            Fill_ListBox_formload();
          //==========

            empty();
            //====================
           
            bt_Save.Enabled = false;
            //=============================
        }
        //===========================================
        private void bt_Update_Click(object sender, EventArgs e)
        {
            //=============================
            if (GetSetPatiantFlage == false) return;


            //************************************
            if (GetTaminID(cmb_Tamine.Text) == 0)
            {
                MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_Tamine.Focus();
                return;

            }
            //=============  
            if (txt_Name.Text == "")
            {
                MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        
            //=============
            update(GetSetPatiantId);
            if (checkBox_Delete.Checked == true)
            {
                updateTrash(GetSetPatiantId);
            }
            //-----------
         
            Fill_ListBox_formload();

            bt_Update.Enabled = false;
            empty();
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
                //==========

                empty();
                return;
                //=================
            }
                Fill_ListBox();
        }
        //=====================
        private void txt_Search_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            listBox1.Items.Clear();


            if (e.KeyChar == 13 && txt_Search_code.Text != null)
            {

                //==========================      
            
            int result3;
            if (int.TryParse(txt_Search_code.Text, out result3) == false)
            {
                MessageBox.Show(" من فضلك أدخل البيانات بصورة صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Search_code.Focus();
                return;
            }
            //***************
                if (txt_Search_code.Text == "")
                {
                    empty();

                    
                    return;
                }
                int PatiantId=int.Parse(txt_Search_code.Text);
                Fill_ListBox_code( PatiantId);

                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
        //==================
    }
}
