using EasySave.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Management
{
    /// <summary>
    /// Display the status of the job.
    /// </summary>
    public class Displayable : IDisplayable
    {
        public event IDisplayable.DisplayUpdate DisplayUpdateEvent;
        public event IDisplayable.TaskProgressUpdate TaskProgressUpdateEvent;

        /// <summary>
        /// Display a text
        /// </summary>
        /// <param name="statut">Statut of the job</param>
        /// <param name="text">Text to display</param>
        public void DisplayText(Statut statut, string text)
        {
            DisplayUpdateEvent(statut, text);
        }

        /// <summary>
        /// Display the progress of the job
        /// </summary>
        /// <param name="jobName">Name of the job</param>
        /// <param name="progress">Progress of the job</param>
        public void DisplayProgress(string jobName, Progress progress)
        {
            TaskProgressUpdateEvent(jobName, progress);
        }
    }
}
