using OxyPlot;
using OxyPlot.Axes;
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
        public PlotModel plot { get;  set; }

        public Graph()
        {
            InitializeComponent();

            plot = new PlotModel();
            plot.TextColor = OxyColor.Parse("#d8c6a0");
            plot.PlotAreaBorderColor = OxyColors.Transparent;

            LinearAxis xAxis = new DateTimeAxis {
                Position = AxisPosition.Bottom,
                AxislineColor = OxyColor.Parse("#d8c6a0"),
                TextColor = OxyColor.Parse("#d8c6a0"),
                TicklineColor = OxyColor.Parse("#d8c6a0"),
                AxislineStyle = LineStyle.Solid,
                StringFormat = "M/d",
                Minimum = DateTimeAxis.ToDouble(DateTime.Now.AddDays(-7)),
                Maximum = DateTimeAxis.ToDouble(DateTime.Now),
                AxislineThickness = 3,
                PositionAtZeroCrossing = true,
                FontSize = 10,
                FontWeight = FontWeights.Bold
            };

            plot.Axes.Add(xAxis);

            LinearAxis yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                AxislineColor = OxyColor.Parse("#d8c6a0"),
                TextColor = OxyColor.Parse("#d8c6a0"),
                TicklineColor = OxyColor.Parse("#d8c6a0"),
                AxislineStyle = LineStyle.Solid
            };
            plot.Axes.Add(yAxis);



            plot.Series.Add(new LineSeries
            {
                Color = OxyColor.Parse("#d8c6a0"),
                
                

                Points =
                {
                    new DataPoint(0, 4),
                    new DataPoint(10, 13),
                    new DataPoint(20, -15),
                    new DataPoint(30, 16),
                    new DataPoint(40, 12),
                    new DataPoint(50, 12)
                }
            });

            DataContext = this;
        }
    }
}
