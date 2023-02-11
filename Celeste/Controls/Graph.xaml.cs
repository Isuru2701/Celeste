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
            double[] y_ax = { -5, -2, 0, 3, 2, 1, 5 };

            double[] x_ax = { 1, 2, 3, 4, 5, 6, 7 };
            
            SentimentGraph.Plot.Style
                (
                figureBackground:System.Drawing.Color.Transparent,
                dataBackground: System.Drawing.Color.Transparent,
                grid: System.Drawing.Color.Transparent                
                
                );

            SentimentGraph.Plot.YAxis.Color(ColorTranslator.FromHtml("#d8c6a0"));
            SentimentGraph.Plot.YAxis.SetSizeLimit(-5, 5);
            SentimentGraph.Plot.YAxis.TickDensity(ratio: 0.5);
            

            SentimentGraph.Plot.XAxis.Color(ColorTranslator.FromHtml("#d8c6a0"));
            SentimentGraph.Plot.XAxis.TickDensity(ratio: 0);

            SentimentGraph.Plot.Layout(padding: 5);


            SentimentGraph.Plot.AddScatter(x_ax,y_ax, lineWidth:2, color:ColorTranslator.FromHtml("#d8c6a0"));
            

        }


    }

}
