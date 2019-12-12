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

        public void DisplayText(Statut statut, string text)
        {
            DisplayUpdateEvent(statut, text);
        }

        public void DisplayProgress(string jobName, Progress progress)
        {
            TaskProgressUpdateEvent(jobName, progress);
        }
    }
}
