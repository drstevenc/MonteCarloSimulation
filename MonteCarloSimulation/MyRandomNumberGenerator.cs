using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloSimulation
{
    public class MyRandomNumberGenerator : RandomNumberGenerator
    {
        private Random random;
        public MyRandomNumberGenerator()
        {
            random = new Random();
        }

        /* Box-Muller Transform to get gaussian pseudo-random variates ~ N(0,1) - only using x */
        public override double RandomGenerator()
        {
            Random rand = new Random();
            double x, y, w;
            do
            {
                x = 2.0 * random.NextDouble();
                y = 2.0 * random.NextDouble();
                w = x * x + y * y;
            } while (w >= 1.0);
            return ((rand.Next(1000) % 2) == 0 ? -1 : 1) * x * Math.Sqrt(-2 * Math.Log(w) / w);
        }
    }
}
