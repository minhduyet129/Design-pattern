using BenchmarkDotNet.Attributes;
using Builder.Builders;
using Builder.Director;
using Builder.Product;
using System;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class BuilderBenchmark
    {
        private HouseDirector _director;
        private ConcreteHouseBuilder _builder;

        [GlobalSetup]
        public void Setup()
        {
            _director = new HouseDirector();
            _builder = new ConcreteHouseBuilder();
            _director.Builder = _builder;
        }

        // 1. Benchmark: New Instance (Standard)
        [Benchmark(Baseline = true)]
        public void StandardConstructor()
        {
            var house = new House
            {
                Walls = 8,
                Doors = 3,
                Windows = 6,
                HasRoof = true,
                HasGarage = true,
                HasSwimmingPool = true,
                HasGarden = true
            };
        }

        // 2. Benchmark: Builder Pattern
        [Benchmark]
        public void BuilderPattern()
        {
            _director.BuildLuxuryHouse();
            var house = _builder.GetResult();
        }

        // 3. Benchmark: Direct Builder (No Director)
        [Benchmark]
        public void DirectBuilder()
        {
            _builder.BuildWalls(8);
            _builder.BuildDoors(3);
            _builder.BuildWindows(6);
            _builder.BuildRoof();
            _builder.BuildGarage();
            _builder.BuildSwimmingPool();
            _builder.BuildGarden();
            var house = _builder.GetResult();
        }
    }
}
