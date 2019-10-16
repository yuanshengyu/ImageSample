using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleMaker
{
    public partial class FormImageShow : Form
    {
        public FormImageShow()
        {
            InitializeComponent();
            this.Visible = false;
        }

        public void ShowImage(Bitmap bitmap)
        {
            this.Visible = true;
            pictureBox1.Image = bitmap;
        }

        private void FormImageShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }
    }
}
