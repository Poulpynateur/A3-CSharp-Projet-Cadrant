using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Command;

namespace EasySave.Model.Task
{
    public class TaskManager : ITaskManager
    {
        public  List<ITask> Map { get; }

        public TaskManager()
        {
            this.Map = new List<ITask>();
        }

        public void AddTask(string taskName, BaseCommand cmd)
        {
            Map.Add(new Task(taskName, cmd));
        }

        public void RemoveTask(string name)
        {
            Map.RemoveAll(task => task.Job.Name == name);
        }
    }
}
