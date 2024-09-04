using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Eventer.Logging
{
    public class LoggerManager
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public void LogError(string message) => _logger.Warn(message);
        public void LogInfo(string message) => _logger.Info(message);
        public void LogWarn(string message) => _logger.Warn(message);
        public void LogFatal(string message) => _logger.Fatal(message);
    }
}
