namespace SampleMaker
{
    partial class FormSample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSSD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.tbSampleDir = new System.Windows.Forms.TextBox();
            this.tbDstDir = new System.Windows.Forms.TextBox();
            this.btnBrowseSampleDir = new System.Windows.Forms.Button();
            this.btnBrowseDstDir = new System.Windows.Forms.Button();
            this.progressBarMake = new System.Windows.Forms.ProgressBar();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericSample = new System.Windows.Forms.NumericUpDown();
            this.btnClearSSD = new System.Windows.Forms.Button();
            this.btnSSDTxt = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbBackColor = new System.Windows.Forms.CheckBox();
            this.cbBackWhite = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbRotate = new System.Windows.Forms.CheckBox();
            this.cbPerspective = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericMinNum = new System.Windows.Forms.NumericUpDown();
            this.numericMaxNum = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRenameToSCE = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericSample)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxNum)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSSD
            // 
            this.btnSSD.Location = new System.Drawing.Point(18, 20);
            this.btnSSD.Name = "btnSSD";
            this.btnSSD.Size = new System.Drawing.Size(99, 30);
            this.btnSSD.TabIndex = 0;
            this.btnSSD.Text = "生成SSD样本";
            this.btnSSD.UseVisualStyleBackColor = true;
            this.btnSSD.Click += new System.EventHandler(this.BtnSSD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "样本目录：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "生成目录：";
            // 
            // tbSampleDir
            // 
            this.tbSampleDir.Location = new System.Drawing.Point(95, 22);
            this.tbSampleDir.Name = "tbSampleDir";
            this.tbSampleDir.Size = new System.Drawing.Size(540, 21);
            this.tbSampleDir.TabIndex = 3;
            // 
            // tbDstDir
            // 
            this.tbDstDir.Location = new System.Drawing.Point(95, 56);
            this.tbDstDir.Name = "tbDstDir";
            this.tbDstDir.Size = new System.Drawing.Size(540, 21);
            this.tbDstDir.TabIndex = 3;
            // 
            // btnBrowseSampleDir
            // 
            this.btnBrowseSampleDir.Location = new System.Drawing.Point(653, 20);
            this.btnBrowseSampleDir.Name = "btnBrowseSampleDir";
            this.btnBrowseSampleDir.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSampleDir.TabIndex = 4;
            this.btnBrowseSampleDir.Text = "浏览";
            this.btnBrowseSampleDir.UseVisualStyleBackColor = true;
            this.btnBrowseSampleDir.Click += new System.EventHandler(this.BtnBrowseSampleDir_Click);
            // 
            // btnBrowseDstDir
            // 
            this.btnBrowseDstDir.Location = new System.Drawing.Point(653, 54);
            this.btnBrowseDstDir.Name = "btnBrowseDstDir";
            this.btnBrowseDstDir.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDstDir.TabIndex = 4;
            this.btnBrowseDstDir.Text = "浏览";
            this.btnBrowseDstDir.UseVisualStyleBackColor = true;
            this.btnBrowseDstDir.Click += new System.EventHandler(this.BtnBrowseDstDir_Click);
            // 
            // progressBarMake
            // 
            this.progressBarMake.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarMake.Location = new System.Drawing.Point(12, 294);
            this.progressBarMake.Name = "progressBarMake";
            this.progressBarMake.Size = new System.Drawing.Size(775, 23);
            this.progressBarMake.TabIndex = 5;
            // 
            // rtbInfo
            // 
            this.rtbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbInfo.Location = new System.Drawing.Point(13, 323);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.Size = new System.Drawing.Size(775, 171);
            this.rtbInfo.TabIndex = 6;
            this.rtbInfo.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "样本数：";
            // 
            // numericSample
            // 
            this.numericSample.Location = new System.Drawing.Point(85, 104);
            this.numericSample.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericSample.Name = "numericSample";
            this.numericSample.Size = new System.Drawing.Size(88, 21);
            this.numericSample.TabIndex = 8;
            this.numericSample.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // btnClearSSD
            // 
            this.btnClearSSD.Location = new System.Drawing.Point(18, 74);
            this.btnClearSSD.Name = "btnClearSSD";
            this.btnClearSSD.Size = new System.Drawing.Size(99, 30);
            this.btnClearSSD.TabIndex = 9;
            this.btnClearSSD.Text = "清除SSD样本";
            this.btnClearSSD.UseVisualStyleBackColor = true;
            this.btnClearSSD.Click += new System.EventHandler(this.BtnClearSSD_Click);
            // 
            // btnSSDTxt
            // 
            this.btnSSDTxt.Location = new System.Drawing.Point(18, 129);
            this.btnSSDTxt.Name = "btnSSDTxt";
            this.btnSSDTxt.Size = new System.Drawing.Size(99, 30);
            this.btnSSDTxt.TabIndex = 10;
            this.btnSSDTxt.Text = "生成训练TXT";
            this.btnSSDTxt.UseVisualStyleBackColor = true;
            this.btnSSDTxt.Click += new System.EventHandler(this.BtnSSDTxt_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSSD);
            this.groupBox1.Controls.Add(this.btnSSDTxt);
            this.groupBox1.Controls.Add(this.btnClearSSD);
            this.groupBox1.Location = new System.Drawing.Point(294, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 174);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SSD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "背景：";
            // 
            // cbBackColor
            // 
            this.cbBackColor.AutoSize = true;
            this.cbBackColor.Checked = true;
            this.cbBackColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBackColor.Location = new System.Drawing.Point(73, 146);
            this.cbBackColor.Name = "cbBackColor";
            this.cbBackColor.Size = new System.Drawing.Size(48, 16);
            this.cbBackColor.TabIndex = 13;
            this.cbBackColor.Text = "彩色";
            this.cbBackColor.UseVisualStyleBackColor = true;
            // 
            // cbBackWhite
            // 
            this.cbBackWhite.AutoSize = true;
            this.cbBackWhite.Checked = true;
            this.cbBackWhite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBackWhite.Location = new System.Drawing.Point(127, 146);
            this.cbBackWhite.Name = "cbBackWhite";
            this.cbBackWhite.Size = new System.Drawing.Size(48, 16);
            this.cbBackWhite.TabIndex = 13;
            this.cbBackWhite.Text = "黑色";
            this.cbBackWhite.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "变形：";
            // 
            // cbRotate
            // 
            this.cbRotate.AutoSize = true;
            this.cbRotate.Checked = true;
            this.cbRotate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRotate.Location = new System.Drawing.Point(73, 184);
            this.cbRotate.Name = "cbRotate";
            this.cbRotate.Size = new System.Drawing.Size(48, 16);
            this.cbRotate.TabIndex = 13;
            this.cbRotate.Text = "旋转";
            this.cbRotate.UseVisualStyleBackColor = true;
            // 
            // cbPerspective
            // 
            this.cbPerspective.AutoSize = true;
            this.cbPerspective.Checked = true;
            this.cbPerspective.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPerspective.Location = new System.Drawing.Point(127, 184);
            this.cbPerspective.Name = "cbPerspective";
            this.cbPerspective.Size = new System.Drawing.Size(48, 16);
            this.cbPerspective.TabIndex = 13;
            this.cbPerspective.Text = "透视";
            this.cbPerspective.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "每张背景包含的模板样本个数：";
            // 
            // numericMinNum
            // 
            this.numericMinNum.Location = new System.Drawing.Point(28, 241);
            this.numericMinNum.Name = "numericMinNum";
            this.numericMinNum.Size = new System.Drawing.Size(45, 21);
            this.numericMinNum.TabIndex = 16;
            this.numericMinNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericMaxNum
            // 
            this.numericMaxNum.Location = new System.Drawing.Point(102, 241);
            this.numericMaxNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericMaxNum.Name = "numericMaxNum";
            this.numericMaxNum.Size = new System.Drawing.Size(45, 21);
            this.numericMaxNum.TabIndex = 16;
            this.numericMaxNum.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(79, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "--";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(147, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "（不包含）";
            // 
            // btnRenameToSCE
            // 
            this.btnRenameToSCE.Location = new System.Drawing.Point(512, 91);
            this.btnRenameToSCE.Name = "btnRenameToSCE";
            this.btnRenameToSCE.Size = new System.Drawing.Size(100, 34);
            this.btnRenameToSCE.TabIndex = 18;
            this.btnRenameToSCE.Text = "重命名为专普电";
            this.btnRenameToSCE.UseVisualStyleBackColor = true;
            this.btnRenameToSCE.Click += new System.EventHandler(this.BtnRenameToSCE_Click);
            // 
            // FormSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 506);
            this.Controls.Add(this.btnRenameToSCE);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericMaxNum);
            this.Controls.Add(this.numericMinNum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbPerspective);
            this.Controls.Add(this.cbBackWhite);
            this.Controls.Add(this.cbRotate);
            this.Controls.Add(this.cbBackColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numericSample);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.progressBarMake);
            this.Controls.Add(this.btnBrowseDstDir);
            this.Controls.Add(this.btnBrowseSampleDir);
            this.Controls.Add(this.tbDstDir);
            this.Controls.Add(this.tbSampleDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormSample";
            this.Text = "生成训练样本";
            ((System.ComponentModel.ISupportInitialize)(this.numericSample)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericMinNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSSD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.TextBox tbSampleDir;
        private System.Windows.Forms.TextBox tbDstDir;
        private System.Windows.Forms.Button btnBrowseSampleDir;
        private System.Windows.Forms.Button btnBrowseDstDir;
        private System.Windows.Forms.ProgressBar progressBarMake;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericSample;
        private System.Windows.Forms.Button btnClearSSD;
        private System.Windows.Forms.Button btnSSDTxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbBackColor;
        private System.Windows.Forms.CheckBox cbBackWhite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbRotate;
        private System.Windows.Forms.CheckBox cbPerspective;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericMinNum;
        private System.Windows.Forms.NumericUpDown numericMaxNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRenameToSCE;
    }
}