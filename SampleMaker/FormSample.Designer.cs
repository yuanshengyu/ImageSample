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
            ((System.ComponentModel.ISupportInitialize)(this.numericSample)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSSD
            // 
            this.btnSSD.Location = new System.Drawing.Point(12, 153);
            this.btnSSD.Name = "btnSSD";
            this.btnSSD.Size = new System.Drawing.Size(74, 30);
            this.btnSSD.TabIndex = 0;
            this.btnSSD.Text = "SSD样本";
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
            this.progressBarMake.Location = new System.Drawing.Point(12, 202);
            this.progressBarMake.Name = "progressBarMake";
            this.progressBarMake.Size = new System.Drawing.Size(775, 23);
            this.progressBarMake.TabIndex = 5;
            // 
            // rtbInfo
            // 
            this.rtbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbInfo.Location = new System.Drawing.Point(13, 231);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.Size = new System.Drawing.Size(775, 263);
            this.rtbInfo.TabIndex = 6;
            this.rtbInfo.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "样本数：";
            // 
            // numericSample
            // 
            this.numericSample.Location = new System.Drawing.Point(85, 91);
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
            this.btnClearSSD.Location = new System.Drawing.Point(99, 153);
            this.btnClearSSD.Name = "btnClearSSD";
            this.btnClearSSD.Size = new System.Drawing.Size(99, 30);
            this.btnClearSSD.TabIndex = 9;
            this.btnClearSSD.Text = "清除SSD样本";
            this.btnClearSSD.UseVisualStyleBackColor = true;
            this.btnClearSSD.Click += new System.EventHandler(this.BtnClearSSD_Click);
            // 
            // btnSSDTxt
            // 
            this.btnSSDTxt.Location = new System.Drawing.Point(220, 153);
            this.btnSSDTxt.Name = "btnSSDTxt";
            this.btnSSDTxt.Size = new System.Drawing.Size(99, 30);
            this.btnSSDTxt.TabIndex = 10;
            this.btnSSDTxt.Text = "生成训练TXT";
            this.btnSSDTxt.UseVisualStyleBackColor = true;
            this.btnSSDTxt.Click += new System.EventHandler(this.BtnSSDTxt_Click);
            // 
            // FormSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 506);
            this.Controls.Add(this.btnSSDTxt);
            this.Controls.Add(this.btnClearSSD);
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
            this.Controls.Add(this.btnSSD);
            this.Name = "FormSample";
            this.Text = "生成样本";
            ((System.ComponentModel.ISupportInitialize)(this.numericSample)).EndInit();
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
    }
}