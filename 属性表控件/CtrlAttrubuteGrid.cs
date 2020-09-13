using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.Geometry;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ESRI.ArcGIS.Controls;

namespace Engine.UI
{
    public partial class CtrlAttrubuteGrid : XtraUserControl
    {
        #region 定义事件
        private IActiveViewEvents_Event pActiveViewEvents;
        #endregion

        #region 定义属性
        public IMapControl4 BindingMapControl
        {
            get;private set;
        }

        /// <summary>
        /// 属性表页面标签，0表示所有属性表，1表示选择要素的属性表
        /// </summary>
        public int PageTag
        {
            get; private set;
        }

        /// <summary>
        /// 所有属性的表控件
        /// </summary>
        public GridControl AllDataGrid
        {
            get { return gridAllAttribute; }
        }

        /// <summary>
        /// 选择属性的表控件
        /// </summary>
        public GridControl SelectionDataGrid
        {
            get { return gridSelectAttribute; }
        }

        /// <summary>
        /// 所有属性的数据表
        /// </summary>
        public DataTable AllAttTable
        {
            get { return allRowsTable; }
        }

        /// <summary>
        /// 选择属性的数据表
        /// </summary>
        public DataTable SelectionAttTable
        {
            get { return selectionRowsTable; }
        }
        #endregion

        #region 私有变量定义
        private IQueryFilter queryFilter;
        private ISpatialFilter spatialFilter;
        private DataTable allRowsTable;
        private DataTable selectionRowsTable;
        private IFeatureLayer featureLayer;
        private List<int> selectIDList = new List<int>();
        private string oidFieldName;
        #endregion

        public CtrlAttrubuteGrid(IMapControl4 pMapControl, ref IFeatureLayer pFeatureLayer, IQueryFilter pQueryFilter)
        {
            try
            {
                InitializeComponent();
                if (pFeatureLayer == null)
                {
                    return;
                }
                queryFilter = pQueryFilter;
                spatialFilter = pQueryFilter as ISpatialFilter;
                featureLayer = pFeatureLayer;
                oidFieldName = (featureLayer.FeatureClass as ITable).OIDFieldName;
                selectionRowsTable = GetSelectionRowsTable(featureLayer);
                allRowsTable = CteateCtrlAttributeTable(featureLayer);
                allRowsTable.DefaultView.Sort = oidFieldName + " ASC";
                allRowsTable = allRowsTable.DefaultView.ToTable();
                selectionRowsTable.DefaultView.Sort = oidFieldName + " ASC";
                selectionRowsTable = selectionRowsTable.DefaultView.ToTable();
                allRowsTable.PrimaryKey = new DataColumn[] { allRowsTable.Columns[oidFieldName] };
                selectionRowsTable.PrimaryKey = new DataColumn[] { selectionRowsTable.Columns[oidFieldName] };

                gridAllAttribute.DataSource = allRowsTable;
                gridSelectAttribute.DataSource = selectionRowsTable;
                gviewSelect.Columns[0].Visible = false;
                gridAllAttribute.Visible = true;
                gridAllAttribute.Dock = DockStyle.Fill;
                gridAllAttribute.Refresh();
                gridAllAttribute.RefreshDataSource();
                gridSelectAttribute.Visible = false;
                ctrlGridNavigation1.InitCtrl(allRowsTable, gridAllAttribute, new int[] { 50, 100, 500 });
                for (int i = 1; i < gviewAll.Columns.Count; i++)
                {
                    gviewAll.Columns[i].OptionsColumn.AllowEdit = false;
                }
                gviewAll.BestFitColumns();
                PageTag = 0;

                BindingMapControl = pMapControl;
                pActiveViewEvents = BindingMapControl.Map as IActiveViewEvents_Event;
                pActiveViewEvents.SelectionChanged += new IActiveViewEvents_SelectionChangedEventHandler(ActiveViewEvents_SelectionChanged);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("属性表初始化失败");
            }
        }

        //地图刷新
        private void ActiveViewEvents_SelectionChanged()
        {
            UpdateCtrlDataSource();
        }

        //点击所有属性列表表格（点击表头排序）
        private bool sortRuleAll = true;//任务列排列的方式，true表示正序，false表示倒序
        private void gridAllAttribute_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    GridHitInfo gridHitInfo = gviewAll.CalcHitInfo(e.X, e.Y);
                    if (gridHitInfo.InColumnPanel)
                    {
                        GridViewInfo gridViewInfo = (GridViewInfo)gviewAll.GetViewInfo();
                        if (!gridHitInfo.InColumn)
                        {
                            return;
                        }
                        int x = gridViewInfo.GetColumnLeftCoord(gridHitInfo.Column) + gridHitInfo.Column.Width;
                        if (e.X <= x + 20)
                        {
                            string sortColnumName = gridHitInfo.Column.FieldName;
                            sortRuleAll = !sortRuleAll;
                            allRowsTable = SortTable(allRowsTable.Copy(), sortColnumName, sortRuleAll);
                            allRowsTable.PrimaryKey = new DataColumn[] { allRowsTable.Columns[oidFieldName] };
                            ctrlGridNavigation1.InitCtrl(allRowsTable, gridAllAttribute, new int[] { 50, 100, 500 });
                            gviewAll.BestFitColumns();
                            gridAllAttribute.RefreshDataSource();
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("排序错误");
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                GridHitInfo gridHitInfo = gviewAll.CalcHitInfo(e.X, e.Y);
                if (gridHitInfo.InColumnPanel)
                {
                    GridViewInfo gridViewInfo = (GridViewInfo)gviewAll.GetViewInfo();
                    if (!gridHitInfo.InColumn)
                    {
                        return;
                    }
                    if (gridHitInfo.Column.FieldName == "选中要素")
                    {
                        int x = Control.MousePosition.X;
                        int y = Control.MousePosition.Y;
                        popupMenu1.ShowPopup(new System.Drawing.Point(x, y));
                    }
                }
            }
        }

        //点击所有属性列表表格（点击表头排序、右键菜单）
        private bool sortRuleSelect = true;//任务列排列的方式，true表示正序，false表示倒序
        private void gridSelectAttribute_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    GridHitInfo gridHitInfo = gviewSelect.CalcHitInfo(e.X, e.Y);
                    if (gridHitInfo.InColumnPanel)
                    {
                        GridViewInfo gridViewInfo = (GridViewInfo)gviewSelect.GetViewInfo();
                        if (!gridHitInfo.InColumn)
                        {
                            return;
                        }
                        int x = gridViewInfo.GetColumnLeftCoord(gridHitInfo.Column) + gridHitInfo.Column.Width;
                        if (e.X < x + 20)
                        {
                            string sortColnumName = gridHitInfo.Column.FieldName;
                            sortRuleSelect = !sortRuleSelect;
                            selectionRowsTable = SortTable(selectionRowsTable.Copy(), sortColnumName, sortRuleSelect);
                            ctrlGridNavigation1.InitCtrl(selectionRowsTable, gridSelectAttribute, new int[] { 50, 100, 500 });
                            gviewSelect.BestFitColumns();
                            gridSelectAttribute.RefreshDataSource();
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("属性表排序错误");
                }
            }
        }

        //双击所有的属性表
        private void gviewAll_DoubleClick(object sender, EventArgs e)
        {
            GridView gridControl = sender as GridView;
            if (gridControl == null || featureLayer.FeatureClass == null)
            {
                return;
            }
            try
            {
                DataRow dataRow = gridControl.GetFocusedDataRow();
                int oid = Convert.ToInt32(dataRow[featureLayer.FeatureClass.OIDFieldName]);
                IFeature pSelFeature = featureLayer.FeatureClass.GetFeature(oid);
                if (pSelFeature == null)
                {
                    return;
                }
                using (ComReleaser pComReleaser = new ComReleaser())
                {
                    pComReleaser.ManageLifetime(pSelFeature);
                    IMap pMap = BindingMapControl.Map;
                    IGeometry pGeometry = pSelFeature.ShapeCopy;
                    if (!IsEqualSpatialReference(pGeometry.SpatialReference, pMap.SpatialReference))
                    {
                        pGeometry.Project(pMap.SpatialReference);
                    }
                    Flash(BindingMapControl, pGeometry, true);
                }
            }
            catch (Exception ep)
            {
            }
        }

        //双击选中的属性表
        private void gviewSelect_DoubleClick(object sender, EventArgs e)
        {
            GridView gridControl = sender as GridView;
            if (gridControl == null || featureLayer.FeatureClass == null)
            {
                return;
            }
            try
            {
                DataRow dataRow = gridControl.GetFocusedDataRow();
                int oid = Convert.ToInt32(dataRow[featureLayer.FeatureClass.OIDFieldName]);
                IFeature pSelFeature = featureLayer.FeatureClass.GetFeature(oid);
                if (pSelFeature == null)
                {
                    return;
                }
                using (ComReleaser pComReleaser = new ComReleaser())
                {
                    pComReleaser.ManageLifetime(pSelFeature);
                    IMap pMap = BindingMapControl.Map;
                    IGeometry pGeometry = pSelFeature.ShapeCopy;
                    if (!IsEqualSpatialReference(pGeometry.SpatialReference, pMap.SpatialReference))
                    {
                        pGeometry.Project(pMap.SpatialReference);
                    }
                    Flash(BindingMapControl, pGeometry, true);
                }
            }
            catch (Exception ep)
            {
            }
        }

        //改变所有属性的勾选状态（勾选即选中对应的要素）
        private void gviewAll_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "选中要素")
            {
                try
                {
                    int rowIndex = e.RowHandle;
                    object o = e.Value;
                    DataRow selectDataRow = allRowsTable.Rows.Find(gviewAll.GetRowCellValue(e.RowHandle, gviewAll.Columns[oidFieldName]));
                    selectDataRow["选中要素"] = o;
                    gridAllAttribute.RefreshDataSource();
                    int oid = Convert.ToInt32(selectDataRow[oidFieldName]);
                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = featureLayer.FeatureClass.OIDFieldName + "=" + oid;
                    if ((bool)o)
                    {
                        (featureLayer as IFeatureSelection).SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultAdd, false);
                    }
                    else
                    {
                        (featureLayer as IFeatureSelection).SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultSubtract, false);
                    }
                    BindingMapControl.Refresh();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("选取要素失败");
                }
            }
        }

        //切换全部/选中属性
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (radioGroup1.SelectedIndex)
            {
                //全部属性
                case 0:
                    RefreshAllData();
                    gviewAll.BestFitColumns();
                    gridSelectAttribute.Visible = false;
                    gridAllAttribute.Visible = true;
                    gridAllAttribute.Dock = DockStyle.Fill;
                    gridAllAttribute.Refresh();
                    ctrlGridNavigation1.InitCtrl(allRowsTable, gridAllAttribute, new int[] { 50, 100, 500 });
                    PageTag = 0;
                    break;
                //选中属性
                case 1:
                    RefreshSelectionData();
                    gridSelectAttribute.DataSource = selectionRowsTable;
                    gviewSelect.BestFitColumns();
                    gridAllAttribute.Visible = false;
                    gridSelectAttribute.Visible = true;
                    gridSelectAttribute.Dock = DockStyle.Fill;
                    gridSelectAttribute.Refresh();
                    ctrlGridNavigation1.InitCtrl(selectionRowsTable, gridSelectAttribute, new int[] { 50, 100, 500 });
                    PageTag = 1;
                    break;
            }
        }

        //右键菜单全选
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                (featureLayer as IFeatureSelection).SelectFeatures(null, esriSelectionResultEnum.esriSelectionResultAdd, false);
                UpdateCtrlDataSource();
                BindingMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("打开属性表错误");
            }
        }

        //右键菜单——当前页全选
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataTable showingDataTable = gridAllAttribute.DataSource as DataTable;
                List<int> oidList = new List<int>();
                foreach (DataRow dataRow in showingDataTable.Rows)
                {
                    oidList.Add(Convert.ToInt32(dataRow[oidFieldName]));
                }
                using (ComReleaser comReleaser = new ComReleaser())
                {
                    string whereClause = "";
                    IQueryFilter pQueryFilter = new QueryFilterClass();
                    comReleaser.ManageLifetime(pQueryFilter);
                    foreach (int i in oidList)
                    {
                        whereClause += "\"" + (featureLayer.FeatureClass as ITable).OIDFieldName + "\"=" + i + " OR ";

                    }
                    whereClause = whereClause.Substring(0, whereClause.Length - 3);
                    pQueryFilter.WhereClause = whereClause;
                    (featureLayer as IFeatureSelection).SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                }
                UpdateCtrlDataSource();
                BindingMapControl.Refresh();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("打开属性表错误");
            }
        }

        //右键菜单——取消选择
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                (featureLayer as IFeatureSelection).Clear();
                UpdateCtrlDataSource();
                BindingMapControl.Refresh();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("打开属性表错误");
            }
        }

        #region 封装方法
        /// <summary>
        /// 刷新全属性表
        /// </summary>
        public void RefreshAllData()
        {
            try
            {
                allRowsTable = CteateCtrlAttributeTable(featureLayer);
                allRowsTable.DefaultView.Sort = oidFieldName + " ASC";
                allRowsTable = allRowsTable.DefaultView.ToTable();
                allRowsTable.PrimaryKey = new DataColumn[] { allRowsTable.Columns[oidFieldName] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("属性表刷新错误");
            }
        }

        /// <summary>
        /// 刷新选择项属性表
        /// </summary>
        public void RefreshSelectionData()
        {
            try
            {
                selectionRowsTable = GetSelectionRowsTable(featureLayer);
                selectionRowsTable.DefaultView.Sort = oidFieldName + " ASC";
                selectionRowsTable = selectionRowsTable.DefaultView.ToTable();
                selectionRowsTable.PrimaryKey = new DataColumn[] { selectionRowsTable.Columns[oidFieldName] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("属性表刷新错误");
            }
        }

        /// <summary>
        /// 获取要素图层中选择要素的属性表
        /// </summary>
        /// <param name="pFeatureLayer"></param>
        /// <returns></returns>
        private DataTable GetSelectionRowsTable(IFeatureLayer pFeatureLayer)
        {
            selectIDList = new List<int>();
            DataTable pDataTable = CreateDataTableByLayer(pFeatureLayer, pFeatureLayer.Name);
            using (ComReleaser comReleaser = new ComReleaser())
            {
                string oidFieldName = pFeatureLayer.FeatureClass.OIDFieldName;
                ICursor pCursor = null;
                DataRow pDataRow = null;
                comReleaser.ManageLifetime(pCursor);
                string shapeType = GetShapeType(pFeatureLayer);
                IFeatureSelection pFeatureSelection = featureLayer as IFeatureSelection;
                ISelectionSet pSelectionSet = pFeatureSelection.SelectionSet;
                if (pSelectionSet.Count == 0)
                    return pDataTable;
                pSelectionSet.Search(null, false, out pCursor);
                IRow pRow = pCursor.NextRow();
                comReleaser.ManageLifetime(pRow);
                int n = 0;
                while (pRow != null)
                {
                    //新建DataTable的行对象
                    pDataRow = pDataTable.NewRow();
                    for (int i = 0; i < pRow.Fields.FieldCount; i++)
                    {
                        //如果字段类型为esriFieldTypeGeometry，则根据图层类型设置字段值
                        if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                        {
                            pDataRow["Shape"] = shapeType;
                        }
                        //当图层类型为Anotation时，要素类中会有esriFieldTypeBlob类型的数据，
                        //其存储的是标注内容，如此情况需将对应的字段值设置为Element
                        else if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeBlob)
                        {
                            pDataRow[i] = "Element";
                        }
                        else
                        {
                            string o = pRow.get_Value(i).ToString();
                            pDataRow[pRow.Fields.Field[i].Name] = pRow.get_Value(i);
                        }
                    }
                    pDataRow[0] = true;
                    selectIDList.Add(Convert.ToInt32(pDataRow[oidFieldName]));
                    pDataTable.Rows.Add(pDataRow);
                    pDataRow = null;
                    n++;
                    pRow = pCursor.NextRow();
                }
            }
            return pDataTable;
        }

        /// <summary>
        /// 创建属性表
        /// </summary>
        /// <param name="_featureLayer">待创建属性表的要素图层</param>
        /// <returns>返回创建的字段表</returns>
        private DataTable CteateCtrlAttributeTable(IFeatureLayer _featureLayer)
        {
            DataTable pDataTable = CreateDataTableByLayer(_featureLayer, _featureLayer.Name);
            string shapeType = GetShapeType(_featureLayer);
            DataRow pDataRow = null;
            ITable pTable = _featureLayer as ITable;
            ICursor pCursor = pTable.Search(queryFilter, false);
            IRow pRow = pCursor.NextRow();
            int n = 0;
            while (pRow != null)
            {
                using (ComReleaser comReleaser = new ComReleaser())
                {
                    comReleaser.ManageLifetime(pRow);
                    //新建DataTable的行对象
                    pDataRow = pDataTable.NewRow();
                    for (int i = 0; i < pRow.Fields.FieldCount; i++)
                    {
                        //如果字段类型为esriFieldTypeGeometry，则根据图层类型设置字段值
                        if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                        {
                            pDataRow["Shape"] = shapeType;
                        }
                        //当图层类型为Anotation时，要素类中会有esriFieldTypeBlob类型的数据，
                        //其存储的是标注内容，如此情况需将对应的字段值设置为Element
                        else if (pRow.Fields.get_Field(i).Type == esriFieldType.esriFieldTypeBlob)
                        {
                            pDataRow[i] = "Element";
                        }
                        else
                        {
                            string o = pRow.get_Value(i).ToString();
                            pDataRow[pRow.Fields.Field[i].Name] = pRow.get_Value(i);
                        }
                    }
                    //设置行选中状态
                    if (selectIDList.Contains(Convert.ToInt32(pDataRow[pTable.OIDFieldName])))
                    {
                        pDataRow["选中要素"] = true;
                    }
                    else
                    {
                        pDataRow["选中要素"] = false;
                    }

                    pDataTable.Rows.Add(pDataRow);
                    pDataRow = null;
                    n++;
                    pRow = pCursor.NextRow();
                }
            }

            //Marshal.ReleaseComObject(pTable);
            return pDataTable;
        }

        /// <summary>
        /// 根据图层字段创建一个只含字段的空DataTable
        /// </summary>
        /// <param name="pLayer"></param>
        /// <param name="tableName"></param>
        /// <returns>返回创建好的空表</returns>
        private DataTable CreateDataTableByLayer(ILayer pLayer, string tableName, bool canSelect = false)
        {
            DataTable pDataTable = new DataTable(tableName);
            ITable pTable = pLayer as ITable;
            IField pField = null;
            DataColumn pDataColumn;

            pDataColumn = new DataColumn("选中要素", typeof(bool));
            pDataColumn.Caption = "选中要素";
            pDataColumn.DefaultValue = false;
            pDataTable.Columns.Add(pDataColumn);

            int oidIndex = pTable.Fields.FindField(pTable.OIDFieldName);
            int shapeIndex = pTable.FindField("Shape");
            IField oidField = pTable.Fields.get_Field(oidIndex);
            IField shapeField = pTable.Fields.get_Field(shapeIndex);
            DataColumn oidDataColumn = new DataColumn(pTable.OIDFieldName);
            oidDataColumn.Unique = true;
            oidDataColumn.AllowDBNull = oidField.IsNullable;
            oidDataColumn.Caption = oidField.AliasName;
            oidDataColumn.DataType = System.Type.GetType(ParseFieldType(oidField.Type));
            oidDataColumn.DefaultValue = oidField.DefaultValue;
            pDataTable.Columns.Add(oidDataColumn);

            pDataColumn = new DataColumn("Shape");
            pDataColumn.AllowDBNull = shapeField.IsNullable;
            pDataColumn.Caption = shapeField.AliasName;
            pDataColumn.DataType = System.Type.GetType(ParseFieldType(shapeField.Type));
            pDataColumn.DefaultValue = shapeField.DefaultValue;
            pDataTable.Columns.Add(pDataColumn);

            for (int i = 0; i < pTable.Fields.FieldCount; i++)
            {
                pField = pTable.Fields.get_Field(i);
                if (pField.Name == pTable.OIDFieldName || pField.Name.ToUpper() == "SHAPE")
                {
                    pField = null;
                    pDataColumn = null;
                    continue;
                }
                pDataColumn = new DataColumn(pField.Name);
                pDataColumn.AllowDBNull = pField.IsNullable;
                pDataColumn.Caption = pField.AliasName;
                pDataColumn.DataType = System.Type.GetType(ParseFieldType(pField.Type));
                pDataColumn.DefaultValue = pField.DefaultValue;

                if (pField.VarType == 8)
                {
                    pDataColumn.MaxLength = pField.Length;
                }
                pDataTable.Columns.Add(pDataColumn);
                pField = null;
                pDataColumn = null;
            }

            return pDataTable;
        }

        /// <summary>
        /// 获得图层的Shape类型
        /// </summary>
        /// <param name="pLayer">图层</param>
        /// <returns>返回图形的几何类型</returns>
        private string GetShapeType(ILayer pLayer)
        {
            IFeatureLayer pFeatLyr = (IFeatureLayer)pLayer;
            switch (pFeatLyr.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    return "Point";

                case esriGeometryType.esriGeometryPolyline:
                    return "Polyline";

                case esriGeometryType.esriGeometryPolygon:
                    return "Polygon";

                default:
                    return "";
            }
        }

        /// <summary>
        /// 将GeoDatabase字段类型转换成.Net相应的数据类型
        /// </summary>
        /// <param name="fieldType">GeoDatabase字段类型</param>
        /// <returns>返回.net的字段类型</returns>
        private string ParseFieldType(esriFieldType fieldType)
        {
            switch (fieldType)
            {
                case esriFieldType.esriFieldTypeBlob:
                    return "System.String";

                case esriFieldType.esriFieldTypeDate:
                    return "System.DateTime";

                case esriFieldType.esriFieldTypeDouble:
                    return "System.Double";

                case esriFieldType.esriFieldTypeGeometry:
                    return "System.String";

                case esriFieldType.esriFieldTypeGlobalID:
                    return "System.String";

                case esriFieldType.esriFieldTypeGUID:
                    return "System.String";

                case esriFieldType.esriFieldTypeInteger:
                    return "System.Int32";

                case esriFieldType.esriFieldTypeOID:
                    return "System.Int32";

                case esriFieldType.esriFieldTypeRaster:
                    return "System.String";

                case esriFieldType.esriFieldTypeSingle:
                    return "System.Single";

                case esriFieldType.esriFieldTypeSmallInteger:
                    return "System.Int32";

                case esriFieldType.esriFieldTypeString:
                    return "System.String";

                default:
                    return "System.String";
            }
        }

        /// <summary>
        /// 任务列表按照某一列排序
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="colnumName"></param>
        /// <param name="sortRule">true表示正序，false表示倒序</param>
        /// <returns></returns>
        private DataTable SortTable(DataTable dataTable, string colnumName, bool sortRule)
        {
            string sort = sortRule ? "ASC" : "DESC";
            if (colnumName == "DX$CheckboxSelectorColumn")
            {
                return dataTable.DefaultView.ToTable();
            }
            dataTable.DefaultView.Sort = colnumName + " " + sort;
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[oidFieldName] };
            return dataTable.DefaultView.ToTable();
        }

        /// <summary>
        /// 更新所有属性表（需要在已经初始化DataTable的情况下调用）
        /// </summary>
        private void UpdateCtrlDataSource()
        {
            if (allRowsTable == null || selectionRowsTable == null)
                return;
            try
            {
                if (gridAllAttribute.Visible == true)
                {
                    ICursor pCursor = null;
                    int selectOid;
                    string where = "";
                    selectIDList = new List<int>();
                    DataColumn dataColumn = allRowsTable.Columns["选中要素"];
                    allRowsTable.Columns.Remove(dataColumn);
                    dataColumn.DefaultValue = false;
                    allRowsTable.Columns.Add(dataColumn);

                    IFeatureSelection pFeatureSelection = featureLayer as IFeatureSelection;
                    ISelectionSet pSelectionSet = pFeatureSelection.SelectionSet;
                    pSelectionSet.Search(null, false, out pCursor);
                    IRow pRow = pCursor.NextRow();
                    while (pRow != null)
                    {
                        selectOid = Convert.ToInt32(pRow.get_Value(pRow.Fields.FindField(oidFieldName)));
                        selectIDList.Add(selectOid);
                        pRow = pCursor.NextRow();
                    }
                    if (selectIDList.Count > 0)
                    {
                        foreach (int i in selectIDList)
                        {
                            where += oidFieldName + "=" + i + " or ";
                        }
                        where = where.Substring(0, where.Length - 3);
                        DataRow[] selectRows = allRowsTable.Select(where);
                        foreach (DataRow dataRow in selectRows)
                        {
                            dataRow["选中要素"] = true;
                        }
                    }
                    gridAllAttribute.DataSource = allRowsTable;
                    gviewAll.RefreshData();
                    ctrlGridNavigation1.InitCtrl(allRowsTable, gridAllAttribute, new int[] { 50, 100, 500 });
                }
                if (gridSelectAttribute.Visible == true)
                {
                    RefreshSelectionData();
                    gviewSelect.RefreshData();
                    ctrlGridNavigation1.InitCtrl(selectionRowsTable, gridSelectAttribute, new int[] { 50, 100, 500 });
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("属性表更新失败");
            }
        }

        /// <summary>
        /// 判断两个空间参考是否一致（不考虑垂直坐标系）
        /// </summary>
        /// <param name="pSrf1"></param>
        /// <param name="pSrf2"></param>
        /// <returns></returns>
        public bool IsEqualSpatialReference(ISpatialReference pSrf1, ISpatialReference pSrf2)
        {
            bool bEqual = false;
            //yh 2017年11月23日15:29:57 如果传入的worksapce为空，则返回false
            if (pSrf1 == null || pSrf2 == null)
            {
                return false;
            }
            if ((pSrf1 as ICompareCoordinateSystems).IsEqualNoVCS(pSrf2))
            {
                bEqual = true;
            }
            return bEqual;
        }

        /// <summary>
        /// 几何闪烁，实现ArcMap的闪烁效果
        /// </summary>
        /// <param name="mapControl"></param>
        /// <param name="geometry"></param>
        /// <param name="bZoom">是否缩放到指定几何，默认不缩放</param>
        public void Flash(IMapControl4 mapControl, IGeometry geometry, bool bZoom = false)
        {
            if (geometry == null || geometry.IsEmpty)
            {
                return;
            }
            IHookHelper hookHelper = new HookHelperClass();
            hookHelper.Hook = mapControl;
            IHookActions hookActions = hookHelper as IHookActions;
            if (bZoom) //先缩放
            {
                hookActions.DoAction(geometry, esriHookActions.esriHookActionsZoom);
                hookHelper.ActiveView.ScreenDisplay.UpdateWindow();
            }
            //再闪烁
            if (hookActions.get_ActionSupported(geometry, esriHookActions.esriHookActionsFlash))
            {
                hookActions.DoAction(geometry, esriHookActions.esriHookActionsFlash);
            }
        }
        #endregion
    }
}
