using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Command;
using EasySave.Model.Config;
using System.Linq;

namespace EasySave.Model.Task
{
    /// <summary>
    /// Singleton class. Manage the task and instanciate then.
    /// </summary>
    public sealed class TaskManager : ITaskManager
    {
        public ConfigManager Config { private get; set; }
        public List<ITask> Map { get; set; }

        private static readonly Lazy<TaskManager> lazy = new Lazy<TaskManager>(() => new TaskManager());
        public static TaskManager Instance { get { return lazy.Value; } }

        private TaskManager()
        {
            this.Map = new List<ITask>();
        }

        /// <summary>
        /// Create taks from task informations.
        /// </summary>
        /// <param name="infos">List of task informations</param>
        public void TasksFromInfo(List<TaskInfo> infos)
        {
            foreach(TaskInfo info in infos)
            {
                Map.Add(new Task(info));
            }
        }

        /// <summary>
        /// Add a task to the task list and the config file.
        /// </summary>
        /// <param name="taskName">Name of the task</param>
        /// <param name="cmdName">Name of the command of the task</param>
        /// <param name="options">Options of the command of the task</param>
        public void AddTask(string taskName, string cmdName, Dictionary<string, string> options)
        {
            if(Map.Count() < 5)
            {
                TaskInfo info = new TaskInfo();
                info.CreatedAt = DateTime.Now;
                info.Name = taskName;
                info.CmdName = cmdName;
                info.Options = options;

                Map.Add(new Task(info));

                //Write config
                List<TaskInfo> infos = Map.Select(task => task.Info).ToList();
                Config.WriteTasksInfo(infos);
            }
            else
            {
                throw new Exception("Max number of task (5) reached, remove tasks before adding new ones.");
            }
        }

        /// <summary>
        /// Remove task(s) from the task list and the config file.
        /// </summary>
        /// <param name="taskName">Task name to delete</param>
        /// <returns>Number of task deleted</returns>
        public int RemoveTask(string taskName)
        {
            int nbrRemove = Map.RemoveAll(task => task.Info.Name == taskName);

            //Write config
            List<TaskInfo> infos = Map.Select(task => task.Info).ToList();
            Config.WriteTasksInfo(infos);
            return nbrRemove;
        }

        /// <summary>
        /// Get a task by it's name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The task if found, else return null</returns>
        public ITask GetTaskByName(string name)
        {
            return Map.Find(task => task.Info.Name == name);
        }
    }
}
