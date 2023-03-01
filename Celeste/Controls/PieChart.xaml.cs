using Celeste.Model;
using HandyControl.Themes;
using LiveCharts;
using LiveCharts.Charts;
using LiveCharts.Wpf;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.Themes;
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
    /// Interaction logic for PieChart.xaml
    /// </summary>
    public partial class PieChart : UserControl
    {
        public PieChart(string type)
        {
            InitializeComponent();

            if (type == "trigger")
                LoadTrigger();
            else
                LoadComfort();
        }

        List<string> sectors = new List<string>();

        public void LoadTrigger()
        {
            try
            {

                int rows = Person.GetInstance(Flow.User_ID).FetchTriggers();
                if (rows > 0)
                {
                    foreach (Record record in Person.GetInstance(Flow.User_ID).Triggers)
                    {
                        sectors.Add(record.Name);
                    }
                    Plot();
                }
                else
                {
                    throw new Exception("PIECHART:NO_DATA_ERROR");
                }
            }

            catch (ArgumentNullException)
            {
                MessageBox.Show("PIECHART:ARG_NULL_ERROR");
            }


        }
        public void LoadComfort()
        {
            try
            {

                int rows = Person.GetInstance(Flow.User_ID).FetchComforts();
                if (rows > 0)
                {
                    foreach (Record record in Person.GetInstance(Flow.User_ID).Comforts)
                    {
                        sectors.Add(record.Name);
                    }
                    Plot();

                }
                else
                {
                    throw new Exception("PIECHART:NO_DATA_ERROR");
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("PIECHART:ARG_NULL_ERROR");
            }
        }

        public void Plot()
        {
            var pie = new LiveCharts.Wpf.PieChart();

            var slices = new SeriesCollection();

            var frequencyCounts = sectors.GroupBy(n => n)
                             .Select(g => new { Element = g.Key, Frequency = g.Count() });


            foreach (var item in frequencyCounts)
            {
                var slice = new PieSeries
                {
                    Title = item.Element,
                    Values = new ChartValues<double> { item.Frequency },
                    
                };

                slices.Add(slice);
            }
            pie.LegendLocation = LegendLocation.Left;
            pie.ChartLegend.Margin = new Thickness(50, 0, 0, 0);
            pie.ChartLegend.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#d8c6a0"));
            pie.ChartLegend.Visibility = Visibility.Visible;


            pie.Series = slices;
            plotter.Children.Add(pie);
        }
    }
}
