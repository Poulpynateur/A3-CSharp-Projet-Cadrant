using EasySave.Helpers;
using EasySave.Helpers.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasySave.Model.Management
{
    /// <summary>
    /// Class used to write logs
    /// </summary>
    public class Logger
    {
        private const string FOLDER_NAME = "log";
        private ProgressSocket progressSocket;
        private string logPath;
        private string progressPath;

        /// <summary>
        /// Constructor of the Logger
        /// </summary>
        public Logger()
        {
            progressSocket = new ProgressSocket();
            this.logPath = Directory.CreateDirectory(
                Path.Combine(Directory.GetCurrentDirectory(), FOLDER_NAME)
            ).FullName;

            this.progressPath = Directory.CreateDirectory(
                Path.Combine(Directory.GetCurrentDirectory(), FOLDER_NAME)
            ).FullName;
            this.progressPath = Path.Combine(progressPath, "progress.json");
        }

        public void Close()
        {
            progressSocket._client.Dispose();
            progressSocket._socket.Dispose();
        }

        /// <summary>
        /// Write a Json file for the log
        /// </summary>
        /// <param name="log"></param>
        public void WriteLog(Log log)
        {
            JsonHelper.WriteJson(log, Path.Combine( logPath, FilesHelper.GenerateName(log.TaskName)) + ".json");
        }

        /// <summary>
        /// Write a Json File for the progress
        /// </summary>
        /// <param name="progress"></param>
        public void WriteProgress(Progress progress)
        {
            JsonHelper.WriteJson(progress, progressPath);
            progressSocket.SendProgress(
                progressSocket.ConvertProgressToBuffer(
                    progress.Name,
                    progress.FilesNumber,
                    progress.FilesNumber,
                    progress.FileInProgress
                )
            );
        }
    }
}
