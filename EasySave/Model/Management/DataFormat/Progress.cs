using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model
{
    /// <summary>
    ///  Format of the progress.
    /// </summary>
    public class Progress
    {
        public string Name { get; set; }

        public bool IsPaused { get; set; }
        public DateTime Date { get; set; }
        /// <summary>
        /// Total files
        /// </summary>
        public int FilesNumber { get; set; }
        public long TotalFilesSize { get; set; }

        /// <summary>
        /// Already done files
        /// </summary>
        public int FilesDone { get; set; }
        public int RemainingFiles { get; set; }
        public long RemainingFilesSize { get; set; }

        public string FileInProgress { get; set; }

        public int EncryptionTimeMs { get; set; }

        /// <summary>
        /// JsonSerializer doesn't permit parameterized constructor.
        /// </summary>
        public void FeedProgress(string name, int filesNumber, long totalFilesSize)
        {
            Name = name;
            IsPaused = false;
            EncryptionTimeMs = 0;
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
        public Progress RefreshFileProgress(string fileInProgress, long fileSize)
        {
            IsPaused = false;
            Date = DateTime.Now;
            FilesDone += 1;
            RemainingFiles = FilesNumber - FilesDone;
            FileInProgress = fileInProgress;
            RemainingFilesSize -= fileSize;

            return this;
        }
    }
}
