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
    public partial class oldPatientKashf : Form
    {
        //***********************
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTable dataTable;
        //================================================
        public DataTable dt_ForPrint = new DataTable();//for add row to the datagrid
        //**************************
        public string stringcon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=GenClinicDB;Data Source=.";
        //*********************************************************
        public string stringconPrint = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ZPrintDB;Data Source=.";
        //***************
        //=========== for  customer
        //==========
        public static int tempPatiantId;
        public int GetSetPatiantId
        {
            set { tempPatiantId = value; }
            get { return tempPatiantId; }
        }
        //=============  
        public oldPatientKashf()
        {
            InitializeComponent();
        }

        private void oldPatientKashf_Load(object sender, EventArgs e)
        {
            Searc_Order();
        }
        //=============
        private void Searc_Order()
        {
            string Diagnosis, KashfDate;
            //======================
         
            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Select_KashfOrder_By_PatiantId";
            //***********************            
            SqlParameter param2 = new SqlParameter("@PatiantId", SqlDbType.Int);
            param2.Value = GetSetPatiantId;
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
                //tempboxPrice_Sell = (float)Math.Round(float.Parse(selectedRow["boxPrice_Sell"].ToString()), 3);              
                int KashfOrderId = int.Parse(selectedRow["KashfOrderId"].ToString());
                Diagnosis = selectedRow["Diagnosis"].ToString();
                KashfDate = displaydate(Convert.ToDateTime(selectedRow["KashfDate"].ToString()));

                dataGridView1.Rows.Add(KashfOrderId, KashfDate,Diagnosis);
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
        //===============        
        private string displaydate(DateTime dt)
        {
            string dd = dt.Date.Day.ToString();
            if (dd.Length == 1) dd = "0" + dd;
            string mm = dt.Date.Month.ToString();
            if (mm.Length == 1) mm = "0" + mm;
            string yyyy = dt.Date.Year.ToString();
            return (yyyy + "/" + mm + "/" + dd);
        }
        //=======================
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //--------------------
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }
            int temid = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            KashfOLD KashfOLD1 = new KashfOLD();
            KashfOLD1.GetSetKashfOrderId = temid;
            KashfOLD1.GetSetPatiantId = GetSetPatiantId;

            KashfOLD1.ShowDialog();
            //---------------
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //get the index of the selected row in datagridview
            //and delete a row from datatable
            //and bind the datagridview with datatable
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }
        //=============
    }
}
