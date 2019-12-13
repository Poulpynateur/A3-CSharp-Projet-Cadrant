using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Task
{
    /// <summary>
    /// Interface to access task manager.
    /// </summary>
    public interface ITaskManager
    {
        /// <summary>
        /// Map of the tasks.
        /// </summary>
        List<Task> Map { get; }

        /// <summary>
        /// Get a task by its name.
        /// </summary>
        /// <param name="name">Name of the target task</param>
        /// <returns>A task or null</returns>
        Task GetTaskByName(string name);

        /// <summary>
        /// Add a task.
        /// </summary>
        /// <param name="taskName">Task name</param>
        /// <param name="cmdName">Command linked to the task</param>
        /// <param name="options">Options of the linked command</param>
        void AddTask(string taskName, string cmdName, Dictionary<string, string> options);

        /// <summary>
        /// Remove a task
        /// </summary>
        /// <param name="taskName">Name of the task to remove</param>
        /// <returns>Number of task removed.</returns>
        int RemoveTask(string taskName);
    }
}
