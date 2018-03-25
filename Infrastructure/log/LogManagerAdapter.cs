using System;
using log4net;

namespace Infrastructure.log
{
    /// <summary>
    /// Log manager adapter class used adapt log message to type object message is logged in.
    /// <see cref="ILogManager/>
    /// </summary>
    public class LogManagerAdapter : ILogManager
    {
        #region ILogManager Operations
        /// <summary>
        /// Assigna a log interface to a requested type
        /// </summary>
        /// <param name="typeAssociatedWithRequestedLog">Requested type</param>
        /// <returns>Log interface</returns>
        public ILog GetLog(Type typeAssociatedWithRequestedLog)
        {
            var log = LogManager.GetLogger(typeAssociatedWithRequestedLog);
            return log;
        }
        #endregion
    }
}
