using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Helpers
{
    /// <summary>
    /// List of all the possible status of a job.
    /// </summary>
    public enum Statut
    {
        INFO,
        SUCCESS,
        ERROR,
        WARNING
    }

    public interface IDisplayable
    {
        /// <summary>
        /// Method notifying about the status of the job.
        /// </summary>*
        /// <param name="statut">Actual status of the selected job/param>
        /// <param name="text">Message text according to the status</param>
        delegate void DisplayUpdate(Statut statut, string text);
        event DisplayUpdate DisplayUpdateEvent;
    }
}
