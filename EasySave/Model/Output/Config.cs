using EasySave.Helpers.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasySave.Model.Output
{
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

        public List<string> LoadErpBlackList()
        {
            return JsonHelper.ReadJson<List<string>>(Path.Combine(configPath, "ErpBlacklist.json")) ?? new List<string>();
        }
        public void SaveErpBlackList(List<string> erp)
        {
            JsonHelper.WriteJson(erp, Path.Combine(configPath, "ErpBlacklist.json"));
        }

        public List<string> LoadCryptFormat()
        {
            return JsonHelper.ReadJson<List<string>>(Path.Combine(configPath, "CryptFormat.json")) ?? new List<string>();
        }
        public void SaveCryptFormat(List<string> format)
        {
            JsonHelper.WriteJson(format, Path.Combine(configPath, "CryptFormat.json"));
        }

        public Dictionary<string, string> LoadDiffSaveConfig(string path)
        {
            return JsonHelper.ReadJson<Dictionary<string, string>>(Path.Combine(path, "conf.json")) ?? new Dictionary<string, string>();
        }
        public void SaveDiffSaveConfig(Dictionary<string, string> diffConfign, string path)
        {
            string filePath = Path.Combine(path, "conf.json");
            if (!File.Exists(filePath))
                JsonHelper.WriteJson(diffConfign, filePath);
        }

        public List<Task.Task> LoadTasks()
        {
            return JsonHelper.ReadJson<List<Task.Task>>(Path.Combine(configPath, "tasks.json")) ?? new List<Task.Task>();
        }

        public void SaveTasks(List<Task.Task> tasks)
        {
            JsonHelper.WriteJson(tasks, Path.Combine(configPath, "tasks.json"));
        }
    }
}
