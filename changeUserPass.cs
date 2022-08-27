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
    public partial class changeUserPass : Form
    {
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTable dataTable;
        string tempoldpassword;
        
        

        //**************************
        public string stringcon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=GenClinicDB;Data Source=.";
        //*******************
        public changeUserPass()
        {
            InitializeComponent();
        }

        private void changeUserPass_Load(object sender, EventArgs e)
        {
           // 
            Filluserename();
            cmb_USERname.SelectedIndex = 1;
            //bt_Update.Enabled = false;
        }
      //===========
        private void Filluserename()
        {
            cmb_USERname.Items.Clear();

            //////////////////////////////////////////////////
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM  dbo.EmployeeTable WHERE  (LoginFormsFlage=1)  and (Trush = 0)";
            //"SELECT UserId, UserName, UserPass, UserClassification FROM [User]";

            //******************
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "USER1");
            // for each row in the table, fill the list
            dataTable = dataSet.Tables["USER1"];

            /////////////// test
            cmb_USERname.DataSource = dataTable;
            cmb_USERname.ValueMember = "EmployeeId";
            cmb_USERname.DisplayMember = "EmployeeName";


           con.Close();con.Dispose();;
        }
        //=================
        private string Getpass(int id)
        {

           
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM EmployeeTable where EmployeeId = " + id + " ";
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "prod_barcode");

            // for each row in the table, fill the list
            dataTable = dataSet.Tables["prod_barcode"];
            //**************************************            

            if ((dataTable.Rows.Count != 0))
            {
                DataRow selectedRow = dataTable.Rows[0];

                tempoldpassword = selectedRow["UserPass"].ToString();
               //=================================================================================
               con.Close();con.Dispose();;
                
            }

            return tempoldpassword;
        }
        private void UpdatePass(int temp1, string temp2)
        {
           
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "update_tb_User_pass";
            //***********************
            SqlParameter param1 = new SqlParameter("@EmployeeId ", SqlDbType.Int);
            param1.Value = temp1;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
            //***************************            
            SqlParameter param3 = new SqlParameter("@UserPass", SqlDbType.NVarChar, 50);
            param3.Value = temp2;
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);
            //=========================
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;


        }

        private void bt_Update_Click(object sender, EventArgs e)
        {
            int usid =int.Parse(cmb_USERname.SelectedValue.ToString());
            //MessageBox.Show(usid.ToString());
            //if (txt_oldPass.Text == Getpass(usid))
            //{
                if (txt_new1.Text == txt_new2.Text)
                {
                    UpdatePass(usid, txt_new1.Text);
                }
                else
                {
                    MessageBox.Show("كلمة السر الجديدة غير متطابقة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            //}
            //else
            //{
            //    MessageBox.Show("كلمة السر القديمة غير صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            bt_Update.Enabled = false;
            txt_new1.Text = "";
            txt_new2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_USERname_SelectedIndexChanged(object sender, EventArgs e)
        {
            bt_Update.Enabled = true;
        }


    }
}
