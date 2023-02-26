using Celeste.Model;
using LiveCharts;
using LiveCharts.Charts;
using LiveCharts.Wpf;
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

        List<string> x_axis = new List<string>();

        public void LoadTrigger()
        {
            int rows = Person.GetInstance(Flow.User_ID).FetchTriggers();
            if (rows > 0)
            {
                foreach(Record record in Person.GetInstance(Flow.User_ID).Triggers)
                {
                    x_axis.Add(record.Name);
                }
                Plot();
            }

        }
        public void LoadComfort()
        {
            int rows = Person.GetInstance(Flow.User_ID).FetchComforts();
            if (rows > 0)
            {
                foreach (Record record in Person.GetInstance(Flow.User_ID).Comforts)
                {
                    x_axis.Add(record.Name);
                }
                Plot();

            }
        }

        public void Plot()
        {
            var pie = new LiveCharts.Wpf.PieChart();

            var slices = new SeriesCollection();

            var frequencyCounts = x_axis.GroupBy(n => n)
                             .Select(g => new { Element = g.Key, Frequency = g.Count() });


            foreach (var item in frequencyCounts)
            {
                var slice = new LiveCharts.Wpf.PieSeries
                {
                    Title = item.Element,
                    Values = new LiveCharts.ChartValues<double> { item.Frequency },
                };

                slices.Add(slice);
            }

            pie.Series = slices;
            plotter.Children.Add(pie);
        }
    }
}
