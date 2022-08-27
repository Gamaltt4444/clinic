using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
//----
using WIALib;
//-------------
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenClinic
{
    public partial class EmployeeForm : Form
    {
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTable dataTable;
        private SqlDataAdapter dataAdapter1;
        private DataSet dataSet1;
        private DataTable dataTable1;
        //**************************
        int tempempId;
        public int getSetempId
        {
            set { tempempId = value; }
            get { return tempempId; }
        }
        //==========================
        bool  tempload=false;
        public bool getSeload
        {
            set { tempload = value; }
            get { return tempload; }
        }
        //=============
        public string stringcon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=GenClinicDB;Data Source=.";
        //**********===========
        string lastDir = null, fileName;
        public EmployeeForm()
        {
            InitializeComponent();
        }
        //======================
     
        private void EmployeeForm_Load(object sender, EventArgs e)
        {


            //=========
            
            //=================         
            FillCmb_ZawageTable();
            FillCmb_GenderTable();
            FillCmb_DianaTable();
            FillCmb_JobTable();
            //--------------
            Fill_dataGridView1();
            //--------------------
            cmb_diana.SelectedIndex = 0;
            cmb_gender.SelectedIndex = 0;
            cmb_job.SelectedIndex = 0;
            cmb_Logine.SelectedIndex = 0;
            cmb_zwage.SelectedIndex = 0;
            //==========================
            getSeload = true;
        }


        //-----------------------------      
        private void FillCmb_ZawageTable()
        {
            cmb_zwage.DataSource = null;

            //////////////////////////////////////////////////
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT  ZawageName, ZawageId FROM ZawageTable";

            //******************
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "categoryTable");
            // for each row in the table, fill the list
            dataTable = dataSet.Tables["categoryTable"];

            /////////////// test 

            cmb_zwage.DataSource = dataTable;
            cmb_zwage.ValueMember = "ZawageId";
            cmb_zwage.DisplayMember = "ZawageName";
            cmb_zwage.SelectedIndex = 0;
           con.Close();con.Dispose();;
        }
        //--------      
        private void FillCmb_GenderTable()
        {
            cmb_gender.DataSource = null;

            //////////////////////////////////////////////////
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT  sexName, sexId FROM GenderTable";

            //******************
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "categoryTable");
            // for each row in the table, fill the list
            dataTable = dataSet.Tables["categoryTable"];

            /////////////// test 

            cmb_gender.DataSource = dataTable;
            cmb_gender.ValueMember = "sexId";
            cmb_gender.DisplayMember = "sexName";
            cmb_gender.SelectedIndex = 0;
           con.Close();con.Dispose();;
        }
        //------
        private void FillCmb_DianaTable()
        {
            cmb_diana.DataSource = null;

            //////////////////////////////////////////////////
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT  dianaName, dianaId FROM DianaTable";

            //******************
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "categoryTable");
            // for each row in the table, fill the list
            dataTable = dataSet.Tables["categoryTable"];

            /////////////// test 

            cmb_diana.DataSource = dataTable;
            cmb_diana.ValueMember = "dianaId";
            cmb_diana.DisplayMember = "dianaName";
            cmb_diana.SelectedIndex = 0;
           con.Close();con.Dispose();;
        }
        //--------    
        private void FillCmb_JobTable()
        {
            cmb_job.DataSource = null;

            //////////////////////////////////////////////////
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT  jobName, jobId FROM JobTable";

            //******************
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "categoryTable");
            // for each row in the table, fill the list
            dataTable = dataSet.Tables["categoryTable"];

            /////////////// test 

            cmb_job.DataSource = dataTable;
            cmb_job.ValueMember = "jobId";
            cmb_job.DisplayMember = "jobName";
            cmb_job.SelectedIndex = 0;
           con.Close();con.Dispose();;
        }
        //====================
        private void bt_searchPhoto_Click(object sender, EventArgs e)
        {
            //// /Ask user to select file.
            
            //--------
            
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.png; *.jpg; *.bmp)|*.png; *.jpg; *.bmp";
            if (lastDir == null)
                open.InitialDirectory = @"C:\";
            else
                open.InitialDirectory = lastDir;
            if (open.ShowDialog() == DialogResult.OK)
            {
                fileName = System.IO.Path.GetFullPath(open.FileName);
                lastDir = open.FileName;
                pictureBox1.Image = new Bitmap(open.FileName);
                //this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            }
            //======================


        }
        //======================
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //==============================
        private void bt_new_Click(object sender, EventArgs e)
        {
            txt_Adrress.Text = "";
            txt_nameEnglish.Text = "";
          //  txt_birthdate.Text = "";
            txt_facebook.Text = "";
            txt_InsuranceNo.Text = "";
            txt_mail.Text = "";
            txt_Mobile1.Text = "";
            txt_mobile2.Text = "";
            txt_Name.Text = "";
            txt_NationalId.Text = "";
            txt_phone1.Text = "";
            txt_phone2.Text = "";
            pictureBox1.Image = pictureBox_temp.Image;
            bt_Add.Enabled = true;
            bt_delete.Enabled = false;
            bt_Update.Enabled = false;
            cmb_diana.SelectedIndex = 0;
            cmb_gender.SelectedIndex = 0;
            cmb_job.SelectedIndex = 0;
            cmb_Logine.SelectedIndex = 0;
            cmb_zwage.SelectedIndex = 0;
            getSetempId = 0;
            
        }
        //==========================
        public byte[] ImageToByteArray(Image img)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        //================================
        //Open file in to a filestream and read data in a byte array.
        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }
        //=================================
        private int insert_EmployeeTable()
        {
            //byte[] imageData;
            //if (txtImagePath.Text != "")
            //{
            //    imageData = ReadFile(txtImagePath.Text);
            //}
            //else
            //{
            //    imageData =null;
            //}

            //get image: 
            Image img;
            //if (fileName != "" && fileName !=null)
            //{
            //     img = Image.FromFile(fileName);
            //}
            //else
            //{
            //    img = pictureBox_temp.Image;
            //}
            //==============
            if (pictureBox1.Image != null)
            {
                img = pictureBox1.Image;
            }
            else
            {
                img = pictureBox_temp.Image;
            }
            //========================
            //get byte array from image:
            byte[] byteImg = ImageToByteArray(img);
            //here do the insertion into dataBase!
            //=====================================================
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insert_EmployeeTable";
            //***********************
            SqlParameter param1 = new SqlParameter("@EmployeeName ", SqlDbType.NVarChar, 50);
            param1.Value = txt_Name.Text;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
            //**************************
             SqlParameter param19 = new SqlParameter("@EmployeeName_english ", SqlDbType.NVarChar, 50);
            param19.Value = txt_nameEnglish.Text; ;
            param19.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param19);
            //*************************************
            SqlParameter param2 = new SqlParameter("@phone1 ", SqlDbType.NVarChar, 50);
            param2.Value =txt_phone1.Text;
            param2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param2);
            //**************************
            SqlParameter param3 = new SqlParameter("@phone2 ", SqlDbType.NVarChar, 50);
            param3.Value = txt_phone2.Text;
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);
            //**************************
            SqlParameter param4 = new SqlParameter("@mobile1 ", SqlDbType.NVarChar, 50);
            param4.Value = txt_Mobile1.Text;
            param4.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param4);
            //*************************
            SqlParameter param5 = new SqlParameter("@mobile2 ", SqlDbType.NVarChar, 50);
            param5.Value = txt_mobile2.Text;
            param5.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param5);
            //*************************
            SqlParameter param6 = new SqlParameter("@address ", SqlDbType.NVarChar, 50);
            param6.Value = txt_Adrress.Text;
            param6.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param6);
            //*************************
            SqlParameter param7 = new SqlParameter("@sexId ", SqlDbType.Int);
            param7.Value = cmb_gender.SelectedValue;
            param7.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param7);
            //**************************
            SqlParameter param8 = new SqlParameter("@dianaId ", SqlDbType.Int);
            param8.Value =cmb_diana.SelectedValue;
            param8.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param8);
            //*************************************
            SqlParameter param9 = new SqlParameter("@ZawageId ", SqlDbType.Int);
            param9.Value = cmb_zwage.SelectedValue;
            param9.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param9);
            //*************************************
            SqlParameter param10 = new SqlParameter("@nationalId ", SqlDbType.NVarChar, 50);
            param10.Value = txt_NationalId.Text;
            param10.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param10);
            //*****************************         
            SqlParameter param11 = new SqlParameter("@image", SqlDbType.Image);
            param11.Value = byteImg;
            param11.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param11);
            //************************************
            SqlParameter param12 = new SqlParameter("@email", SqlDbType.NVarChar, 50);
            param12.Value = txt_mail.Text;
            param12.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param12);
            //*******************************   facebookid
            SqlParameter param13 = new SqlParameter("@facebookid", SqlDbType.NVarChar, 50);
            param13.Value = txt_facebook.Text;
            param13.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param13);
            //*************************
      
            SqlParameter param14 = new SqlParameter("@hireDate ", SqlDbType.DateTime);
            param14.Value = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());
            param14.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param14);
            //*************************
           
            SqlParameter param16 = new SqlParameter("@insuranceNo ", SqlDbType.NVarChar, 50);
            param16.Value = txt_InsuranceNo.Text; ;
            param16.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param16);
            //*************************************
            SqlParameter param17 = new SqlParameter("@jobId ", SqlDbType.Int);
            param17.Value = cmb_job.SelectedValue; ;
            param17.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param17);
            //***************************** 
            SqlParameter param18 = new SqlParameter("@LoginFormsFlage ", SqlDbType.Int);
            if( cmb_Logine.SelectedIndex ==0)
            {
                 param18.Value = 0;
            }
            else
            {
                 param18.Value = 1;
            }
           
            param18.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param18);
            //**********************           
            SqlParameter IDParameter = new SqlParameter("@NewID", SqlDbType.Int);
            IDParameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(IDParameter);
            //**********************
            cmd.ExecuteScalar();
            int id = (int)IDParameter.Value;         
           con.Close();con.Dispose();;
            return id;
        }
        //===============
        private void update_EmployeeTable(int empId)
        {
            Image img;
          

            if (pictureBox1.Image != null)
            {
                img = pictureBox1.Image;
            }
            else
            {
                img = pictureBox_temp.Image;
            }
            //get byte array from image:
            byte[] byteImg = ImageToByteArray(img);
          
            //here do the insertion into dataBase!
            //======================================================
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "update_EmployeeTable";
            //***********************
             SqlParameter param1 = new SqlParameter("@EmployeeName ", SqlDbType.NVarChar, 50);
            param1.Value = txt_Name.Text;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
            //**************************
             SqlParameter param19 = new SqlParameter("@EmployeeName_english ", SqlDbType.NVarChar, 50);
            param19.Value = txt_nameEnglish.Text; ;
            param19.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param19);
            //*************************************
            SqlParameter param2 = new SqlParameter("@phone1 ", SqlDbType.NVarChar, 50);
            param2.Value =txt_phone1.Text;
            param2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param2);
            //**************************
            SqlParameter param3 = new SqlParameter("@phone2 ", SqlDbType.NVarChar, 50);
            param3.Value = txt_phone2.Text;
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);
            //**************************
            SqlParameter param4 = new SqlParameter("@mobile1 ", SqlDbType.NVarChar, 50);
            param4.Value = txt_Mobile1.Text;
            param4.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param4);
            //*************************
            SqlParameter param5 = new SqlParameter("@mobile2 ", SqlDbType.NVarChar, 50);
            param5.Value = txt_mobile2.Text;
            param5.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param5);
            //*************************
            SqlParameter param6 = new SqlParameter("@address ", SqlDbType.NVarChar, 50);
            param6.Value = txt_Adrress.Text;
            param6.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param6);
            //*************************
            SqlParameter param7 = new SqlParameter("@sexId ", SqlDbType.Int);
            param7.Value = cmb_gender.SelectedValue;
            param7.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param7);
            //**************************
            SqlParameter param8 = new SqlParameter("@dianaId ", SqlDbType.Int);
            param8.Value =cmb_diana.SelectedValue;
            param8.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param8);
            //*************************************
            SqlParameter param9 = new SqlParameter("@ZawageId ", SqlDbType.Int);
            param9.Value = cmb_zwage.SelectedValue;
            param9.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param9);
            //*************************************
            SqlParameter param10 = new SqlParameter("@nationalId ", SqlDbType.NVarChar, 50);
            param10.Value = txt_NationalId.Text;
            param10.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param10);
            //*****************************         
            SqlParameter param11 = new SqlParameter("@image", SqlDbType.Image);
                param11.Value = byteImg;           
            param11.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param11);
            //************************************
            SqlParameter param12 = new SqlParameter("@email", SqlDbType.NVarChar, 50);
            param12.Value = txt_mail.Text;
            param12.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param12);
            //*******************************   facebookid
            SqlParameter param13 = new SqlParameter("@facebookid", SqlDbType.NVarChar, 50);
            param13.Value = txt_facebook.Text;
            param13.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param13);
            //*************************
      
            SqlParameter param14 = new SqlParameter("@hireDate ", SqlDbType.DateTime);
            param14.Value = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());
            param14.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param14);
            //*************************
          
            SqlParameter param16 = new SqlParameter("@insuranceNo ", SqlDbType.NVarChar, 50);
            param16.Value = txt_InsuranceNo.Text; ;
            param16.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param16);
            //*************************************
            SqlParameter param17 = new SqlParameter("@jobId ", SqlDbType.Int);
            param17.Value = cmb_job.SelectedValue; ;
            param17.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param17);
            //***************************** 
            SqlParameter param18 = new SqlParameter("@LoginFormsFlage ", SqlDbType.Int);
            if( cmb_Logine.SelectedIndex ==0)
            {
                 param18.Value = 0;
            }
            else
            {
                 param18.Value = 1;
            }
           
            param18.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param18);
            //********************** 
           
            SqlParameter param119 = new SqlParameter("@EmployeeId ", SqlDbType.Int);
            param119.Value = empId;
            param119.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param119);
            //******************************************

            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;
        }
        //=============================
        private void bt_Add_Click(object sender, EventArgs e)
        {

            #region   cmb && validation
            //=============================================================
            //********************************
            if (txt_Name.Text == "")
            {
                MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Name.Focus();
                return;
            }
            //==============================
            //if (txt_nameEnglish.Text == "")
            //{
            //    MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txt_nameEnglish.Focus();
            //    return;
            //}
            //======================================================================            
            if (cmb_diana.SelectedIndex == -1)
            {
                MessageBox.Show(" من فضلك أدخل البيانات بصورة صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_diana.Focus();
                return;
            }
            //============================================================        
            if (cmb_gender.SelectedIndex == -1)
            {
                MessageBox.Show(" من فضلك أدخل البيانات بصورة صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_gender.Focus();
                return;
            }
            //===========================================            
            if (cmb_job.SelectedIndex == -1)
            {
                MessageBox.Show(" من فضلك أدخل البيانات بصورة صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_job.Focus();
                return;
            }
            //=====================================================     
            if (cmb_zwage.SelectedIndex == -1)
            {
                MessageBox.Show(" من فضلك أدخل البيانات بصورة صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_zwage.Focus();
                return;
            }
            //==============================
            //DateTime result3;
            //if (DateTime.TryParse(txt_birthdate.Text, out result3) == false)
            //{
            //    MessageBox.Show(" من فضلك أدخل البيانات بصورة صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txt_birthdate.Focus();
            //    return;
            //}
            //=======================================            
            if (txt_Name.Text == "")
            {
                MessageBox.Show(" من فضلك أدخل البيانات بصورة صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Name.Focus();
                return;
            }
            //===========
            #endregion
            //--------------------------
            insert_EmployeeTable();

            Fill_dataGridView1();

            bt_new.PerformClick();



            //************************
        }
        //==================================
        private void Getemplyeedata(int tempempId)
        {           
            //------
            //if (getSeload == false) return;
            ///----------------------------
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Select_EmpTable";
            //================
            SqlParameter param1 = new SqlParameter("@EmployeeId", SqlDbType.Int);
            param1.Value = tempempId;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
            //***************************
            dataAdapter1 = new SqlDataAdapter(cmd);
            dataSet1 = new DataSet();

            dataAdapter1.Fill(dataSet1, "prod_id");

            // for each row in the table, fill the list
            dataTable1 = dataSet1.Tables["prod_id"];
            //**************************************            
         
            if ((dataTable1.Rows.Count != 0))
            {
                DataRow selectedRow = dataTable1.Rows[0];


                getSetempId = int.Parse(selectedRow["EmployeeId"].ToString());

                txt_Name.Text = selectedRow["EmployeeName"].ToString();
                txt_nameEnglish.Text = selectedRow["EmployeeName_english"].ToString();
                txt_phone1.Text = selectedRow["phone1"].ToString();
                txt_phone2.Text= selectedRow["phone2"].ToString();
                txt_Mobile1.Text= selectedRow["mobile1"].ToString();
                txt_mobile2.Text = selectedRow["mobile2"].ToString();
                txt_Adrress.Text = selectedRow["address"].ToString();
                txt_NationalId.Text = selectedRow["nationalId"].ToString();
                //=================================
                    //BLOB is read into Byte array, then used to construct MemoryStream,
                    //then passed to PictureBox.

                Byte[] byteBLOBData = new Byte[0];
                byteBLOBData = (Byte[])(selectedRow["image"]);
                MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                pictureBox1.Image = Image.FromStream(stmBLOBData);
              
                //=============================================
                   txt_mail.Text = selectedRow["email"].ToString();
                   txt_facebook.Text = selectedRow["facebookid"].ToString();
                   dateTimePicker1.Value = Convert.ToDateTime(selectedRow["hireDate"].ToString());
                //   txt_birthdate.Text = displaydate(Convert.ToDateTime(selectedRow["birthDate"].ToString()));
                   txt_InsuranceNo.Text = selectedRow["insuranceNo"].ToString();                  
                   cmb_diana.Text = selectedRow["dianaName"].ToString();
                   cmb_gender.Text = selectedRow["sexName"].ToString();
                   cmb_job.Text = selectedRow["jobName"].ToString();
                   cmb_zwage.Text = selectedRow["ZawageName"].ToString();
                  
                if(int.Parse(selectedRow["LoginFormsFlage"].ToString())==0)
                {
                  cmb_Logine.SelectedIndex=0;
                }
                else
                {
                     cmb_Logine.SelectedIndex=1;
                }
                     
  
               
          

                //========
                bt_Update.Enabled = true;
                bt_delete.Enabled = true;

            }
            
               con.Close();con.Dispose();;

              


           


           

        }
        //=============================
        private string displaydate(DateTime dt)
        {
            string dd = dt.Date.Day.ToString();
            if (dd.Length == 1) dd = "0" + dd;
            string mm = dt.Date.Month.ToString();
            if (mm.Length == 1) mm = "0" + mm;
            string yyyy = dt.Date.Year.ToString();
            // return (dd + "/" + mm + "/" + yyyy);
            return (yyyy + "/" + mm + "/" + dd);
        }
        //============
        //When user changes row selection, display image of selected row in picture box.
        private void ShowPhoto(int rowcount)
        {
           
            try
            {
                //Get image data from gridview column.
                byte[] imageData = (byte[])dataGridView1.Rows[rowcount].Cells[1].Value;

                //Initialize image variable
                Image newImage;
                // Read image data into a memory stream
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);

                    // Set image variable value using memory stream.
                    newImage = Image.FromStream(ms, true);
                }

                //set picture
                pictureBox1.Image = newImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //=========================================
        private void Fill_dataGridView1()
        {

            dataGridView1.Rows.Clear();
            //==========================            
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //            string sql1 = "SELECT * from tb_poduct where prod_name like '" + textBox1.Text + "%' ";
            string sql1 = "SELECT EmployeeTable.EmployeeId, EmployeeTable.EmployeeName FROM EmployeeTable  WHERE (EmployeeTable.Trush ="+0+" )";
            //  and empName like '" + txt_Name.Text + "%' ORDER BY empName ";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql1;
            //***************************
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "all");
            // for each row in the table, fill the list
            dataTable = dataSet.Tables["all"];
            if (dataTable.Rows.Count == 0)
            {
                ////*****************************
               con.Close();con.Dispose();;
                
                //===============================
                return;
            }
            string empId,empName;//, branchName;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow selectedRow = dataTable.Rows[i];
                empId = selectedRow["EmployeeId"].ToString();
                empName = selectedRow["EmployeeName"].ToString();
                           
                //'''''''''''''''''''''''''''''''''''''''''''''''        
                dataGridView1.Rows.Add(empId, empName);


            }
           con.Close();con.Dispose();;

        }
        //===============================================
    

        
   
        //==============================  
     
        private void update_EmployeeTable_Dellete(int empId)
        {

            //======================================================
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "update_EmployeeTable_Dellete";
            //***********************

            SqlParameter param4 = new SqlParameter("@EmployeeId ", SqlDbType.Int);
            param4.Value = empId;
            param4.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param4);
            //**********************************************************   
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;
        }

     //========================

    

        private void bt_Update_Click_1(object sender, EventArgs e)
        {
            #region   cmb && validation
            //=============================================================
            //********************************
            if (txt_Name.Text == "")
            {
                MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Name.Focus();
                return;
            }
            //==============================
            //if (txt_nameEnglish.Text == "")
            //{
            //    MessageBox.Show("من فضلك  أكمل البيانات", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txt_nameEnglish.Focus();
            //    return;
            //}

            ////=====================================
            //if (cmb_branch.SelectedIndex == -1)
            //{
            //    MessageBox.Show(" من فضلك أدخل البيانات بصورة صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cmb_branch.Focus();
            //    return;
            //}
            //==========================================================            
            if (cmb_diana.SelectedIndex == -1)
            {
                MessageBox.Show(" من فضلك أدخل البيانات بصورة صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_diana.Focus();
                return;
            }
            //============================================================        
            if (cmb_gender.SelectedIndex == -1)
            {
                MessageBox.Show(" من فضلك أدخل البيانات بصورة صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_gender.Focus();
                return;
            }
            //===========================================            
            if (cmb_job.SelectedIndex == -1)
            {
                MessageBox.Show(" من فضلك أدخل البيانات بصورة صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_job.Focus();
                return;
            }
            //=====================================================     
            if (cmb_zwage.SelectedIndex == -1)
            {
                MessageBox.Show(" من فضلك أدخل البيانات بصورة صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_zwage.Focus();
                return;
            }
            //================================================
           // DateTime result3;
            //if (DateTime.TryParse(txt_birthdate.Text, out result3) == false)
            //{
            //    MessageBox.Show(" من فضلك أدخل البيانات بصورة صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txt_birthdate.Focus();
            //    return;
            //}
            //=======================================            
            if (txt_Name.Text == "")
            {
                MessageBox.Show(" من فضلك أدخل البيانات بصورة صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Name.Focus();
                return;
            }
            //===========
            #endregion
            //=============

            //--------------------------======================== 
            update_EmployeeTable(getSetempId);
            Fill_dataGridView1();
            bt_new.PerformClick();
        }
        //===============================
        private void bt_delete_Click_1(object sender, EventArgs e)
        {

            if (getSetempId == 0) return;

            DialogResult result3;
            result3 = MessageBox.Show(" هل تريد حذف الموظف ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result3 == DialogResult.Yes)
            {
                update_EmployeeTable_Dellete(getSetempId);
              
               
                bt_Add.Enabled = false;

                Fill_dataGridView1();
                bt_new.PerformClick();
                MessageBox.Show("تم الحذف");
               
            }
            //--------------------------======================== 
           
           
            
        }

       //=============


        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;

            int tempempId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Getemplyeedata(tempempId);
            bt_Add.Enabled = false;
            bt_delete.Enabled = true;
            bt_Update.Enabled = true;
            //-------------------------
        }

        

    
      
        
        

        
        //=======***************
    }
}