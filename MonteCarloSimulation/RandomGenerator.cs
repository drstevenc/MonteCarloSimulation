using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloSimulation
{
    public abstract class RandomNumberGenerator : Factories.IRandomGenerator
    {
        /* Implementing IRandomGenerator interface */
        public abstract double RandomGenerator();
    }
}
