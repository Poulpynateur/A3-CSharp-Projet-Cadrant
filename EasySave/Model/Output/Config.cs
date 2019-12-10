using EasySave.Helpers.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasySave.Model.Output
{
    /// <summary>
    /// Load the configuration.
    /// </summary>
    public class Config
    {
        private const string FOLDER_NAME = "config";
        private string configPath;

        public Config()
        {
            this.configPath = Directory.CreateDirectory(
                Path.Combine(Directory.GetCurrentDirectory(), FOLDER_NAME)
            ).FullName;
        }

        /// <summary>
        /// Load ERP blacklist.
        /// </summary>
        public List<string> LoadErpBlackList()
        {
            return JsonHelper.ReadJson<List<string>>(Path.Combine(configPath, "ERP blacklist.json")) ?? new List<string>();
        }

        /// <summary>
        /// Save ERP blacklist.
        /// </summary>
        /// <param name="erp">Entered list by the user</param>
        public void SaveErpBlackList(List<string> erp)
        {
            JsonHelper.WriteJson(erp, Path.Combine(configPath, "ERP blacklist.json"));
        }

        /// <summary>
        /// Load the crypt format of the tasks.
        /// </summary>
        public List<string> LoadEncryptFormat()
        {
            return JsonHelper.ReadJson<List<string>>(Path.Combine(configPath, "Encrypt extensions.json")) ?? new List<string>();
        }

        /// <summary>
        /// Save the crypt format of the task
        /// </summary>
        /// <param name="format">Entered crypt format by the user</param>
        public void SaveEncryptFormat(List<string> format)
        {
            JsonHelper.WriteJson(format, Path.Combine(configPath, "Encrypt extensions.json"));
        }

        /// <summary>
        /// Load the config of the differential save.
        /// </summary>
        /// <param name="path">Entered path by the user</param>
        public Dictionary<string, string> LoadDiffSaveConfig(string path)
        {
            return JsonHelper.ReadJson<Dictionary<string, string>>(Path.Combine(path, "conf.json")) ?? new Dictionary<string, string>();
        }

        /// <summary>
        /// Save the config of the differential save.
        /// </summary>
        /// <param name="diffConfign">Entered the differencial save config by the user</param>
        /// <param name="path">Entered path by the user</param>
        public void SaveDiffSaveConfig(Dictionary<string, string> diffConfign, string path)
        {
            string filePath = Path.Combine(path, "conf.json");
            if (!File.Exists(filePath))
                JsonHelper.WriteJson(diffConfign, filePath);
        }

        /// <summary>
        /// Load all the tasks.
        /// </summary>
        public List<Task.Task> LoadTasks()
        {
            return JsonHelper.ReadJson<List<Task.Task>>(Path.Combine(configPath, "tasks.json")) ?? new List<Task.Task>();
        }

        /// <summary>
        /// Save a renseigned task.
        /// </summary>
        /// <param name="tasks">Save the new tasks in the json file</param>
        public void SaveTasks(List<Task.Task> tasks)
        {
            JsonHelper.WriteJson(tasks, Path.Combine(configPath, "tasks.json"));
        }
    }
}
