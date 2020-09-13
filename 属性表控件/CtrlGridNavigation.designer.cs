namespace Base.UI
{
    partial class CtrlGridNavigation
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTotalPages = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tbxCurrentPage = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbFirstPage = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lbPrePage = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lbNextPage = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.lbEnd = new DevExpress.XtraEditors.LabelControl();
            this.lbTotalRows = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cbxRowCount = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxCurrentPage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxRowCount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTotalPages
            // 
            this.lbTotalPages.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalPages.Appearance.Options.UseBackColor = true;
            this.lbTotalPages.Location = new System.Drawing.Point(408, 3);
            this.lbTotalPages.Name = "lbTotalPages";
            this.lbTotalPages.Size = new System.Drawing.Size(60, 18);
            this.lbTotalPages.StyleController = this.layoutControl1;
            this.lbTotalPages.TabIndex = 3;
            this.lbTotalPages.Text = "总页数";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(396, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(6, 18);
            this.labelControl3.StyleController = this.layoutControl1;
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "/";
            // 
            // tbxCurrentPage
            // 
            this.tbxCurrentPage.Location = new System.Drawing.Point(326, 1);
            this.tbxCurrentPage.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.tbxCurrentPage.Name = "tbxCurrentPage";
            this.tbxCurrentPage.Properties.Mask.EditMask = "[0-9]*";
            this.tbxCurrentPage.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.tbxCurrentPage.Size = new System.Drawing.Size(64, 24);
            this.tbxCurrentPage.StyleController = this.layoutControl1;
            this.tbxCurrentPage.TabIndex = 2;
            this.tbxCurrentPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxCurrentPage_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(260, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 18);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "当前页：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(619, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 18);
            this.labelControl2.StyleController = this.layoutControl1;
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "每页显示：";
            // 
            // lbFirstPage
            // 
            this.lbFirstPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbFirstPage.Location = new System.Drawing.Point(3, 3);
            this.lbFirstPage.Name = "lbFirstPage";
            this.lbFirstPage.Size = new System.Drawing.Size(30, 18);
            this.lbFirstPage.StyleController = this.layoutControl1;
            this.lbFirstPage.TabIndex = 7;
            this.lbFirstPage.Text = "首页";
            this.lbFirstPage.Click += new System.EventHandler(this.lbFirstPage_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(39, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(6, 18);
            this.labelControl4.StyleController = this.layoutControl1;
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "|";
            // 
            // lbPrePage
            // 
            this.lbPrePage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbPrePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbPrePage.Location = new System.Drawing.Point(52, -2);
            this.lbPrePage.Name = "lbPrePage";
            this.lbPrePage.Size = new System.Drawing.Size(49, 26);
            this.lbPrePage.StyleController = this.layoutControl1;
            this.lbPrePage.TabIndex = 9;
            this.lbPrePage.Text = "上一页";
            this.lbPrePage.Click += new System.EventHandler(this.lbPrePage_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(109, 3);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(6, 18);
            this.labelControl6.StyleController = this.layoutControl1;
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "|";
            // 
            // lbNextPage
            // 
            this.lbNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbNextPage.Location = new System.Drawing.Point(124, 3);
            this.lbNextPage.Name = "lbNextPage";
            this.lbNextPage.Size = new System.Drawing.Size(45, 18);
            this.lbNextPage.StyleController = this.layoutControl1;
            this.lbNextPage.TabIndex = 12;
            this.lbNextPage.Text = "下一页";
            this.lbNextPage.Click += new System.EventHandler(this.lbNextPage_Click);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(179, 3);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(6, 18);
            this.labelControl9.StyleController = this.layoutControl1;
            this.labelControl9.TabIndex = 13;
            this.labelControl9.Text = "|";
            // 
            // lbEnd
            // 
            this.lbEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbEnd.Location = new System.Drawing.Point(194, 3);
            this.lbEnd.Name = "lbEnd";
            this.lbEnd.Size = new System.Drawing.Size(30, 18);
            this.lbEnd.StyleController = this.layoutControl1;
            this.lbEnd.TabIndex = 14;
            this.lbEnd.Text = "末页";
            this.lbEnd.Click += new System.EventHandler(this.lbEnd_Click);
            // 
            // lbTotalRows
            // 
            this.lbTotalRows.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalRows.Appearance.Options.UseBackColor = true;
            this.lbTotalRows.Location = new System.Drawing.Point(497, 3);
            this.lbTotalRows.Name = "lbTotalRows";
            this.lbTotalRows.Size = new System.Drawing.Size(100, 18);
            this.lbTotalRows.StyleController = this.layoutControl1;
            this.lbTotalRows.TabIndex = 15;
            this.lbTotalRows.Text = "共  条记录";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(813, 33);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lbTotalRows);
            this.layoutControl1.Controls.Add(this.lbEnd);
            this.layoutControl1.Controls.Add(this.labelControl9);
            this.layoutControl1.Controls.Add(this.lbNextPage);
            this.layoutControl1.Controls.Add(this.labelControl6);
            this.layoutControl1.Controls.Add(this.lbPrePage);
            this.layoutControl1.Controls.Add(this.labelControl4);
            this.layoutControl1.Controls.Add(this.lbFirstPage);
            this.layoutControl1.Controls.Add(this.labelControl2);
            this.layoutControl1.Controls.Add(this.cbxRowCount);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.tbxCurrentPage);
            this.layoutControl1.Controls.Add(this.labelControl3);
            this.layoutControl1.Controls.Add(this.lbTotalPages);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(271, 457, 562, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(817, 32);
            this.layoutControl1.TabIndex = 7;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cbxRowCount
            // 
            this.cbxRowCount.EditValue = "全部显示";
            this.cbxRowCount.Location = new System.Drawing.Point(694, 0);
            this.cbxRowCount.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.cbxRowCount.MaximumSize = new System.Drawing.Size(100, 24);
            this.cbxRowCount.MinimumSize = new System.Drawing.Size(100, 24);
            this.cbxRowCount.Name = "cbxRowCount";
            this.cbxRowCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxRowCount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbxRowCount.Size = new System.Drawing.Size(100, 24);
            this.cbxRowCount.TabIndex = 5;
            this.cbxRowCount.SelectedIndexChanged += new System.EventHandler(this.cbxRowCount_SelectedIndexChanged);
            // 
            // CtrlGridNavigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "CtrlGridNavigation";
            this.Size = new System.Drawing.Size(817, 32);
            ((System.ComponentModel.ISupportInitialize)(this.tbxCurrentPage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.layoutControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxRowCount.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbTotalPages;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LabelControl lbTotalRows;
        private DevExpress.XtraEditors.LabelControl lbEnd;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl lbNextPage;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lbPrePage;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lbFirstPage;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit tbxCurrentPage;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.ComboBoxEdit cbxRowCount;
    }
}
