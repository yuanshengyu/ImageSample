namespace SampleMaker
{
    partial class FormTeach
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
            this.components = new System.ComponentModel.Container();
            this.pictureBoxTemplate = new System.Windows.Forms.PictureBox();
            this.listViewItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.tbTemplatePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericX = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericY = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyAllKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericY)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxTemplate
            // 
            this.pictureBoxTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxTemplate.Location = new System.Drawing.Point(3, 94);
            this.pictureBoxTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxTemplate.Name = "pictureBoxTemplate";
            this.pictureBoxTemplate.Size = new System.Drawing.Size(630, 487);
            this.pictureBoxTemplate.TabIndex = 0;
            this.pictureBoxTemplate.TabStop = false;
            // 
            // listViewItems
            // 
            this.listViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewItems.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewItems.HideSelection = false;
            this.listViewItems.Location = new System.Drawing.Point(654, 94);
            this.listViewItems.MultiSelect = false;
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(232, 487);
            this.listViewItems.TabIndex = 1;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            this.listViewItems.View = System.Windows.Forms.View.Details;
            this.listViewItems.SelectedIndexChanged += new System.EventHandler(this.ListViewItems_SelectedIndexChanged);
            this.listViewItems.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ListViewItems_PreviewKeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "模板项";
            this.columnHeader1.Width = 170;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "模板图片：";
            // 
            // tbTemplatePath
            // 
            this.tbTemplatePath.Location = new System.Drawing.Point(84, 10);
            this.tbTemplatePath.Name = "tbTemplatePath";
            this.tbTemplatePath.Size = new System.Drawing.Size(599, 21);
            this.tbTemplatePath.TabIndex = 3;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(701, 8);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(80, 29);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "浏览";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "高度：";
            // 
            // numericHeight
            // 
            this.numericHeight.Location = new System.Drawing.Point(247, 58);
            this.numericHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericHeight.Name = "numericHeight";
            this.numericHeight.Size = new System.Drawing.Size(73, 21);
            this.numericHeight.TabIndex = 6;
            this.numericHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericHeight.ValueChanged += new System.EventHandler(this.NumericHeight_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "X:";
            // 
            // numericX
            // 
            this.numericX.Location = new System.Drawing.Point(32, 41);
            this.numericX.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericX.Name = "numericX";
            this.numericX.ReadOnly = true;
            this.numericX.Size = new System.Drawing.Size(85, 21);
            this.numericX.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Y:";
            // 
            // numericY
            // 
            this.numericY.Location = new System.Drawing.Point(32, 67);
            this.numericY.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericY.Name = "numericY";
            this.numericY.ReadOnly = true;
            this.numericY.Size = new System.Drawing.Size(85, 21);
            this.numericY.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(806, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 29);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(654, 60);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(62, 30);
            this.btnAddItem.TabIndex = 8;
            this.btnAddItem.Text = "新增";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(811, 58);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(62, 30);
            this.btnRemoveItem.TabIndex = 8;
            this.btnRemoveItem.Text = "删除";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.BtnRemoveItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(733, 60);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(62, 30);
            this.btnEditItem.TabIndex = 8;
            this.btnEditItem.Text = "编辑";
            this.btnEditItem.UseVisualStyleBackColor = true;
            this.btnEditItem.Click += new System.EventHandler(this.BtnEditItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditToolStripMenuItem,
            this.CopyToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.CopyAllKeyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.EditToolStripMenuItem.Text = "编辑";
            this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CopyToolStripMenuItem.Text = "复制";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DeleteToolStripMenuItem.Text = "删除";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // CopyAllKeyToolStripMenuItem
            // 
            this.CopyAllKeyToolStripMenuItem.Name = "CopyAllKeyToolStripMenuItem";
            this.CopyAllKeyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CopyAllKeyToolStripMenuItem.Text = "复制所有Key";
            this.CopyAllKeyToolStripMenuItem.Click += new System.EventHandler(this.CopyAllKeyToolStripMenuItem_Click);
            // 
            // FormTeach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 593);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnEditItem);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numericY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbTemplatePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewItems);
            this.Controls.Add(this.pictureBoxTemplate);
            this.Name = "FormTeach";
            this.Text = "模板参数示教器";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormTeach_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormTeach_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericY)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTemplate;
        private System.Windows.Forms.ListView listViewItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTemplatePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericY;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyAllKeyToolStripMenuItem;
    }
}

