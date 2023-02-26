using LiveCharts.Wpf;
using LiveCharts;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Collections.ObjectModel;
using LiveCharts.Definitions.Series;
using LiveCharts.Wpf.Charts.Base;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;
using Celeste.Model;
using System.Reflection.Emit;

namespace Celeste.Controls
{
    /// <summary>
    /// Interaction logic for Chart.xaml
    /// </summary>
    public partial class Chart : UserControl
    {



        public Chart()
        {
            InitializeComponent();
            LoadData();
            Plot();
        }

        List<string> x_axis = new List<string>();
        List<double> y_axis = new List<double>();

        public void LoadData()
        {
            Person.GetInstance(Flow.User_ID).FetchScores();
            foreach(Score score in Person.GetInstance(Flow.User_ID).Scores)
            {
                x_axis.Add(score.Date.ToString("yyyy/MM/dd"));
                y_axis.Add(Math.Round(score.Value, 1) * 5);
            }
        }

        public void Plot()
        {
            CartesianChart ch = new CartesianChart();
            ch.Zoom = ZoomingOptions.None;
            ch.AxisX.Add
                (
                    new LiveCharts.Wpf.Axis
                    {
                        Title = "Months",
                        Labels = x_axis,
                    }
                );
            ch.AxisX[0].Separator.StrokeThickness = 0;
            ch.AxisY[0].Separator.StrokeThickness = 0;

            ch.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Sentiment",
                    Values = new ChartValues<double>(y_axis),
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255))
                }
            };
                    plotter.Children.Add(ch);
        }

    }

}

