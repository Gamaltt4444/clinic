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
    public partial class About_program : Form
    {
        public About_program()
        {
            InitializeComponent();
        }

        private void About_program_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kashf Kashf1 = new Kashf();
            Kashf1.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
