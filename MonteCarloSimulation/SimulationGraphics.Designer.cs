using System.Collections.Generic;
using System.Windows.Forms;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace MonteCarloSimulation
{
    public partial class SimulationGraphics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private OxyPlot.WindowsForms.PlotView Plot;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(List<double[]> paths)
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "SimulationGraphics";

            this.Plot = Graph(paths);
        }

        public OxyPlot.WindowsForms.PlotView Graph(List<double[]> paths)
        {
            OxyPlot.WindowsForms.PlotView myPlot = new OxyPlot.WindowsForms.PlotView();
            myPlot.Model = new PlotModel();
            myPlot.Dock = DockStyle.Fill;
            this.Controls.Add(myPlot);

            myPlot.Model.PlotType = PlotType.XY;
            myPlot.Model.Background = OxyColor.FromRgb(255, 255, 255);
            myPlot.Model.TextColor = OxyColor.FromRgb(0, 0, 0);

            List<LineSeries> lsList = new List<LineSeries>();
            for (int i = 0; i < paths.Count; i++) lsList.Add(CreateLineSeries(paths[i], "LS" + i));
            foreach (LineSeries ls in lsList) myPlot.Model.Series.Add(ls);

            return myPlot;
        }

        public LineSeries CreateLineSeries(double[] data, string name)
        {
            var ls = new LineSeries { Title = name, StrokeThickness = 1 };
            for (int i = 0; i < data.Length; i++) ls.Points.Add(new DataPoint(i, data[i]));
            return ls;
        }

        #endregion
    }
}