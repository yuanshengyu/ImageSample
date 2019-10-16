namespace SampleMaker
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbTemplatePath = new System.Windows.Forms.TextBox();
            this.btnBrowseTemplatePath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTargetRoot = new System.Windows.Forms.TextBox();
            this.btnBrowseTargetRoot = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericSample = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.progressBarMake = new System.Windows.Forms.ProgressBar();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.cbSampleType = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnTeachTemplate = new System.Windows.Forms.Button();
            this.btnMakeOne = new System.Windows.Forms.Button();
            this.btnCombineSample = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericSample)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "模板路径：";
            // 
            // tbTemplatePath
            // 
            this.tbTemplatePath.Location = new System.Drawing.Point(88, 78);
            this.tbTemplatePath.Name = "tbTemplatePath";
            this.tbTemplatePath.Size = new System.Drawing.Size(587, 21);
            this.tbTemplatePath.TabIndex = 1;
            // 
            // btnBrowseTemplatePath
            // 
            this.btnBrowseTemplatePath.Location = new System.Drawing.Point(690, 75);
            this.btnBrowseTemplatePath.Name = "btnBrowseTemplatePath";
            this.btnBrowseTemplatePath.Size = new System.Drawing.Size(84, 29);
            this.btnBrowseTemplatePath.TabIndex = 2;
            this.btnBrowseTemplatePath.Text = "浏览";
            this.btnBrowseTemplatePath.UseVisualStyleBackColor = true;
            this.btnBrowseTemplatePath.Click += new System.EventHandler(this.BtnBrowseTemplatePath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "生成目录：";
            // 
            // tbTargetRoot
            // 
            this.tbTargetRoot.Location = new System.Drawing.Point(88, 120);
            this.tbTargetRoot.Name = "tbTargetRoot";
            this.tbTargetRoot.Size = new System.Drawing.Size(587, 21);
            this.tbTargetRoot.TabIndex = 1;
            // 
            // btnBrowseTargetRoot
            // 
            this.btnBrowseTargetRoot.Location = new System.Drawing.Point(690, 115);
            this.btnBrowseTargetRoot.Name = "btnBrowseTargetRoot";
            this.btnBrowseTargetRoot.Size = new System.Drawing.Size(84, 29);
            this.btnBrowseTargetRoot.TabIndex = 2;
            this.btnBrowseTargetRoot.Text = "浏览";
            this.btnBrowseTargetRoot.UseVisualStyleBackColor = true;
            this.btnBrowseTargetRoot.Click += new System.EventHandler(this.BtnBrowseTargetRoot_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "类型：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "样本个数：";
            // 
            // numericSample
            // 
            this.numericSample.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericSample.Location = new System.Drawing.Point(88, 193);
            this.numericSample.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericSample.Name = "numericSample";
            this.numericSample.Size = new System.Drawing.Size(120, 21);
            this.numericSample.TabIndex = 7;
            this.numericSample.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(257, 181);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(95, 41);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // progressBarMake
            // 
            this.progressBarMake.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarMake.Location = new System.Drawing.Point(12, 252);
            this.progressBarMake.Name = "progressBarMake";
            this.progressBarMake.Size = new System.Drawing.Size(776, 43);
            this.progressBarMake.TabIndex = 9;
            // 
            // rtbInfo
            // 
            this.rtbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbInfo.Location = new System.Drawing.Point(2, 321);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.Size = new System.Drawing.Size(795, 228);
            this.rtbInfo.TabIndex = 10;
            this.rtbInfo.Text = "";
            // 
            // cbSampleType
            // 
            this.cbSampleType.FormattingEnabled = true;
            this.cbSampleType.Items.AddRange(new object[] {
            "火车票"});
            this.cbSampleType.Location = new System.Drawing.Point(88, 18);
            this.cbSampleType.Name = "cbSampleType";
            this.cbSampleType.Size = new System.Drawing.Size(121, 20);
            this.cbSampleType.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnTeachTemplate
            // 
            this.btnTeachTemplate.Location = new System.Drawing.Point(591, 12);
            this.btnTeachTemplate.Name = "btnTeachTemplate";
            this.btnTeachTemplate.Size = new System.Drawing.Size(84, 41);
            this.btnTeachTemplate.TabIndex = 11;
            this.btnTeachTemplate.Text = "示教模板";
            this.btnTeachTemplate.UseVisualStyleBackColor = true;
            this.btnTeachTemplate.Click += new System.EventHandler(this.BtnTeachTemplate_Click);
            // 
            // btnMakeOne
            // 
            this.btnMakeOne.Location = new System.Drawing.Point(428, 181);
            this.btnMakeOne.Name = "btnMakeOne";
            this.btnMakeOne.Size = new System.Drawing.Size(95, 41);
            this.btnMakeOne.TabIndex = 12;
            this.btnMakeOne.Text = "生成一张";
            this.btnMakeOne.UseVisualStyleBackColor = true;
            this.btnMakeOne.Click += new System.EventHandler(this.BtnMakeOne_Click);
            // 
            // btnCombineSample
            // 
            this.btnCombineSample.Location = new System.Drawing.Point(591, 181);
            this.btnCombineSample.Name = "btnCombineSample";
            this.btnCombineSample.Size = new System.Drawing.Size(95, 41);
            this.btnCombineSample.TabIndex = 13;
            this.btnCombineSample.Text = "样本组合";
            this.btnCombineSample.UseVisualStyleBackColor = true;
            this.btnCombineSample.Click += new System.EventHandler(this.BtnCombineSample_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 553);
            this.Controls.Add(this.btnCombineSample);
            this.Controls.Add(this.btnMakeOne);
            this.Controls.Add(this.btnTeachTemplate);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.progressBarMake);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.numericSample);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSampleType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseTargetRoot);
            this.Controls.Add(this.btnBrowseTemplatePath);
            this.Controls.Add(this.tbTargetRoot);
            this.Controls.Add(this.tbTemplatePath);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "样本生成器";
            ((System.ComponentModel.ISupportInitialize)(this.numericSample)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTemplatePath;
        private System.Windows.Forms.Button btnBrowseTemplatePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTargetRoot;
        private System.Windows.Forms.Button btnBrowseTargetRoot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericSample;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progressBarMake;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.ComboBox cbSampleType;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnTeachTemplate;
        private System.Windows.Forms.Button btnMakeOne;
        private System.Windows.Forms.Button btnCombineSample;
    }
}

