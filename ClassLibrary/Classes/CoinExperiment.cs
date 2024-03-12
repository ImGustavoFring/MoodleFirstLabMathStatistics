using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Classes
{
    public static class CoinExperiment
    {
        public static double[] GetOneExperiment(int N)
        {
            var result = new double[N];
            int headsCount = 0; // кол-во выпадений решки
            int flipCoin;

            for (int i = 0; i < N; i++)
            {
                flipCoin = Coin.Flip();
                if (flipCoin == 1) 
                {
                    headsCount++;
                }
                result[i] = (double)headsCount / (i + 1);
            }
            return result;
        }
        public static double[][] GetSeriesExperiment(int N, int M)
        {
            var result = new double[M][];
            for (int i = 0; i < M; i++)
            {
                result[i] = GetOneExperiment(N);
            }
            return result;
        }
        public static double[] GetColumnMeans(double[][] result) // метод для вычисления средней частоты по столбцам
        {
            int rowCount = result.Length;
            int columnCount = result[0].Length;
            double[] columnMeans = new double[columnCount];
            double sum;

            for (int j = 0; j < columnCount; j++) 
            {
                sum = 0;
                for (int i = 0; i < rowCount; i++)
                {
                    sum += result[i][j];
                }
                columnMeans[j] = sum / rowCount;
            }
            return columnMeans;
        }
        public static double[][] GetConfidenceInterval(double[][] result, double alpha)
        {
            int m = result.Length; 
            double a = (1 - alpha) / 2;
            int mDown = (int)(m * a);
            int mUp = m - mDown - 1;

            Sort2DArray(result);

            double[][] intervals = new double[result[0].Length][];
            for (int j = 0; j < result[0].Length; j++)
            {
                intervals[j] = new double[] { result[mDown][j], result[mUp][j] };
            }

            return intervals;
        }

        private static void Sort2DArray(double[][] array)
        {
            int rowCount = array.Length;
            int columnCount = array[0].Length;

            for (int j = 0; j < columnCount; j++)
            {
                double[] column = Enumerable.Range(0, rowCount)
                                             .Select(i => array[i][j])
                                             .OrderBy(x => x)
                                             .ToArray();
                for (int i = 0; i < rowCount; i++)
                {
                    array[i][j] = column[i];
                }
            }
        }
        static public double GetNormalQuantile(double p)
        {
            return 4.91 * (Math.Pow(p, 0.14) - Math.Pow((1 - p), 0.14));
        }
        static public double[] GetTheoreticalError(int N, double alpha)
        {
            double coefficient = GetNormalQuantile((1+ alpha) / 2);
            var theoreticalErrorValues = new double[N];

            for (int i = 1; i < N + 1; i++)
            {
                theoreticalErrorValues[i - 1] = coefficient * Math.Sqrt(0.5 * 0.5 / i);
            }
            return theoreticalErrorValues;
        }
    }
}
