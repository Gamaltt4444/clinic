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
    public partial class MedcinReport : Form
    {
        //***********************
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTable dataTable;
        //===============
        //private SqlDataAdapter dataAdapter1;
        //private DataSet dataSet1;
        //private DataTable dataTable1;
        ////==========================
        //private SqlDataAdapter dataAdapter2;
        //private DataSet dataSet2;
        //private DataTable dataTable2;
        //==================================
        public DataTable dt_ForPrint = new DataTable();//for add row to the datagrid
        //**************************
        public string stringcon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=GenClinicDB;Data Source=.\\SQL2008";
        //*********************************************************
        public string stringconPrint = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ZPrintDB;Data Source=.\\SQL2008";
        //***************
        public MedcinReport()
        {
            InitializeComponent();
        }

        private void MedcinReport_Load(object sender, EventArgs e)
        {
            delete_ZtempTest1();
            Search_Order();
        }
        //======================================
        private void delete_ZtempTest1() //egmaly
        {

            SqlConnection con = new SqlConnection(stringconPrint);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from ZtempTest1 ";
            cmd.ExecuteNonQuery();
           con.Close();con.Dispose();;

        }
        //================================== Masrofat
        private void insert_ZtempTest1(string MedcinID, string MedcinName, string MedcinTypeName,string count)
        {
            SqlConnection con = new SqlConnection(stringconPrint);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insert_ZtempTest1";
            //*********************************
            SqlParameter param7 = new SqlParameter("@c1", SqlDbType.NVarChar, 50);
            param7.Value = MedcinID;
            param7.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param7);
            //============== 
            SqlParameter param79 = new SqlParameter("@c2", SqlDbType.NVarChar, 50);
            param79.Value = MedcinName;
            param79.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param79);
            //***************************
            SqlParameter param77 = new SqlParameter("@c3", SqlDbType.NVarChar, 50);
            param77.Value = MedcinTypeName;
            param77.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param77);
            //============== 
            SqlParameter param71 = new SqlParameter("@c4", SqlDbType.NVarChar, 50);
            param71.Value = count;
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
            param110.Value ="";
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
           con.Close();con.Dispose();;
        }
        //============== ===
        private void Search_Order()
        {
            string MedcinID, MedcinName, MedcinTypeName;
            int count;
            //======================

            SqlConnection con = new SqlConnection(stringcon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT     Medcin.MedcinID, Medcin.MedcinName, MedcinType.MedcinTypeName FROM  Medcin INNER JOIN MedcinType ON Medcin.MedcinTypeID = MedcinType.MedcinTypeID ORDER BY Medcin.MedcinName";
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
                
                //===============================
                return;
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {

                //========================
                DataRow selectedRow = dataTable.Rows[i];

                MedcinID = selectedRow["MedcinID"].ToString();
                MedcinName = selectedRow["MedcinName"].ToString();
                MedcinTypeName = selectedRow["MedcinTypeName"].ToString();
                count = i + 1;
                insert_ZtempTest1(MedcinID, MedcinName, MedcinTypeName, count.ToString());
                //====
              
                //-------------------
            }




           con.Close();con.Dispose();;



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //===============
        //=====================================
    }
}
