using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Config
{
    public sealed class ConfigManager : ILogger, IProgress
    {
        private JsonManager json;

        private static readonly Lazy<ConfigManager> lazy =
            new Lazy<ConfigManager>(() => new ConfigManager());

        public static ConfigManager Instance { get { return lazy.Value; } }

        private ConfigManager()
        {
            this.json = new JsonManager();
        }

        public List<ITask> LoadTasks()
        {
            return new List<ITask>();
        }

        public void WriteLog()
        {
            throw new NotImplementedException();
        }

        public void WriteProgress()
        {
            throw new NotImplementedException();
        }
    }
}
