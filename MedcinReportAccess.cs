using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenClinic
{
    public partial class MedcinReportAccess : Form
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
        public string AccessConString = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source= C:\ZPrintDBAceess.mdb";
        //***************
        public MedcinReportAccess()
        {
            InitializeComponent();
        }
        //=====================
        private void MedcinReportAccess_Load(object sender, EventArgs e)
        {

        }
        //======================================
        private void delete_ZtempTest1() //egmaly
        {

          
            //=
            OleDbConnection conn = new OleDbConnection(AccessConString);
            conn.Open();
            OleDbCommand cmd = conn.CreateCommand();
            OleDbCommand cmdSelect = conn.CreateCommand();
            cmd.CommandText = "delete from ZtempTest1 ";
            

            cmd.ExecuteNonQuery();
            conn.Close();
            //====================
            //=============


        }
        //================================== Masrofat
   
        private void Searc_Order()
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
        //===========================
        private void insert_ZtempTest1(string MedcinID, string MedcinName, string MedcinTypeName, string count)
        {

            //=======================================================
            OleDbConnection conn = new OleDbConnection(AccessConString);
            conn.Open();
            OleDbCommand cmd = conn.CreateCommand();
            OleDbCommand cmdSelect = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO [ZtempTest1](c1,c2,c3,c4)VALUES(@c1,@c2,@c3,@c4) ";
            cmd.Parameters.AddWithValue("@c1", MedcinID);
            cmd.Parameters.AddWithValue("@c2", MedcinName);
            cmd.Parameters.AddWithValue("@c3", MedcinTypeName); // 
            cmd.Parameters.AddWithValue("@c4", count); // 
           
            cmd.ExecuteNonQuery();
            conn.Close();
            //====================
        }
        //=================
    }
}
