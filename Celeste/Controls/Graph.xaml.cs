using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Celeste.Controls
{
    /// <summary>
    /// Interaction logic for Graph.xaml
    /// </summary>
    public partial class Graph : UserControl
    {
        public PlotModel PlotModel { get;  set; }

        public Graph()
        {
            InitializeComponent();

            PlotModel = new PlotModel { Title = "Line Graph Example" };
            PlotModel.Series.Add(new LineSeries
            {
                Points =
                {
                    new DataPoint(0, 4),
                    new DataPoint(10, 13),
                    new DataPoint(20, 15),
                    new DataPoint(30, 16),
                    new DataPoint(40, 12),
                    new DataPoint(50, 12)
                }
            });

            DataContext = this;
        }
    }
}
