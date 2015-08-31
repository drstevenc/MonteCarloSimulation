using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloSimulation
{
    public class GBM : SDE
    {
        public GBM(double mu, double sigma)
        {
            this.Drift = mu; 
            this.Diffusion = sigma;
        }
    }
}
