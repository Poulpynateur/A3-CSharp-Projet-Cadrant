using EasySave.Helpers.Files;
using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasySave.Model.Config
{
    /// <summary>
    /// Mangage the config and logs of the app.
    /// </summary>
    public sealed class ConfigManager : ILogger
    {
        private string configPath;
        private string logPath;

        private JsonManager json;

        private static readonly Lazy<ConfigManager> lazy =
            new Lazy<ConfigManager>(() => new ConfigManager());

        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static ConfigManager Instance { get { return lazy.Value; } }

        private ConfigManager()
        {
            string projectDirectory = 
                Path.GetFullPath(
                    Path.Combine(Directory.GetCurrentDirectory(), "../../../")
                );

            this.configPath = Path.Combine(projectDirectory, "_config");
            Directory.CreateDirectory(configPath);
            this.logPath = Path.Combine(projectDirectory, "_log");
            Directory.CreateDirectory(logPath);

            this.json = new JsonManager();
        }

        /// <summary>
        /// Load all task informations from the tasks.json file.
        /// </summary>
        /// <returns></returns>
        public List<TaskInfo> LoadTasksInfo()
        {
            return json.ReadJson<List<TaskInfo>>(Path.Combine(configPath, "tasks.json")) ?? new List<TaskInfo>();
        }

        /// <summary>
        /// Write task informations to tasks.json file.
        /// </summary>
        /// <param name="tasks">List of task informations to write</param>
        public void WriteTasksInfo(List<TaskInfo> tasks)
        {
            json.WriteJson(tasks, Path.Combine(configPath, "tasks.json"));
        }

        /// <summary>
        /// Write log to the log folder.
        /// </summary>
        /// <param name="log"></param>
        public void WriteLog(Log log)
        {
            json.WriteJson(log, Path.Combine(logPath, FilesManager.GenerateName(log.TaskName) + ".json"));
        }

        /// <summary>
        /// Write progress to the progress.json file.
        /// </summary>
        /// <param name="progress"></param>
        public void WriteProgress(Progress progress)
        {
            json.WriteJson(progress, Path.Combine(logPath, "progress.json"));
        }
    }
}
