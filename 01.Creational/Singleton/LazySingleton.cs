using System;

namespace Singleton.Basic
{
    /// <summary>
    /// Thread-safe Singleton using Lazy<T>.
    /// This is the recommended approach for most cases in .NET.
    /// </summary>
    public sealed class LazySingleton
    {
        // Lazy<T> provides built-in thread safety and lazy initialization.
        private static readonly Lazy<LazySingleton> _lazy = 
            new Lazy<LazySingleton>(() => new LazySingleton());

        public static LazySingleton Instance => _lazy.Value;

        private LazySingleton()
        {
            Console.WriteLine("LazySingleton Initialized");
        }

        public void DoSomething()
        {
            Console.WriteLine("LazySingleton is working.");
        }
    }
}
