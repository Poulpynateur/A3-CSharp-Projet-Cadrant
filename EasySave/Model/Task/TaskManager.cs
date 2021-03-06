﻿using System;
using System.Collections.Generic;
using System.Linq;
using EasySave.Helpers.Files;
using EasySave.Model.Management;

namespace EasySave.Model.Task
{
    /// <summary>
    /// Singleton class. Manage the task and instanciate then.
    /// </summary>
    public sealed class TaskManager : ITaskManager
    {
        /// <summary>
        /// Config object
        /// </summary>
        private Config config;

        /// <summary>
        /// List of the tasks
        /// </summary>
        public List<Task> Map { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public TaskManager()
        {
            this.config = Management.Management.Instance.Config;
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
            Task task = new Task
            {
                CreatedAt = DateTime.Now,
                Name = taskName,
                JobName = cmdName,
                Options = options
            };
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
