using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloSimulation.Utils
{
    public static class Statistics
    {
        public static double StandardDeviation(double[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            return Math.Sqrt(Variance(data));
        }

        public static double Variance(double[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            double num = 0.0;
            double num2 = 0.0;
            int num3 = 0;
            int length = data.Length;
            if (length > 0)
            {
                num3++;
                num2 = data[0];
            }
            for (int i = 1; i < length; i++)
            {
                num3++;
                double num6 = data[i];
                num2 += num6;
                double num7 = (num3 * num6) - num2;
                num += (num7 * num7) / ((double)(num3 * (num3 - 1)));
            }
            return (num / ((double)(num3 - 1)));
        }

        public static double Mean(double[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            double num = 0.0;
            int num2 = 0;
            int length = data.Length;
            for (int i = 0; i < length; i++)
            {
                num += (data[i] - num) / ((double)(++num2));
            }
            return num;
        }
    }
}
