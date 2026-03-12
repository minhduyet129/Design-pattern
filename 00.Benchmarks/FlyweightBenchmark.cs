using BenchmarkDotNet.Attributes;
using Flyweight.Context;
using System;
using System.Collections.Generic;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class FlyweightBenchmark
    {
        private const int TreeCount = 100_000;

        // 1. Benchmark: Standard approach (No Flyweight)
        // Each tree has its own copy of heavy data.
        [Benchmark(Baseline = true)]
        public List<HeavyTree> StandardApproach()
        {
            var trees = new List<HeavyTree>();
            for (int i = 0; i < TreeCount; i++)
            {
                if (i % 2 == 0)
                    trees.Add(new HeavyTree(i, i, "Summer Oak", "Green", "OakTexture.png"));
                else
                    trees.Add(new HeavyTree(i, i, "Autumn Maple", "Orange", "MapleTexture.png"));
            }
            return trees;
        }

        // 2. Benchmark: Flyweight approach
        // Heavy data is shared via Flyweight.
        [Benchmark]
        public Forest FlyweightApproach()
        {
            var forest = new Forest();
            for (int i = 0; i < TreeCount; i++)
            {
                if (i % 2 == 0)
                    forest.PlantTree(i, i, "Summer Oak", "Green", "OakTexture.png");
                else
                    forest.PlantTree(i, i, "Autumn Maple", "Orange", "MapleTexture.png");
            }
            return forest;
        }
    }

    public class HeavyTree
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Texture { get; set; }

        public HeavyTree(int x, int y, string name, string color, string texture)
        {
            X = x;
            Y = y;
            Name = name;
            Color = color;
            Texture = texture;
        }
    }
}
