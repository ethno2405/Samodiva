using System;
using System.Diagnostics.Contracts;
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
            Contract.Requires<ArgumentNullException>(ex != null);

            log.Error(message, ex);
        }

        public void LogException(Exception ex)
        {
            Contract.Requires<ArgumentNullException>(ex != null);

            log.Error(ex.Message, ex);
        }
    }
}
