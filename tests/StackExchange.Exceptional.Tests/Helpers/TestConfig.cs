﻿using Jil;
using System;

namespace StackExchange.Exceptional.Tests
{
    public static class TestConfig
    {
        private const string FileName = "TestConfig.json";

        public static Config Current { get; }

        static TestConfig()
        {
            Current = new Config();
            try
            {
                var json = Resource.Get(FileName);
                if (!string.IsNullOrEmpty(json))
                {
                    Current = JSON.Deserialize<Config>(json);
                    Console.WriteLine("  {0} found, using for configuration.", FileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Deserializing TestConfig.json: " + ex);
            }
        }

        public class Config
        {
            public bool RunLongRunning { get; set; }

            public string SQLConnectionString { get; set; } = "Server=.;Database=tempdb;Trusted_Connection=True;";
            public string MySQLConnectionString { get; set; }
        }
    }
}