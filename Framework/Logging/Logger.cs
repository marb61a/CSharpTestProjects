using System;
using System.IO;

namespace Framework.Logging
{
    public class Logger
    {
        private readonly string _filepath;

        public Logger(string testName, string filepath)
        {
            _filepath = filepath;

            using(var log = File.CreateText(_filepath))
            {
                log.WriteLine($"Starting Timestamp : {DateTime.Now.ToLocalTime()}");
                log.WriteLine($"Test: {testName}");
            }
        }

        public void Info(string message)
        {
            WriteLine($"[INFO]: {message}");
        }
    }
}