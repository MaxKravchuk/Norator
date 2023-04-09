using Core.Interfaces.Services;
using log4net;
using log4net.Config;
using System.Reflection;

namespace Application.Services
{
    public class LoggerManager : ILoggerManager
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(LoggerManager));

        //public LoggerManager()
        //{
        //    var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
        //    XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        //    _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        //}

        public void LogDebug(string message) => _logger.Debug(message);

        public void LogError(string message) => _logger.Error(message);

        public void LogInfo(string message) => _logger.Info(message);

        public void LogWarn(string message) => _logger.Warn(message);
    }
}
