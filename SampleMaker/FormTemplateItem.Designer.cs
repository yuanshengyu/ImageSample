namespace SampleMaker
{
    partial class FormTemplateItem
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbContent = new System.Windows.Forms.TextBox();
            this.cbIsImage = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnColor = new System.Windows.Forms.Button();
            this.lblFont = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.btnSelectFont = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "内容：";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(109, 278);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(96, 47);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(100, 30);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(132, 21);
            this.tbName.TabIndex = 4;
            // 
            // tbContent
            // 
            this.tbContent.Location = new System.Drawing.Point(100, 126);
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(198, 21);
            this.tbContent.TabIndex = 4;
            // 
            // cbIsImage
            // 
            this.cbIsImage.AutoSize = true;
            this.cbIsImage.Location = new System.Drawing.Point(100, 75);
            this.cbIsImage.Name = "cbIsImage";
            this.cbIsImage.Size = new System.Drawing.Size(60, 16);
            this.cbIsImage.TabIndex = 5;
            this.cbIsImage.Text = "是图片";
            this.cbIsImage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "颜色：";
            // 
            // lblColor
            // 
            this.lblColor.Location = new System.Drawing.Point(89, 173);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(39, 28);
            this.lblColor.TabIndex = 7;
            this.lblColor.Text = "color";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(147, 173);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(58, 28);
            this.btnColor.TabIndex = 8;
            this.btnColor.Text = "选择";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.BtnColor_Click);
            // 
            // lblFont
            // 
            this.lblFont.AutoSize = true;
            this.lblFont.Location = new System.Drawing.Point(45, 231);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(41, 12);
            this.lblFont.TabIndex = 9;
            this.lblFont.Text = "字体：";
            // 
            // btnSelectFont
            // 
            this.btnSelectFont.Location = new System.Drawing.Point(147, 223);
            this.btnSelectFont.Name = "btnSelectFont";
            this.btnSelectFont.Size = new System.Drawing.Size(58, 28);
            this.btnSelectFont.TabIndex = 10;
            this.btnSelectFont.Text = "选择";
            this.btnSelectFont.UseVisualStyleBackColor = true;
            this.btnSelectFont.Click += new System.EventHandler(this.BtnSelectFont_Click);
            // 
            // FormTemplateItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 337);
            this.Controls.Add(this.btnSelectFont);
            this.Controls.Add(this.lblFont);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbIsImage);
            this.Controls.Add(this.tbContent);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FormTemplateItem";
            this.Text = "新增模板项";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbContent;
        private System.Windows.Forms.CheckBox cbIsImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button btnSelectFont;
    }
}