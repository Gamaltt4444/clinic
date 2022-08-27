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
    public partial class HagzKashf : Form
    {
        //***********************
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTable dataTable;
        //===============       
        DateTime beginDate;
        //==================================       
        public string stringcon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=GenClinicDB;Data Source=.";
        //*********************************************************
        public string stringconPrint = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ZPrintDB;Data Source=.";
         //=========== for  customer
        public static string tempKashfFlage;
        public string GetSetKashfFlage
        {
            set { tempKashfFlage = value; }
            get { return tempKashfFlage; }
        }
        //==========
        //================================
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
        public HagzKashf()
        {
            InitializeComponent();
        }
        //==============================
     
       
        //==========================
     


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
        //================
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
        private void Searc_Order(DateTime begindate1)
        {
            string PatiantId, KashfDate, PatiantName, KashfFlageName, HagzNote, TaminName;
            bool  FinishFlage;

            dataGridView1.Rows.Clear();
            //======================

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Select_HagzOrder";
            //***********************  *************            
            SqlParameter param2 = new SqlParameter("@bigenDate", SqlDbType.DateTime);
            param2.Value = begindate1;
            param2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param2);
            //*************************** ********************
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
                
                //===============================
                return;
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {

                //========================
                DataRow selectedRow = dataTable.Rows[i];
                      
                int HagzOrderId = int.Parse(selectedRow["HagzOrderId"].ToString());
                PatiantId = selectedRow["PatiantId"].ToString();
                KashfDate = displaydate(Convert.ToDateTime(selectedRow["KashfDate"].ToString()));
                PatiantName = selectedRow["PatiantName"].ToString();
                KashfFlageName = selectedRow["KashfFlageName"].ToString();
                HagzNote = selectedRow["HagzNote"].ToString();
                TaminName = selectedRow["TaminName"].ToString();
                if (selectedRow["FinishFlage"].ToString() == "0")
                {
                    FinishFlage = false;
                }
                else
                {
                    FinishFlage = true ;
                }
                dataGridView1.Rows.Add(PatiantId, i + 1, PatiantName, PatiantId, TaminName, KashfFlageName, HagzNote, selectedRow["KashfFlage"].ToString(), HagzOrderId, FinishFlage);
                //====
                //----------- to color datagridview
                if (i % 2 == 0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }
                //-------------------
            }




           con.Close();con.Dispose();;



        }
        //==================================== 
       
        private string displaydate(DateTime dt)
        {
            string dd = dt.Date.Day.ToString();
            if (dd.Length == 1) dd = "0" + dd;
            string mm = dt.Date.Month.ToString();
            if (mm.Length == 1) mm = "0" + mm;
            string yyyy = dt.Date.Year.ToString();
            return (yyyy + "/" + mm + "/" + dd);
        }
        //=====================
    
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //--------------------
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }
           // int temid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int PatiantId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string tName = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string Tamin = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string Kasf_Estishara=dataGridView1.CurrentRow.Cells[5].Value.ToString();
            KashfHagz KashfHagz1 = new KashfHagz();          
            KashfHagz1.GetSetPatiant_flage = true;
            KashfHagz1.GetSetName = tName;
            KashfHagz1.GetSetPatiantId = PatiantId;
            KashfHagz1.GetSetTamin = Tamin;
            KashfHagz1.GetSetKash_isteshara = Kasf_Estishara;
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "")
            {
                KashfHagz1.GetSetNoteFlage = false ;
              
            }
            else
            {
                KashfHagz1.GetSetNoteFlage = true;
                KashfHagz1.GetSetNoteString = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }

            KashfHagz1.ShowDialog();
            //---------------
        }
        //==============================

        private void SumcodeGrid()
        {
            int kasf = 0, esteshara = 0, kasfGiar = 0, estesharaGiar = 0, Giar = 0;

            if (dataGridView1.Rows.Count != 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    switch (dataGridView1.Rows[i].Cells[5].Value.ToString())
                    {
                        case "كشف":
                        kasf = kasf + 1;
                        break;
                        case "استشارة":           
                        esteshara = esteshara + 1;
                        break;
                        case "كشف و غيار":
                        kasfGiar = kasfGiar + 1;
                        break;
                        case "استشارة و غيار":
                        estesharaGiar = estesharaGiar + 1;
                        break;
                        case "غيار":
                        Giar = Giar + 1;
                        break;
                    }
                }


            }
            txt_All_Count.Text = dataGridView1.Rows.Count.ToString();
           txt_Esteshara.Text=esteshara.ToString();
           txt_Esteshara_Giar.Text = estesharaGiar.ToString();
           txt_Giar.Text = Giar.ToString();
           txt_Kasf.Text = kasf.ToString();
           txt_Kasf_Giar.Text = kasfGiar.ToString();

            //====================

            }
        //====================------------============
        private bool Search_Patient_Name()
        {
            //=======================================
            SqlConnection con1 = new SqlConnection(stringcon);
            con1.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con1;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT     Patiant.*, Patiant.PatiantName, TaminTable.TaminName FROM   Patiant INNER JOIN  TaminTable ON Patiant.TaminID = TaminTable.TaminID  where ( PatiantName = '" + txt_Name.Text + "') and (Patiant.Trash="+0+") ";

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
        private void txt_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            //---------------------
            if (e.KeyChar == 13 && txt_code.Text != null && txt_code.Text != "")
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

                cmb_Kasf_Estishara.Focus();
            }
            //---------------------------
        }
        //=======================
        private void txt_Name_KeyDown(object sender, KeyEventArgs e)
        {
            //==========================
            if (e.KeyCode == Keys.Enter)
            {
                Search_Patient_Name();

                cmb_Kasf_Estishara.Focus();


            }

            //==================
        }
        //---------------------------------------
        private void cmb_Kasf_Estishara_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Note.Focus();
                //bt_Dowen.PerformClick();
            }
        }
        //=====================
        private void bt_Dowen_Click(object sender, EventArgs e)
        {

            if ( GetSetPatiant_flage == false)
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
            //---------  TestIfIInsertedInDataGridbefor
            if (TestIfIInsertedInDataGridbefor(GetSetPatiantId)==true)
            {
               
                MessageBox.Show(" من فضلك هذا المريض قد تم تسجيله ", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Name.Focus();
                return;
            }
            if (GetKashfFlage(cmb_Kasf_Estishara.Text) == 0)
            {
                MessageBox.Show(" من فضلك قم بإختيار الكشف أو  الإستشارة ", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb_Kasf_Estishara.Focus();
                return;
            }
            int count=dataGridView1.Rows.Count+1;

            int HagzOrderId = insert_HagzOrder(count, GetSetPatiantId);
            dataGridView1.Rows.Add(GetSetPatiantId, count, txt_Name.Text, txt_code.Text, txt_Tamine.Text, cmb_Kasf_Estishara.Text, txt_Note.Text, GetKashfFlage(cmb_Kasf_Estishara.Text), HagzOrderId,false);
            //----------- to color datagridview
            if ((count-1) % 2 == 0)
            {
                dataGridView1.Rows[count - 1].DefaultCellStyle.BackColor = Color.LightYellow;
            }
            else
            {
                dataGridView1.Rows[count - 1].DefaultCellStyle.BackColor = Color.LightGray;
            }
            //-------------------
            
            empty();
            SumcodeGrid();
            txt_Name.Focus();
            //==================
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
        private int  insert_HagzOrder(int Taratip, int PatiantId)
        {

            //=====================================================
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insert_HagzOrder";
            //*****************************************
            SqlParameter param14 = new SqlParameter("@Taratip ", SqlDbType.Int);
            param14.Value = Taratip;
            param14.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param14);
            //*********************
             SqlParameter param3 = new SqlParameter("@PatiantId ", SqlDbType.Int);
            param3.Value = PatiantId;
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);
            //==============================
            SqlParameter param2 = new SqlParameter("@KashfDate", SqlDbType.DateTime);
            param2.Value = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());
            param2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param2);
            //***************************************************    
            SqlParameter param5 = new SqlParameter("@KashfFlage  ", SqlDbType.Int);
            param5.Value = GetKashfFlage(cmb_Kasf_Estishara.Text);//cmb_Kasf_Estishara.SelectedValue;getset
            param5.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param5);
            //*******************************
            SqlParameter param6 = new SqlParameter("@HagzNote ", SqlDbType.NVarChar, 100);
            param6.Value = txt_Note.Text;
            param6.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param6);
            //*********************
            SqlParameter param7 = new SqlParameter("@FinishFlage ", SqlDbType.Int);
            param7.Value = 0;
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
            //=================/=================
        }
        //=======================
        private void empty()
        {
            txt_Name.Text = "";
            txt_code.Text = "";
            txt_Tamine.Text = "";
            txt_Note.Text = "";
            GetSetPatiant_flage = false;
        }
        //=========================       
        private void bt_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }
            //====================
            DialogResult result3;
            result3 = MessageBox.Show("هل تريد حذف هذا الحجز", "  ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result3 == DialogResult.No)
            {

                return;
            }
            //=====================

            Cursor.Current = Cursors.WaitCursor;
            //===========================

            int hagzorderid = int.Parse(dataGridView1.CurrentRow.Cells[8].Value.ToString());

            beginDate = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());

            update_HagzOrder_Trash(hagzorderid);

            Searc_Order(beginDate);

            SumcodeGrid();
           
           
            MessageBox.Show("تم الحذف بنجاح  ");
            //===========
           
            //========================
            Cursor.Current = Cursors.Default;
            //===============
            //========================
        }
        //-------------========
        private void update_HagzOrder_Trash(int HagzOrderId)
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "update_HagzOrderTrash";
            //***********************
            SqlParameter param1 = new SqlParameter("@HagzOrderId ", SqlDbType.Int);
            param1.Value = HagzOrderId;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
            //***************** 
           
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;

            //***********************************

        }
        //=======================
        private void update_HagzOrderFinishFlage(int HagzOrderId,int FinishFlage)
        {

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "update_HagzOrderFinishFlage";
            //***********************
            SqlParameter param1 = new SqlParameter("@HagzOrderId ", SqlDbType.Int);
            param1.Value = HagzOrderId;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
            //***************** 
             SqlParameter param2 = new SqlParameter("@FinishFlage ", SqlDbType.Int);
            param2.Value = FinishFlage;
            param2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param2);
            //***************** 
           
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;

            //***********************************

        }
        //=======================
        private void bt_refresh_Click(object sender, EventArgs e)
        {
            beginDate = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());


            Searc_Order(beginDate);

            SumcodeGrid();
            //-------------------
        }
        //======================

        private void HagzKashf_Load(object sender, EventArgs e)
        {
            //=================
          


            //==============
            FillKashfFlageName();
            //=========

            AutocompleteText_Patient();

            dateTimePicker1.Value = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());

            beginDate = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());


            Searc_Order(beginDate);

            SumcodeGrid();


            cmb_Kasf_Estishara.SelectedIndex = 0;

          


            //----------------------------
        }
        //=============
        private void bt_AddNew_Patient_Click(object sender, EventArgs e)
        {
                 PatientKashf PatientKashf1 = new PatientKashf();
                    PatientKashf1.ShowDialog();
                
                AutocompleteText_Patient();
        }
        //==========================
        private void txt_Note_KeyPress(object sender, KeyPressEventArgs e)
        {
            //---------------------
            if (e.KeyChar == 13 )
            {

                bt_Dowen.PerformClick();          

               
            }
            //---------------------------
        }
        //==================
        private void bt_CheckDone_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }
           

           int HagzOrderId=int.Parse(dataGridView1.CurrentRow.Cells[8].Value.ToString());
            //===========================
            if (bool.Parse(dataGridView1.CurrentRow.Cells[9].Value.ToString()) == false)
            {
                dataGridView1.CurrentRow.Cells[9].Value = true;
                
                update_HagzOrderFinishFlage(HagzOrderId, 1);
            }
            else
            {
                dataGridView1.CurrentRow.Cells[9].Value = false;
                update_HagzOrderFinishFlage(HagzOrderId, 0);
            }

            //==================
             int PatiantId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int  old_KashfOrderId = Get_KashfOrderId_Giar(Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString()), PatiantId);
           if (int.Parse(dataGridView1.CurrentRow.Cells[7].Value.ToString()) == 5)
            {
               //-----------
                if (old_KashfOrderId == 0) //يعنى متعملش اليوم قبل هذا
                {
                    int KashfOrderId = insert_KashfOrder_Giar(PatiantId);
                    insert_KashfOrderDetail_Giar(KashfOrderId);
                }
               //--------------
            }
            //==========================


        }
        //===================================== 
        private bool TestIfIInsertedInDataGridbefor(int PatiantId)
        {
            // to be sure the from store is the same in the order

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (PatiantId ==int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()))
                    return true;
            }
            return false;
        }
        //=========== 
        private int insert_KashfOrder_Giar(int PatiantId)
        {



            //=====================================================
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insert_KashfOrder";
            //***********************

            SqlParameter param2 = new SqlParameter("@KashfDate", SqlDbType.DateTime);
            param2.Value = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());
            param2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param2);
            //*************************************************** 

            SqlParameter param3 = new SqlParameter("@PatiantId ", SqlDbType.Int);
            param3.Value = PatiantId;
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);
            //********************************
            SqlParameter param14 = new SqlParameter("@Diagnosis ", SqlDbType.NVarChar, 200);
            param14.Value = "غيار";
            param14.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param14);
            //*********************
            SqlParameter param5 = new SqlParameter("@KashfFlage  ", SqlDbType.Int);
            param5.Value = 5;//cmb_Kasf_Estishara.SelectedIndex;
            param5.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param5);
            //**************************
            SqlParameter IDParameter = new SqlParameter("@NewID", SqlDbType.Int);
            IDParameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(IDParameter);
            //**********************
            cmd.ExecuteScalar();
            int id = (int)IDParameter.Value;
           con.Close();con.Dispose();;
            return id;
            //=================
        }
        //=======================================
        private void insert_KashfOrderDetail_Giar(int KashfOrderId)
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
            param1000.Value = "غيار";
            param1000.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1000);
            //******************************************
            SqlParameter param5 = new SqlParameter("@MedcinID", SqlDbType.Int);
            param5.Value = 291;
            param5.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param5);
            //***************************  
            SqlParameter param10000 = new SqlParameter("@MedcinTypeName ", SqlDbType.NVarChar, 50);
            param10000.Value = "غيار";
            param10000.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param10000);
            //******************************************

            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;
        }
        //====================
        //===========
        private int Get_KashfOrderId_Giar(DateTime KashfDate, int PatiantId)
        {
            int xx = 0;

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Select_KashfOrder_Giar_IF_Exist";
            //===================================
            SqlParameter param2 = new SqlParameter("@PatiantId", SqlDbType.Int);
            param2.Value = PatiantId;
            param2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param2);
            //*************************** 
            SqlParameter param1 = new SqlParameter("@KashfDate ", SqlDbType.DateTime);
            param1.Value = KashfDate;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
            //***************************
            dataAdapter = new SqlDataAdapter(cmd);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "all");

            // for each row in the table, fill the list
            dataTable = dataSet.Tables["all"];

            if (!(dataTable.Rows.Count == 0))
            {
                //=========================

                DataRow selectedRow = dataTable.Rows[0];
                if (selectedRow["KashfOrderId"].ToString() != "" && selectedRow["KashfOrderId"].ToString() != null)
                {
                    xx = int.Parse(selectedRow["KashfOrderId"].ToString());
                }
               con.Close();con.Dispose();;

            }
            return xx;
        }
        //=========== 
        //=========================
    }
}
