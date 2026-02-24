using System;
using System.Collections.Generic;

namespace Singleton.RealWorld
{
    /// <summary>
    /// Real-world Example 1: Configuration Manager
    /// Simulates loading application settings once and accessing them globally.
    /// </summary>
    public sealed class ConfigurationManager
    {
        private static readonly Lazy<ConfigurationManager> _instance = 
            new Lazy<ConfigurationManager>(() => new ConfigurationManager());
        
        private Dictionary<string, string> _settings;

        public static ConfigurationManager Instance => _instance.Value;

        private ConfigurationManager()
        {
            Console.WriteLine("Loading configuration from file...");
            // Simulate heavy IO operation
            _settings = new Dictionary<string, string>
            {
                { "DbConnectionString", "Server=.;Database=MyDb;Trusted_Connection=True;" },
                { "MaxRetries", "3" },
                { "ApiKey", "Secret_12345" }
            };
        }

        public string? GetSetting(string key)
        {
            return _settings.ContainsKey(key) ? _settings[key] : null;
        }
    }
}
