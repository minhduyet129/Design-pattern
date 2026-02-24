using System;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running Benchmarks...");
            // Use BenchmarkRunner to run the benchmarks
            var summary = BenchmarkRunner.Run<SingletonBenchmark>();
        }
    }
}
