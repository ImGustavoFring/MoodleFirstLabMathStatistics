using ClassLibrary.Classes;
using System.Runtime.InteropServices;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Параметры для серии экспериментов
            int N = 10; // Количество бросков монеты в одном эксперименте
            int M = 5;  // Количество экспериментов в серии

            // Получаем серию экспериментов
            double[][] seriesExperiment = CoinExperiment.GetSeriesExperiment(N, M);

            // Выводим результаты серии экспериментов
            Console.WriteLine("Результаты серии экспериментов:");
            for (int i = 0; i < M; i++)
            {
                Console.WriteLine($"Эксперимент {i + 1}:");
                for (int j = 0; j < N; j++)
                {
                    Console.WriteLine($"  Результат броска {j + 1}: {seriesExperiment[i][j]}");
                }
            }
        }
    }

}
