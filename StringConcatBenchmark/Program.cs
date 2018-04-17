using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StringConcatBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate source
            var source = new List<string>();
            for (int i = 0; i < 30000; i++)
            {
                source.Add(i.ToString());
            }

            var stopwatch = new Stopwatch();

            // Benchmark 1
            stopwatch.Restart();
            StringJoin(source);
            stopwatch.Stop();

            Console.WriteLine($"Benchmark 1 runs for {stopwatch.Elapsed}");

            // Benchmark 2
            stopwatch.Restart();
            StringBuilder(source);
            stopwatch.Stop();

            Console.WriteLine($"Benchmark 2 runs for {stopwatch.Elapsed}");

            // Benchmark 3
            stopwatch.Restart();
            PlusOperator(source);
            stopwatch.Stop();

            Console.WriteLine($"Benchmark 3 runs for {stopwatch.Elapsed}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }


        static void StringJoin(List<string> source)
        {
            var result = string.Join(";", source);
        }

        static void StringBuilder(List<string> source)
        {
            var result = new StringBuilder();
            foreach (var item in source)
            {
                result.Append(item);
                result.Append(";");
            }
        }

        static void PlusOperator(List<string> source)
        {
            var result = string.Empty;
            foreach(var item in source)
            {
                result += item + ";";
            }
        }
    }
}
