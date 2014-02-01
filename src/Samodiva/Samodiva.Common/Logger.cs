using System;
using log4net;

namespace Samodiva.Common
{
    public class Logger
    {
        private readonly ILog log;

        public Logger(Type type)
        {
            log = LogManager.GetLogger(type ?? typeof(Logger));
        }

        public void LogException(Exception ex, string message)
        {
            log.Error(message, ex);
        }

        public void LogException(Exception ex)
        {
            log.Error(ex.Message, ex);
        }
    }
}
