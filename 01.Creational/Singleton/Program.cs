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
            
            // 2. Configuration Manager
            Console.WriteLine("\n--- 2. Configuration Manager ---");
            var dbConn = ConfigurationManager.Instance.GetSetting("DbConnectionString");
            Console.WriteLine($"DB Connection: {dbConn}");

            // 3. Connection Pool with IDisposable (The "using" pattern)
            Console.WriteLine("\n--- 3. Connection Pool (IDisposable Pattern) ---");
            var pool = DatabaseConnectionPool.Instance;

            // Client 1: Uses connection and automatically releases it
            Console.WriteLine("\n[Client 1] Requesting connection...");
            using (var conn1 = pool.GetConnection())
            {
                if (conn1 != null) conn1.ExecuteQuery("SELECT * FROM Users");
            } // conn1 is disposed here -> returned to pool

            // Client 2
            Console.WriteLine("\n[Client 2] Requesting connection...");
            using (var conn2 = pool.GetConnection())
            {
                if (conn2 != null) conn2.ExecuteQuery("SELECT * FROM Products");
            }

            // Simulate heavy load (Pool size = 3)
            Console.WriteLine("\n[Simulating High Load]");
            using (var c1 = pool.GetConnection())
            using (var c2 = pool.GetConnection())
            using (var c3 = pool.GetConnection())
            {
                Console.WriteLine("Pool is now exhausted.");
                var c4 = pool.GetConnection(); // Should fail or wait
                if (c4 == null) Console.WriteLine("Client 4 waiting... (Pool Empty)");
            } // c1, c2, c3 released here

            // Check if returned connections are reusable
            Console.WriteLine("\n[Client 5] Retry after release...");
            using (var c5 = pool.GetConnection())
            {
                if (c5 != null) Console.WriteLine("Client 5 got connection successfully!");
            }

            Console.WriteLine("\nEnd of Singleton Demo.");
        }
    }
}
