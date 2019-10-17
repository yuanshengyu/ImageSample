using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SampleMaker.Util;
using SampleMaker.Maker;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace SampleMaker
{
    public partial class FormMain : Form
    {
        // 用于保存正在制作的模板
        private string templatePath = string.Empty;
        private string targetRoot = string.Empty;
        private int sampleNum = 0;

        private FormImageShow formImageShow = new FormImageShow();
        private volatile bool runFlag = false;

        public string TemplatePath
        {
            get
            {
                string path = tbTemplatePath.Text;
                return File.Exists(path) ? path : "";
            }
            set
            {
                tbTemplatePath.Text = value;
            }
        }

        public string TargetRoot
        {
            get
            {
                string dir = tbTargetRoot.Text;
                return Directory.Exists(dir) ? dir : "";
            }
            set
            {
                tbTargetRoot.Text = value;
            }
        }

        public FormMain()
        {
            InitializeComponent();
            initController();

            //Font font = new Font("黑体", 30, FontStyle.Regular, GraphicsUnit.Pixel);
            //var bitmap = WordTool.GetBitmap("上海南", Color.Black, font);
            //Bitmap bitmap = QRCodeTool.CreateQRCode("010572491393415088940081299896345173232157648345951266835886597081684566420484023943247082755378267424233867319862829180726275060579536369100982", 4);
            //bitmap = ImageHelper.Rotate(bitmap, -30, Color.Transparent);


            //PointF[] points = new PointF[4];
            //points[0] = new PointF(0, 0);
            //points[1] = new PointF(bitmap.Width, bitmap.Height * 0.2f);
            //points[2] = new PointF(0, bitmap.Height);
            //points[3] = new PointF(bitmap.Width, bitmap.Height * 0.8f);
            //var mat = EmguHelper.WarpAffine(bitmap, points);

            //var bitmap = SealTool.CreateInvoiceSeal("上海测试有限公司", "000000000000000000");

            //formImageShow.ShowImage(bitmap);

            //string[] files = Directory.GetFiles(@"E:\pytorch_images\sce");
            //int count = 1;

            //foreach(var file in files)
            //{
            //    if (!file.EndsWith("jpg"))
            //    {
            //        File.Delete(file);
            //        continue;
            //    }
            //    Bitmap bitmap = Bitmap.FromFile(file) as Bitmap;
            //    if(Math.Min(bitmap.Width, bitmap.Height) > 700)
            //    {
            //        double ratio = Math.Min(bitmap.Width, bitmap.Height) / 660f;
            //        var temp = ImageHelper.ZoomImage(bitmap, ratio);
            //        bitmap.Dispose();
            //        bitmap = temp;
            //    }
            //    ImageHelper.SaveJPEG(bitmap, Path.Combine(@"E:\pytorch_images\sce", $"sce_{count++:D6}.jpg"), 50L);
            //    bitmap.Dispose();
            //    File.Delete(file);
                
            //}

        }

        private void start(BaseMaker maker)
        {
            int index = 1;
            string[] files = Directory.GetFiles(targetRoot);
            if (files.Length > 0)
            {
                List<string> names = files.Select(file => Path.GetFileNameWithoutExtension(file)).OrderByDescending(x => x).ToList();
                string temp = names[0].Substring(names[0].LastIndexOf('_') + 1);
                index = int.Parse(temp) + 1;
            }

            int count = 0;
            runFlag = true;
            Task.Run(() =>
            {
                try
                {
                    while (runFlag && count < sampleNum)
                    {
                        using (Bitmap bitmap = maker.MakeOne())
                        {
                            string path = Path.Combine(targetRoot, string.Format("{0}_{1:D6}.jpg", maker.getName(), index++));
                            bitmap.Save(path);
                        }
                        showProgress(++count);
                        Thread.Sleep(10);
                    }
                    // 可在此处保存样本内容数据
                }
                catch(Exception ex)
                {
                    showInfo(ex.Message);
                }
                complete();
            });
        }

        private void stop()
        {
            runFlag = false;
        }

        private void complete()
        {
            var action = new Action(() =>
            {
                rtbInfo.AppendText("生成结束！\r\n");
                rtbInfo.SelectionStart = rtbInfo.Text.Length;
                rtbInfo.ScrollToCaret();

                btnStart.Text = "开始";
            });

            if (rtbInfo.InvokeRequired)
            {
                rtbInfo.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private BaseMaker getMaker()
        {
            var items = parseTemplateItems(TemplatePath);
            BaseMaker maker = null;
            if(cbSampleType.Text == "火车票")
            {
                maker = new TrainMaker();
            }
            else if(cbSampleType.Text == "专票")
            {
                maker = new SpecialInvoiceMaker();
            }
            if (maker != null)
            {
                string msg = maker.Check(items);
                if (msg != string.Empty)
                {
                    MessageBox.Show(msg);
                    return null;
                }
                maker.SetTemplate(TemplatePath, items);
            }
            return maker;
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

        private void initController()
        {
            cbSampleType.SelectedIndex = 0;
        }

        private void showInfo(string info)
        {
            var action = new Action(() =>
            {
                rtbInfo.AppendText(info + "\r\n");
                rtbInfo.SelectionStart = rtbInfo.Text.Length;
                rtbInfo.ScrollToCaret();
            });

            if (rtbInfo.InvokeRequired)
            {
                rtbInfo.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void showProgress(int count)
        {
            var action = new Action(() =>
            {
                progressBarMake.Value = count;
            });

            if (progressBarMake.InvokeRequired)
            {
                progressBarMake.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void showImage(Bitmap bitmap)
        {
            formImageShow.ShowImage(bitmap);
        }

        private void BtnBrowseTemplatePath_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TemplatePath = openFileDialog1.FileName;
            }
        }

        private void BtnBrowseTargetRoot_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TargetRoot = folderBrowserDialog1.SelectedPath;
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (runFlag)
            {
                stop();
                btnStart.Text = "开始";
            }
            else
            {
                if (string.IsNullOrEmpty(TemplatePath))
                {
                    MessageBox.Show("模板文件不存在");
                    return;
                }
                if (string.IsNullOrEmpty(TargetRoot))
                {
                    MessageBox.Show("目标路径不存在");
                    return;
                }
                var maker = getMaker();
                if (maker == null)
                {
                    MessageBox.Show("未找到制作器");
                    return;
                }
                btnStart.Text = "停止";
                
                templatePath = TemplatePath;
                targetRoot = TargetRoot;
                sampleNum = (int)(numericSample.Value);
                progressBarMake.Value = 0;
                progressBarMake.Maximum = sampleNum;
                start(maker);
            }
        }

        private void BtnTeachTemplate_Click(object sender, EventArgs e)
        {
            FormTeach formTeach = new FormTeach();
            formTeach.TemplatePath = TemplatePath;
            formTeach.Show();
        }

        private void BtnMakeOne_Click(object sender, EventArgs e)
        {
            if (!File.Exists(TemplatePath))
            {
                MessageBox.Show("模板文件不存在");
                return;
            }
            string templateItemsPath = getTemplateItemsPath(TemplatePath);
            if (!File.Exists(templateItemsPath))
            {
                MessageBox.Show("模板参数文件不存在");
                return;
            }

            var maker = getMaker();
            if(maker == null)
            {
                MessageBox.Show("未找到制作器");
                return;
            }
            Bitmap bitmap = maker.MakeOne();
            showImage(bitmap);
        }

        private void BtnCombineSample_Click(object sender, EventArgs e)
        {
            FormSample form = new FormSample();
            form.Show();
        }
    }
}
