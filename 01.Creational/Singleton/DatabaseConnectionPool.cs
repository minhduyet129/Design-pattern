using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Singleton.RealWorld
{
    /// <summary>
    /// Real-world Example 3: Database Connection Pool Manager
    /// Manages a limited set of expensive resources.
    /// </summary>
    public sealed class DatabaseConnectionPool
    {
        private static readonly Lazy<DatabaseConnectionPool> _instance = 
            new Lazy<DatabaseConnectionPool>(() => new DatabaseConnectionPool());
        
        private ConcurrentBag<string> _connections;
        private int _poolSize = 3;

        public static DatabaseConnectionPool Instance => _instance.Value;

        private DatabaseConnectionPool()
        {
            Console.WriteLine("Initializing Connection Pool...");
            _connections = new ConcurrentBag<string>();
            for (int i = 1; i <= _poolSize; i++)
            {
                _connections.Add($"Connection_{i}");
            }
        }

        public PooledConnection GetConnection()
        {
            if (_connections.TryTake(out string? connection))
            {
                Console.WriteLine($"-> Leased: {connection}");
                return new PooledConnection(connection, this);
            }
            Console.WriteLine("-> Failed to lease: Pool empty!");
            return null;
        }

        public void ReleaseConnection(string connection)
        {
            _connections.Add(connection);
        }
    }
}
