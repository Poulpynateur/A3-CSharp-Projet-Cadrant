using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Command;

namespace EasySave.Model.Task
{
    public class TaskManager : ITaskManager
    {
        private List<ITask> tasks;

        public void AddTask(string name, Command.Command command)
        {
            tasks.Add(new Task(command));
        }

        public void RemoveTask(string name)
        {
            tasks.RemoveAll(task => task.Command.Name == name);
        }
    }
}
