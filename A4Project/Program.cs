using System;
using System.Collections.Generic;

namespace A4Program
{
    /**
     * Library of statistical functions using Generics for different statistical
     * calculations.
     * 
     * see http://www.calculator.net/standard-deviation-calculator.html
     * for sample standard deviation calculations
     *
     * @author Joey Programmer
     */
    ///<summary>
    ///produces a set of 4 results and displays
    ///</summary>
    public class A4
    {
        /// <summary>
        /// produces sum of all positive numbers in array
        /// </summary>
        /// <param name="x">items in the array</param>
        /// <param name="incNeg">boolean</param>
        /// <returns>sum of positive numbers in list</returns>
        public static double TotalAverage(List<double> x, bool incNeg)
        {
            double s = Average(x, incNeg);
            int c = 0;
            for (int i = 0; i < x.Count; i++)
            {
                if (incNeg || x[i] >= 0)
                {
                    c++;
                }
            }
            if (c == 0)
            {
                throw new ArgumentException("no values are > 0");
            }
            return s / c;
        }

        /// <summary>
        /// produces average of items in array
        /// </summary>
        /// <param name="x">items in the array</param>
        /// <param name="incNeg">boolean</param>
        /// <returns>sum of numbers / total numbers(average)</returns>
        public static double Average(List<double> x, bool incNeg)
        {
            if (x.Count < 0)
            {
                throw new ArgumentException("x cannot be empty");
            }

            double sum = 0.0;
            foreach (double val in x)
            {
                if (incNeg || val >= 0)
                {
                    sum += val;
                }
            }
            return sum;
        }

        /// <summary>
        /// produces median value from an array set
        /// </summary>
        /// <param name="data">data from the List array of doubles</param>
        /// <returns>the number in the middle of the array</returns>
        public static double Median(List<double> data)
        {
            if (data.Count == 0)
            {
                throw new ArgumentException("Size of array must be greater than 0");
            }

            data.Sort();

            double median = data[data.Count / 2];
            if (data.Count % 2 == 0)
                median = (data[data.Count / 2] + data[data.Count / 2 - 1]) / 2;

            return median;
        }

        /// <summary>
        /// produces and displays the standard deviation for the set
        /// </summary>
        /// <param name="data">data from the List array of doubles</param>
        /// <returns>standard deviation</returns>
        public static double StandardDeviation(List<double> data)
        {
            if (data.Count <= 1)
            {
                throw new ArgumentException("Size of array must be greater than 1");
            }

            int n = data.Count;
            double s = 0;
            double a = A4.TotalAverage(data, true);

            for (int i = 0; i < n; i++)
            {
                double v = data[i];
                s += Math.Pow(v - a, 2);
            }
            double stdev = Math.Sqrt(s / (n - 1));
            return stdev;
        }

        // Simple set of tests that confirm that functions operate correctly
        static void Main(string[] args)
        {
            List<Double> testDataD = new List<Double> { 2.2, 3.3, 66.2, 17.5, 30.2, 31.1 };

            Console.WriteLine("The sum of the array = {0}", Average(testDataD, true));

            Console.WriteLine("The average of the array = {0}", TotalAverage(testDataD, true));

            Console.WriteLine("The median value of the Double data set = {0}", Median(testDataD));

            Console.WriteLine("The sample standard deviation of the Double test set = {0}\n", StandardDeviation(testDataD));
        }
    }
}
