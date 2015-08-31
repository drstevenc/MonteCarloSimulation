using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloSimulation
{
    public abstract class Discretisation : Factories.IDiscretisation
    {
        /* Implementing IDiscretization interface */
        protected SDE sde;
        protected double initialPrice;
        protected double expiry;
        
        public double InitialPrice { get { return initialPrice; } }
        public double Expiry { get { return expiry; } }
        public Discretisation(SDE _sde, double _initialPrice, double _expiry) 
        {
            this.sde = _sde; 
            this.initialPrice = _initialPrice; 
            this.expiry = _expiry;
        }
        public abstract double Next(double s, double dt, double rnd);
    }
}
