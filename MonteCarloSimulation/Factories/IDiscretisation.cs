using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloSimulation.Factories
{
    public interface IDiscretisation
    {
        double Next(double s, double dt, double rnd);
    }
}
