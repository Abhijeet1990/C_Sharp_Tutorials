using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegressionAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] xdata = new double[] { 2,3,4,5,6,7,8,9,10,11 };
            double[] ydata = new double[] { 8,14,22,31,44,58,74,92,112,134}; //y = 2 + x + x^2 
            var param = Program.calcParameters(xdata, ydata);

            double coeffOfDetermination = GoodnessOfFit.RSquared(xdata.Select(x => param.Item1 + param.Item2 * x), ydata);

            Console.WriteLine(param.Item1.ToString());
            Console.WriteLine(param.Item2.ToString());
            Console.WriteLine(coeffOfDetermination.ToString());

            int order =8;
            var polyParam = Program.calcParametersPolynomial(xdata, ydata, order);
            for (int i = 0; i < polyParam.Count(); i++)
            {
                Console.WriteLine(polyParam[i].ToString());
            }

            Console.WriteLine(Program.calcCoeffOfDetermination(polyParam,xdata,ydata).ToString());

            Console.WriteLine(Program.ComputeCoeff(xdata, ydata).ToString());

            Console.ReadLine();

        }


        public static Tuple<double,double> calcParameters(double[] xdata, double[] ydata)
        {
            Tuple<double, double> p = Fit.Line(xdata, ydata);
            //double[] pPol = Fit.Polynomial(xdata, ydata, 3);
            double a = p.Item1; 
            double b = p.Item2; 
            return p;
        }

        public static double[] calcParametersPolynomial(double[] xdata,double[] ydata,int order)
        {
            double[] pPol = Fit.Polynomial(xdata, ydata, order);
            return pPol;
        }

        public static double calcCoeffOfDetermination(double[] p,double[] xdata,double[] ydata)
        {
            for (int j = 0; j < xdata.Length; j++)
            {
                for (int i = 0; i < p.Length; i++)
                {
                    xdata[j] += p[i] * Math.Pow(p[i], i);
                }
            }
            
            return GoodnessOfFit.RSquared(xdata, ydata);
        }

        public static double ComputeCoeff(double[] values1, double[] values2)
        {
            if (values1.Length != values2.Length)
                throw new ArgumentException("values must be the same length");

            var avg1 = values1.Average();
            var avg2 = values2.Average();

            var sum1 = values1.Zip(values2, (x1, y1) => (x1 - avg1) * (y1 - avg2)).Sum();

            var sumSqr1 = values1.Sum(x => Math.Pow((x - avg1), 2.0));
            var sumSqr2 = values2.Sum(y => Math.Pow((y - avg2), 2.0));

            var result = sum1 / Math.Sqrt(sumSqr1 * sumSqr2);

            return result;
        }

    }
}
