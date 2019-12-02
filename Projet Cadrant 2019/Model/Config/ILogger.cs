using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Config
{
    /// <summary>
    /// Interface used to log informations.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Write log.
        /// </summary>
        /// <param name="log">Log to write</param>
        void WriteLog(Log log);
        /// <summary>
        /// Write progress.
        /// </summary>
        /// <param name="progress">Progress to write</param>
        void WriteProgress(Progress progress);
    }
}
