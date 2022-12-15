using System;
using System.Configuration;
using NUnit.Framework;

namespace ParaBankPractice.Helpers
{
    public class ConfigHelper
    {
        public static string WEB_ENV { get; }
        public static string WEB_URL { get; }
        public static string WEB_API_URL { get; }

        static ConfigHelper()
        {
            WEB_ENV = ReadConfiguration("env");
            WEB_URL = ReadConfiguration("url");
            WEB_API_URL = ReadConfiguration("apiUrl");
        }

        private static bool ReadBooleanConfiguration(string key)
        {
            string rawValue = "";
            bool value;
            try
            {
                rawValue = ReadConfiguration(key);
                value = Boolean.Parse(rawValue);
            }
            catch (Exception e)
            {
                throw new Exception("Configuration parameter: '" + key +
                                    "' should be Boolean and have value of true/false, but the value was: '" +
                                    rawValue + "'");
            }

            return value;
        }

        private static string ReadConfiguration(string key)
        {
            string value;

            Console.WriteLine("Reading configuration for key: " + key + " from .runsettings");
            value = TestContext.Parameters[key];

            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Reading configuration for key: " + key + " from .config");
                value = ConfigurationManager.AppSettings.Get(key);
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Reading configuration for key: " + key + " from environment variable");
                value = Environment.GetEnvironmentVariable(key);
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("Configuration parameter: '" + key +
                                    "' could not be found in any of the expected sources: runsettings, config or environment variable");
            }
            return value;
        }
    }
}