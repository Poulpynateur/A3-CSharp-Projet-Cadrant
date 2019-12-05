using System;
using System.Collections.Generic;
using System.Linq;
using EasySave.Helpers.Files;
using EasySave.Model.Output;

namespace EasySave.Model.Task
{
    /// <summary>
    /// Singleton class. Manage the task and instanciate then.
    /// </summary>
    public sealed class TaskManager : ITaskManager
    {
        private Config config;

        public List<Task> Map { get; set; }

        private static readonly Lazy<TaskManager> lazy = new Lazy<TaskManager>(() => new TaskManager());
        public static TaskManager Instance { get { return lazy.Value; } }

        private TaskManager()
        { }

        public void LoadTasks(Config config)
        {
            this.config = config;
            Map = config.LoadTasks();
        }

        /// <summary>
        /// Add a task to the task list and the config file.
        /// </summary>
        /// <param name="taskName">Name of the task</param>
        /// <param name="cmdName">Name of the command of the task</param>
        /// <param name="options">Options of the command of the task</param>
        public void AddTask(string taskName, string cmdName, Dictionary<string, string> options)
        {
            Task task = new Task();
            task.CreatedAt = DateTime.Now;
            task.Name = taskName;
            task.JobName = cmdName;
            task.Options = options;
            Map.Add(task);

            config.SaveTasks(Map);
        }

        /// <summary>
        /// Remove task(s) from the task list and the config file.
        /// </summary>
        /// <param name="taskName">Task name to delete</param>
        /// <returns>Number of task deleted</returns>
        public int RemoveTask(string taskName)
        {
            int nbrRemove = Map.RemoveAll(task => task.Name == taskName);

            config.SaveTasks(Map);

            return nbrRemove;
        }

        /// <summary>
        /// Get a task by it's name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The task if found, else return null</returns>
        public Task GetTaskByName(string name)
        {
            return Map.Find(task => task.Name == name);
        }
    }
}
