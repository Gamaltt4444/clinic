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
    public partial class LOGIN : Form
    {
        //***********************
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTable dataTable;
        string mypassword,tempusername;
        
      
        int trypasswordflage = 0, LoginFormsFlage;//if it =3 close the application
        bool tempLoginflage = false;
        
        //**************************
        public string stringcon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=GenClinicDB;Data Source=.";
        //***********************
        public LOGIN()
        {
            InitializeComponent();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
           
            Filluserename();
        }
        //===============
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
        //================
        private void button1_Click(object sender, EventArgs e)
        {
          
            #region get pass
            //////////////////////////////////////////////////
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM EmployeeTable where EmployeeId=" + cmb_USERname.SelectedValue + "";
            //"SELECT UserId, UserName, UserPass, UserClassification FROM [User]";

            //******************
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "all");
            // for each row in the table, fill the list
            dataTable = dataSet.Tables["all"];
            DataRow selectedRow = dataTable.Rows[0];
            mypassword = selectedRow["UserPass"].ToString();
            tempusername = selectedRow["EmployeeName"].ToString();
            LoginFormsFlage = int.Parse(selectedRow["LoginFormsFlage"].ToString());
           con.Close();con.Dispose();;
#endregion
            //================================
            if (mypassword != textBox1.Text)
            {
                if (trypasswordflage >= 3)
                {

                    Application.Exit();
                }
                else
                {

                    MessageBox.Show("من فضلك أدخل كلمة السر الصحيحة", "لا حول و لا قوة إلا بالله ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox1.Focus();
                    trypasswordflage += 1;
                    return;
                }
            }
            else
            {
                tempLoginflage = true;
                //================================
              
            }


            this.Close();
               
        }

        private void LOGIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            main main1 = new main();
            //main1.GetSetadminKind = tempcalassification;
            main1.GetSetLoginflage = tempLoginflage;
            main1.GetSetLoginName = tempusername;
            main1.GetSetLoginUeserId = int.Parse(cmb_USERname.SelectedValue.ToString());

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && textBox1.Text != null)
            {
                button1.PerformClick();
            }
        }
        
        
        
    }
}
