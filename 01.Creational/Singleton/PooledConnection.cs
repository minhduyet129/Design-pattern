using System;

namespace Singleton.RealWorld
{
    /// <summary>
    /// A wrapper around the raw connection string that implements IDisposable.
    /// When this object is disposed (end of using block), it automatically returns the connection to the pool.
    /// </summary>
    public class PooledConnection : IDisposable
    {
        private readonly string _connection;
        private readonly DatabaseConnectionPool _pool;
        private bool _disposed = false;

        public string ConnectionString => _connection;

        public PooledConnection(string connection, DatabaseConnectionPool pool)
        {
            _connection = connection;
            _pool = pool;
        }

        public void ExecuteQuery(string query)
        {
            Console.WriteLine($"Executing '{query}' on {_connection}...");
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                // Return the connection back to the pool automatically!
                _pool.ReleaseConnection(_connection);
                _disposed = true;
                Console.WriteLine($"[Auto-Release] {_connection} returned to pool.");
            }
        }
    }
}
