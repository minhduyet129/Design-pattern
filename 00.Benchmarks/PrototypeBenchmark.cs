using BenchmarkDotNet.Attributes;
using Prototype.Prototypes;
using System;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class PrototypeBenchmark
    {
        private Circle _circle;
        private Rectangle _rectangle;

        [GlobalSetup]
        public void Setup()
        {
            _circle = new Circle { X = 10, Y = 10, Radius = 50, Color = "Red" };
            _rectangle = new Rectangle { X = 20, Y = 20, Width = 100, Height = 200, Color = "Blue" };
        }

        // 1. Benchmark: New Instance (Standard)
        [Benchmark(Baseline = true)]
        public void NewInstance()
        {
            var c = new Circle { X = 10, Y = 10, Radius = 50, Color = "Red" };
            var r = new Rectangle { X = 20, Y = 20, Width = 100, Height = 200, Color = "Blue" };
        }

        // 2. Benchmark: Prototype Clone
        [Benchmark]
        public void PrototypeClone()
        {
            var c = _circle.Clone();
            var r = _rectangle.Clone();
        }
    }
}
