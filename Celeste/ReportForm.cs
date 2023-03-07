using CefSharp.DevTools.Fetch;
using Celeste.DataSet1TableAdapters;
using Celeste.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Celeste
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            this.fetcherAdapter.Fill(this.dataSet1.Fetcher, Flow.User_ID);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
        }
    }
}
