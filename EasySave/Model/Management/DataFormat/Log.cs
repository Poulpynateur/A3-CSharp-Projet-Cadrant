using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model
{
    /// <summary>
    /// Format of the log to read from Json.
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Date of the execution
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Name of the task
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Source path
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Target path
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Size of the total files
        /// </summary>
        public long FilesSize { get; set; }

        /// <summary>
        /// Time spent on the transfer
        /// </summary>
        public TimeSpan TransfertTime { get; set; }

        /// <summary>
        /// JsonSerializer doesn't permit parameterized constructor.
        /// </summary>
        /// <param name="taskName">Name of the task</param>
        /// <param name="source">Source path</param>
        /// <param name="target">Target path</param>
        /// <param name="filesSize">Total size of the files</param>
        /// <param name="transfertTime">Time of transfert</param>
        public void FeedLog(string taskName, string source, string target, long filesSize, TimeSpan transfertTime)
        {
            Date = DateTime.Now;
            TaskName = taskName;
            Source = source;
            Target = target;
            FilesSize = filesSize;
            TransfertTime = transfertTime;
        }
    }
}
