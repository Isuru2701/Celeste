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

using ScottPlot;
using ScottPlot.Renderable;

namespace Celeste.Controls
{
    /// <summary>
    /// Interaction logic for Graph.xaml
    /// </summary>
    public partial class Graph : UserControl
    {

        public Graph()
        {
            InitializeComponent();
            DrawPlot();
        }

        public void DrawPlot()
        {

            SentimentGraph.Plot.YAxis.Color(ColorTranslator.FromHtml("#d8c6a0"));
            SentimentGraph.Plot.XAxis.TickLabelFormat("M/d", dateTimeFormat: true);
        }


    }

}
