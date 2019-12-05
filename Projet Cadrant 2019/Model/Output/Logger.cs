using EasySave.Helpers;
using EasySave.Helpers.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasySave.Model.Output
{
    public class Logger
    {
        private const string FOLDER_NAME = "log";

        private string logPath;
        private string progressPath;

        public Logger()
        {
            this.logPath = Directory.CreateDirectory(
                Path.Combine(Directory.GetCurrentDirectory(), FOLDER_NAME)
            ).FullName;

            this.progressPath = Directory.CreateDirectory(
                Path.Combine(Directory.GetCurrentDirectory(), FOLDER_NAME)
            ).FullName;
            this.progressPath = Path.Combine(progressPath, "progress.json");
        }

        public void WriteLog(Log log)
        {
            JsonHelper.WriteJson(log, Path.Combine( logPath, FilesHelper.GenerateName(log.TaskName)));
        }

        public void WriteProgress(Progress progress)
        {
            JsonHelper.WriteJson(progress, progressPath);
        }
    }
}
