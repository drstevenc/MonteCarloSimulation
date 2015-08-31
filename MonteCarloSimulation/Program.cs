using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonteCarloSimulation
{
    class Program
    {
        private static SimulationEngine simulationEngine;
        private static PayoffFunction callPayoff;
        private static Func<double> discountFactor;
        private static List<Pricer> pricers = new List<Pricer>();
        
        private static SDE sde;
        private static Discretisation discretisation;
        private static RandomNumberGenerator rdmGenerator;

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                int steps = 100;
                long paths = 10000;
                double t = 360.0;
                double initialPrice = 88.0;
                double _strike = 100.0;
                double mu = 0.10;
                double sigma = 0.20;
                double rate = 0.005;
                sde = new GBM(mu, sigma);
                discretisation = new EulerDiscretisation(sde, initialPrice, t);
                rdmGenerator = new MyRandomNumberGenerator();

                simulationEngine = new SimulationEngine(discretisation, rdmGenerator, paths, steps);
                callPayoff = (double spot, double strike) => Math.Max(0.0, spot - strike);
                discountFactor = () => Math.Exp(-rate * t);

                int tot_cnt = 100;
                for (int i = 0; i < tot_cnt; i++) pricers.Add(new EuropeanPricer(callPayoff, _strike, discountFactor));

                List<SimulationEngine> simulationEngines = new List<SimulationEngine>();
                for (int i = 0; i < tot_cnt; i++) simulationEngines.Add(new SimulationEngine(discretisation, rdmGenerator, paths, steps));
                for (int i = 0; i < tot_cnt; i++) simulationEngines[i].ProcessPath += pricers[i].ProcessPath;
                for (int i = 0; i < tot_cnt; i++) simulationEngines[i].StopProcess += pricers[i].Calculate;

                List<double[]> outPaths = new List<double[]>();
                foreach (SimulationEngine sEngine in simulationEngines) outPaths.Add(sEngine.Run());

                double[] results = new double[tot_cnt];
                for (int i = 0; i < tot_cnt; i++) results[i] = pricers[i].Price();

                Console.WriteLine("Price (Mean) = " + Utils.Statistics.Mean(results));
                Console.WriteLine("Standard Error = " + Utils.Statistics.StandardDeviation(results));

                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();

                Form graphics = new SimulationGraphics(outPaths);
                Application.EnableVisualStyles();
                Application.Run(graphics);

                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
