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
            Plot();
        }

        List<string> x_axis = new List<string>();
        List<double> y_axis = new List<double>();


        public void LoadData()
        {
            Person.GetInstance(Flow.User_ID).FetchScores();
            foreach(Score score in Person.GetInstance(Flow.User_ID).Scores)
            {
                x_axis.Add(score.Date.ToString("MM/dd"));
                y_axis.Add(Math.Round(score.Value, 1) * 5);
            }

        }

        public void Plot()
        {
            LoadData();
            SentimentGraph.AxisX.Add(new LiveCharts.Wpf.Axis()
            {
                Title = "Days",
                Labels = x_axis
            });


            var series = new SeriesCollection
                (
                    new LineSeries
                    {
                        Title = "Sentiment Score",
                        Values = new ChartValues<double>(y_axis)
                    }
                );
            SentimentGraph.Series = series;
            
        }
    }

}

