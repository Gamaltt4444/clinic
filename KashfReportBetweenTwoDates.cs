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
    public partial class KashfReportBetweenTwoDates : Form
    {
        //***********************
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTable dataTable;
        //===============      
        DateTime beginDate, enddate;
        //==================================
        public DataTable dt_ForPrint = new DataTable();//for add row to the datagrid
        //**************************
        public string stringcon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=GenClinicDB;Data Source=.";
        //*********************************************************
        public string stringconPrint = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ZPrintDB;Data Source=.";
        //***************
        public KashfReportBetweenTwoDates()
        {
            InitializeComponent();
        }
        //===========================
        private void KashfReportBetweenTwoDates_Load(object sender, EventArgs e)
        {
            //------------
            radio_All.Checked = true;
            FillKashfFlageName();
            cmb_Kasf_Estishara.SelectedIndex = 0;
            //---------------------        
     
            dateTimePicker1.Value= Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
            dateTimePicker2.Value = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
            beginDate = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());
            enddate = Convert.ToDateTime(dateTimePicker2.Value.Date.ToShortDateString());

            Searc_OrderAll(beginDate, enddate);

            SumcodeGrid();
            //-------------------
        }
        //=============
        private void Searc_OrderAll(DateTime begindate1, DateTime enddate1)
        {
            string PatiantId, KashfDate, PatiantName, KashfFlageName;
            dataGridView1.Rows.Clear();
            //======================

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SelecKasfOrder_FromDate_toDate";
            //***********************  *************            
            SqlParameter param2 = new SqlParameter("@bigenDate", SqlDbType.DateTime);
            param2.Value = begindate1;
            param2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param2);
            //*************************** 
            SqlParameter param1 = new SqlParameter("@endDate ", SqlDbType.DateTime);
            param1.Value = enddate1;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
            //***************************
            //SqlParameter param3 = new SqlParameter("@OrderKind ", SqlDbType.Int);
            //param3.Value = 0;
            //param3.Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(param3);
            ////************************************************

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
                
                //===============================
                return;
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {

                //========================
                DataRow selectedRow = dataTable.Rows[i];
                //tempboxPrice_Sell = (float)Math.Round(float.Parse(selectedRow["boxPrice_Sell"].ToString()), 3);              
                int KashfOrderId = int.Parse(selectedRow["KashfOrderId"].ToString());
                PatiantId = selectedRow["PatiantId"].ToString();
                KashfDate = displaydate(Convert.ToDateTime(selectedRow["KashfDate"].ToString()));
                PatiantName = selectedRow["PatiantName"].ToString();
               KashfFlageName=selectedRow["KashfFlageName"].ToString();

               dataGridView1.Rows.Add(KashfOrderId, PatiantId, KashfDate, PatiantName, KashfFlageName);
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
        private void Searc_Order_KashfFlage(DateTime begindate1, DateTime enddate1, int KashfFlage)
        {
            string PatiantId, KashfDate, PatiantName, KashfFlageName;
            dataGridView1.Rows.Clear();
            //======================

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SelecKasfOrder_KashfFlage_FromDatetoDate";
            //***********************  *************            
            SqlParameter param2 = new SqlParameter("@bigenDate", SqlDbType.DateTime);
            param2.Value = begindate1;
            param2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param2);
            //*************************** 
            SqlParameter param1 = new SqlParameter("@endDate ", SqlDbType.DateTime);
            param1.Value = enddate1;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
            //***************************
            SqlParameter param3 = new SqlParameter("@KashfFlage ", SqlDbType.Int);
            param3.Value = KashfFlage;
            param3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param3);
            ////************************************************

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

                //===============================
                return;
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {

                //========================
                DataRow selectedRow = dataTable.Rows[i];
                //tempboxPrice_Sell = (float)Math.Round(float.Parse(selectedRow["boxPrice_Sell"].ToString()), 3);              
                int KashfOrderId = int.Parse(selectedRow["KashfOrderId"].ToString());
                PatiantId = selectedRow["PatiantId"].ToString();
                KashfDate = displaydate(Convert.ToDateTime(selectedRow["KashfDate"].ToString()));
                PatiantName = selectedRow["PatiantName"].ToString();
                KashfFlageName = selectedRow["KashfFlageName"].ToString();
                dataGridView1.Rows.Add(KashfOrderId, PatiantId, KashfDate, PatiantName, KashfFlageName);
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
        private void bt_Search_Click(object sender, EventArgs e)
        {
            beginDate = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());
            enddate = Convert.ToDateTime(dateTimePicker2.Value.Date.ToShortDateString());

            if (radio_All.Checked == true)
            {
                Searc_OrderAll(beginDate, enddate);
            }
            //================================
            int KashfFlage=GetKashfFlage(cmb_Kasf_Estishara.Text);
            if (radio_Esteshara.Checked == true)
            {
                if (KashfFlage== 0)
                {
                    MessageBox.Show(" من فضلك قم بإختيار الكشف أو  الإستشارة ", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmb_Kasf_Estishara.Focus();
                    return;
                }
                //================                
                Searc_Order_KashfFlage(beginDate, enddate,KashfFlage);
                //===============
            }
            //=====================================
            SumcodeGrid();
            //==============


        }
        //==============================

        private void SumcodeGrid()
        {
            int kasf = 0, esteshara = 0, kasfGiar = 0, estesharaGiar = 0, Giar = 0;

            if (dataGridView1.Rows.Count != 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    switch (dataGridView1.Rows[i].Cells[4].Value.ToString())
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
            txt_Esteshara.Text = esteshara.ToString();
            txt_Esteshara_Giar.Text = estesharaGiar.ToString();
            txt_Giar.Text = Giar.ToString();
            txt_Kasf.Text = kasf.ToString();
            txt_Kasf_Giar.Text = kasfGiar.ToString();

            //====================

        }
        //=============
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //--------------------
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }
            int temid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int PatiantId = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());

            KashfOLD KashfOLD1 = new KashfOLD();
            KashfOLD1.GetSetKashfOrderId = temid;
            KashfOLD1.GetSetPatiantId = PatiantId;

            KashfOLD1.ShowDialog();
            //---------------
        }
        //-----------------------------------
        private void bt_print_Click(object sender, EventArgs e)
        {
            delete_ZtempTest10();
            insert_ZtempTest10All();

        }
        //===================================
        private void delete_ZtempTest10() 
        {

            SqlConnection con = new SqlConnection(stringconPrint);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from ZtempTest10 ";
            cmd.ExecuteNonQuery();
            con.Close(); con.Dispose(); ;

        }
        //================================== Masrofat
        private void insert_ZtempTest10(int count, string tempdadte, string Name, string Kashf_flage)
        {
            SqlConnection con = new SqlConnection(stringconPrint);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insert_ZtempTest10";
            //*********************************
            SqlParameter param7 = new SqlParameter("@c1", SqlDbType.Int);
            param7.Value = count;
            param7.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param7);
            //============== 
            SqlParameter param79 = new SqlParameter("@c2", SqlDbType.NVarChar, 50);
            param79.Value = tempdadte;
            param79.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param79);
            //***************************
            SqlParameter param77 = new SqlParameter("@c3", SqlDbType.NVarChar, 50);
            param77.Value = Name;
            param77.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param77);
            //============== 
            SqlParameter param71 = new SqlParameter("@c4", SqlDbType.NVarChar, 50);
            param71.Value = Kashf_flage;
            param71.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param71);
            //***************************  
            SqlParameter param711 = new SqlParameter("@c5", SqlDbType.NVarChar, 50);
            param711.Value = "";
            param711.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param711);
            //============  
            SqlParameter param1 = new SqlParameter("@c6 ", SqlDbType.NVarChar, 50);
            param1.Value = "";
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
            //**************************** 
            SqlParameter param17 = new SqlParameter("@c7 ", SqlDbType.NVarChar, 50);
            param17.Value = "";
            param17.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param17);
            //************************
            SqlParameter param18 = new SqlParameter("@c8 ", SqlDbType.NVarChar, 50);
            param18.Value = "";// user date
            param18.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param18);
            //************************
            SqlParameter param19 = new SqlParameter("@c9 ", SqlDbType.NVarChar, 50);
            param19.Value = "";
            param19.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param19);
            //************************
            SqlParameter param110 = new SqlParameter("@c10 ", SqlDbType.NVarChar, 50);
            param110.Value = "";
            param110.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param110);
            //************************
            SqlParameter param111 = new SqlParameter("@c11 ", SqlDbType.NVarChar, 50);
            param111.Value = "";
            param111.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param111);
            //************************
            SqlParameter param112 = new SqlParameter("@c12 ", SqlDbType.NVarChar, 50);
            param112.Value = "";
            param112.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param112);
            //************************
            SqlParameter param113 = new SqlParameter("@c13 ", SqlDbType.NVarChar, 50);
            param113.Value = "";
            param113.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param113);
            //************************
            SqlParameter param114 = new SqlParameter("@c14 ", SqlDbType.NVarChar, 50);
            param114.Value = "";
            param114.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param114);
            //************************
            SqlParameter param115 = new SqlParameter("@c15 ", SqlDbType.NVarChar, 50);
            param115.Value = "";
            param115.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param115);
            //************************
            SqlParameter param116 = new SqlParameter("@c16 ", SqlDbType.NVarChar, 50);
            param116.Value = "";
            param116.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param116);
            //************************
            SqlParameter param117 = new SqlParameter("@c17 ", SqlDbType.NVarChar, 50);
            param117.Value = "";
            param117.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param117);
            //************************
            SqlParameter param118 = new SqlParameter("@c18 ", SqlDbType.NVarChar, 50);
            param118.Value = "";
            param118.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param118);
            //************************
            SqlParameter param119 = new SqlParameter("@c19 ", SqlDbType.NVarChar, 50);
            param119.Value = "";
            param119.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param119);
            //************************
            SqlParameter param20 = new SqlParameter("@c20 ", SqlDbType.NVarChar, 50);
            param20.Value = "";
            param20.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param20);
            //************************
            cmd.ExecuteNonQuery();
            con.Close(); con.Dispose(); ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //get the index of the selected row in datagridview
            //and delete a row from datatable
            //and bind the datagridview with datatable
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        //========================= 
        private void insert_ZtempTest10All()
        {


            string tempdadte, Name, Kashf_flage;
            int count = 0;
            //=================================
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                //=======================
                count = count + 1;
                tempdadte = dataGridView1.Rows[i].Cells[1].Value.ToString();
                Name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                Kashf_flage = dataGridView1.Rows[i].Cells[1].Value.ToString();
                          

                //==================
                insert_ZtempTest10(count, tempdadte, Name, Kashf_flage);
                //===========================
            }

        }
        //========================
        //===========
       
            //-----------------



        

        //=========================
    }
}
