using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloSimulation
{
    public class EuropeanPricer : Pricer
    {
        private double strike;
        
        public EuropeanPricer(PayoffFunction payoff, double _strike, Func<double> discountFactor) : base(payoff, discountFactor)
        {
            this.strike = _strike;
        }

        public override void ProcessPath(ref double[] path)
        {
            optionPrice += payoff(path[path.Length - 1], strike);
            paths++;
        }
    }
}
