using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonteCarloSimulation
{
    public partial class SimulationGraphics : Form
    {
        public SimulationGraphics(List<double[]> paths)
        {
            InitializeComponent(paths);
        }
    }
}
