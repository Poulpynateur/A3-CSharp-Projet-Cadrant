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
        /// <summary>
        /// Folder name where to store the logs
        /// </summary>
        private const string FOLDER_NAME = "log";

        /// <summary>
        /// ProgressSocket object
        /// </summary>
        private ProgressSocket progressSocket;

        /// <summary>
        /// Path of where the folder "log" will be stored
        /// </summary>
        private string logPath;

        /// <summary>
        /// Path where to store the progress log
        /// </summary>
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

        /// <summary>
        /// Dispose of the resources used by the progress socket
        /// </summary>
        public void Close()
        {
            if(progressSocket._client != null)
                progressSocket._client.Dispose();
            if (progressSocket._socket != null)
                progressSocket._socket.Dispose();
        }

        /// <summary>
        /// Write a Json file for the log
        /// </summary>
        /// <param name="log">Log object</param>
        public void WriteLog(Log log)
        {
            JsonHelper.WriteJson(log, Path.Combine( logPath, FilesHelper.GenerateName(log.TaskName)) + ".json");
        }

        /// <summary>
        /// Write a Json File for the progress
        /// </summary>
        /// <param name="progress">Progress object</param>
        public void WriteProgress(Progress progress)
        {
            JsonHelper.WriteJson(progress, progressPath);
            progressSocket.SendProgress(
                progressSocket.ConvertProgressToBuffer(
                    progress.Name,
                    progress.FilesNumber,
                    progress.FilesDone,
                    progress.FileInProgress
                )
            );
        }
    }
}
