using System;
using System.Threading.Tasks;
using Singleton.Basic;
using Singleton.RealWorld;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Singleton Pattern Showcase ===\n");

            // 1. Basic Usage
            Console.WriteLine("--- 1. Basic Lazy Singleton ---");
            LazySingleton.Instance.DoSomething();
            LazySingleton.Instance.DoSomething(); // Constructor not called again
            
            // 2. Configuration Manager
            Console.WriteLine("\n--- 2. Configuration Manager ---");
            var dbConn = ConfigurationManager.Instance.GetSetting("DbConnectionString");
            Console.WriteLine($"DB Connection: {dbConn}");

            // 3. Logger (Thread Safety Check)
            Console.WriteLine("\n--- 3. Logger (Multi-threaded) ---");
            Parallel.For(0, 5, i =>
            {
                Logger.Instance.Log($"Message from thread {Task.CurrentId}");
            });

            // 4. Connection Pool
            Console.WriteLine("\n--- 4. Connection Pool ---");
            var pool = DatabaseConnectionPool.Instance;
            Console.WriteLine($"Client 1 got: {pool.GetConnection()}");
            Console.WriteLine($"Client 2 got: {pool.GetConnection()}");
            Console.WriteLine($"Client 3 got: {pool.GetConnection()}");
            Console.WriteLine($"Client 4 got: {pool.GetConnection()}"); // Should be empty

            Console.WriteLine("\nEnd of Singleton Demo.");
        }
    }
}
