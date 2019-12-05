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
        public DateTime Date { get; set; }

        public string TaskName { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public long FilesSize { get; set; }
        public TimeSpan TransfertTime { get; set; }

        /// <summary>
        /// JsonSerializer doesn't permit parameterized constructor.
        /// </summary>
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
