using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Config
{
    /// <summary>
    ///  Format of the progress.
    /// </summary>
    public class Progress
    {
        public DateTime Date { get; set; }
        public int FilesNumber { get; set; }
        public long TotalFilesSize { get; set; }

        public int FilesDone { get; set; }
        public int RemainingFiles { get; set; }
        public long RemainingFilesSize { get; set; }

        public string FileInProgress { get; set; }

        /// <summary>
        /// JsonSerializer doesn't permit parameterized constructor.
        /// </summary>
        public void FeedProgress(int filesNumber, long totalFilesSize)
        {
            Date = DateTime.Now;
            FilesNumber = filesNumber;
            TotalFilesSize = totalFilesSize;
            FilesDone = 0;
            RemainingFiles = filesNumber;
            RemainingFilesSize = totalFilesSize;
            FileInProgress = "";
        }

        /// <summary>
        /// Refresh the progress object.
        /// </summary>
        public void RefreshProgress(string fileInProgress)
        {
            Date = DateTime.Now;
            FilesDone = FilesNumber - RemainingFiles;
            FileInProgress = fileInProgress;
        }
    }
}
