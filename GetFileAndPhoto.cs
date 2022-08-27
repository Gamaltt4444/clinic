using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace GenClinic
{
    public partial class GetFileAndPhoto : Form
    {
       private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTable dataTable;
        //===============
        //private SqlDataAdapter dataAdapter1;
        //private DataSet dataSet1;
        //private DataTable dataTable1;
          //===========
        public static int tempPatiantId;
        public int GetSetPatiantId
        {
            set { tempPatiantId = value; }
            get { return tempPatiantId; }
        }
        //============= =====
        private int rowcount;
        public int Getsetrowcount
        {
            set { rowcount = value; }
            get { return rowcount; }
        }
        //=============
        public string stringcon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=GenClinicDB;Data Source=.";
        //************
        public static int adminKind;
        public int GetSetadminKind
        {
            set { adminKind = value; }
            get { return adminKind; }
        }
        //===================
        public static bool tempLoginflage = false;
        public bool GetSetLoginflage
        {
            set { tempLoginflage = value; }
            get { return tempLoginflage; }
        }
        //=====================
        public static string tempLoginName;
        public string GetSetLoginName
        {
            set { tempLoginName = value; }
            get { return tempLoginName; }
        }
        //==================
        public static int tempUeserUeserId;
        public int GetSetLoginUeserId
        {
            set { tempUeserUeserId = value; }
            get { return tempUeserUeserId; }
        }
        //=========================
        public GetFileAndPhoto()
        {
            InitializeComponent();
        }

        //Get table rows from sql server to be displayed in Datagrid.
        private void GetImagesFromDatabase(int ImageOrderDetailId)
        {
            #region old code
            //try
            //{
            //    //Initialize SQL Server connection.
            //    SqlConnection CN = new SqlConnection(stringcon);

            //    //Initialize SQL adapter.
            //    SqlDataAdapter ADAP = new SqlDataAdapter("Select * from ImagesStore", CN);

            //    //Initialize Dataset.
            //    DataSet DS = new DataSet();

            //    //Fill dataset with ImagesStore table.
            //    ADAP.Fill(DS, "ImagesStore");

            //    //Fill Grid with dataset.
            //    dataGridView2.DataSource = DS.Tables["ImagesStore"];
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            #endregion 
            //=============================
            try
            {
                //Initialize SQL Server connection.
                SqlConnection CN = new SqlConnection(stringcon);

                //Initialize SQL adapter.
                SqlDataAdapter ADAP = new SqlDataAdapter("SELECT     ImageOrderDetail_image FROM  dbo.ImageOrderDetail WHERE  (ImageOrderDetailId = " + ImageOrderDetailId + ")", CN);

                //Initialize Dataset.
                DataSet DS = new DataSet();

                //Fill dataset with ImagesStore table.
                ADAP.Fill(DS, "ImagesStore");

                //Fill Grid with dataset.
                dataGridView1.DataSource = DS.Tables["ImagesStore"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //================================ to use next before < >
            Getsetrowcount = 0;
                //===========
            if (dataGridView1.Rows.Count != 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = i;
                }
                ShowPhoto(0);
            }
            //==========================================
        }

       //============================== 
        //When user changes row selection, display image of selected row in picture box.
        private void ShowPhoto(int rowcount)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;//ááÊÇßÏ ÃäåÇ áíÓÊ ÝÇÑÛÉ
            }
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
        //====================
        private void frmImagesStore_Load(object sender, EventArgs e)
        {
            AutocompleteText_Patient();
        }
        //============================================
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
        //======================to display time in good stye
        private string displaydate(DateTime dt)
        {
            string dd = dt.Date.Day.ToString();
            string mm = dt.Date.Month.ToString();
            string yyyy = dt.Date.Year.ToString();
            // return (dd + "/" + mm + "/" + yyyy);
            return (yyyy + "/" + mm + "/" + dd);
        }
        //=========================  
        private void GetTXTFomDataBase(int ImageOrderDetailId)
         {
             //=============
             #region Txtx write to hard code
             //=============
             string sPathToSaveFileTo = @"D:\2.txt";  // on this path i will create selected PDF File Data    open pdf for checking

             //=============
             SqlConnection con1 = new SqlConnection(stringcon);
             con1.Open();
             SqlCommand cmd = new SqlCommand();
             cmd.Connection = con1;
             cmd.CommandType = CommandType.Text;
             cmd.CommandText = "SELECT     ImageOrderDetail_image FROM  dbo.ImageOrderDetail WHERE     (ImageOrderDetailId = " + ImageOrderDetailId + ")";
             //=======================

             //Read Connection from web config




             SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default);

             if (dr.Read())
             {
                 // read in using GetValue and cast to byte array
                 byte[] fileData = (byte[])dr.GetValue(0);


                 // write bytes to disk as file
                 using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                 {
                     // use a binary writer to write the bytes to disk
                     using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                     {
                         bw.Write(fileData);
                         bw.Close();
                     }
                 }
                 //=========
                 System.Diagnostics.Process.Start(sPathToSaveFileTo);
                 //================
             }

             dr.Close();
             // close reader to database





             #endregion
             //======================
         }
         //==============================
         private void GetpdfFomDataBase(int ImageOrderDetailId)
         {
             //=============
             #region pdf write to hard code
             //=============
            // string sPathToSaveFileTo = @"C:\WINDOWS\system\SelectedFile.pdf";  // on this path i will create selected PDF File Data    open pdf for checking
             string sPathToSaveFileTo = @"D:\SelectedFile.pdf";  // on this path i will create selected PDF File Data    open pdf for checking
             //=============
             SqlConnection con1 = new SqlConnection(stringcon);
             con1.Open();
             SqlCommand cmd = new SqlCommand();
             cmd.Connection = con1;
             cmd.CommandType = CommandType.Text;
             cmd.CommandText = "SELECT     ImageOrderDetail_image FROM  dbo.ImageOrderDetail WHERE     (ImageOrderDetailId = " + ImageOrderDetailId + ")";
             //=======================

             //Read Connection from web config




             SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default);

             if (dr.Read())
             {
                 // read in using GetValue and cast to byte array
                 byte[] fileData = (byte[])dr.GetValue(0);


                 // write bytes to disk as file
                 using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                 {
                     // use a binary writer to write the bytes to disk
                     using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                     {
                         bw.Write(fileData);
                         bw.Close();
                     }
                 }
                 //=========
                 System.Diagnostics.Process.Start(sPathToSaveFileTo);
                 //================
             }

             dr.Close();
             // close reader to database





             #endregion
             //======================
         }
         //============================================== GetWORD_xFomDataBase
         private void GetWORD_xFomDataBase(int ImageOrderDetailId)
         {
             //=============
             #region pdf write to hard code
             //=============
             string sPathToSaveFileTo = @"D:\w1.docx";  // on this path i will create selected PDF File Data    open pdf for checking

             //=============
             SqlConnection con1 = new SqlConnection(stringcon);
             con1.Open();
             SqlCommand cmd = new SqlCommand();
             cmd.Connection = con1;
             cmd.CommandType = CommandType.Text;
             cmd.CommandText = "SELECT     ImageOrderDetail_image FROM  dbo.ImageOrderDetail WHERE     (ImageOrderDetailId = " + ImageOrderDetailId + ")";
             //=======================

             //Read Connection from web config




             SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default);

             if (dr.Read())
             {
                 // read in using GetValue and cast to byte array
                 byte[] fileData = (byte[])dr.GetValue(0);


                 // write bytes to disk as file
                 using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                 {
                     // use a binary writer to write the bytes to disk
                     using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                     {
                         bw.Write(fileData);
                         bw.Close();
                     }
                 }
                 //=========
                 System.Diagnostics.Process.Start(sPathToSaveFileTo);
                 //================
             }
             dr.Close();

             // close reader to database





             #endregion
             //======================
         }
         //==============================================
         private void GetWORDFomDataBase(int ImageOrderDetailId)
         {
             //=============
             #region pdf write to hard code
             //=============
             string sPathToSaveFileTo = @"D:\w.doc";  // on this path i will create selected PDF File Data    open pdf for checking

             //=============
             SqlConnection con1 = new SqlConnection(stringcon);
             con1.Open();
             SqlCommand cmd = new SqlCommand();
             cmd.Connection = con1;
             cmd.CommandType = CommandType.Text;
             cmd.CommandText = "SELECT     ImageOrderDetail_image FROM  dbo.ImageOrderDetail WHERE     (ImageOrderDetailId = " + ImageOrderDetailId + ")";
             //=======================

             //Read Connection from web config




             SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default);

             if (dr.Read())
             {
                 // read in using GetValue and cast to byte array
                 byte[] fileData = (byte[])dr.GetValue(0);


                 // write bytes to disk as file
                 using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                 {
                     // use a binary writer to write the bytes to disk
                     using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                     {
                         bw.Write(fileData);
                         bw.Close();
                     }
                 }
                 //=========
                 System.Diagnostics.Process.Start(sPathToSaveFileTo);
                 //================
             }
             dr.Close();

             // close reader to database





             #endregion
             //======================
         }
         //==============================================
         private void GetXcel_xfromDataBase(int ImageOrderDetailId)
         {
             //=============
             #region pdf write to hard code
             //=============
             string sPathToSaveFileTo = @"D:\x11.xlsx";  // on this path i will create selected PDF File Data    open pdf for checking

             //=============
             SqlConnection con1 = new SqlConnection(stringcon);
             con1.Open();
             SqlCommand cmd = new SqlCommand();
             cmd.Connection = con1;
             cmd.CommandType = CommandType.Text;
             cmd.CommandText = "SELECT     ImageOrderDetail_image  FROM  dbo.ImageOrderDetail WHERE     (ImageOrderDetailId = " + ImageOrderDetailId + ")";
             //=======================

             //Read Connection from web config




             SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default);

             if (dr.Read())
             {
                 // read in using GetValue and cast to byte array
                 byte[] fileData = (byte[])dr.GetValue(0);


                 // write bytes to disk as file
                 using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                 {
                     // use a binary writer to write the bytes to disk
                     using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                     {
                         bw.Write(fileData);
                         bw.Close();
                     }
                 }
                 //=========
                 System.Diagnostics.Process.Start(sPathToSaveFileTo);
                 //================
             }
             dr.Close();

             // close reader to database





             #endregion
             //======================
         }
         //==============================================
         private void GetXcelfromDataBase(int ImageOrderDetailId)
         {
             //=============
             #region pdf write to hard code
             //=============
             string sPathToSaveFileTo = @"D:\x.xls";  // on this path i will create selected PDF File Data    open pdf for checking

             //=============
             SqlConnection con1 = new SqlConnection(stringcon);
             con1.Open();
             SqlCommand cmd = new SqlCommand();
             cmd.Connection = con1;
             cmd.CommandType = CommandType.Text;
             cmd.CommandText = "SELECT     ImageOrderDetail_image FROM  dbo.ImageOrderDetail WHERE     (ImageOrderDetailId = " + ImageOrderDetailId + ")";
             //=======================

             //Read Connection from web config




             SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default);

             if (dr.Read())
             {
                 // read in using GetValue and cast to byte array
                 byte[] fileData = (byte[])dr.GetValue(0);


                 // write bytes to disk as file
                 using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                 {
                     // use a binary writer to write the bytes to disk
                     using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                     {
                         bw.Write(fileData);
                         bw.Close();
                     }
                 }
                 //=========
                 System.Diagnostics.Process.Start(sPathToSaveFileTo);
                 //================
             }
             dr.Close();

             // close reader to database





             #endregion
             //======================
         }
         //====================================
         private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
         {
              pictureBox1.Image = null;
             int id=int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
             int paperkind = int.Parse(dataGridView2.CurrentRow.Cells[3].Value.ToString());
             switch (paperkind)
             {
                 case 1:
                    // groupBox1.Enabled = true;
                     GetImagesFromDatabase(id);
                     break;
                 default:
                    // groupBox1.Enabled = false;
                     //pictureBox1.Image = null;
                     //GetpdfFomDataBase(id);
                     break;
             }
             
         }
        //====================================
         private void Search_ImageOrderDetail(int PatiantId)
         {
             //=============================

             dataGridView2.Rows.Clear();

             string File_Extention, paperkindText = "Photo", KashfDate;
             int ImageOrderDetailId, Paper_Kind;
             //====================================================
             SqlConnection con1 = new SqlConnection(stringcon);
             con1.Open();
             SqlCommand cmd = new SqlCommand();
             cmd.Connection = con1;
             cmd.CommandType = CommandType.Text;
             cmd.CommandText = "SELECT * FROM ImageOrderDetail  where (PatiantId= " + PatiantId + ")  order by KashfDate DESC ";


             dataAdapter = new SqlDataAdapter(cmd);
             dataSet = new DataSet();

             dataAdapter.Fill(dataSet, "All");

             // for each row in the table, fill the list
             dataTable = dataSet.Tables["All"];
             //**************************************            

             if (!(dataTable.Rows.Count == 0))
             {

                 //========================= 
                 for (int i = 0; i < dataTable.Rows.Count; i++)
                 {
                     DataRow selectedRow = dataTable.Rows[i];

                     ImageOrderDetailId = (int)selectedRow["ImageOrderDetailId"];

                     KashfDate =displaydate(Convert.ToDateTime(selectedRow["KashfDate"].ToString()));
                     File_Extention = selectedRow["File_Extention"].ToString();
                      Paper_Kind = int.Parse(selectedRow["Paper_Kind_Id"].ToString());
                     switch (Paper_Kind)
                     {
                         case 1:
                             paperkindText = "Photo";
                             break;
                         case 2:
                             paperkindText = "PDF";
                             break;
                         case 3:
                             paperkindText = "Word";
                             break;
                         case 4:
                             paperkindText = "Excel";
                             break;
                         case 5:
                             paperkindText = "Text";
                             break;

                     }
                     dataGridView2.Rows.Add(ImageOrderDetailId, KashfDate, paperkindText, Paper_Kind, File_Extention);
                 }


                 //==================

                 con1.Close();
                 //========


             }
             else
             {


                 con1.Close();




             }




         }
        //=======================
         private void bt_next_Click(object sender, EventArgs e)
         {
             if (dataGridView1.Rows.Count == 0)
             {
                 return;
             }
                
                
             
             Getsetrowcount = Getsetrowcount + 1;
             if (Getsetrowcount > dataGridView1.Rows.Count - 1)
             {
                 Getsetrowcount = Getsetrowcount - 1;
             }
             //=============
             ShowPhoto(Getsetrowcount);
             //===================
         }
        //=======================================
         private void bt_previous_Click(object sender, EventArgs e)
         {
             if (dataGridView1.Rows.Count == 0)
             {
                 return;
             }
             //=========
             Getsetrowcount = Getsetrowcount - 1;
             if (Getsetrowcount == -1)
             {
                 Getsetrowcount = 0;
                 //messagebox.show("first record);
             }
             //=============
             ShowPhoto(Getsetrowcount);
             //===========
         }

         private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
         {
         //    float x = pictureBox1.Image.Height;
         //    float y = pictureBox1.Image.Width;

             e.Graphics.DrawImage(pictureBox1.Image,23, 33);

      


             //Point ulCorner = new Point(100, 100);
             //e.Graphics.DrawImage(pictureBox1.Image, ulCorner);

         }
        //========================
         private void button1_Click(object sender, EventArgs e)
         {
             //PrintDialog dlg = new PrintDialog();
             //dlg.Document = printDocument1;
             //dlg.ShowDialog();


             PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
             printPreviewDialog1.Document = this.printDocument1;
             printPreviewDialog1.ShowDialog();
         }
        //================================
         private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
         {
             pictureBox1.Image = null;
             int id = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
             int paperkind = int.Parse(dataGridView2.CurrentRow.Cells[3].Value.ToString());
             string File_Extention = dataGridView2.CurrentRow.Cells[4].Value.ToString();
             switch (paperkind)
             {
                 case 1:
                   //  groupBox1.Enabled = true;
                     GetImagesFromDatabase(id);
                     break;
                 case 2:
                     //groupBox1.Enabled = false;
                     GetpdfFomDataBase(id);
                     break;
                 case 3:
                     if (File_Extention == ".doc")
                     {
                         GetWORDFomDataBase(id);
                     }
                     else
                     {
                         GetWORD_xFomDataBase(id);
                     }
                     break;
                 case 4:
                     if (File_Extention == ".xls")
                     {
                         GetXcelfromDataBase(id);
                     }
                     else
                     {
                         GetXcel_xfromDataBase(id);
                     }
                     break;
                 case 5:
                     GetTXTFomDataBase(id);
                     break;
                 
             }

         }
        //==========================================
         private void txt_Name_KeyDown(object sender, KeyEventArgs e)
         {
             //==========================
             if (e.KeyCode == Keys.Enter)
             {
                 Search_Patient_Name();


             }

             //==================
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
        //=========================================
         private void bt_Search_Click(object sender, EventArgs e)
         {
             Search_Patient_Name();
             if(GetSetPatiantId!=0)
             {
                 Search_ImageOrderDetail(GetSetPatiantId);
             }
         }
        //=================
        
    }
}