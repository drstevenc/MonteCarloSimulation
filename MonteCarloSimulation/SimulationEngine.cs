using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloSimulation
{
    class SimulationEngine
    {
        public delegate void PathSender(ref double[] path);
        public delegate void ProcessStopper();

        private Discretisation Discretisation = null;
        private RandomNumberGenerator RdmGenerator;
        private long Paths;
        private int Steps;
        public event PathSender ProcessPath;
        public event ProcessStopper StopProcess;

        public SimulationEngine(Discretisation discretisation, RandomNumberGenerator rdmGenerator, long npaths, int totsteps)
        {
            this.Discretisation = discretisation;
            this.RdmGenerator = rdmGenerator;
            this.Paths = npaths;
            this.Steps = totsteps;
        }

        public double[] Run()
        {
            double[] path = new double[Steps + 1];
            double dt = Discretisation.Expiry / Steps;
            double previousValue = 0.0; 
            double nextValue = 0.0;

            for (int i = 0; i < Paths; i++)
            {
                path[0] = previousValue = Discretisation.InitialPrice;

                for (int j = 1; j <= Steps; j++)
                {
                    nextValue = Discretisation.Next(previousValue, dt, RdmGenerator.RandomGenerator());
                    path[j] = nextValue; 
                    previousValue = nextValue;
                }
                ProcessPath(ref path);
            }
            StopProcess();
            return path;
        }
    }
}
