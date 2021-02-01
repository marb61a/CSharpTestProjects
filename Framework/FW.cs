using System;
using System.IO;
using Framework.Logging;
using NUnit.Framework;

namespace Framework
{
    public class FW
    {
        public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../../../../");
        public static Logger Log => _logger ?? throw new NullReferenceException("_logger is null. SetLogger() first.");

        [ThreadStatic]
        public static DirectoryInfo CurrentTestDirectory;

        [ThreadStatic]
        private static Logger _logger;

        public static void setLogger()
        {
            lock(_setLoggerLock)
            {
                
            }
        }

        private static object _setLoggerLock = new object();
    }
}