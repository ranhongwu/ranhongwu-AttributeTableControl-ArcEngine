using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine.UI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;

namespace 属性表控件
{
    public partial class Form2 : Form
    {
        public IMapControl4 mapControl;
        public IFeatureLayer featureLayer;
        public IQueryFilter queryFilter;

        public Form2(IMapControl4 pMapControl,IFeatureLayer pFeatureLayer,IQueryFilter pQueryFilter)
        {
            InitializeComponent();
            mapControl = pMapControl;
            featureLayer = pFeatureLayer;
            queryFilter = pQueryFilter;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CtrlAttrubuteGrid ctrlAttrubuteGrid = new CtrlAttrubuteGrid(mapControl, ref featureLayer, queryFilter);
            this.Controls.Add(ctrlAttrubuteGrid);
            ctrlAttrubuteGrid.Dock = DockStyle.Fill;
        }
    }
}
