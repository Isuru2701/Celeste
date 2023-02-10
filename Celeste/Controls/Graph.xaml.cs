using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                Minimum = DateTimeAxis.ToDouble(DateTime.Now.AddDays(-7)),
                Maximum = DateTimeAxis.ToDouble(DateTime.Now),
                StringFormat = "M/d",
                IntervalLength = 100,
                AxislineThickness = 3,
                PositionAtZeroCrossing = true,
                FontWeight = OxyPlot.FontWeights.Bold,
                IsZoomEnabled = false,
                IsPanEnabled = true
            };


            plot.Axes.Add(xAxis);

            LinearAxis yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                AxislineColor = OxyColor.Parse("#d8c6a0"),
                TextColor = OxyColor.Parse("#d8c6a0"),
                TicklineColor = OxyColor.Parse("#d8c6a0"),
                AxislineStyle = LineStyle.Solid,
                AxislineThickness = 3,
                FontWeight = OxyPlot.FontWeights.Bold,
                Maximum = 5,
                Minimum = -5,
                IntervalLength = 100,
                IsZoomEnabled = false



            };
            plot.Axes.Add(yAxis);



            for (int i = 0; i < 7; ++i)
            {

            }

            plot.Series.Add(new LineSeries
            {
                Color = OxyColor.Parse("#d8c6a0"),
                LineStyle = LineStyle.LongDashDotDot,


                Points =
                {
                    new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(0)), 4),
                    new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(-1)), 1),
                    new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(-2)), 3),
                    new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(-3)), -5),
                    new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(-4)), -2),
                    new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(-5)), -5),
                    new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(-6)), 2),
                    new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(-7)), 2)


                }
            });

            DataContext = this;
        }
    }
}
