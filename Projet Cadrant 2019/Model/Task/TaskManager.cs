using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Job;

namespace EasySave.Model.Task
{
    public class TaskManager : ITaskManager
    {
        private List<ITask> map;

        public TaskManager()
        {
            this.map = new List<ITask>();
        }

        public void AddTask(string name, Job.Job Job)
        {
            map.Add(new Task(Job));
        }

        public void RemoveTask(string name)
        {
            map.RemoveAll(task => task.Job.Name == name);
        }
    }
}
