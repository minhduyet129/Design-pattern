using System;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Design Patterns Benchmark Runner ===");
            Console.WriteLine("Chon Pattern muon chay Benchmark:");
            Console.WriteLine("1. Singleton Pattern");
            Console.WriteLine("2. Builder Pattern");
            Console.WriteLine("3. Prototype Pattern");
            Console.WriteLine("4. Flyweight Pattern");
            Console.WriteLine("0. Thoat");
            Console.Write("\nLua chon cua ban: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nDang chay Benchmark cho Singleton Pattern...");
                    BenchmarkRunner.Run<SingletonBenchmark>();
                    break;
                case "2":
                    Console.WriteLine("\nDang chay Benchmark cho Builder Pattern...");
                    BenchmarkRunner.Run<BuilderBenchmark>();
                    break;
                case "3":
                    Console.WriteLine("\nDang chay Benchmark cho Prototype Pattern...");
                    BenchmarkRunner.Run<PrototypeBenchmark>();
                    break;
                case "4":
                    Console.WriteLine("\nDang chay Benchmark cho Flyweight Pattern...");
                    BenchmarkRunner.Run<FlyweightBenchmark>();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    break;
            }

            Console.WriteLine("\n\n============================================================");
            Console.WriteLine("   PHAN TICH KET QUA (BENCHMARK ANALYSIS)");
            Console.WriteLine("============================================================");
            Console.WriteLine("1. Mean: Thoi gian trung binh de thuc hien method.");
            Console.WriteLine("2. Allocated: Bo nho duoc cap phat.");
            Console.WriteLine("\nXem chi tiet tai file: BENCHMARK_ANALYSIS.md");
        }
    }
}
