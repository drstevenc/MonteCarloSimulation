using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloSimulation
{
    public delegate double PayoffFunction(double spot, double strike);
    
    public abstract class Pricer : Factories.IPricer
    {
        protected PayoffFunction payoff; 
        protected Func<double> discountFactor; 
        protected double optionPrice; 
        protected long paths;
        
        public Pricer(PayoffFunction payoff, Func<double> discountFactor)
        {
            this.payoff = payoff; 
            this.discountFactor = discountFactor;
        }

        public abstract void ProcessPath(ref double[] path);
        
        public void Calculate()
        {
            optionPrice = (optionPrice / paths) * discountFactor();
        }

        public double Price()
        {
            return optionPrice;
        }
    }
}
