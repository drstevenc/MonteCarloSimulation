using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloSimulation
{
    public class EulerDiscretisation : Discretisation
    { 
        public EulerDiscretisation(SDE sde, double initialPrice, double expiry) : base(sde, initialPrice, expiry) 
        { 
        
        }

        public override double Next(double s, double dt, double rnd)
        {
            return s + sde.Drift * dt + sde.Diffusion * Math.Sqrt(dt) * rnd;
        }
    }
}
