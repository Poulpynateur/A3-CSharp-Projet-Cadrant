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
        void WriteLog(Log log);
        void WriteProgress(Progress progress);
    }
}
