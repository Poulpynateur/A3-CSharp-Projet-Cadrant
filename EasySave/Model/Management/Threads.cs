using EasySave.Model.Management.DataFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasySave.Model.Management
{
    public class Threads
    {
        public ManualResetEvent Priority { get; }
        public ManualResetEvent FileSizeLimit { get; }
        public Dictionary<string, ThreadInfo> Map { get; }

        public Threads()
        {
            Priority = new ManualResetEvent(true);
            FileSizeLimit = new ManualResetEvent(true);
            Map = new Dictionary<string, ThreadInfo>();
        }

        public bool AddThread(string name, Thread thread)
        {
            if(!Map.ContainsKey(name))
            {
                Map.Add(name, new ThreadInfo(thread, new ManualResetEvent(true)));
                return true;
            }
            return false;
        }

        public void PauseAll()
        {
            foreach (var thread in Map)
            {
                thread.Value.ManualResetEvent.Reset();
            }
        }

        public void SetThreadPriority(string name, bool priority)
        {
            Map[name].IsPriority = priority;

            if (priority)
                Priority.Reset();

            //Is last priority thread then free others 
            if (priority == false && !Map.Where(thread => thread.Value.IsPriority == true).Any())
                Priority.Set();
        }
    }
}
