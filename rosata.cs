using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenClinic
{
    public partial class rosata : Form
    {
        public rosata()
        {
            InitializeComponent();
        }

        private void printDocument1_printpage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.rosta, 70,20, 700, 1000);
        }
        private void label12_Click(object sender, EventArgs e)
        {

        }

        //Bitmap Bitmap;
        private void button6_Click(object sender, EventArgs e)
        {
          
            //((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            //if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            //{
                printDocument1.Print();

            //}
            printDialog1.ShowDialog();




            //Panel panel = new Panel();
            //this.Controls.Add(panel);

           // Graphics graphics = panel.CreateGraphics();
            //Size size = this.ClientSize;
            //Bitmap = new Bitmap(size.Width, size.Height, graphics);
            //graphics = Graphics.FromImage(Bitmap);
            //Point point = PointToScreen(panel.Location);
            //graphics.CopyFromScreen(point.X, point.Y, 200, 0, size);
            //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();
           
            //Graphics g = this.CreateGraphics();
            //bam = new Bitmap(this.Size.Width, this.Size.Height, g);
            //Graphics mg = Graphics.FromImage(bam);
            //mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            //printPreviewDialog1.Show();



        }

        private void rosata_Load(object sender, EventArgs e)
        {
           

        }
    }
}
