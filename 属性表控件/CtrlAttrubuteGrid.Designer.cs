using Base.UI;

namespace Engine.UI
{
    partial class CtrlAttrubuteGrid
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
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridSelectAttribute = new DevExpress.XtraGrid.GridControl();
            this.gviewSelect = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridAllAttribute = new DevExpress.XtraGrid.GridControl();
            this.gviewAll = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelButtom = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.ctrlGridNavigation1 = new Base.UI.CtrlGridNavigation();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSelectAttribute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gviewSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllAttribute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gviewAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelButtom)).BeginInit();
            this.panelButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridSelectAttribute);
            this.panelControl1.Controls.Add(this.gridAllAttribute);
            this.panelControl1.Controls.Add(this.panelButtom);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1054, 658);
            this.panelControl1.TabIndex = 2;
            // 
            // gridSelectAttribute
            // 
            this.gridSelectAttribute.Location = new System.Drawing.Point(574, 33);
            this.gridSelectAttribute.MainView = this.gviewSelect;
            this.gridSelectAttribute.Name = "gridSelectAttribute";
            this.gridSelectAttribute.Size = new System.Drawing.Size(453, 354);
            this.gridSelectAttribute.TabIndex = 2;
            this.gridSelectAttribute.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gviewSelect});
            this.gridSelectAttribute.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridSelectAttribute_MouseDown);
            // 
            // gviewSelect
            // 
            this.gviewSelect.GridControl = this.gridSelectAttribute;
            this.gviewSelect.Name = "gviewSelect";
            this.gviewSelect.OptionsBehavior.Editable = false;
            this.gviewSelect.OptionsCustomization.AllowColumnMoving = false;
            this.gviewSelect.OptionsCustomization.AllowFilter = false;
            this.gviewSelect.OptionsCustomization.AllowSort = false;
            this.gviewSelect.OptionsMenu.EnableColumnMenu = false;
            this.gviewSelect.OptionsView.ColumnAutoWidth = false;
            this.gviewSelect.OptionsView.ShowGroupPanel = false;
            this.gviewSelect.DoubleClick += new System.EventHandler(this.gviewSelect_DoubleClick);
            // 
            // gridAllAttribute
            // 
            this.gridAllAttribute.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridAllAttribute.Location = new System.Drawing.Point(58, 43);
            this.gridAllAttribute.MainView = this.gviewAll;
            this.gridAllAttribute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridAllAttribute.Name = "gridAllAttribute";
            this.gridAllAttribute.Size = new System.Drawing.Size(475, 395);
            this.gridAllAttribute.TabIndex = 1;
            this.gridAllAttribute.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gviewAll});
            this.gridAllAttribute.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridAllAttribute_MouseDown);
            // 
            // gviewAll
            // 
            this.gviewAll.GridControl = this.gridAllAttribute;
            this.gviewAll.Name = "gviewAll";
            this.gviewAll.OptionsCustomization.AllowColumnMoving = false;
            this.gviewAll.OptionsCustomization.AllowFilter = false;
            this.gviewAll.OptionsCustomization.AllowSort = false;
            this.gviewAll.OptionsMenu.EnableColumnMenu = false;
            this.gviewAll.OptionsSelection.MultiSelect = true;
            this.gviewAll.OptionsView.ColumnAutoWidth = false;
            this.gviewAll.OptionsView.ShowGroupPanel = false;
            this.gviewAll.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gviewAll_CellValueChanging);
            this.gviewAll.DoubleClick += new System.EventHandler(this.gviewAll_DoubleClick);
            // 
            // panelButtom
            // 
            this.panelButtom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelButtom.Controls.Add(this.panelControl4);
            this.panelButtom.Controls.Add(this.panelControl3);
            this.panelButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtom.Location = new System.Drawing.Point(2, 615);
            this.panelButtom.Margin = new System.Windows.Forms.Padding(0);
            this.panelButtom.Name = "panelButtom";
            this.panelButtom.Size = new System.Drawing.Size(1050, 41);
            this.panelButtom.TabIndex = 0;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.ctrlGridNavigation1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(206, 2);
            this.panelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(842, 37);
            this.panelControl4.TabIndex = 1;
            // 
            // ctrlGridNavigation1
            // 
            this.ctrlGridNavigation1.BindingDataTable = null;
            this.ctrlGridNavigation1.BindingGrid = null;
            this.ctrlGridNavigation1.CurrentPage = 0;
            this.ctrlGridNavigation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlGridNavigation1.Location = new System.Drawing.Point(2, 2);
            this.ctrlGridNavigation1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctrlGridNavigation1.Name = "ctrlGridNavigation1";
            this.ctrlGridNavigation1.RowsCount = 0;
            this.ctrlGridNavigation1.ShowingDataTable = null;
            this.ctrlGridNavigation1.Size = new System.Drawing.Size(838, 33);
            this.ctrlGridNavigation1.TabIndex = 0;
            this.ctrlGridNavigation1.TotalPages = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.radioGroup1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(204, 37);
            this.panelControl3.TabIndex = 0;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup1.Location = new System.Drawing.Point(2, 2);
            this.radioGroup1.Margin = new System.Windows.Forms.Padding(0);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Columns = 2;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "全部属性"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "选中属性")});
            this.radioGroup1.Size = new System.Drawing.Size(200, 33);
            this.radioGroup1.TabIndex = 0;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "全选";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "当前页全选";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "取消选择";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1054, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 658);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1054, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 658);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1054, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 658);
            // 
            // CtrlAttrubuteGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CtrlAttrubuteGrid";
            this.Size = new System.Drawing.Size(1054, 658);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSelectAttribute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gviewSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllAttribute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gviewAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelButtom)).EndInit();
            this.panelButtom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelButtom;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gridAllAttribute;
        private DevExpress.XtraGrid.Views.Grid.GridView gviewAll;
        private Base.UI.CtrlGridNavigation ctrlGridNavigation1;
        private DevExpress.XtraGrid.GridControl gridSelectAttribute;
        private DevExpress.XtraGrid.Views.Grid.GridView gviewSelect;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
