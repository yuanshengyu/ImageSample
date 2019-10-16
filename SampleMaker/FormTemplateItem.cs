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
    public partial class FormTemplateItem : Form
    {
        public string Key
        {
            get
            {
                return tbName.Text;
            }
            set
            {
                tbName.Text = value;
            }
        }

        public string Content
        {
            get
            {
                return tbContent.Text;
            }
            set
            {
                tbContent.Text = value;
            }
        }

        public bool IsImage
        {
            get
            {
                return cbIsImage.Checked;
            }
            set
            {
                cbIsImage.Checked = value;
            }
        }

        public Color ItemColor
        {
            get
            {
                return lblColor.BackColor;
            }
            set
            {
                lblColor.BackColor = value;
            }
        }

        public Font ItemFont
        {
            get
            {
                return lblFont.Font;
            }
            set
            {
                lblFont.Font = value;
            }
        }

        public FormTemplateItem(bool add)
        {
            InitializeComponent();
            ItemColor = Color.Black;
            ItemFont = new Font("宋体", 20, FontStyle.Regular);
            lblColor.Text = "   ";
            tbName.Enabled = add;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = ItemColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ItemColor = colorDialog1.Color;
            }
        }

        private void BtnSelectFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = ItemFont;
            
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                ItemFont = fontDialog1.Font;
            }
        }
    }
}
