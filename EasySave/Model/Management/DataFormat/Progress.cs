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
        /// <summary>
        /// Name of the job in progress
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Boolean to check if the progress is paused
        /// </summary>
        public bool IsPaused { get; set; }

        /// <summary>
        /// Date of the execution
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Number of total files
        /// </summary>
        public int FilesNumber { get; set; }

        /// <summary>
        /// Total size of the files
        /// </summary>
        public long TotalFilesSize { get; set; }

        /// <summary>
        /// Number of already done files
        /// </summary>
        public int FilesDone { get; set; }

        /// <summary>
        /// Number of remaining files
        /// </summary>
        public int RemainingFiles { get; set; }

        /// <summary>
        /// Size of the remaining files
        /// </summary>
        public long RemainingFilesSize { get; set; }

        /// <summary>
        /// Path of the file which is in progress
        /// </summary>
        public string FileInProgress { get; set; }

        /// <summary>
        /// Time spent on the encryption
        /// </summary>
        public int EncryptionTimeMs { get; set; }

        /// <summary>
        /// JsonSerializer doesn't permit parameterized constructor.
        /// </summary>
        /// <param name="name">Name of the task</param>
        /// <param name="filesNumber">Number of files</param>
        /// <param name="totalFilesSize">Total size of the files</param>
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
        /// <param name="fileInProgress">Path of the file in progress</param>
        /// <param name="fileSize">Size of the file</param>
        /// <returns>Returns the Progress object refreshed</returns>
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
