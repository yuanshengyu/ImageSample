using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using SampleMaker.Util;

namespace SampleMaker
{
    public partial class FormTeach : Form
    {

        private Dictionary<string, PictureBox> pictureBoxes = new Dictionary<string, PictureBox>();
        private Dictionary<string, TemplateItem> templateItems = new Dictionary<string, TemplateItem>();

        private PictureBox selectedPictureBox = null;
        private int xPos = 0, yPos = 0;
        private bool moveFlag = false;

        public string TemplatePath
        {
            get
            {
                return tbTemplatePath.Text;
            }
            set
            {
                tbTemplatePath.Text = value;
                refreshTemplate();
            }
        }

        public FormTeach()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void refreshTemplate()
        {
            if (!File.Exists(TemplatePath))
            {
                return;
            }
            if (pictureBoxTemplate.Image != null)
            {
                pictureBoxTemplate.Image.Dispose();
            }
            Image bitmap = Bitmap.FromFile(TemplatePath);
            pictureBoxTemplate.Size = new Size(bitmap.Width, bitmap.Height);
            pictureBoxTemplate.Image = bitmap;
            foreach (var entry in pictureBoxes)
            {
                entry.Value.Image.Dispose();
            }
            pictureBoxes.Clear();
            this.templateItems.Clear();

            listViewItems.SuspendLayout();
            listViewItems.Items.Clear();
            Dictionary<string, TemplateItem> tempItems = parseTemplateItems(TemplatePath);
            foreach (var entry in tempItems)
            {
                addTemplateItem(entry.Key, entry.Value);
            }
            listViewItems.ResumeLayout();
        }

        private void addTemplateItem(string key, TemplateItem templateItem)
        {
            ListViewItem item = new ListViewItem(key);
            listViewItems.Items.Add(item);
            Bitmap bitmap2 = getTemplateItemImage(TemplatePath, templateItem);
            var pictureBox = addPictureBox(key, bitmap2, templateItem.X, templateItem.Y);
            pictureBox.Tag = templateItem;
            pictureBox.Size = new Size(bitmap2.Width, bitmap2.Height);
            templateItems[key] = templateItem;
        }

        private Bitmap getTemplateItemImage(string templatePath, TemplateItem item)
        {
            Bitmap bitmap = null;
            if (item.IsImage)
            {
                string imagePath = Path.Combine(Path.GetDirectoryName(templatePath), item.Content);
                bitmap = Bitmap.FromFile(imagePath) as Bitmap;
                double ratio = (double)bitmap.Height / item.Height;
                Bitmap newBitmap = ImageHelper.ZoomImage(bitmap, ratio);
                bitmap.Dispose();
                bitmap = newBitmap;
            }
            else
            {
                Font font = new Font(item.FontName, item.FontSize, item.FontStyle);
                Color color = ColorTool.ToColor(item.ColorHex);
                bitmap = WordTool.GetBitmap(item.Content, color, font);
            }

            return bitmap;
        }

        private void redrawImage(PictureBox pictureBox, TemplateItem templateItem)
        {
            Bitmap bitmap = getTemplateItemImage(TemplatePath, templateItem);
            pictureBox.Image.Dispose();
            pictureBox.Image = bitmap;
            pictureBox.Size = new Size(bitmap.Width, bitmap.Height);
        }

        private PictureBox addPictureBox(string key, Bitmap bitmap, int x = 0, int y = 0)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Location = new Point(x == 0 ? 10 : x, y == 0 ? 10 : y);
            pictureBox.Margin = new System.Windows.Forms.Padding(0);
            pictureBox.Size = new Size(bitmap.Width, bitmap.Height);
            pictureBox.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox.Image = bitmap;
            pictureBox.Click += PictureBox_Click;
            pictureBoxes[key] = pictureBox;
            pictureBoxTemplate.Controls.Add(pictureBox);
            return pictureBox;
        }

        private void changeSelectedPictureBox(PictureBox newPictureBox)
        {
            if (selectedPictureBox != null)
            {
                selectedPictureBox.BorderStyle = BorderStyle.None;
                registerPictureBoxMoveEvent(selectedPictureBox, false);
            }
            selectedPictureBox = null;

            TemplateItem templateItem = newPictureBox.Tag as TemplateItem;
            newPictureBox.BorderStyle = BorderStyle.FixedSingle;
            numericX.Value = newPictureBox.Left;
            numericY.Value = newPictureBox.Top;

            numericHeight.Value = templateItem.IsImage ? newPictureBox.Height : (decimal)templateItem.FontSize;
            registerPictureBoxMoveEvent(newPictureBox, true);
            selectedPictureBox = newPictureBox;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox newPictureBox = sender as PictureBox;
            changeSelectedPictureBox(newPictureBox);
            //TemplateItem templateItem = newPictureBox.Tag as TemplateItem;
            //listViewItems.Focus();
            //foreach (ListViewItem item in listViewItems.Items)
            //{
            //    var temp = templateItems[item.Text];
            //    if(temp == templateItem)
            //    {
            //        item.Selected = true;
            //        item.Focused = true;
            //        break;
            //    }
            //}
        }

        private Dictionary<string, TemplateItem> parseTemplateItems(string templatePath)
        {
            string templateItemsPath = getTemplateItemsPath(templatePath);
            if (File.Exists(templateItemsPath))
            {
                string content = File.ReadAllText(templateItemsPath);
                if (content != string.Empty)
                {
                    return JsonConvert.DeserializeObject<Dictionary<string, TemplateItem>>(content);
                }
            }
            return new Dictionary<string, TemplateItem>();
        }

        private string getTemplateItemsPath(string templatePath)
        {
            if (!File.Exists(templatePath))
            {
                return string.Empty;
            }
            string dir = Path.GetDirectoryName(templatePath);
            string templateName = Path.GetFileNameWithoutExtension(templatePath);
            return Path.Combine(dir, templateName + "_items.json");
        }

        private void registerPictureBoxMoveEvent(PictureBox pictureBox, bool flag)
        {
            if (flag)
            {
                pictureBox.MouseDown += picBox_MouseDown;
                pictureBox.MouseUp += picBox_MouseUp;
                pictureBox.MouseMove += picBox_MouseMove;
            }
            else
            {
                pictureBox.MouseDown -= picBox_MouseDown;
                pictureBox.MouseUp -= picBox_MouseUp;
                pictureBox.MouseMove -= picBox_MouseMove;
            }
        }

        private void moveAll(int xStep, int yStep)
        {
            foreach(var pictureBox in pictureBoxes.Values)
            {
                movePictureBox(pictureBox, xStep, yStep);
            }
        }

        private void movePictureBox(PictureBox pictureBox, int xStep, int yStep)
        {
            if (pictureBox.Left + xStep < 0)
            {
                pictureBox.Left = 0;
            }
            else if (pictureBox.Left + xStep > pictureBoxTemplate.Width - pictureBox.Width)
            {
                pictureBox.Left = pictureBoxTemplate.Width - pictureBox.Width;
            }
            else
            {
                pictureBox.Left += xStep;//设置x坐标.
            }
            if (pictureBox.Top + yStep < 0)
            {
                pictureBox.Top = 0;
            }
            else if (pictureBox.Top + yStep > pictureBoxTemplate.Height - pictureBox.Height)
            {
                pictureBox.Top = pictureBoxTemplate.Height - pictureBox.Height;
            }
            else
            {
                pictureBox.Top += yStep;//设置y坐标.
            }
            numericX.Value = pictureBox.Left;
            numericY.Value = pictureBox.Top;
            TemplateItem item = pictureBox.Tag as TemplateItem;
            item.X = pictureBox.Left;
            item.Y = pictureBox.Top;
        }

        private void editItem(TemplateItem templateItem, string name)
        {
            FormTemplateItem form = new FormTemplateItem(false);
            form.Name = name;
            form.Content = templateItem.Content;
            form.ItemColor = ColorTool.ToColor(templateItem.ColorHex);
            form.ItemFont = new Font(templateItem.FontName, templateItem.FontSize, templateItem.FontStyle);

            if (form.ShowDialog() == DialogResult.OK)
            {
                templateItem.Content = form.Content;
                templateItem.ColorHex = ColorTool.ToHex(form.ItemColor);
                templateItem.FontName = form.ItemFont.Name;
                templateItem.FontSize = form.ItemFont.Size;
                templateItem.FontStyle = form.ItemFont.Style;
                PictureBox pictureBox = pictureBoxes[name];
                redrawImage(pictureBox, templateItem);
            }
        }

        private void addNewItem(FormTemplateItem form)
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                string key = form.Key;
                string content = form.Content;
                bool isImage = form.IsImage;
                Color color = form.ItemColor;
                Font font = form.ItemFont;
                if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(content))
                {
                    return;
                }
                if (isImage)
                {
                    string imagePath = Path.Combine(Path.GetDirectoryName(TemplatePath), content);
                    if (!File.Exists(imagePath))
                    {
                        MessageBox.Show("图片不存在");
                        return;
                    }
                }

                TemplateItem item = new TemplateItem();
                item.IsImage = isImage;
                item.Content = content;
                item.X = 10;
                item.Y = 10;
                item.Height = pictureBoxTemplate.Height / 10;
                item.ColorHex = ColorTool.ToHex(color);
                item.FontName = font.Name;
                item.FontStyle = font.Style;
                item.FontSize = font.Size;
                addTemplateItem(key, item);
            }
        }

        private int getIntValue(NumericUpDown num)
        {
            return (int)num.Value;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TemplatePath = openFileDialog1.FileName;
            }
        }

        private void BtnRedraw_Click(object sender, EventArgs e)
        {
            if (selectedPictureBox == null)
            {
                return;
            }
            TemplateItem templateItem = selectedPictureBox.Tag as TemplateItem;
            redrawImage(selectedPictureBox, templateItem);
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(TemplatePath))
            {
                MessageBox.Show("模板不存在");
                return;
            }
            FormTemplateItem form = new FormTemplateItem(true);
            addNewItem(form);
        }

        private void BtnEditItem_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedIndices.Count == 0)
            {
                MessageBox.Show("请先选中要编辑的项");
                return;
            }

            int index = listViewItems.SelectedIndices[0];
            ListViewItem item = listViewItems.Items[index];
            TemplateItem templateItem = templateItems[item.Text];
            editItem(templateItem, item.Text);
        }

        private void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedIndices.Count == 0)
            {
                MessageBox.Show("请先选中要删除的项");
                return;
            }

            int index = listViewItems.SelectedIndices[0];
            ListViewItem item = listViewItems.Items[index];

            PictureBox pictureBox = pictureBoxes[item.Text];
            pictureBox.Image.Dispose();
            registerPictureBoxMoveEvent(pictureBox, false);
            pictureBox.Dispose();
            pictureBox = null;
            selectedPictureBox = null;
            pictureBoxes.Remove(item.Text);
            templateItems.Remove(item.Text);
            listViewItems.Items.RemoveAt(index);

            numericHeight.Value = 0;
            numericX.Value = 0;
            numericY.Value = 0;

            if (listViewItems.Items.Count > 0)
            {
                listViewItems.Select();
            }
        }

        private void ListViewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewItems.SelectedIndices.Count == 0)
            {
                return;
            }
            int index = listViewItems.SelectedIndices[0];
            ListViewItem item = listViewItems.Items[index];
            PictureBox pictureBox = pictureBoxes[item.Text];
            changeSelectedPictureBox(pictureBox);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string path = getTemplateItemsPath(TemplatePath);
            if (path == string.Empty)
            {
                MessageBox.Show("请先选择模板");
                return;
            }
            foreach(var entry in templateItems)
            {
                PictureBox pictureBox = pictureBoxes[entry.Key];
                entry.Value.Height = pictureBox.Height;
            }
            string json = JsonConvert.SerializeObject(templateItems);
            File.WriteAllText(path, json);
        }

        private void NumericHeight_ValueChanged(object sender, EventArgs e)
        {
            if (selectedPictureBox == null)
            {
                return;
            }
            TemplateItem item = selectedPictureBox.Tag as TemplateItem;
            if (item.IsImage)
            {
                item.Height = getIntValue(numericHeight);
            }
            else
            {
                item.FontSize = getIntValue(numericHeight);
            }
            redrawImage(selectedPictureBox, item);
        }

        private void FormTeach_KeyDown(object sender, KeyEventArgs e)
        {
            if (selectedPictureBox == null)
            {
                return;
            }
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                movePictureBox(selectedPictureBox, 0, 1);
            }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                movePictureBox(selectedPictureBox, -1, 0);
            }
            if (e.KeyCode == Keys.D | e.KeyCode == Keys.Right)
            {
                movePictureBox(selectedPictureBox, 1, 0);
            }
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                movePictureBox(selectedPictureBox, 0, -1);
            }
        }

        private void FormTeach_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                e.IsInputKey = true;
        }

        //在picturebox的鼠标按下事件里,记录三个变量.
        private void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            moveFlag = true;//已经按下.
            xPos = e.X;//当前x坐标.
            yPos = e.Y;//当前y坐标.
        }

        //在picturebox的鼠标按下事件里.
        private void picBox_MouseUp(object sender, MouseEventArgs e)
        {
            moveFlag = false;
        }

        private void ListViewItems_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                e.IsInputKey = true;
        }

        //在picturebox鼠标移动
        private void picBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveFlag)
            {
                if (selectedPictureBox == null)
                {
                    return;
                }
                movePictureBox(selectedPictureBox, e.X - xPos, e.Y - yPos);
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedIndices.Count == 0)
            {
                MessageBox.Show("请先选中要编辑的项");
                return;
            }

            int index = listViewItems.SelectedIndices[0];
            ListViewItem item = listViewItems.Items[index];
            TemplateItem templateItem = templateItems[item.Text];
            editItem(templateItem, item.Text);
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedIndices.Count == 0)
            {
                MessageBox.Show("请先选中要复制的项");
                return;
            }

            int index = listViewItems.SelectedIndices[0];
            ListViewItem item = listViewItems.Items[index];
            TemplateItem src = templateItems[item.Text];

            FormTemplateItem form = new FormTemplateItem(true);
            form.Key = item.Text + " copy";
            form.Name = item.Text+" copy";
            form.Content = src.Content;
            form.ItemColor = ColorTool.ToColor(src.ColorHex);
            form.ItemFont = new Font(src.FontName, src.FontSize, src.FontStyle);
            form.IsImage = src.IsImage;

            addNewItem(form);
        }

        private void CopyAllKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var key in templateItems.Keys)
            {
                sb.Append("\"").Append(key).Append("\", ");
            }
            Clipboard.SetDataObject(sb.ToString(), true);
        }

        private void BtnMoveAllLeft_Click(object sender, EventArgs e)
        {
            moveAll(-1, 0);
        }

        private void BtnMoveAllRight_Click(object sender, EventArgs e)
        {
            moveAll(1, 0);
        }

        private void BtnMoveAllUp_Click(object sender, EventArgs e)
        {
            moveAll(-1, 0);
        }

        private void BtnMoveAllDown_Click(object sender, EventArgs e)
        {
            moveAll(1, 0);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnRemoveItem_Click(null, null);
        }
    }
}
