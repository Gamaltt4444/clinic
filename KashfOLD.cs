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
    public partial class KashfOLD : Form
    {
        //***********************
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTable dataTable;
        //===============
        private SqlDataAdapter dataAdapter1;
        private DataSet dataSet1;
        private DataTable dataTable1;
        //==========================
        //private SqlDataAdapter dataAdapter2;
        //private DataSet dataSet2;
        //private DataTable dataTable2;
        //==================================
        public DataTable dt_ForPrint = new DataTable();//for add row to the datagrid
        //**************************
        public string stringcon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=GenClinicDB;Data Source=.";
        //*********************************************************
        public string stringconPrint = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ZPrintDB;Data Source=.";
        //***************
        //=========== for  customer
        public static string tempName;
        public string GetSetName
        {
            set { tempName = value; }
            get { return tempName; }
        }
        //==========
        public static int tempPatiantId;
        public int GetSetPatiantId
        {
            set { tempPatiantId = value; }
            get { return tempPatiantId; }
        }
        //=============  
        public static bool tempPatiantIdboll=false;
        public bool GetSetPatiant_flage
        {
            set { tempPatiantIdboll = value; }
            get { return tempPatiantIdboll; }
        }
        //===========
        public static int tempXRaysID;
        public int GetSetXRaysID
        {
            set { tempXRaysID = value; }
            get { return tempXRaysID; }
        }
        //======================      GetSetTestID
        public static int tempGetSetTestID;
        public int GetSetTestID
        {
            set { tempGetSetTestID = value; }
            get { return tempGetSetTestID; }
        }
        //=============
        public static int tempKashfOrderId;
        public int GetSetKashfOrderId
        {
            set { tempKashfOrderId = value; }
            get { return tempKashfOrderId; }
        }
        //===============   GetSetMedcinID
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
        //======================
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
          


            //================= new 
            //if (keyData == (Keys.F7))
            //{

            //    toolStripButton2.PerformClick();
            //    return true;
            //}
            ////---
            //if (keyData == (Keys.F8))
            //{

            //    toolStripButton2.PerformClick();
            //    return true;
            //}
            //================================
            //if (keyData == (Keys.Control | Keys.Shift | Keys.Z))     // if (keyData == (Keys.Control | Keys.X))
            if (keyData == (Keys.F10))
            {
                //make print which mean we like press click on the button  toolStripButton3
                toolStrip_Save.PerformClick();
                return true;
            }
            //================= Isteshara
            if (keyData == (Keys.F11))
            {

                toolStrip_Save.PerformClick();
                return true;
            }

            //=================
            if (keyData == (Keys.F12))
            {

                toolStrip_Save.PerformClick();
                return true;
            }
            //----------------------------------------------
            //=================
            if (keyData == Keys.F2)
            {

                printToolStripButton.PerformClick();
                return true;
            }
            //=====================
            if (keyData == Keys.F3)
            {

                printToolStripButton.PerformClick();
                return true;
            }
            //=================
            if (keyData == Keys.F4)
            {
                printToolStripButton.PerformClick();
                return true;
            }
            //=====================
            if (keyData == Keys.F5)
            {

                printToolStripButton.PerformClick();
                return true;
            }
            //=====================
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //=====================
        public KashfOLD()
        {
            InitializeComponent();
        }
        //---------------------     

        private void txt_Name_KeyDown(object sender, KeyEventArgs e)
        {
            //==========================
            if (e.KeyCode == Keys.Enter)
            {
               Search_Patient_Name() ;
               txt_Diagnosis.Focus();
                     
               
            }

            //==================
        }
        //--------------------=====================------------============
        private bool Search_Patient_Name()
        {
            //=======================================
            SqlConnection con1 = new SqlConnection(stringcon);
            con1.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con1;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT     Patiant.*, Patiant.PatiantName, TaminTable.TaminName FROM   Patiant INNER JOIN  TaminTable ON Patiant.TaminID = TaminTable.TaminID  where ( PatiantName = '" + txt_Name.Text + "') and (Patiant.Trash=" + 0 + ") ";

            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "name");

            // for each row in the table, fill the list
            dataTable = dataSet.Tables["name"];
            //**************************************            

            if (dataTable.Rows.Count > 0)
            {

                //========================= 
                DataRow selectedRow = dataTable.Rows[0];

                GetSetPatiantId = (int)selectedRow["PatiantId"];
                txt_code.Text = GetSetPatiantId.ToString();
                GetSetName = selectedRow["PatiantName"].ToString();

                txt_Tamine.Text = selectedRow["TaminName"].ToString();
                //=============================================
               con1.Close();con1.Dispose();;
                //========
                GetSetPatiant_flage = true;
                return true;

            }
            else
            {
               con1.Close();con1.Dispose();;
                GetSetPatiant_flage = false;
                return false;


            }




        }
        //==============================---------============
        private bool Search_Patient_COde(int PatiantId)
        {
            //=======================================
            SqlConnection con1 = new SqlConnection(stringcon);
            con1.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con1;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT     Patiant.*, Patiant.PatiantName, TaminTable.TaminName FROM   Patiant INNER JOIN  TaminTable ON Patiant.TaminID = TaminTable.TaminID  where (PatiantId = " + PatiantId + " ) and(Patiant.Trash=" + 0 + ")  ";
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "name");

            // for each row in the table, fill the list
            dataTable = dataSet.Tables["name"];
            //**************************************            

            if (dataTable.Rows.Count > 0)
            {

                //========================= 
                DataRow selectedRow = dataTable.Rows[0];

                GetSetPatiantId = (int)selectedRow["PatiantId"];
                //txt_code.Text = GetSetPatiantId.ToString();
                GetSetName = selectedRow["PatiantName"].ToString();
                txt_Name.Text = GetSetName;
                txt_Tamine.Text = selectedRow["TaminName"].ToString();
                //=============================================
               con1.Close();con1.Dispose();;
                //========
                GetSetPatiant_flage = true;
                return true;

            }
            else
            {
               con1.Close();con1.Dispose();;
                GetSetPatiant_flage = false;
                return false;


            }




        }
        //===================
        private bool Search_XRay()
        {
            //=======================================
            SqlConnection con1 = new SqlConnection(stringcon);
            con1.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con1;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT    * FROM XRays  where  ( XRaysName = '" + txt_Xray.Text.Trim() + "') ";

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

                GetSetXRaysID = (int)selectedRow["XRaysID"];

               // GetSetName = selectedRow["XRaysName"].ToString();
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
        //========================
        private bool Search_Test()
        {
            //=======================================
            SqlConnection con1 = new SqlConnection(stringcon);
            con1.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con1;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT    * FROM Tests  where  ( TestName = '" + txt_Test.Text.Trim() + "') ";

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

                GetSetTestID = (int)selectedRow["TestID"];

               
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
        //===========================
        private bool Search_MedcinID(int MedcinID)
        {
            //=======================================
            SqlConnection con1 = new SqlConnection(stringcon);
            con1.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con1;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT    * FROM Medcin  where  ( MedcinID = " + MedcinID + ") ";

            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "name");

            // for each row in the table, fill the list
            dataTable = dataSet.Tables["name"];
            //**************************************            

            if (!(dataTable.Rows.Count == 0))
            {
                GetSetMedcinID = MedcinID;
                //========================= 
                DataRow selectedRow = dataTable.Rows[0];

                GetSetMedcinTypeID = (int)selectedRow["MedcinTypeID"];
                txt_MedcinName.Text = selectedRow["MedcinName"].ToString();
                //=============================================
                con1.Close(); con1.Dispose(); ;
                //========

                return true;

            }
            else
            {
                con1.Close(); con1.Dispose(); ;

                return false;


            }




        }
        //========================
        private bool Search_MedcinName()
        {
            //=======================================
            SqlConnection con1 = new SqlConnection(stringcon);
            con1.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con1;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT    * FROM Medcin  where  ( MedcinName = '" + txt_MedcinName.Text + "') ";

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

                GetSetMedcinID = (int)selectedRow["MedcinID"];
                txt_Medcin_Code.Text = GetSetMedcinID.ToString();
                GetSetMedcinTypeID = (int)selectedRow["MedcinTypeID"];
                //=============================================
                con1.Close(); con1.Dispose(); ;
                //========

                return true;

            }
            else
            {
                con1.Close(); con1.Dispose(); ;

                return false;


            }




        }
        //========================
        private string Search_MedcinType(int MedcinTypeID)
        {
            string MedcinTypeName = " ";
            //=======================================
            SqlConnection con2 = new SqlConnection(stringcon);
            con2.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con2;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT    * FROM MedcinType  where  ( MedcinTypeID = " + MedcinTypeID + ") ";

            dataAdapter1 = new SqlDataAdapter(cmd);
            dataSet1 = new DataSet();
            dataAdapter1.Fill(dataSet1, "name");
            // for each row in the table, fill the list
            dataTable1 = dataSet1.Tables["name"];
            //**************************************            

            if (!(dataTable1.Rows.Count == 0))
            {

                //========================= 
                DataRow selectedRow = dataTable1.Rows[0];

                MedcinTypeName = selectedRow["MedcinTypeName"].ToString();

               
                
                //========

               

            }
            con2.Close();
            return MedcinTypeName;



        }
        //========================
        private bool Search_MedcinWay()
        {
            //=======================================
            SqlConnection con1 = new SqlConnection(stringcon);
            con1.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con1;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT    * FROM MedcinWay  where  ( MedcinWayDescription = '" +txt_MedcinWay.Text + "') ";

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

                GetSetMedcinWayId = (int)selectedRow["MedcinWayId"];

                // GetSetName = selectedRow["MedcinName"].ToString();
                //===============================
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
        //===============
        private void AutocompleteText_Patient()
        {
            //=====================================================
            SqlConnection con100 = new SqlConnection(stringcon);
            con100.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con100;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT    distinct   PatiantName FROM Patiant WHERE (Trash =" + 0 + ") order by  PatiantName";
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            //***********************
            SqlDataReader dReader;
            dReader = cmd.ExecuteReader();
            if (dReader.HasRows == true)
            {
                while (dReader.Read())
                    namesCollection.Add(dReader["PatiantName"].ToString());

            }
            else
            {
                //MessageBox.Show("اسم الصنف غير موجود الرجاء إضافته أولا");
            }
            dReader.Close();

            txt_Name.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_Name.AutoCompleteCustomSource = namesCollection;

        }
        //===================
        private void AutocompleteText_XRay()
        {
            //=====================================================
            SqlConnection con100 = new SqlConnection(stringcon);
            con100.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con100;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT    distinct   XRaysName FROM XRays WHERE (Trash =" + 0 + ") order by  XRaysName";
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            //***********************
            SqlDataReader dReader;
            dReader = cmd.ExecuteReader();
            if (dReader.HasRows == true)
            {
                while (dReader.Read())
                    namesCollection.Add(dReader["XRaysName"].ToString());

            }
            else
            {
                //MessageBox.Show("اسم الصنف غير موجود الرجاء إضافته أولا");
            }
            dReader.Close();
            
            txt_Xray.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_Xray.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_Xray.AutoCompleteCustomSource = namesCollection;

        }
        //===================
        private void AutocompleteText_Medcin()
        {
            //=====================================================
            SqlConnection con100 = new SqlConnection(stringcon);
            con100.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con100;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT    distinct   MedcinName FROM Medcin WHERE (Trash =" + 0 + ") order by  MedcinName";
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            //***********************
            SqlDataReader dReader;
            dReader = cmd.ExecuteReader();
            if (dReader.HasRows == true)
            {
                while (dReader.Read())
                    namesCollection.Add(dReader["MedcinName"].ToString());

            }
            else
            {
                //MessageBox.Show("اسم الصنف غير موجود الرجاء إضافته أولا");
            }
            dReader.Close();

            txt_MedcinName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_MedcinName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_MedcinName.AutoCompleteCustomSource = namesCollection;

        }
        //==========================
        private void AutocompleteText_MedcinType()
        {
            //=====================================================
            SqlConnection con100 = new SqlConnection(stringcon);
            con100.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con100;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT    distinct   MedcinTypeName FROM MedcinType WHERE (Trash =" + 0 + ") order by  MedcinTypeName";
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            //***********************
            SqlDataReader dReader;
            dReader = cmd.ExecuteReader();
            if (dReader.HasRows == true)
            {
                while (dReader.Read())
                    namesCollection.Add(dReader["MedcinTypeName"].ToString());

            }
            else
            {
                //MessageBox.Show("اسم الصنف غير موجود الرجاء إضافته أولا");
            }
            dReader.Close();

            txt_MedcineType.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_MedcineType.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_MedcineType.AutoCompleteCustomSource = namesCollection;

        }
        //==========================
        private void AutocompleteText_MedcinWay_Description()
        {
            //=====================================================
            SqlConnection con100 = new SqlConnection(stringcon);
            con100.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con100;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT    distinct MedcinWayDescription   FROM MedcinWay WHERE (Trash =" + 0 + ") order by  MedcinWayDescription";
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            //***********************
            SqlDataReader dReader;
            dReader = cmd.ExecuteReader();
            if (dReader.HasRows == true)
            {
                while (dReader.Read())
                    namesCollection.Add(dReader["MedcinWayDescription"].ToString());

            }
            else
            {
                //MessageBox.Show("اسم الصنف غير موجود الرجاء إضافته أولا");
            }
            dReader.Close();

            txt_MedcinWay.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_MedcinWay.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_MedcinWay.AutoCompleteCustomSource = namesCollection;

        }
        //==========================
        private void AutocompleteText_Test()
        {
            //=====================================================
            SqlConnection con100 = new SqlConnection(stringcon);
            con100.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con100;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT    distinct TestName   FROM Tests WHERE (Trash =" + 0 + ") order by  TestName";
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            //***********************
            SqlDataReader dReader;
            dReader = cmd.ExecuteReader();
            if (dReader.HasRows == true)
            {
                while (dReader.Read())
                    namesCollection.Add(dReader["TestName"].ToString());

            }
            else
            {
                //MessageBox.Show("اسم الصنف غير موجود الرجاء إضافته أولا");
            }
            dReader.Close();

            txt_Test.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_Test.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_Test.AutoCompleteCustomSource = namesCollection;

        }
        //==========================
        private void FillKashfFlageName()
        {





            cmb_Kasf_Estishara.DataSource = null;

            //////////////////////////////////////////////////
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT  * FROM KashfFlageTable where (Trash=" + 0 + ") order by  KashfFlage";

            //******************
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "categoryTable");
            // for each row in the table, fill the list
            dataTable = dataSet.Tables["categoryTable"];

            /////////////// test
            cmb_Kasf_Estishara.DataSource = dataTable;
            cmb_Kasf_Estishara.ValueMember = "KashfFlage";
            cmb_Kasf_Estishara.DisplayMember = "KashfFlageName";

           con.Close();con.Dispose();;


            //==============

        }
        //======================
        private void KashfOLD_Load(object sender, EventArgs e)
        {
            //=========
            FillKashfFlageName();
            //----------------------------
            AutocompleteText_Patient();
            AutocompleteText_XRay();
            AutocompleteText_Medcin();
            AutocompleteText_MedcinType();
            AutocompleteText_MedcinWay_Description();
            AutocompleteText_Test();            
            //---------------------
            Searc_Order(GetSetKashfOrderId);
            Searc_Order_Xray(GetSetKashfOrderId);
            Searc_Order_Test(GetSetKashfOrderId);
            //=========================================
        }

        //=============
        private void Searc_Order(int KashfOrderId)
        {

            string MedcinTypeName, MedcinName, Description, MedcinID;

            //======================

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Select_KashfOrderMedcin";
            //***********************            
            SqlParameter param2 = new SqlParameter("@KashfOrderId", SqlDbType.Int);
            param2.Value = KashfOrderId;
            param2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param2);

            //***************************
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "all");
            // for each row in the table, fill the list
            dataTable = dataSet.Tables["all"];
            //************************************** 
            if (dataTable.Rows.Count == 0)
            {
                ////*****************************
               con.Close();con.Dispose();;
                dataGridView1.Rows.Clear();
                //===============================
                return;
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {

                //========================
                DataRow selectedRow = dataTable.Rows[i];

                int KashfOrderDetailId = int.Parse(selectedRow["KashfOrderDetailId"].ToString());
                MedcinName = selectedRow["MedcinName"].ToString();
                MedcinTypeName = selectedRow["MedcinTypeName"].ToString();

                Description = selectedRow["Description"].ToString();

                MedcinID = selectedRow["MedcinID"].ToString();



                dataGridView1.Rows.Add(MedcinName, MedcinTypeName, Description, MedcinID, KashfOrderDetailId);
                //=======================================
            }


            DataRow selectedRow1 = dataTable.Rows[0];
            txt_Name.Text = selectedRow1["PatiantName"].ToString();
            txt_code.Text = selectedRow1["PatiantId"].ToString();
            txt_Diagnosis.Text = selectedRow1["Diagnosis"].ToString();
            txt_Tamine.Text = selectedRow1["TaminName"].ToString();
            cmb_Kasf_Estishara.Text = selectedRow1["KashfFlageName"].ToString();
            //--------------------------
            dateTimePicker1.Value = Convert.ToDateTime(selectedRow1["KashfDate"].ToString());
            //======================

           con.Close();con.Dispose();;
            //===========         

           




        }
        //=============== 
        private void Searc_Order_Xray(int KashfOrderId)
        {

            string XRaysID, XRaysName;

            //======================

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT    KashfOrderXRaysDetail.XRaysID, XRays.XRaysName FROM KashfOrderXRaysDetail INNER JOIN XRays ON KashfOrderXRaysDetail.XRaysID = XRays.XRaysID WHERE (KashfOrderXRaysDetail.KashfOrderId = " + KashfOrderId + ")";
            //***********************            

            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "all");
            // for each row in the table, fill the list
            dataTable = dataSet.Tables["all"];
            //************************************** 
            if (dataTable.Rows.Count == 0)
            {
                ////*****************************
               con.Close();con.Dispose();;
                dataGridView_XRay.Rows.Clear();
                //===============================
                return;
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {

                //========================
                DataRow selectedRow = dataTable.Rows[i];


                XRaysID = selectedRow["XRaysID"].ToString();
                XRaysName = selectedRow["XRaysName"].ToString();




                dataGridView_XRay.Rows.Add(XRaysID, XRaysName);
                //====
            }





           con.Close();con.Dispose();;



        }
        //=============== 
        private void Searc_Order_Test(int KashfOrderId)
        {

            string TestID, TestName;

            //======================

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT     KashfOrderTestDetail.TestID, Tests.TestName FROM KashfOrderTestDetail INNER JOIN Tests ON KashfOrderTestDetail.TestID = Tests.TestID WHERE  (KashfOrderTestDetail.KashfOrderId = " + KashfOrderId + ")";
            //***********************            

            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "all");
            // for each row in the table, fill the list
            dataTable = dataSet.Tables["all"];
            //************************************** 
            if (dataTable.Rows.Count == 0)
            {
                ////*****************************
               con.Close();con.Dispose();;
                dataGridView_Test.Rows.Clear();
                //===============================
                return;
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {

                //========================
                DataRow selectedRow = dataTable.Rows[i];


                TestID = selectedRow["TestID"].ToString();
                TestName = selectedRow["TestName"].ToString();




                dataGridView_Test.Rows.Add(TestID, TestName);
                //====
            }





           con.Close();con.Dispose();;



        }
        //=============== 
        private string displaydate(DateTime dt)
        {
            string dd = dt.Date.Day.ToString();
            if (dd.Length == 1) dd = "0" + dd;
            string mm = dt.Date.Month.ToString();
            if (mm.Length == 1) mm = "0" + mm;
            string yyyy = dt.Date.Year.ToString();
            return (yyyy + "   " + mm + "      " + dd);
        }
        private void bt_Dowen_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(txt_MedcinName.Text, txt_MedcineType.Text,txt_MedcinWay.Text,GetSetMedcinID,GetSetMedcinWayId);

            //string way = txt_MedcineType.Text + " / " + txt_MedcinWay.Text;
            //int x = way.Length;
            //MessageBox.Show(x.ToString());

            txt_MedcinName.Text = "";
            txt_MedcinWay.Text = "";
            txt_Medcin_Code.Focus();
        }
        //======================
        private void txt_MedcinName_KeyDown(object sender, KeyEventArgs e)
        {
            //==========================
            if (e.KeyCode == Keys.Enter)
            {
               
                if (Search_MedcinName()==false)
                {
                   DialogResult result3;
                    result3 = MessageBox.Show("هذا الدواء غير مسجل هل تريد تسجيله", " warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result3 == DialogResult.Yes)
                    {
                        MedcineKashf MedcineKashf1 = new MedcineKashf();
                        MedcineKashf1.ShowDialog();
                        //insertItem_Medcin();
                        //Search_MedcinName();
                        txt_MedcinName.Text = "";
                        AutocompleteText_Medcin();

                    }
                    
                }

                txt_MedcineType.Text = Search_MedcinType(GetSetMedcinTypeID);

                txt_MedcineType.Focus();

                
            }
            //==================
        }
        //============================
        private void txt_MedcinWay_KeyDown(object sender, KeyEventArgs e)
        {
            //==========================
            if (e.KeyCode == Keys.Enter)
            {
                
                if (Search_MedcinWay()==false)
                {

                    insert_MedcinWay();
                    Search_MedcinWay();
                    AutocompleteText_MedcinWay_Description();

                   
                    
                }
               bt_Dowen.PerformClick();

            }

            //==================
        }
        //=====================================
        private void txt_Xray_KeyDown(object sender, KeyEventArgs e)
        {
            //==========================
            if (e.KeyCode == Keys.Enter)
            {

                bt_down_XRay.PerformClick();

            }

            //=================

        }
        //=================================
        private void insertItem_Xray()
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insert_XRays";
            //***********************

            SqlParameter param3 = new SqlParameter("@XRaysName ", SqlDbType.NVarChar, 100);
            param3.Value = txt_Xray.Text;
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);
            //*****************
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;

            //***********************************

        }
        //=====================================
        private void insertItem_Test()
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insert_Tests";
            //***********************

            SqlParameter param3 = new SqlParameter("@TestName ", SqlDbType.NVarChar, 50);
            param3.Value =txt_Test.Text;
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);
            //*****************
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;

            //***********************************

        }
        //==================
        private void insertItem_Medcin()
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insert_Medcin";
            //***********************

            SqlParameter param3 = new SqlParameter("@MedcinName ", SqlDbType.NVarChar, 100);
            param3.Value = txt_MedcinName.Text;
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);
            //*****************
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;

            //***********************************

        }
        //==================
        private void insert_MedcinWay()
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insert_MedcinWay";
            //***********************

            SqlParameter param3 = new SqlParameter("@MedcinWayDescription ", SqlDbType.NVarChar, 100);
            param3.Value =txt_MedcinWay.Text;
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);
            //*****************
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;

            //***********************************

        }
        //==================
        private void toolStrip_Save_Click(object sender, EventArgs e)
        {

            //===================== 
           
            if (dataGridView1.Rows.Count == 0 && dataGridView_XRay.Rows.Count==0)
            {
                MessageBox.Show(" من فضلك قم بكتابة دواء ", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //---------------------------
            if (GetKashfFlage(cmb_Kasf_Estishara.Text) == 0)
            {
                MessageBox.Show(" من فضلك قم بإختيار الكشف أو  الإستشارة ", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_Kasf_Estishara.Focus();
                return;
            }
            //==========
            
            GetSetPatiant_flage = Search_Patient_Name();

            if (txt_Name.Text != "" && GetSetPatiant_flage == false)
            {
                DialogResult result3;
                result3 = MessageBox.Show(" من فضلك هذا المريض غير مسجل  هل تريد تسجيله ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result3 == DialogResult.Yes)
                {
                    PatientKashf PatientKashf1 = new PatientKashf();
                    PatientKashf1.ShowDialog();
                }
                AutocompleteText_Patient();
                txt_Name.Text = "";
                return;
            }
            //---------
            //================== insert order

            delete_KashfOrderDetail(GetSetKashfOrderId);
            delete_KashfOrderTestDetail(GetSetKashfOrderId);
            delete_KashfOrderXRaysDetail(GetSetKashfOrderId);

            Update_KashfOrder();
            //=======================           
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //=======================
             int   MedcinID = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            
             string MedcinTypeName = dataGridView1.Rows[i].Cells[1].Value.ToString();
             string Description = dataGridView1.Rows[i].Cells[2].Value.ToString();
             insert_KashfOrderDetail(GetSetKashfOrderId, Description, MedcinID, MedcinTypeName);

                //===============
            }

            //================================           
            for (int i = 0; i < dataGridView_XRay.Rows.Count; i++)
            {
                //=======================
                int XRaysID = int.Parse(dataGridView_XRay.Rows[i].Cells[0].Value.ToString());

                insert_KashfOrderXRaysDetail(GetSetKashfOrderId, XRaysID);

                //===============
            }

            //================================           
            for (int i = 0; i < dataGridView_Test.Rows.Count; i++)
            {
                //=======================
                int TestID = int.Parse(dataGridView_Test.Rows[i].Cells[0].Value.ToString());

                insert_KashfOrderTestDetail(GetSetKashfOrderId, TestID);

                //===============
            }

            //==================
            toolStrip_Save.Enabled = false;

            //===========================================
        }
        //============================================
        private void delete_KashfOrderDetail(int KashfOrderId)
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from KashfOrderDetail where KashfOrderId=" + KashfOrderId + " ";
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;

        }
        //=========
        private void delete_KashfOrderTestDetail(int KashfOrderId)
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from KashfOrderTestDetail where KashfOrderId=" + KashfOrderId + " ";
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;

        }
        //=========
        private void delete_KashfOrderXRaysDetail(int KashfOrderId)
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from KashfOrderXRaysDetail where KashfOrderId=" + KashfOrderId + " ";
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;

        }
        //===========
        private int GetKashfFlage(string KashfFlageName)
        {
            int xx = 0;

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM KashfFlageTable WHERE(KashfFlageName ='" + KashfFlageName + "')";
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "all");

            // for each row in the table, fill the list
            dataTable = dataSet.Tables["all"];

            if (!(dataTable.Rows.Count == 0))
            {
                //=========================

                DataRow selectedRow = dataTable.Rows[0];
                if (selectedRow["KashfFlage"].ToString() != "" && selectedRow["KashfFlage"].ToString() != null)
                {
                    xx = int.Parse(selectedRow["KashfFlage"].ToString());
                }
               con.Close();con.Dispose();;

            }
            return xx;
        }
        //===========
        private void Update_KashfOrder()
        {



            //=====================================================
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "update_KashfOrder";
            //***********************

            SqlParameter param2 = new SqlParameter("@KashfDate", SqlDbType.DateTime);
            param2.Value = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());
            param2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param2);
            //*************************************************** 

            SqlParameter param3 = new SqlParameter("@PatiantId ", SqlDbType.Int);           
            param3.Value = GetSetPatiantId;            
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);
            //********************************
            SqlParameter param14 = new SqlParameter("@Diagnosis ", SqlDbType.NVarChar, 200);
            param14.Value = txt_Diagnosis.Text;
            param14.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param14);
            //*********************
            SqlParameter param5 = new SqlParameter("@KashfFlage  ", SqlDbType.Int);
            param5.Value = GetKashfFlage(cmb_Kasf_Estishara.Text);// cmb_Kasf_Estishara.SelectedIndex;
            param5.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param5);
            //********************************
            SqlParameter param6 = new SqlParameter("@KashfOrderId ", SqlDbType.Int);
            param6.Value = GetSetKashfOrderId;
            param6.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param6);
            //********************************
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;
            //=================
        }
        //=======================================
        private void insert_KashfOrderDetail(int KashfOrderId, string Description, int MedcinID, string MedcinTypeName)
        {
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insert_KashfOrderDetail";
            //***********************
            SqlParameter param11 = new SqlParameter("@KashfOrderId", SqlDbType.Int);
            param11.Value = KashfOrderId;
            param11.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param11);
            ////***************************
            SqlParameter param1000 = new SqlParameter("@Description ", SqlDbType.NVarChar, 200);
            param1000.Value = Description;
            param1000.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1000);
            //******************************************
            SqlParameter param5 = new SqlParameter("@MedcinID", SqlDbType.Int);
            param5.Value = MedcinID;
            param5.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param5);
            //***************************  
            SqlParameter param10000 = new SqlParameter("@MedcinTypeName ", SqlDbType.NVarChar, 50);
            param10000.Value = MedcinTypeName;
            param10000.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param10000);
            //******************************************
           
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;
        }
        //================================
        private void insert_KashfOrderXRaysDetail(int KashfOrderId, int XRaysID)
        {
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insert_KashfOrderXRaysDetail";
            //***********************
            SqlParameter param11 = new SqlParameter("@KashfOrderId", SqlDbType.Int);
            param11.Value = KashfOrderId;
            param11.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param11);
            ////***************************            
            SqlParameter param5 = new SqlParameter("@XRaysID", SqlDbType.Int);
            param5.Value = XRaysID;
            param5.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param5);
            //***************************           

            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;
        }
        //====================     
        private void insert_KashfOrderTestDetail(int KashfOrderId, int TestID)
        {
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insert_KashfOrderTestDetail";
            //***********************
            SqlParameter param11 = new SqlParameter("@KashfOrderId", SqlDbType.Int);
            param11.Value = KashfOrderId;
            param11.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param11);
            ////***************************            
            SqlParameter param5 = new SqlParameter("@TestID", SqlDbType.Int);
            param5.Value = TestID;
            param5.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param5);
            //***************************           

            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;
        }
        //====================
        private void bt_down_XRay_Click(object sender, EventArgs e)
        {
            if (Search_XRay())
            {
                dataGridView_XRay.Rows.Add(GetSetXRaysID, txt_Xray.Text);
            }
            else
            {
                DialogResult result3;
                result3 = MessageBox.Show("هذه غير مسجلة هل تريد تسجيلها", " warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result3 == DialogResult.Yes)
                {
                    insertItem_Xray();
                    Search_XRay();
                    dataGridView_XRay.Rows.Add(GetSetXRaysID, txt_Xray.Text);
                    AutocompleteText_XRay();

                }
                else
                    return;
                //////////////////////
            }
            txt_Xray.Text = "";
        }
        //==========================
        private void txt_Diagnosis_KeyPress(object sender, KeyPressEventArgs e)
        {
            //--------------------------
            if (e.KeyChar == 13 && txt_Diagnosis.Text != null && txt_Diagnosis.Text != "")
            {
                txt_MedcinName.Focus();
            }

            //======== //========
        }
        //==============================
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            txt_Diagnosis.Text = "";
            txt_MedcinName.Text = "";
            txt_MedcinWay.Text = "";
            txt_Name.Text = "";
            txt_code.Text = "";
            txt_Xray.Text = "";
            txt_MedcineType.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView_XRay.Rows.Clear();
            dataGridView_Test.Rows.Clear();
            toolStrip_Save.Enabled = true;
        }
        //====================
        private void txt_MedcineType_KeyDown(object sender, KeyEventArgs e)
        {
            //==========================
            if (e.KeyCode == Keys.Enter)
            {

                txt_MedcinWay.Focus();


            }
            //==================
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Image = new Bitmap(Image.png, new Size(227, 171));
            e.Graphics.DrawImage(Properties.Resources.rosta, 49, 0, 700, 935);
            //=========
            #region Kasf Print
            //=================================        
            float yPos = 20;
            int leftMargin = 15;
            // Pen pen = new Pen(Brushes.Black);

            //e.HasMorePages =true;
            // pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            //Font printFont4d = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
            //Font printFont = new System.Drawing.Font("Times New Roman", 14);
            //Font printFont11 = new System.Drawing.Font("Times New Roman", 16);
            //Font printFontFoorer = new System.Drawing.Font("Times New Roman", 12);
            //Font printFontheader_DRName = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);
            //------
            string medicn, Gruaa, MedcinWay, way;

            Font PatientFontheader = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);

            Font PatientNormal = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            Font patientNormal2 = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            //======================================                      

            yPos += 380;
            //e.Graphics.DrawString("Medcin Name", patientNormal2, Brushes.Black, leftMargin + 80, 360, new StringFormat());
            //e.Graphics.DrawString("Medcin Way", patientNormal2, Brushes.Black, leftMargin + 450, 360, new StringFormat());
            // e.Graphics.DrawString("Medcin Gruaa", patientNormal2, Brushes.Black, leftMargin + 570, 360, new StringFormat());


            e.Graphics.DrawString(txt_Name.Text, PatientFontheader, Brushes.Black, leftMargin + 220, 262, new StringFormat());

            //e.Graphics.DrawString("Code", PatientFontheader, Brushes.Black, leftMargin + 475, yPos, new StringFormat());

            //e.Graphics.DrawString(": " + txt_code.Text, PatientFontheader, Brushes.Black, leftMargin + 525, yPos, new StringFormat());
            yPos += 25;

            e.Graphics.DrawString("Patient Diagnosis: " + txt_Diagnosis.Text, PatientFontheader, Brushes.Black, leftMargin + 80, 320, new StringFormat());

            e.Graphics.DrawString("", PatientFontheader, Brushes.Black, leftMargin + 475, 20, new StringFormat());
            string KashfDate = displaydate(dateTimePicker1.Value);
            e.Graphics.DrawString(" " + KashfDate, PatientFontheader, Brushes.Black, leftMargin + 555, 262, new StringFormat());
            yPos += 5;
            //=========================  for adust right align 
            //SizeF stringSize = new SizeF();
            //stringSize = e.Graphics.MeasureString(way1, PatientNormal);

            //e.Graphics.DrawString(way1, PatientNormal, Brushes.Black, 500 - stringSize.Width, yPos);
            yPos -= 40;
            //==========================
            SizeF stringSize = new SizeF();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                medicn = dataGridView1.Rows[i].Cells[0].Value.ToString();
                Gruaa = dataGridView1.Rows[i].Cells[1].Value.ToString();
                MedcinWay = dataGridView1.Rows[i].Cells[2].Value.ToString();
                e.Graphics.DrawString(medicn.ToUpper(), PatientNormal, Brushes.Black, leftMargin + 80, yPos, new StringFormat());
                yPos += 1;
                way = "   " + Gruaa + "    " + MedcinWay;
                stringSize = e.Graphics.MeasureString(way, PatientNormal);
                e.Graphics.DrawString(way, PatientNormal, Brushes.Black, 680 - stringSize.Width, yPos);
                yPos += 20;
            }
            #endregion
            //===========
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //============================
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = this.printDocument1;
            printPreviewDialog1.FormBorderStyle = FormBorderStyle.Fixed3D;
            //printPreviewDialog1.SetBounds(20, 20, this.Width, this.Height);

            // printPreviewDialog1.ShowDialog();
            printDialog1.ShowDialog();

            //============================
        }
        //----------------------------------
        private void printToolStripButton_Click(object sender, EventArgs e)
        {

            toolStrip_Save.PerformClick();
            //======================
            if (dataGridView1.Rows.Count <= 22 && dataGridView1.Rows.Count !=0  && dataGridView_XRay.Rows.Count > 0 && dataGridView_Test.Rows.Count > 0)  // ==صفحة واحدة
            {
                PrintPreviewDialog printPreviewDialog6 = new PrintPreviewDialog();
                printPreviewDialog6.Document = this.printDocument6;
                printPreviewDialog6.FormBorderStyle = FormBorderStyle.Fixed3D;
                printPreviewDialog6.SetBounds(20, 20, this.Width, this.Height);
                printPreviewDialog6.ShowDialog();


                printDocument6.Print();

            }

               
                else
                {
                    if (dataGridView1.Rows.Count <= 22 &&  dataGridView1.Rows.Count != 0 && dataGridView_XRay.Rows.Count > 0)  // ==صفحة واحدة
                    {

                        PrintPreviewDialog printPreviewDialog7 = new PrintPreviewDialog();
                        printPreviewDialog7.Document = this.printDocument7;
                        printPreviewDialog7.FormBorderStyle = FormBorderStyle.Fixed3D;
                        printPreviewDialog7.SetBounds(20, 20, this.Width, this.Height);
                        printPreviewDialog7.ShowDialog();
                        printDocument7.Print();
                              
                    }
                    else
                    {
                        if (dataGridView1.Rows.Count <= 22 && dataGridView1.Rows.Count != 0 && dataGridView_Test.Rows.Count > 0)  // ==صفحة واحدة
                        {
                            PrintPreviewDialog printPreviewDialog8 = new PrintPreviewDialog();
                            printPreviewDialog8.Document = this.printDocument8;
                            printPreviewDialog8.FormBorderStyle = FormBorderStyle.Fixed3D;
                            printPreviewDialog8.SetBounds(20, 20, this.Width, this.Height);
                            printPreviewDialog8.ShowDialog();
                            printDocument8.Print();
                        }
                        else
                        {

                            if (dataGridView1.Rows.Count <= 22  && dataGridView1.Rows.Count != 0 )  // ==صفحة واحدة
                            {
                                PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                                printPreviewDialog1.Document = this.printDocument1;
                                printPreviewDialog1.FormBorderStyle = FormBorderStyle.Fixed3D;
                                printPreviewDialog1.SetBounds(20, 20, this.Width, this.Height);
                                printPreviewDialog1.ShowDialog();
                                printDocument1.Print();
                            }
                            else
                            {

                                //DialogResult result3;
                                //result3 = MessageBox.Show("لا يمكن الطباعه تخطي الحد الاقصي من الادوية", " warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                //PrintPreviewDialog printPreviewDialog2 = new PrintPreviewDialog();
                                //printPreviewDialog2.Document = this.printDocument2;
                                //printPreviewDialog2.FormBorderStyle = FormBorderStyle.Fixed3D;
                                //printPreviewDialog1.SetBounds(20, 20, this.Width, this.Height );
                                //printPreviewDialog2.ShowDialog();

                                //printDocument2.Print();

                                //PrintPreviewDialog printPreviewDialog3 = new PrintPreviewDialog();
                                //printPreviewDialog3.Document = this.printDocument3;
                                //printPreviewDialog3.FormBorderStyle = FormBorderStyle.Fixed3D;
                                //printPreviewDialog1.SetBounds(20, 20, this.Width, this.Height);
                                //printPreviewDialog3.ShowDialog();

                                //printDocument3.Print();

                            }


                        }


                    }

                if (dataGridView_XRay.Rows.Count > 0  && dataGridView_Test.Rows.Count > 0 && dataGridView_Test.Rows.Count != 0 && dataGridView_XRay.Rows.Count != 0)
                {
                    PrintPreviewDialog printPreviewDialog9 = new PrintPreviewDialog();
                    printPreviewDialog9.Document = this.printDocument9;
                    printPreviewDialog9.FormBorderStyle = FormBorderStyle.Fixed3D;
                    printPreviewDialog9.SetBounds(20, 20, this.Width, this.Height);
                    printPreviewDialog9.ShowDialog();
                    printDocument9.Print();

                }
                else
                {
                    if (dataGridView_XRay.Rows.Count > 0 && dataGridView1.Rows.Count == 0 )  // ==صفحة أشعة
                    {
                        PrintPreviewDialog printPreviewDialog4 = new PrintPreviewDialog();
                        printPreviewDialog4.Document = this.printDocument4;
                        printPreviewDialog4.FormBorderStyle = FormBorderStyle.Fixed3D;
                        //printPreviewDialog1.SetBounds(20, 20, this.Width, this.Height);
                        printPreviewDialog4.ShowDialog();

                        printDocument4.Print();
                    }
                    else
                    {
                        if (dataGridView_Test.Rows.Count > 0 && dataGridView1.Rows.Count == 0)  // ==صفحة تحاليل
                        {
                            PrintPreviewDialog printPreviewDialog5 = new PrintPreviewDialog();
                            printPreviewDialog5.Document = this.printDocument5;
                            printPreviewDialog5.FormBorderStyle = FormBorderStyle.Fixed3D;
                            ////printPreviewDialog1.SetBounds(20, 20, this.Width, this.Height);
                            printPreviewDialog5.ShowDialog();

                            printDocument5.Print();
                        }
                    }

                }
            }
            //=================================

           

            
                
            


        }
        //===========================
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Image = new Bitmap(Image.png, new Size(227, 171));
            //e.Graphics.DrawImage(Properties.Resources.rosta, 49, 0, 700, 935);
            //=========
            #region Kasf Print
            //=================================        
            float yPos = 20;
            int leftMargin = 15;
            // Pen pen = new Pen(Brushes.Black);

            //e.HasMorePages =true;
            // pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            //Font printFont4d = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
            //Font printFont = new System.Drawing.Font("Times New Roman", 14);
            //Font printFont11 = new System.Drawing.Font("Times New Roman", 16);
            //Font printFontFoorer = new System.Drawing.Font("Times New Roman", 12);
            //Font printFontheader_DRName = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);
            //------
            string medicn, Gruaa, MedcinWay, way;

            Font PatientFontheader = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);

            Font PatientNormal = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            Font patientNormal2 = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            //======================================                      

            yPos += 380;
            //e.Graphics.DrawString("Medcin Name", patientNormal2, Brushes.Black, leftMargin + 80, 360, new StringFormat());
            //e.Graphics.DrawString("Medcin Way", patientNormal2, Brushes.Black, leftMargin + 450, 360, new StringFormat());
            //e.Graphics.DrawString("Medcin Gruaa", patientNormal2, Brushes.Black, leftMargin + 570, 360, new StringFormat());


            e.Graphics.DrawString(txt_Name.Text, PatientFontheader, Brushes.Black, leftMargin + 280, 222, new StringFormat());

            //e.Graphics.DrawString("Code", PatientFontheader, Brushes.Black, leftMargin + 475, yPos, new StringFormat());

            //e.Graphics.DrawString(": " + txt_code.Text, PatientFontheader, Brushes.Black, leftMargin + 525, yPos, new StringFormat());
            yPos += 25;

            e.Graphics.DrawString("Patient Diagnosis: " + txt_Diagnosis.Text, PatientFontheader, Brushes.Black, leftMargin + 80, 320, new StringFormat());

            e.Graphics.DrawString("", PatientFontheader, Brushes.Black, leftMargin + 475, 20, new StringFormat());
            string KashfDate = displaydate(dateTimePicker1.Value);
            e.Graphics.DrawString(" " + KashfDate, PatientFontheader, Brushes.Black, leftMargin + 555, 222, new StringFormat());
            yPos += 5;
            //=========================  for adust right align 
            //SizeF stringSize = new SizeF();
            //stringSize = e.Graphics.MeasureString(way1, PatientNormal);

            //e.Graphics.DrawString(way1, PatientNormal, Brushes.Black, 500 - stringSize.Width, yPos);
            yPos -= 40;
            //==========================
            SizeF stringSize = new SizeF();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                medicn = dataGridView1.Rows[i].Cells[0].Value.ToString();
                Gruaa = dataGridView1.Rows[i].Cells[1].Value.ToString();
                MedcinWay = dataGridView1.Rows[i].Cells[2].Value.ToString();
                e.Graphics.DrawString(medicn.ToUpper(), PatientNormal, Brushes.Black, leftMargin + 80, yPos, new StringFormat());
                yPos += 1;
                way = "   " + Gruaa + "    " + MedcinWay;
                stringSize = e.Graphics.MeasureString(way, PatientNormal);
                e.Graphics.DrawString(way, PatientNormal, Brushes.Black, 680 - stringSize.Width, yPos);
                yPos += 20;
            }
            #endregion
            //===========
        }
        //====================
        private void txt_Test_KeyDown(object sender, KeyEventArgs e)
        {
            //==========================
            if (e.KeyCode == Keys.Enter)
            {

                bt_down_Test.PerformClick();

            }

            //=================

        }
        //====================
        private void bt_down_Test_Click(object sender, EventArgs e)
        {
            if (Search_Test())
            {
                dataGridView_Test.Rows.Add(GetSetTestID, txt_Test.Text);
            }
            else
            {
                DialogResult result3;
                result3 = MessageBox.Show("هذا التحليل غير مسجل هل تريد تسجيله", " warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result3 == DialogResult.Yes)
                {
                    insertItem_Test();
                    Search_Test();
                    dataGridView_Test.Rows.Add(GetSetTestID, txt_Test.Text);
                    AutocompleteText_Test();

                }
                else
                    return;
                //////////////////////
            }
            txt_Test.Text = "";
        }

        private void txt_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            //---------------------
            if (e.KeyChar == 13 && txt_code.Text != null&&txt_code.Text!="")
            {
                
                //==========================      GetMarkaId(cmb_Marka.Text)

                int result3;
                if (int.TryParse(txt_code.Text, out result3) == false)
                {
                    MessageBox.Show(" من فضلك أدخل البيانات بصورة صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_code.Focus();
                    return;
                }
                //***************

                int PatiantId = int.Parse(txt_code.Text);
                Search_Patient_COde(PatiantId);

                txt_Diagnosis.Focus();
            }
            //---------------------------
        }
        //===================
        private void button2_Click(object sender, EventArgs e)
        {

            if (Search_Patient_Name() == false)
            {
                MessageBox.Show(" من فضلك قم بإختيار مريض", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Name.Focus();
                return;
            }
            oldPatientKashf oldPatientKashf1 = new oldPatientKashf();
            oldPatientKashf1.GetSetPatiantId = GetSetPatiantId;
            oldPatientKashf1.ShowDialog();
        }

        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Image = new Bitmap(Image.png, new Size(227, 171));
            e.Graphics.DrawImage(Properties.Resources.rosta, 49, 0, 700, 935);
            //=========
            #region Kasf Print
            //=================================        
            float yPos = 20;
            int leftMargin = 15;
            // Pen pen = new Pen(Brushes.Black);

            //e.HasMorePages =true;
            // pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            //Font printFont4d = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
            //Font printFont = new System.Drawing.Font("Times New Roman", 14);
            //Font printFont11 = new System.Drawing.Font("Times New Roman", 16);
            //Font printFontFoorer = new System.Drawing.Font("Times New Roman", 12);
            //Font printFontheader_DRName = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);
            //------
            string medicn, Gruaa, MedcinWay, way;

            Font PatientFontheader = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);

            Font PatientNormal = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            Font patientNormal2 = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            //======================================                      

            yPos += 380;
            e.Graphics.DrawString("Medcin Name", patientNormal2, Brushes.Black, leftMargin + 80, 360, new StringFormat());
            e.Graphics.DrawString("Medcin Way", patientNormal2, Brushes.Black, leftMargin + 450, 360, new StringFormat());
            e.Graphics.DrawString("Medcin Gruaa", patientNormal2, Brushes.Black, leftMargin + 570, 360, new StringFormat());


            e.Graphics.DrawString(txt_Name.Text, PatientFontheader, Brushes.Black, leftMargin + 280, 262, new StringFormat());

            //e.Graphics.DrawString("Code", PatientFontheader, Brushes.Black, leftMargin + 475, yPos, new StringFormat());

            //e.Graphics.DrawString(": " + txt_code.Text, PatientFontheader, Brushes.Black, leftMargin + 525, yPos, new StringFormat());
            yPos += 25;

            e.Graphics.DrawString("Patient Diagnosis: " + txt_Diagnosis.Text, PatientFontheader, Brushes.Black, leftMargin + 80, 320, new StringFormat());

            e.Graphics.DrawString("", PatientFontheader, Brushes.Black, leftMargin + 475, 20, new StringFormat());
            string KashfDate = displaydate(dateTimePicker1.Value);
            e.Graphics.DrawString(" " + KashfDate, PatientFontheader, Brushes.Black, leftMargin + 555, 262, new StringFormat());
            yPos += 5;
            //=========================  for adust right align 
            //SizeF stringSize = new SizeF();
            //stringSize = e.Graphics.MeasureString(way1, PatientNormal);

            //e.Graphics.DrawString(way1, PatientNormal, Brushes.Black, 500 - stringSize.Width, yPos);
            yPos -= 40;
            //==========================
            SizeF stringSize = new SizeF();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                medicn = dataGridView1.Rows[i].Cells[0].Value.ToString();
                Gruaa = dataGridView1.Rows[i].Cells[1].Value.ToString();
                MedcinWay = dataGridView1.Rows[i].Cells[2].Value.ToString();
                e.Graphics.DrawString(medicn.ToUpper(), PatientNormal, Brushes.Black, leftMargin + 80, yPos, new StringFormat());
                yPos += 1;
                way = "   " + Gruaa + "    " + MedcinWay;
                stringSize = e.Graphics.MeasureString(way, PatientNormal);
                e.Graphics.DrawString(way, PatientNormal, Brushes.Black, 680 - stringSize.Width, yPos);
                yPos += 20;
            }
            #endregion
            //===========
        }
        //================
        private void printDocument4_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.rosta, 49, 0, 700, 935);
            //=========
            #region Xray Print
            //=================================        
            float yPos = 8;
            int leftMargin = 15;
            // Pen pen = new Pen(Brushes.Black);

            //e.HasMorePages =true;
            // pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            //Font printFont4d = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
            //Font printFont = new System.Drawing.Font("Times New Roman", 14);
            //Font printFont11 = new System.Drawing.Font("Times New Roman", 16);
            //Font printFontFoorer = new System.Drawing.Font("Times New Roman", 12);
            //Font printFontheader_DRName = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);
            //------
            string xray;

            Font PatientFontheader = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);

            Font PatientNormal = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            Font PatientNormal1 = new System.Drawing.Font("Arial",12, FontStyle.Bold);
            //======================================                      

            //======================================                      

            //e.Graphics.DrawString("Code", PatientFontheader, Brushes.Black, leftMargin + 475, yPos, new StringFormat());
            //e.Graphics.DrawString(": " + txt_code.Text, PatientFontheader, Brushes.Black, leftMargin + 525, yPos, new StringFormat());
            //e.Graphics.DrawString(txt_Diagnosis.Text, PatientFontheader, Brushes.Black, leftMargin + 210, yPos, new StringFormat());
            //e.Graphics.DrawString("Date", PatientFontheader, Brushes.Black, leftMargin + 475, yPos, new StringFormat());
            yPos += 360;
            e.Graphics.DrawString("اشاعة", PatientNormal1, Brushes.Black, leftMargin + 400, yPos, new StringFormat());
            e.Graphics.DrawString(txt_Name.Text, PatientFontheader, Brushes.Black, leftMargin + 280, 262, new StringFormat());
            yPos += 25;

            e.Graphics.DrawString("Patient Diagnosis: " + txt_Diagnosis.Text, PatientFontheader, Brushes.Black, leftMargin + 80, 320, new StringFormat());

            e.Graphics.DrawString("", PatientFontheader, Brushes.Black, leftMargin + 475, 20, new StringFormat());
            string KashfDate = displaydate(dateTimePicker1.Value);
            e.Graphics.DrawString(" " + KashfDate, PatientFontheader, Brushes.Black, leftMargin + 555, 262, new StringFormat());
            //yPos += 5;
            //=========================  

            yPos += 30;
            for (int i = 0; i < dataGridView_XRay.Rows.Count; i++)
            {
                xray = dataGridView_XRay.Rows[i].Cells[1].Value.ToString();

                e.Graphics.DrawString(xray.ToUpper(), PatientNormal, Brushes.Black, leftMargin + 80, yPos, new StringFormat());



                yPos += 30;


            }



            #endregion
            //===========  
        }
        //=======================
        private void printDocument5_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.rosta, 49, 0, 700, 935);
            //=========
            #region Test Print
            //=================================        
            float yPos = 8;
            int leftMargin = 15;

            string Test;

            Font PatientFontheader = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);

            Font PatientNormal = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            Font PatientNormal1 = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            //======================================                      

            //======================================
            yPos += 360;
            e.Graphics.DrawString("تحاليل", PatientNormal1, Brushes.Black, leftMargin + 400, yPos, new StringFormat());
            e.Graphics.DrawString(txt_Name.Text, PatientFontheader, Brushes.Black, leftMargin + 280, 262, new StringFormat());
            yPos += 25;

            e.Graphics.DrawString("Patient Diagnosis: " + txt_Diagnosis.Text, PatientFontheader, Brushes.Black, leftMargin + 80, 320, new StringFormat());

            e.Graphics.DrawString("", PatientFontheader, Brushes.Black, leftMargin + 475, 20, new StringFormat());
            string KashfDate = displaydate(dateTimePicker1.Value);
            e.Graphics.DrawString(" " + KashfDate, PatientFontheader, Brushes.Black, leftMargin + 555, 262, new StringFormat());
            yPos += 5;

            //e.Graphics.DrawString(txt_Name.Text, PatientFontheader, Brushes.Black, leftMargin + 190, yPos, new StringFormat());

            //e.Graphics.DrawString("Code", PatientFontheader, Brushes.Black, leftMargin + 475, yPos, new StringFormat());

            //e.Graphics.DrawString(": " + txt_code.Text, PatientFontheader, Brushes.Black, leftMargin + 525, yPos, new StringFormat());


            //e.Graphics.DrawString(txt_Diagnosis.Text, PatientFontheader, Brushes.Black, leftMargin + 210, yPos, new StringFormat());

            //e.Graphics.DrawString("Date", PatientFontheader, Brushes.Black, leftMargin + 475, yPos, new StringFormat());

            //string KashfDate = displaydate(dateTimePicker1.Value);

            //e.Graphics.DrawString(" " + KashfDate, PatientFontheader, Brushes.Black, leftMargin + 525, yPos, new StringFormat());

            //=========================
            yPos += 30;

            for (int i = 0; i < dataGridView_Test.Rows.Count; i++)
            {
                Test = dataGridView_Test.Rows[i].Cells[1].Value.ToString();

                e.Graphics.DrawString(Test.ToUpper(), PatientNormal, Brushes.Black, leftMargin + 80, yPos, new StringFormat());
                yPos += 30;
            }



            #endregion
            //=========== 
        }

        //-------------------------------
        private void txt_Medcin_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            //---------------------
            if (e.KeyChar == 13 && txt_Medcin_Code.Text != null && txt_Medcin_Code.Text != "")
            {

                //==========================      GetMarkaId(cmb_Marka.Text)

                int result3;
                if (int.TryParse(txt_Medcin_Code.Text, out result3) == false)
                {
                    MessageBox.Show(" من فضلك أدخل البيانات بصورة صحيحة", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Medcin_Code.Focus();
                    return;
                }
                //***************

                int Id = int.Parse(txt_Medcin_Code.Text);
                Search_MedcinID(Id);

                txt_MedcineType.Text = Search_MedcinType(GetSetMedcinTypeID);

                txt_MedcineType.Focus();

            }
            //---------------------------
        }

        private void printDocument6_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.rosta, 49, 0, 700, 935);


            //=========
            #region Kasf Print
            //=================================        
            float yPos = 20;
            int leftMargin = 15;
            // Pen pen = new Pen(Brushes.Black);

            //e.HasMorePages =true;
            // pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            //Font printFont4d = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
            //Font printFont = new System.Drawing.Font("Times New Roman", 14);
            //Font printFont11 = new System.Drawing.Font("Times New Roman", 16);
            //Font printFontFoorer = new System.Drawing.Font("Times New Roman", 12);
            //Font printFontheader_DRName = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);
            //------
            string medicn, Gruaa, MedcinWay, way;

            Font PatientFontheader = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);

            Font PatientNormal = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            Font PatientNormal1 = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            Font patientNormal2 = new System.Drawing.Font("Black", 12, FontStyle.Bold);
            //======================================                      

            yPos += 380;
           // e.Graphics.DrawString("Medcin Name", patientNormal2, Brushes.Black, leftMargin + 80, 360, new StringFormat());
           // e.Graphics.DrawString("Medcin Way", patientNormal2, Brushes.Black, leftMargin + 450, 360, new StringFormat());
            //e.Graphics.DrawString("Medcin Gruaa", patientNormal2, Brushes.Black, leftMargin + 570, 360, new StringFormat());
            




            e.Graphics.DrawString(txt_Name.Text, PatientFontheader, Brushes.Black, leftMargin + 280, 262, new StringFormat());
            
            //e.Graphics.DrawString("Code", PatientFontheader, Brushes.Black, leftMargin + 475, yPos, new StringFormat());

            //e.Graphics.DrawString(": " + txt_code.Text, PatientFontheader, Brushes.Black, leftMargin + 525, yPos, new StringFormat());
            yPos += 25;

            e.Graphics.DrawString("Patient Diagnosis: " + txt_Diagnosis.Text, PatientFontheader, Brushes.Black, leftMargin + 80, 320, new StringFormat());

            e.Graphics.DrawString("", PatientFontheader, Brushes.Black, leftMargin + 475, 20, new StringFormat());
            string KashfDate = displaydate(dateTimePicker1.Value);
            e.Graphics.DrawString(" " + KashfDate, PatientFontheader, Brushes.Black, leftMargin + 555, 262, new StringFormat());
            yPos += 5; 
            //=========================  for adust right align 
            //SizeF stringSize = new SizeF();
            //stringSize = e.Graphics.MeasureString(way1, PatientNormal);

            //e.Graphics.DrawString(way1, PatientNormal, Brushes.Black, 500 - stringSize.Width, yPos);
            yPos -= 40;
            //==========================
            SizeF stringSize = new SizeF();
            string Test;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                medicn = dataGridView1.Rows[i].Cells[0].Value.ToString();
                Gruaa = dataGridView1.Rows[i].Cells[1].Value.ToString();
                MedcinWay = dataGridView1.Rows[i].Cells[2].Value.ToString();
                e.Graphics.DrawString(medicn.ToUpper(), PatientNormal, Brushes.Black, leftMargin + 80, yPos, new StringFormat());
                yPos += 1;
                way = "   " + Gruaa + "    " + MedcinWay;
                stringSize = e.Graphics.MeasureString(way, PatientNormal);
                e.Graphics.DrawString(way, PatientNormal, Brushes.Black, 680 - stringSize.Width, yPos);
                yPos += 20;
            }
            yPos += 30;
            e.Graphics.DrawString("اشاعه", PatientNormal1, Brushes.Black, leftMargin + 80, yPos, new StringFormat());
            e.Graphics.DrawString("تحاليل", PatientNormal1, Brushes.Black, leftMargin + 550, yPos, new StringFormat());
            yPos += 20;
            for (int i = 0; i < dataGridView_Test.Rows.Count; i++)
            {
                Test = dataGridView_Test.Rows[i].Cells[1].Value.ToString();

                e.Graphics.DrawString(Test.ToUpper(), PatientNormal, Brushes.Black, leftMargin + 550, yPos, new StringFormat());
                yPos += 20;
            }
               yPos -=23;
                string xray;
             for (int i = 0; i < dataGridView_XRay.Rows.Count; i++)
            {
                xray = dataGridView_XRay.Rows[i].Cells[1].Value.ToString();

                e.Graphics.DrawString(xray.ToUpper(), PatientNormal, Brushes.Black, leftMargin + 80 , yPos, new StringFormat());

                yPos +=20;


            }





            #endregion
            //===========









        }

        private void printPreviewDialog6_Load(object sender, EventArgs e)
        {

        }

        private void printDocument7_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.rosta, 49, 0, 700, 935);

            //=========
            #region Kasf Print
            //=================================        
            float yPos = 20;
            int leftMargin = 15;
            // Pen pen = new Pen(Brushes.Black);

            //e.HasMorePages =true;
            // pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            //Font printFont4d = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
            //Font printFont = new System.Drawing.Font("Times New Roman", 14);
            //Font printFont11 = new System.Drawing.Font("Times New Roman", 16);
            //Font printFontFoorer = new System.Drawing.Font("Times New Roman", 12);
            //Font printFontheader_DRName = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);
            //------
            string medicn, Gruaa, MedcinWay, way;

            Font PatientFontheader = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);

            Font PatientNormal = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            Font PatientNormal1 = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            Font patientNormal2 = new System.Drawing.Font("Black", 12, FontStyle.Bold);
            //======================================                      

            yPos += 380;
            //e.Graphics.DrawString("Medcin Name", patientNormal2, Brushes.Black, leftMargin + 80, 360, new StringFormat());
            //e.Graphics.DrawString("Medcin Way", patientNormal2, Brushes.Black, leftMargin + 450, 360, new StringFormat());
            //e.Graphics.DrawString("Medcin Gruaa", patientNormal2, Brushes.Black, leftMargin + 570, 360, new StringFormat());
            




            e.Graphics.DrawString(txt_Name.Text, PatientFontheader, Brushes.Black, leftMargin + 280, 262, new StringFormat());

            //e.Graphics.DrawString("Code", PatientFontheader, Brushes.Black, leftMargin + 475, yPos, new StringFormat());

            //e.Graphics.DrawString(": " + txt_code.Text, PatientFontheader, Brushes.Black, leftMargin + 525, yPos, new StringFormat());
            yPos += 25;

            e.Graphics.DrawString("Patient Diagnosis: " + txt_Diagnosis.Text, PatientFontheader, Brushes.Black, leftMargin + 80, 320, new StringFormat());

            e.Graphics.DrawString("", PatientFontheader, Brushes.Black, leftMargin + 475, 20, new StringFormat());
            string KashfDate = displaydate(dateTimePicker1.Value);
            e.Graphics.DrawString(" " + KashfDate, PatientFontheader, Brushes.Black, leftMargin + 555, 262, new StringFormat());
            yPos += 5;
            //=========================  for adust right align 
            //SizeF stringSize = new SizeF();
            //stringSize = e.Graphics.MeasureString(way1, PatientNormal);

            //e.Graphics.DrawString(way1, PatientNormal, Brushes.Black, 500 - stringSize.Width, yPos);
            yPos -= 40;
            //==========================
            SizeF stringSize = new SizeF();
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                medicn = dataGridView1.Rows[i].Cells[0].Value.ToString();
                Gruaa = dataGridView1.Rows[i].Cells[1].Value.ToString();
                MedcinWay = dataGridView1.Rows[i].Cells[2].Value.ToString();
                e.Graphics.DrawString(medicn.ToUpper(), PatientNormal, Brushes.Black, leftMargin + 80, yPos, new StringFormat());
                yPos += 1;
                way = "   " + Gruaa + "    " + MedcinWay;
                stringSize = e.Graphics.MeasureString(way, PatientNormal);
                e.Graphics.DrawString(way, PatientNormal, Brushes.Black, 680 - stringSize.Width, yPos);
                yPos += 20;
            }
            yPos += 30;
            e.Graphics.DrawString("اشاعه", PatientNormal1, Brushes.Black, leftMargin + 400, yPos, new StringFormat());
            yPos +=30;

            string xray;
             for (int i = 0; i < dataGridView_XRay.Rows.Count; i++)
            {
                xray = dataGridView_XRay.Rows[i].Cells[1].Value.ToString();

                e.Graphics.DrawString(xray.ToUpper(), PatientNormal, Brushes.Black, leftMargin + 80 , yPos, new StringFormat());
                yPos += 20;


            }






            #endregion
            //===========









        }

        private void printDocument8_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.rosta, 49, 0, 700, 935);

            //=========
            #region Kasf Print
            //=================================        
            float yPos = 20;
            int leftMargin = 15;
            // Pen pen = new Pen(Brushes.Black);

            //e.HasMorePages =true;
            // pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            //Font printFont4d = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
            //Font printFont = new System.Drawing.Font("Times New Roman", 14);
            //Font printFont11 = new System.Drawing.Font("Times New Roman", 16);
            //Font printFontFoorer = new System.Drawing.Font("Times New Roman", 12);
            //Font printFontheader_DRName = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);
            //------
            string medicn, Gruaa, MedcinWay, way;

            Font PatientFontheader = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);

            Font PatientNormal = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            Font PatientNormal1 = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            Font patientNormal2 = new System.Drawing.Font("Black", 12, FontStyle.Bold);
            //======================================                      

            yPos += 380;
            //e.Graphics.DrawString("Medcin Name", patientNormal2, Brushes.Black, leftMargin + 80, 360, new StringFormat());
            //e.Graphics.DrawString("Medcin Way", patientNormal2, Brushes.Black, leftMargin + 450, 360, new StringFormat());
            //e.Graphics.DrawString("Medcin Gruaa", patientNormal2, Brushes.Black, leftMargin + 570, 360, new StringFormat());
            



            e.Graphics.DrawString(txt_Name.Text, PatientFontheader, Brushes.Black, leftMargin + 280, 262, new StringFormat());

            //e.Graphics.DrawString("Code", PatientFontheader, Brushes.Black, leftMargin + 475, yPos, new StringFormat());

            //e.Graphics.DrawString(": " + txt_code.Text, PatientFontheader, Brushes.Black, leftMargin + 525, yPos, new StringFormat());
            yPos += 25;

            e.Graphics.DrawString("Patient Diagnosis: " + txt_Diagnosis.Text, PatientFontheader, Brushes.Black, leftMargin + 80, 320, new StringFormat());

            e.Graphics.DrawString("", PatientFontheader, Brushes.Black, leftMargin + 475, 20, new StringFormat());
            string KashfDate = displaydate(dateTimePicker1.Value);
            e.Graphics.DrawString(" " + KashfDate, PatientFontheader, Brushes.Black, leftMargin + 555, 262, new StringFormat());
            yPos += 5;
            //=========================  for adust right align 
            //SizeF stringSize = new SizeF();
            //stringSize = e.Graphics.MeasureString(way1, PatientNormal);

            //e.Graphics.DrawString(way1, PatientNormal, Brushes.Black, 500 - stringSize.Width, yPos);
            yPos -= 30;
            //==========================
            SizeF stringSize = new SizeF();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                medicn = dataGridView1.Rows[i].Cells[0].Value.ToString();
                Gruaa = dataGridView1.Rows[i].Cells[1].Value.ToString();
                MedcinWay = dataGridView1.Rows[i].Cells[2].Value.ToString();
                e.Graphics.DrawString(medicn.ToUpper(), PatientNormal, Brushes.Black, leftMargin + 80, yPos, new StringFormat());
                yPos += 1;
                way = "   " + Gruaa + "    " + MedcinWay;
                stringSize = e.Graphics.MeasureString(way, PatientNormal);
                e.Graphics.DrawString(way, PatientNormal, Brushes.Black, 680 - stringSize.Width, yPos);
                yPos += 20;
            }
            yPos += 30;
            e.Graphics.DrawString("تحاليل", PatientNormal1, Brushes.Black, leftMargin + 400, yPos, new StringFormat());

            yPos += 30;
            string Test;
            for (int i = 0; i < dataGridView_Test.Rows.Count; i++)
            {
                Test = dataGridView_Test.Rows[i].Cells[1].Value.ToString();

                e.Graphics.DrawString(Test.ToUpper(), PatientNormal, Brushes.Black, leftMargin + 80, yPos, new StringFormat());
                yPos += 20;
            }





            #endregion
            //===========









        }

        private void printDocument9_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.rosta, 49, 0, 700, 935);

            //=========
            #region Kasf Print
            //=================================        
            float yPos = 20;
            int leftMargin = 15;
            // Pen pen = new Pen(Brushes.Black);

            //e.HasMorePages =true;
            // pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            //Font printFont4d = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
            //Font printFont = new System.Drawing.Font("Times New Roman", 14);
            //Font printFont11 = new System.Drawing.Font("Times New Roman", 16);
            //Font printFontFoorer = new System.Drawing.Font("Times New Roman", 12);
            //Font printFontheader_DRName = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);
            //------

            Font PatientFontheader = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);

            Font PatientNormal = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            Font PatientNormal1 = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            Font patientNormal2 = new System.Drawing.Font("Black", 12, FontStyle.Bold);
            //======================================                      

            yPos += 360;
            e.Graphics.DrawString("اشاعه", PatientNormal1, Brushes.Black, leftMargin + 80, yPos, new StringFormat());
            e.Graphics.DrawString("تحاليل", PatientNormal1, Brushes.Black, leftMargin + 550, yPos, new StringFormat());



            e.Graphics.DrawString(txt_Name.Text, PatientFontheader, Brushes.Black, leftMargin + 280, 262, new StringFormat());

            //e.Graphics.DrawString("Code", PatientFontheader, Brushes.Black, leftMargin + 475, yPos, new StringFormat());

            //e.Graphics.DrawString(": " + txt_code.Text, PatientFontheader, Brushes.Black, leftMargin + 525, yPos, new StringFormat());
            yPos += 25;

            e.Graphics.DrawString("Patient Diagnosis: " + txt_Diagnosis.Text, PatientFontheader, Brushes.Black, leftMargin + 80, 320, new StringFormat());

            e.Graphics.DrawString("", PatientFontheader, Brushes.Black, leftMargin + 475, 20, new StringFormat());
            string KashfDate = displaydate(dateTimePicker1.Value);
            e.Graphics.DrawString(" " + KashfDate, PatientFontheader, Brushes.Black, leftMargin + 555, 262, new StringFormat());
            yPos += 5;
            //=========================  for adust right align 
            //SizeF stringSize = new SizeF();
            //stringSize = e.Graphics.MeasureString(way1, PatientNormal);

            //e.Graphics.DrawString(way1, PatientNormal, Brushes.Black, 500 - stringSize.Width, yPos);
            //yPos += 70;
            //==========================
            yPos -=5;
            string Test;
            for (int n = 0; n < dataGridView_Test.Rows.Count; n++) // تحليل
            {
                Test = dataGridView_Test.Rows[n].Cells[1].Value.ToString();

                e.Graphics.DrawString(Test.ToUpper(), PatientNormal, Brushes.Black, leftMargin + 550, yPos, new StringFormat());
                yPos += 30;
            }
            yPos -=23;
            string xray;
            for (int i = 0; i < dataGridView_XRay.Rows.Count; i++)
            {
                xray = dataGridView_XRay.Rows[i].Cells[1].Value.ToString();

                e.Graphics.DrawString(xray.ToUpper(), PatientNormal, Brushes.Black, leftMargin + 80, yPos, new StringFormat());



                yPos += 30;


            }




            #endregion
            //===========









        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //get the index of the selected row in datagridview
            //and delete a row from datatable
            //and bind the datagridview with datatable
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //get the index of the selected row in datagridview
            //and delete a row from datatable
            //and bind the datagridview with datatable
            int rowIndex = dataGridView_XRay.CurrentCell.RowIndex;
            dataGridView_XRay.Rows.RemoveAt(rowIndex);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //get the index of the selected row in datagridview
            //and delete a row from datatable
            //and bind the datagridview with datatable
            int rowIndex = dataGridView_Test.CurrentCell.RowIndex;
            dataGridView_Test.Rows.RemoveAt(rowIndex);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //if(printDialog1.ShowDialog()== DialogResult.OK)
            //{
            //printDocument1.Print();
            //}

            toolStrip_Save.PerformClick();
            //======================
            if (dataGridView1.Rows.Count <= 22 && dataGridView1.Rows.Count != 0 && dataGridView_XRay.Rows.Count > 0 && dataGridView_Test.Rows.Count > 0)  // ==صفحة واحدة
            {
                PrintPreviewDialog printPreviewDialog6 = new PrintPreviewDialog();
                printPreviewDialog6.Document = this.printDocument6;
                printPreviewDialog6.FormBorderStyle = FormBorderStyle.Fixed3D;
                printPreviewDialog6.SetBounds(20, 20, this.Width, this.Height);
                printPreviewDialog6.ShowDialog();


                printDocument6.Print();

            }


            else
            {
                if (dataGridView1.Rows.Count <= 22 && dataGridView1.Rows.Count != 0 && dataGridView_XRay.Rows.Count > 0)  // ==صفحة واحدة
                {

                    PrintPreviewDialog printPreviewDialog7 = new PrintPreviewDialog();
                    printPreviewDialog7.Document = this.printDocument7;
                    printPreviewDialog7.FormBorderStyle = FormBorderStyle.Fixed3D;
                    printPreviewDialog7.SetBounds(20, 20, this.Width, this.Height);
                    printPreviewDialog7.ShowDialog();
                    printDocument7.Print();

                }
                else
                {
                    if (dataGridView1.Rows.Count <= 22 && dataGridView1.Rows.Count != 0 && dataGridView_Test.Rows.Count > 0)  // ==صفحة واحدة
                    {
                        PrintPreviewDialog printPreviewDialog8 = new PrintPreviewDialog();
                        printPreviewDialog8.Document = this.printDocument8;
                        printPreviewDialog8.FormBorderStyle = FormBorderStyle.Fixed3D;
                        printPreviewDialog8.SetBounds(20, 20, this.Width, this.Height);
                        printPreviewDialog8.ShowDialog();
                        printDocument8.Print();
                    }
                    else
                    {

                        if (dataGridView1.Rows.Count <= 22 && dataGridView1.Rows.Count != 0)  // ==صفحة واحدة
                        {
                            PrintPreviewDialog printPreviewDialog10 = new PrintPreviewDialog();
                            printPreviewDialog10.Document = this.printDocument10;
                            printPreviewDialog10.FormBorderStyle = FormBorderStyle.Fixed3D;
                            printPreviewDialog10.SetBounds(20, 20, this.Width, this.Height);
                            printPreviewDialog10.ShowDialog();
                            printDocument10.Print();
                        }
                        else
                        {

                            //DialogResult result3;
                            //result3 = MessageBox.Show("لا يمكن الطباعه تخطي الحد الاقصي من الادوية", " warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            //PrintPreviewDialog printPreviewDialog2 = new PrintPreviewDialog();
                            //printPreviewDialog2.Document = this.printDocument2;
                            //printPreviewDialog2.FormBorderStyle = FormBorderStyle.Fixed3D;
                            //printPreviewDialog1.SetBounds(20, 20, this.Width, this.Height );
                            //printPreviewDialog2.ShowDialog();

                            //printDocument2.Print();

                            //PrintPreviewDialog printPreviewDialog3 = new PrintPreviewDialog();
                            //printPreviewDialog3.Document = this.printDocument3;
                            //printPreviewDialog3.FormBorderStyle = FormBorderStyle.Fixed3D;
                            //printPreviewDialog1.SetBounds(20, 20, this.Width, this.Height);
                            //printPreviewDialog3.ShowDialog();

                            //printDocument3.Print();

                        }


                    }


                }

                if (dataGridView_XRay.Rows.Count > 0 && dataGridView_Test.Rows.Count > 0 && dataGridView_Test.Rows.Count != 0 && dataGridView_XRay.Rows.Count != 0)
                {
                    PrintPreviewDialog printPreviewDialog9 = new PrintPreviewDialog();
                    printPreviewDialog9.Document = this.printDocument9;
                    printPreviewDialog9.FormBorderStyle = FormBorderStyle.Fixed3D;
                    printPreviewDialog9.SetBounds(20, 20, this.Width, this.Height);
                    printPreviewDialog9.ShowDialog();
                    printDocument9.Print();

                }
                else
                {
                    if (dataGridView_XRay.Rows.Count > 0 && dataGridView1.Rows.Count == 0)  // ==صفحة أشعة
                    {
                        PrintPreviewDialog printPreviewDialog4 = new PrintPreviewDialog();
                        printPreviewDialog4.Document = this.printDocument4;
                        printPreviewDialog4.FormBorderStyle = FormBorderStyle.Fixed3D;
                        //printPreviewDialog1.SetBounds(20, 20, this.Width, this.Height);
                        printPreviewDialog4.ShowDialog();

                        printDocument4.Print();
                    }
                    else
                    {
                        if (dataGridView_Test.Rows.Count > 0 && dataGridView1.Rows.Count == 0)  // ==صفحة تحاليل
                        {
                            PrintPreviewDialog printPreviewDialog5 = new PrintPreviewDialog();
                            printPreviewDialog5.Document = this.printDocument5;
                            printPreviewDialog5.FormBorderStyle = FormBorderStyle.Fixed3D;
                            ////printPreviewDialog1.SetBounds(20, 20, this.Width, this.Height);
                            printPreviewDialog5.ShowDialog();

                            printDocument5.Print();
                        }
                    }

                }
            }
        }

        private void printDocument10_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Image = new Bitmap(Image.png, new Size(227, 171));
            //e.Graphics.DrawImage(Properties.Resources.rosa2, 49, 0, 700, 935);
            //=========
            #region Kasf Print
            //=================================        
            float yPos = 20;
            int leftMargin = 15;
            // Pen pen = new Pen(Brushes.Black);

            //e.HasMorePages =true;
            // pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            //Font printFont4d = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
            //Font printFont = new System.Drawing.Font("Times New Roman", 14);
            //Font printFont11 = new System.Drawing.Font("Times New Roman", 16);
            //Font printFontFoorer = new System.Drawing.Font("Times New Roman", 12);
            //Font printFontheader_DRName = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);
            //------
            string medicn, Gruaa, MedcinWay, way;

            Font PatientFontheader = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold);

            Font PatientNormal = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            Font patientNormal2 = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            //======================================                      

            yPos += 330;
            //e.Graphics.DrawString("Medcin Name", patientNormal2, Brushes.Black, leftMargin + 80, 360, new StringFormat());
            //e.Graphics.DrawString("Medcin Way", patientNormal2, Brushes.Black, leftMargin + 450, 360, new StringFormat());
            //e.Graphics.DrawString("Medcin Gruaa", patientNormal2, Brushes.Black, leftMargin + 570, 360, new StringFormat());


            e.Graphics.DrawString(txt_Name.Text, PatientFontheader, Brushes.Black, leftMargin + 220, 215, new StringFormat());

            //e.Graphics.DrawString("Code", PatientFontheader, Brushes.Black, leftMargin + 475, yPos, new StringFormat());

            //e.Graphics.DrawString(": " + txt_code.Text, PatientFontheader, Brushes.Black, leftMargin + 525, yPos, new StringFormat());
            yPos += 25;

            e.Graphics.DrawString("Patient Diagnosis: " + txt_Diagnosis.Text, PatientFontheader, Brushes.Black, leftMargin + 80, 280, new StringFormat());

            e.Graphics.DrawString("", PatientFontheader, Brushes.Black, leftMargin + 475, 20, new StringFormat());
            string KashfDate = displaydate(dateTimePicker1.Value);
            e.Graphics.DrawString(" " + KashfDate, PatientFontheader, Brushes.Black, leftMargin + 530, 212, new StringFormat());
            yPos += 5;
            //=========================  for adust right align 
            //SizeF stringSize = new SizeF();
            //stringSize = e.Graphics.MeasureString(way1, PatientNormal);

            //e.Graphics.DrawString(way1, PatientNormal, Brushes.Black, 500 - stringSize.Width, yPos);
            yPos -= 40;
            //==========================
            SizeF stringSize = new SizeF();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                medicn = dataGridView1.Rows[i].Cells[0].Value.ToString();
                Gruaa = dataGridView1.Rows[i].Cells[1].Value.ToString();
                MedcinWay = dataGridView1.Rows[i].Cells[2].Value.ToString();
                e.Graphics.DrawString(medicn.ToUpper(), PatientNormal, Brushes.Black, leftMargin + 80, yPos, new StringFormat());
                yPos += 1;
                way = "   " + Gruaa + "    " + MedcinWay;
                stringSize = e.Graphics.MeasureString(way, PatientNormal);
                e.Graphics.DrawString(way, PatientNormal, Brushes.Black, 680 - stringSize.Width, yPos);
                yPos += 20;
            }
            #endregion
            //===========
        }



        //======
    }
}
