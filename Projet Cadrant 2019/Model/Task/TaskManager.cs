using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Command;

namespace EasySave.Model.Task
{
    public sealed class TaskManager
    {
        public  List<ITask> Map { get; }

        private static readonly Lazy<TaskManager> lazy = new Lazy<TaskManager>(() => new TaskManager());
        public static TaskManager Instance { get { return lazy.Value; } }

        private TaskManager()
        {
            this.Map = new List<ITask>();
        }


        public void AddTask(string taskName, string cmdName)
        {
            Map.Add(new Task(taskName, cmdName));
        }

        public void RemoveTask(string name)
        {
            Map.RemoveAll(task => task.CmdName == name);
        }
    }
}
