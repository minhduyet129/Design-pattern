using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace Benchmarks
{
    [MemoryDiagnoser] // Tracks memory allocation
    public class SingletonBenchmark
    {
        // 1. Singleton Instance
        [Benchmark]
        public void SingletonAccess()
        {
            var instance = Singleton.Basic.LazySingleton.Instance;
            instance.DoSomething();
        }

        // 2. New Instance (Standard)
        [Benchmark(Baseline = true)]
        public void NewInstance()
        {
            var instance = new NormalClass();
            instance.DoSomething();
        }

        // 3. Static Method
        [Benchmark]
        public void StaticCall()
        {
            StaticClass.DoSomething();
        }
    }

    public class NormalClass
    {
        public void DoSomething() { }
    }

    public static class StaticClass
    {
        public static void DoSomething() { }
    }
}
