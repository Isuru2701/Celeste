﻿using LiveCharts.Wpf;
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
using System.Windows.Markup;

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
        }

        List<string> x_axis = new List<string>();
        List<double> y_axis = new List<double>();

        public void LoadData()
        {
            try
            {
                int rows = Person.GetInstance(Flow.User_ID).FetchScores();
                if (rows > 0)
                {
                    foreach (Score score in Person.GetInstance(Flow.User_ID).Scores)
                    {
                        x_axis.Add(score.Date.ToString("yyyy/MM/dd"));
                        y_axis.Add(Math.Round(score.Value, 2));
                    }

                    // normalizing the data
                    List<double> logData = new List<double>();
                    foreach (double value in y_axis)
                    {
                        logData.Add(Math.Log(value));
                    }

                    double minLogData = logData[0];
                    double maxLogData = logData[0];
                    foreach (double value in logData)
                    {
                        if (value < minLogData)
                        {
                            minLogData = value;
                        }
                        if (value > maxLogData)
                        {
                            maxLogData = value;
                        }
                    }

                    y_axis.Clear();
                    foreach (double value in logData)
                    {
                        double rescaledValue = ((value - minLogData) * (10 / (maxLogData - minLogData))) - 5;
                        y_axis.Add(rescaledValue);
                    }

                    Plot();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        Title = "Day",
                        Labels = x_axis,

                        Separator = new LiveCharts.Wpf.Separator
                        {
                            StrokeThickness = 0
                        }


                    }
                );


            ch.AxisY.Add
                (
                    new LiveCharts.Wpf.Axis
                    {
                        Title = "Score",
                        MaxValue = 5,
                        MinValue = -5,



                        Separator = new LiveCharts.Wpf.Separator
                        {
                            StrokeThickness = 0,
                            
                        }
                        
                    }
                );


            ch.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Sentiment",
                    Values = new ChartValues<double>(y_axis),
                    Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255)),
                    Fill = null
                }
            };
            plotter.Children.Add(ch);
        }

    }

}

