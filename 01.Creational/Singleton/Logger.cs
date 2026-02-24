using System;
using System.IO;

namespace Singleton.RealWorld
{
    /// <summary>
    /// Real-world Example 2: Centralized Logger
    /// Ensures all logs go through a single point of control (e.g., locking file access).
    /// </summary>
    public sealed class Logger
    {
        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());
        private readonly object _lock = new object();

        public static Logger Instance => _instance.Value;

        private Logger() { }

        public void Log(string message)
        {
            // Simulate writing to a file in a thread-safe way
            lock (_lock)
            {
                Console.WriteLine($"[LOG - {DateTime.Now}]: {message}");
            }
        }
    }
}
