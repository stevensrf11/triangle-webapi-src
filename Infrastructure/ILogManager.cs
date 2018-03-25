using System;
using log4net;

namespace Infrastructure
{
    /// <summary>
    /// Log manager interface
    /// </summary>
    public interface ILogManager
    {
        /// <summary>
        /// Assign a log interface to a requested type
        /// </summary>
        /// <param name="typeAssociatedWithRequestedLog">Requested type</param>
        /// <returns>Log interface</returns>
        ILog GetLog(Type typeAssociatedWithRequestedLog);
    }
}
