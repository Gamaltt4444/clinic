using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using WIALib;
using System.Runtime.InteropServices;
namespace GenClinic
{
    public partial class frmNewImage : Form
    {
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private DataTable dataTable;
        //===============
        
       public string			imageFileName;
        //=============
       public string stringcon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=GenClinicDB;Data Source=.";
       //==========
       public static int tempPatiantId;
       public int GetSetPatiantId
       {
           set { tempPatiantId = value; }
           get { return tempPatiantId; }
       }
       //============= 
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
        //======================***  File_Extention
        public static string tempFile_Extention="";
        public string GetSetFile_Extention
        {
            set { tempFile_Extention = value; }
            get { return tempFile_Extention; }
        }
        //=========== for 
        public static int tempPaper_Kind_Id=1;
        public int GetSetPaper_Kind_Id
        {
            set { tempPaper_Kind_Id = value; }
            get { return tempPaper_Kind_Id; }
        }
        //================= for 
        public static int tempImageOrderId;
        public int GetSetImageOrderId
        {
            set { tempImageOrderId = value; }
            get { return tempImageOrderId; }
        }
        //===================  
        public static bool tempTheSameflage = false;
        public bool getSetTheSameflage
        {
            set { tempTheSameflage = value; }
            get { return tempTheSameflage; }
        }
        //========
        public static int tempKashfOrderId;
        public int GetSetKashfOrderId
        {
            set { tempKashfOrderId = value; }
            get { return tempKashfOrderId; }
        }
        //============
      
        public frmNewImage()
        {
            InitializeComponent();
        }


        private void bt_Save_Click(object sender, EventArgs e)
        {
            
              //======
            if (GetSetPatiantId == 0)
            {
                MessageBox.Show(" من فضلك قم بإختيار اسم مريض ", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
              
            }
            else
            {
                insert_ImageOrderDetail(GetSetPatiantId);
                //GetSetPatiantId = 0;
            }
            //=-=========
            bt_Save.Enabled = false;
            //----------------
            
    }
//===========================
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
        //============================
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //Close this form if user clicks cancel.
            this.Close();
        }
        //==========================================
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
        private void insert_ImageOrderDetail(int PatiantId)
        {
            //Read Image Bytes into a byte array
            byte[] imageData = ReadFile(txtImagePath.Text);

            try
            {
                //=====================================================
                SqlConnection con = new SqlConnection(stringcon);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Insert_ImageOrderDetail";
                //***********************
                SqlParameter param1 = new SqlParameter("@PatiantId ", SqlDbType.Int);
                param1.Value = PatiantId;
                param1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param1);
                //*************************************
                SqlParameter param2 = new SqlParameter("@Paper_Kind_Id ", SqlDbType.Int);
                param2.Value = GetSetPaper_Kind_Id;
                param2.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param2);
                //*************************************
                SqlParameter param3 = new SqlParameter("@File_Extention ", SqlDbType.NVarChar, 50);
                param3.Value = GetSetFile_Extention;
                param3.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param3);
                //*************************************
                SqlParameter param4 = new SqlParameter("@KashfDate ", SqlDbType.DateTime);
                param4.Value = Convert.ToDateTime(dateTimePicker1.Value.Date.ToShortDateString());
                param4.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param4);
                //*************************************
                SqlParameter param7 = new SqlParameter("@ImageOrderDetail_image ", SqlDbType.Image);
                param7.Value = imageData;
                param7.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param7);
                //************************************

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //========================================
        private void cmdBrowse_Click_1(object sender, EventArgs e)
        {
           // /Ask user to select file.
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgRes = dlg.ShowDialog();
            if (dlgRes != DialogResult.Cancel)
            {
               
                
                //Provide file path in txtImagePath text box.
                txtImagePath.Text = dlg.FileName;
                string Extension = Path.GetExtension(dlg.FileName);
                //==============
                switch (Extension)
                {
                    case ".bmp":
                        radioButton1.Checked = true;
                        break;
                    case  ".jpg":
                        radioButton1.Checked = true;
                        break;
                    case ".JPG":
                        radioButton1.Checked = true;
                        break;
                    case ".pdf" :
                        radioButton2.Checked = true;
                        break;
                    case  ".PDF":
                        radioButton2.Checked = true;
                        break;

                   
                    case ".doc":
                        radioButton3.Checked = true;
                        GetSetFile_Extention = ".doc";
                        break;
                    case ".docx":
                        radioButton3.Checked = true;
                        GetSetFile_Extention = ".docx";
                        break;
                    case ".xls":
                        radioButton4.Checked = true;
                        GetSetFile_Extention = ".xls";
                        break;
                    case ".xlsx":
                        radioButton4.Checked = true;
                        GetSetFile_Extention = ".xlsx";
                        break;
                    case ".txt":
                        radioButton5.Checked = true;
                        GetSetFile_Extention = ".txt";                        
                        break; 
                    default:
                        MessageBox.Show("من فضلك اختار صيغة مناسبة");
                        return;
                       
                    

                }
                //==============
                //Set image in picture box
                pictureBox1.ImageLocation = dlg.FileName;
                //=================
                bt_Save.Enabled = true;
               // MessageBox.Show("hhh");
                //==========================
              
            }
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
        //===========================
        private void frmNewImage_Load_1(object sender, EventArgs e)
        {
            AutocompleteText_Patient();
            //========================
            radioButton1.Checked = true;
            //=========================
        }
        //================================
        private void bt_new_Click(object sender, EventArgs e)
        {//========================
            radioButton1.Checked = true;
            //=============
            //txt_FileName.Text = "";
            
            pictureBox1.Image = null;
            //pictureBox1.Invalidate();
            tempTheSameflage = false;
           
        }
        //=========================
        private void cmdCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        //=====================
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            tempTheSameflage = true;
            
        }
        //==========================
        private void bt_Find_Click(object sender, EventArgs e)
        {
            
           
            pictureBox1.Image = null;
            //pictureBox1.Invalidate();
            tempTheSameflage = false;
           
            //========================
        }
        //=======================        
		/// <summary> Remove image from screen, dispose object and delete the temporary file. </summary>
	       private void DisposeImage()
	{
				// disable "Save As" menu entry
		Image oldImg = pictureBox1.Image;
		pictureBox1.Image = null;					// empty picture box
		if( oldImg != null )
			oldImg.Dispose();						// dispose old image (free memory, unlock file)

		if( imageFileName != null ) {				// try to delete the temporary image file
			try {
				File.Delete( imageFileName );
			}
			catch( Exception )
			{ }
		}
	}
        //=================================
        private void bt_Scanner_Click(object sender, EventArgs e)
        {
           
            //==================
            WiaClass wiaManager = null;		// WIA manager COM object
            CollectionClass wiaDevs = null;		// WIA devices collection COM object
            ItemClass wiaRoot = null;		// WIA root device COM object
            CollectionClass wiaPics = null;		// WIA collection COM object
            ItemClass wiaItem = null;		// WIA image COM object

            try
            {
                wiaManager = new WiaClass();		// create COM instance of WIA manager

                wiaDevs = wiaManager.Devices as CollectionClass;			// call Wia.Devices to get all devices
                if ((wiaDevs == null) || (wiaDevs.Count == 0))
                {
                    MessageBox.Show(this, " áÇ íæÌÏ ãÇÓÍ ÖæÆì ãÊÕá ÈÇáÌåÇÒ", "WIA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //Application.Exit();
                    return;
                }

                object selectUsingUI = System.Reflection.Missing.Value;			// = Nothing
                wiaRoot = (ItemClass)wiaManager.Create(ref selectUsingUI);	// let user select device
                if (wiaRoot == null)											// nothing to do
                    return;

                // this call shows the common WIA dialog to let the user select a picture:
                wiaPics = wiaRoot.GetItemsFromUI(WiaFlag.SingleImage, WiaIntent.ImageTypeColor) as CollectionClass;
                if (wiaPics == null)
                    return;

                bool takeFirst = true;						// this sample uses only one single picture
                foreach (object wiaObj in wiaPics)			// enumerate all the pictures the user selected
                {
                    if (takeFirst)
                    {
                        DisposeImage();						// remove previous picture
                        wiaItem = (ItemClass)Marshal.CreateWrapperOfType(wiaObj, typeof(ItemClass));
                        imageFileName = Path.GetTempFileName();				// create temporary file for image
                        Cursor.Current = Cursors.WaitCursor;				// could take some time
                        this.Refresh();
                        wiaItem.Transfer(imageFileName, false);			// transfer picture to our temporary file
                        pictureBox1.Image = Image.FromFile(imageFileName);	// create Image instance from file
                      						// enable "Save as" menu entry
                        takeFirst = false;									// first and only one done.
                    }
                    Marshal.ReleaseComObject(wiaObj);					// release enumerated COM object
                }
                string  FileName1 = @"C:\WINDOWS\system\1.bmp";
       		// save to file
                pictureBox1.Image.Save(FileName1);
                txtImagePath.Text = @"C:\WINDOWS\system\1.bmp";
            }
            catch (Exception ee)
            {
                MessageBox.Show(this, "Acquire from WIA Imaging failed\r\n" + ee.Message, "WIA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //Application.Exit();
            }
            finally
            {
                if (wiaItem != null)
                    Marshal.ReleaseComObject(wiaItem);		// release WIA image COM object
                if (wiaPics != null)
                    Marshal.ReleaseComObject(wiaPics);		// release WIA collection COM object
                if (wiaRoot != null)
                    Marshal.ReleaseComObject(wiaRoot);		// release WIA root device COM object
                if (wiaDevs != null)
                    Marshal.ReleaseComObject(wiaDevs);		// release WIA devices collection COM object
                if (wiaManager != null)
                    Marshal.ReleaseComObject(wiaManager);		// release WIA manager COM object
                Cursor.Current = Cursors.Default;				// restore cursor
            }
            //======================
        }
        //=============================
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                GetSetPaper_Kind_Id = 1;
                GetSetFile_Extention = "bmp";
            }
        }
        //=====================
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                GetSetPaper_Kind_Id = 2;
                GetSetFile_Extention = "pdf";
            }
        }
        //==================
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true) GetSetPaper_Kind_Id = 3;
        }
        //=========
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true) GetSetPaper_Kind_Id = 4;
        }
        //================
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true) GetSetPaper_Kind_Id = 5;
        }
        //================================
        private void txt_Name_KeyDown(object sender, KeyEventArgs e)
        {
            //==========================
            if (e.KeyCode == Keys.Enter)
            {
                Search_Patient_Name();              


            }

            //==================
        }
        //=========

    }
}