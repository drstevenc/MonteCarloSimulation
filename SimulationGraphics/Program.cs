using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace SimulationGraphics
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Plot myPlot = new OxyPlot.WindowsForms.Plot();
            myPlot.Model = new PlotModel();
            myPlot.Dock = DockStyle.Fill;
            this.Controls.Add(myPlot);

            myPlot.Model.PlotType = PlotType.XY;
            myPlot.Model.Background = OxyColor.FromRgb(255, 255, 255);
            myPlot.Model.TextColor = OxyColor.FromRgb(0, 0, 0);

            // Create Line series
            var s1 = new LineSeries { Title = "LineSeries", StrokeThickness = 1 };
            s1.Points.Add(new DataPoint(2,7));
            s1.Points.Add(new DataPoint(7, 9));
            s1.Points.Add(new DataPoint(9, 4));

            // add Series and Axis to plot model
            myPlot.Model.Series.Add(s1);
            myPlot.Model.Axes.Add(new LinearAxis(AxisPosition.Bottom, 0.0, 10.0));
            myPlot.Model.Axes.Add(new LinearAxis(AxisPosition.Left, 0.0, 10.0));
        }
    }
}
