using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Command;
using EasySave.Model.Config;

namespace EasySave.Model.Task
{
    public sealed class TaskManager : ITaskManager
    {
        public ILogger Logger { private get; set; }
        public  List<ITask> Map { get; set; }

        private static readonly Lazy<TaskManager> lazy = new Lazy<TaskManager>(() => new TaskManager());
        public static TaskManager Instance { get { return lazy.Value; } }

        private TaskManager()
        {
            this.Map = new List<ITask>();
        }

        public void AddTask(string taskName, string cmdName, Dictionary<string, string> options)
        {
            Map.Add(new Task(Logger, taskName, cmdName, options));
        }

        public void RemoveTask(string taskName)
        {
            Map.RemoveAll(task => task.Name == taskName);
        }
    }
}
