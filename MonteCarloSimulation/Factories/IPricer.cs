using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloSimulation.Factories
{
    public interface IPricer
    {
        void ProcessPath(ref double[] path);
        void Calculate();
        double Price();
    }
}
