using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SampleMaker.Util;
using SampleMaker.Sample;
using Emgu.CV;
using Emgu.CV.Structure;

namespace SampleMaker
{
    public partial class FormSample : Form
    {
        private string[] backImages = new string[0];
        private int backIndex = 0;
        private string[] sampleImages = new string[0];
        private int sampleIndex = 0;
        private volatile bool ssdFlag = false;
        private FormImageShow formImageShow = new FormImageShow();

        private bool rotateEnabled = true, perspectiveEnabled = true;
        private int minNum = 0, maxNum = 6;

        public FormSample()
        {
            InitializeComponent();
            tbSampleDir.Text = @"E:\pytorch_images\sample_mix";
            tbDstDir.Text = @"E:\pytorch_images\ssd\train2";
        }

        private void setParameters()
        {
            rotateEnabled = cbRotate.Checked;
            perspectiveEnabled = cbPerspective.Checked;

            minNum = (int)numericMinNum.Value;
            maxNum = (int)numericMaxNum.Value;
        }

        private void loadBackImages()
        {
            List<string> images = new List<string>();
            if (cbBackColor.Checked)
            {
                string[] files = Directory.GetFiles("back_color");
                images.AddRange(files);
            }
            if (cbBackWhite.Checked)
            {
                string[] files = Directory.GetFiles("back_white");
                images.AddRange(files);
            }
            backImages = images.ToArray();
            CommonTool.Shuffle(backImages);
            backIndex = 0;
        }

        private void loadSampleImages()
        {
            sampleImages = Directory.GetFiles(tbSampleDir.Text);
            CommonTool.Shuffle(sampleImages);
            sampleIndex = 0;
        }

        private Mat getNextBackImage()
        {
            if(backImages.Length == 0)
            {
                return null;
            }
            var path = backImages[backIndex++];
            if(backIndex == backImages.Length)
            {
                backIndex = 0;
            }
            return CvInvoke.Imread(path);
        }

        private Tuple<Bitmap, string> getNextSample()
        {
            var path = sampleImages[sampleIndex++];
            if (sampleIndex == sampleImages.Length)
            {
                sampleIndex = 0;
            }
            string name = Path.GetFileNameWithoutExtension(path);
            string type = name.Substring(0, name.LastIndexOf('_'));
            return new Tuple<Bitmap, string>(Bitmap.FromFile(path) as Bitmap, type);
        }

        private void startMakeSSD()
        {
            int sampleNum = (int)numericSample.Value;
            progressBarMake.Maximum = sampleNum;
            string dir = tbDstDir.Text;
            createSSDDir(dir);

            int count = 0;
            Task.Run(() =>
            {
                while (ssdFlag && sampleNum>count)
                {
                    var info = makeOneSSD();
                    info.Save(dir);
                    count++;
                    showProgress(count);
                }

                var action = new Action(() =>
                {
                    rtbInfo.AppendText(ssdFlag ? "生成结束！\r\n" : "生成停止");
                    rtbInfo.SelectionStart = rtbInfo.Text.Length;
                    rtbInfo.ScrollToCaret();

                    btnSSD.Text = "SSD样本";
                });

                if (rtbInfo.InvokeRequired)
                {
                    rtbInfo.Invoke(action);
                }
                else
                {
                    action();
                }

            });
        }

        private void createSSDDir(string dir)
        {
            string jpegDir = Path.Combine(dir, "JPEGImages");
            string annotationDir = Path.Combine(dir, "Annotations");
            string imageSetDir = Path.Combine(dir, "ImageSets");
            string classDir = Path.Combine(dir, "SegmentationClass");
            string objectDir = Path.Combine(dir, "SegmentationObject");

            string[] dirs = { jpegDir, annotationDir, imageSetDir, classDir, objectDir };
            foreach(var temp in dirs)
            {
                if (!Directory.Exists(temp))
                {
                    Directory.CreateDirectory(temp);
                }
            }
        }

        private SSDInfo makeOneSSD()
        {
            SSDInfo info = new SSDInfo();
            info.objects = new List<SSDObject>();
            int padding = 3;
            Random random = new Random(Guid.NewGuid().GetHashCode());
            
            // 是否添加背景
            if (backImages.Length == 0 || random.Next(0, 10) == 0)
            {
                var sample = getNextSample();
                var sampleImage = sample.Item1;

                int rotate = random.Next(0, 10);
                if (rotate < 3)
                {
                    float angle = rotate == 0 ? 90 : (rotate == 1 ? -90 : 180);
                    info.Bitmap = ImageHelper.Rotate(sampleImage, angle, Color.Transparent);
                    sampleImage.Dispose();
                }
                else
                {
                    info.Bitmap = sampleImage;
                }
                SSDObject obj = new SSDObject(sample.Item2);
                obj.bndbox.xmin = padding;
                obj.bndbox.ymin = padding;
                obj.bndbox.xmax = info.Bitmap.Width - padding;
                obj.bndbox.ymax = info.Bitmap.Height - padding;
                info.objects.Add(obj);
            }
            else
            {
                Mat back = getNextBackImage();
                double backResizeRatio = random.Next(105, 130) / 100f;
                if(random.Next(0, 2) == 0) // 拉伸Width
                {
                    var temp = EmguHelper.Resize(back, (int)(back.Width * backResizeRatio), back.Height);
                    back.Dispose();
                    back = temp;
                }
                else
                {
                    var temp = EmguHelper.Resize(back, Width, (int)(back.Height * backResizeRatio));
                    back.Dispose();
                    back = temp;
                }


                float len = random.Next(1200, 1500);
                float zoomRatio = Math.Min(back.Width, back.Height) / len;
                var tempBack = EmguHelper.Resize(back, zoomRatio); // 先增大背景图片，最后再缩小
                back.Dispose();

                int maxNum = random.Next(minNum, this.maxNum) ;
                List<Rectangle> parts = new List<Rectangle>();
                int x = 50, y = 50;
                while (--maxNum>=0)
                {
                    GC.Collect();
                    var sample = getNextSample();
                    var sampleImage = sample.Item1;
                    float sampleZoomRatio = Math.Min(sampleImage.Width, sampleImage.Height) / 500f;
                    var tempSampleImage = ImageHelper.ZoomImage(sampleImage, sampleZoomRatio);
                    sampleImage.Dispose();
                    sampleImage = tempSampleImage;

                    if (perspectiveEnabled && random.Next(0, 10) < 3) // 仿射变换概率30%
                    {
                        var temp = warpAffine(sampleImage);
                        sampleImage.Dispose();
                        sampleImage = temp;
                    }
                    if (rotateEnabled && random.Next(0, 10) < 3) // 旋转概率30%
                    {
                        var temp = ImageHelper.Rotate(sampleImage, random.Next(-180, 180), Color.Transparent);
                        sampleImage.Dispose();
                        sampleImage = temp;
                    }
                    Point? loc = findEmpty(parts, x, y, tempBack.Size, sampleImage.Size);
                    if(loc == null)
                    {
                        sampleImage.Dispose();
                        break;
                    }
                    int x0 = loc.Value.X;
                    int y0 = loc.Value.Y;

                    EmguHelper.AddImage(tempBack, sampleImage, loc.Value);
                    SSDObject obj = new SSDObject(sample.Item2);
                    obj.bndbox.xmin = x0+padding;
                    obj.bndbox.ymin = y0+padding;
                    obj.bndbox.xmax = x0+sampleImage.Width - padding;
                    obj.bndbox.ymax = y0+sampleImage.Height - padding;
                    info.objects.Add(obj);
                    parts.Add(obj.bndbox.ToRect());
                    x = x0 + sampleImage.Width;
                    y = y0;

                    sampleImage.Dispose();
                }

                info.Bitmap = ImageHelper.ZoomImage(tempBack.Bitmap, 1 / zoomRatio);
                tempBack.Dispose();

                foreach(var obj in info.objects)
                {
                    obj.bndbox.xmin = (int)(obj.bndbox.xmin * zoomRatio)-1;
                    obj.bndbox.ymin = (int)(obj.bndbox.ymin * zoomRatio) - 1;
                    obj.bndbox.xmax = (int)(obj.bndbox.xmax * zoomRatio) + 1;
                    obj.bndbox.ymax = (int)(obj.bndbox.ymax * zoomRatio) + 1;
                }
            }

            return info;
        }

        private Point? findEmpty(List<Rectangle> parts, int x0, int y0, Size srcSize, Size partSize)
        {
            int x = x0, y = y0;
            Random random = new Random(Guid.NewGuid().GetHashCode());
            while (true)
            {
                if(x+partSize.Width + 100>= srcSize.Width)
                {
                    x = 50;
                    if (y + partSize.Height + 100 >= srcSize.Height)
                    {
                        break;
                    }
                    y += random.Next(50, srcSize.Height - partSize.Height - y);
                }
                else
                {
                    x += random.Next(50, srcSize.Width - partSize.Width - x);
                }
                Rectangle rect = new Rectangle(x, y, partSize.Width, partSize.Height);
                if (!parts.Any(p => p.IntersectsWith(rect)))
                {
                    return new Point(x, y);
                }
            }
            return null;
        }

        private Bitmap drawSSDInfo(SSDInfo info)
        {
            Bitmap tmp = new Bitmap(info.Bitmap.Width+2, info.Bitmap.Height+2);
            Graphics g = Graphics.FromImage(tmp);
            g.DrawImage(info.Bitmap, new Point(1, 1));
            Font font = new Font("宋体", 20, FontStyle.Bold, GraphicsUnit.Pixel);
            g.DrawString(info.objects.Count.ToString(), font, new SolidBrush(Color.Blue), new PointF(10, 10));
            foreach (var obj in info.objects)
            {
                Pen pen = null;
                switch (obj.name)
                {
                    case "train":
                        pen = new Pen(Color.Red, 3);
                        break;
                    default:
                        pen = new Pen(Color.Blue, 3);
                        break;
                }
                var rect = obj.bndbox.ToRect();
                g.DrawRectangle(pen, rect);
                
                g.DrawString(obj.name, font, new SolidBrush(pen.Color), new PointF(rect.X, rect.Y));
            }
            return tmp;
        }

        private Bitmap warpAffine(Bitmap bitmap)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            PointF[] points = new PointF[4];
            points[0] = new PointF(0, 0);
            points[1] = new PointF(bitmap.Width, 0);
            points[2] = new PointF(0, bitmap.Height);
            points[3] = new PointF(bitmap.Width, bitmap.Height);

            float temp = random.Next(0, 20);
            float ratio = temp / 100;
            int flag = random.Next(0, 8);
            switch (flag)
            {
                case 0:
                    points[0] = new PointF(bitmap.Width * ratio, 0);
                    points[3] = new PointF(bitmap.Width*(1 - ratio), bitmap.Height);
                    break;
                case 1:
                    points[1] = new PointF(bitmap.Width * (1 - ratio), 0);
                    points[2] = new PointF(bitmap.Width * ratio, bitmap.Height);
                    break;
                case 2:
                    points[0] = new PointF(0, bitmap.Height * ratio);
                    points[3] = new PointF(bitmap.Width, bitmap.Height * (1 - ratio));
                    break;
                case 3:
                    points[1] = new PointF(bitmap.Width, bitmap.Height * ratio);
                    points[2] = new PointF(0, bitmap.Height * (1 - ratio));
                    break;
                case 4:
                    points[0] = new PointF(bitmap.Width * ratio, 0);
                    points[1] = new PointF(bitmap.Width * (1 - ratio), 0);
                    break;
                case 5:
                    points[2] = new PointF(bitmap.Width * ratio, bitmap.Height);
                    points[3] = new PointF(bitmap.Width * (1 - ratio), bitmap.Height);
                    break;
                case 6:
                    points[1] = new PointF(bitmap.Width, bitmap.Height * ratio);
                    points[3] = new PointF(bitmap.Width, bitmap.Height * (1 - ratio));
                    break;
                case 7:
                    points[0] = new PointF(0, bitmap.Height * ratio);
                    points[2] = new PointF(0, bitmap.Height * (1 - ratio));
                    break;
            }
            var mat = EmguHelper.WarpAffine(bitmap, points);
            var dst = ImageHelper.CloneBitmap(mat.Bitmap);
            mat.Dispose();
            return dst;
        }

        private void showInfo(string info, bool append = true)
        {
            var action = new Action(() =>
            {
                if (append)
                {
                    rtbInfo.AppendText(info + "\r\n");
                    rtbInfo.SelectionStart = rtbInfo.Text.Length;
                    rtbInfo.ScrollToCaret();
                }
                else
                {
                    rtbInfo.Text = info + "\r\n";
                }
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

        private void BtnBrowseSampleDir_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbSampleDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void BtnBrowseDstDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                tbDstDir.Text = folderBrowserDialog2.SelectedPath;
            }
        }

        private void BtnSSD_Click(object sender, EventArgs e)
        {
            if(btnSSD.Text == "生成SSD样本")
            {
                if (!Directory.Exists(tbSampleDir.Text))
                {
                    MessageBox.Show("样本文件夹不存在");
                    return;
                }
                if (!Directory.Exists(tbDstDir.Text))
                {
                    MessageBox.Show("目标文件夹不存在");
                    return;
                }
                setParameters();
                loadBackImages();
                loadSampleImages();

                ssdFlag = true;
                btnSSD.Text = "停止";
                startMakeSSD();

                //var info = makeOneSSD();
                //var bmp = drawSSDInfo(info);
                //formImageShow.ShowImage(bmp);
            }
            else
            {
                ssdFlag = false;
                btnSSD.Text = "生成SSD样本";
            }
        }

        private void BtnRenameToSCE_Click(object sender, EventArgs e)
        {
            string dir = tbSampleDir.Text;
            if (!Directory.Exists(dir))
            {
                MessageBox.Show("样本文件夹不存在");
                return;
            }
            if (MessageBox.Show("确定将所有文件重命名为sce_xxxxxx.jpg格式？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string[] files = Directory.GetFiles(dir);
                    // 先重命名为guid.jpg
                    foreach(var file in files)
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        fileInfo.MoveTo(Path.Combine(dir, $"{Guid.NewGuid()}.jpg"));
                    }

                    files = Directory.GetFiles(dir);
                    // 再重命名为sce.jpg
                    int count = 1;
                    foreach (var file in files)
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        fileInfo.MoveTo(Path.Combine(dir, $"sce_{count++:D6}.jpg"));
                    }
                    showInfo("重命名完毕");
                }
                catch (Exception ex)
                {
                    showInfo(ex.Message);
                }
            }
        }

        private void BtnClearSSD_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tbDstDir.Text))
            {
                if(MessageBox.Show("确定删除样本数据？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string jpegDir = Path.Combine(tbDstDir.Text, "JPEGImages");
                    string annotationDir = Path.Combine(tbDstDir.Text, "Annotations");
                    try
                    {
                        if (Directory.Exists(jpegDir))
                        {
                            Directory.Delete(jpegDir, true);
                            Directory.CreateDirectory(jpegDir);
                        }
                        if (Directory.Exists(annotationDir))
                        {
                            Directory.Delete(annotationDir, true);
                            Directory.CreateDirectory(annotationDir);
                        }
                        showInfo("清除完毕");
                    }
                    catch(Exception ex)
                    {
                        showInfo(ex.Message);
                    }
                }
            }
        }

        private void BtnSSDTxt_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(tbDstDir.Text))
            {
                MessageBox.Show("目标文件夹不存在");
                return;
            }
            string dir = tbDstDir.Text;
            string jpegDir = Path.Combine(dir, "JPEGImages");
            string annotationDir = Path.Combine(dir, "Annotations");
            string imageSetDir = Path.Combine(dir, "ImageSets");
            string classDir = Path.Combine(dir, "SegmentationClass");
            string objectDir = Path.Combine(dir, "SegmentationObject");

            string[] dirs = { jpegDir, annotationDir, imageSetDir, classDir, objectDir };
            foreach (var temp in dirs)
            {
                if (!Directory.Exists(temp))
                {
                    MessageBox.Show($"{temp}不存在");
                }
            }

            string mainDir = Path.Combine(imageSetDir, "Main");
            if (!Directory.Exists(mainDir))
            {
                Directory.CreateDirectory(mainDir);
            }

            string[] images = Directory.GetFiles(jpegDir);
            CommonTool.Shuffle(images);

            string trainTxt = Path.Combine(mainDir, "train.txt");
            string testTxt = Path.Combine(mainDir, "test.txt");
            string trainValTxt = Path.Combine(mainDir, "trainval.txt");
            string valTxt = Path.Combine(mainDir, "val.txt");

            Action<string, int, int> action = new Action<string, int, int>((txtPath, index, num) =>
            {
                if (File.Exists(txtPath))
                {
                    File.Delete(txtPath);
                }
                for (int i = 0; i < num; i++)
                {
                    string image = images[index + i];
                    File.AppendAllLines(txtPath, new string[] { Path.GetFileNameWithoutExtension(image) });
                }
            });
            action(trainTxt, 0, (int)(images.Length *0.7));
            CommonTool.Shuffle(images);
            action(testTxt, 0, (int)(images.Length *0.3));
            CommonTool.Shuffle(images);
            action(trainValTxt, 0, (int)(images.Length *0.8));
            CommonTool.Shuffle(images);
            action(valTxt, 0, (int)(images.Length * 0.2));

            showInfo("完毕", false);
        }
    }
}
