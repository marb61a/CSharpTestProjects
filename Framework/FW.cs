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
    }
}