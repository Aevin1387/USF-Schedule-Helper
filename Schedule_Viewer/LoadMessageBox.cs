using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Schedule_Viewer
{
    public partial class LoadMessageBox : Form
    {
        public int return_val;
        public LoadMessageBox()
        {
            InitializeComponent();
        }

        public void buttonAppend_Click(object sender, EventArgs e)
        {
            return_val =  1;
            this.Close();
        }

        private void buttonOverwrite_Click(object sender, EventArgs e)
        {
            return_val =  2;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            return_val =  -1;
            this.Close();
        }
    }
}
