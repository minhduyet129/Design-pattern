using System;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Design Patterns Benchmark Runner ===");
            Console.WriteLine("Dang chay Benchmark cho Singleton Pattern...");
            Console.WriteLine("Vui long doi trong giay lat (co the mat 1-2 phut)...");
            
            // Use BenchmarkRunner to run the benchmarks
            var summary = BenchmarkRunner.Run<SingletonBenchmark>();

            Console.WriteLine("\n\n============================================================");
            Console.WriteLine("   PHAN TICH KET QUA (BENCHMARK ANALYSIS)");
            Console.WriteLine("============================================================");
            Console.WriteLine("1. Mean: Thoi gian trung binh de thuc hien method.");
            Console.WriteLine("   - SingletonAccess: Truy cap qua Instance property.");
            Console.WriteLine("   - NewInstance: Tao moi object moi lan goi (Baseline).");
            Console.WriteLine("   - StaticCall: Goi method tinh (Static).");
            Console.WriteLine("\n2. Allocated: Bo nho duoc cap phat.");
            Console.WriteLine("   - SingletonAccess & StaticCall: Thuong la 0 hoac rat thap (vi khong new object).");
            Console.WriteLine("   - NewInstance: Se ton bo nho cho moi lan goi.");
            Console.WriteLine("\n3. KET LUAN:");
            Console.WriteLine("   - Singleton nhanh hon viec 'new' object nhieu lan vi bo qua duoc step cap phat bo nho.");
            Console.WriteLine("   - Tuy nhien, Singleton cham hon Static Method mot chut xiu vi phai qua Property Getter.");
            Console.WriteLine("   - Hieu qua nhat: Static Method > Singleton > New Instance.");
            Console.WriteLine("============================================================");
            Console.WriteLine("Xem chi tiet tai file: BENCHMARK_ANALYSIS.md");
        }
    }
}
