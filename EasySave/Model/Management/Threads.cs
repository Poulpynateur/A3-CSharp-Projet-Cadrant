using EasySave.Model.Management.DataFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasySave.Model.Management
{
    /// <summary>
    /// Used for 
    /// </summary>
    public class Threads
    {
        /// <summary>
        /// ManualResetEvent to manage priority
        /// </summary>
        public ManualResetEvent Priority { get; }

        /// <summary>
        /// ManualResetEvent to manage the limit size of the files
        /// </summary>
        public ManualResetEvent FileSizeLimit { get; }

        /// <summary>
        /// Dictionary of the name of the thread and the ThreadInfo
        /// </summary>
        public Dictionary<string, ThreadInfo> Map { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Threads()
        {
            Priority = new ManualResetEvent(true);
            FileSizeLimit = new ManualResetEvent(true);
            Map = new Dictionary<string, ThreadInfo>();
        }

        /// <summary>
        /// Add the thread in the dictionary while checking if already in the dictionary
        /// </summary>
        /// <param name="name">Name of the thread</param>
        /// <param name="thread">Thread object</param>
        /// <returns>Boolean to check if the thread is already in the dictionary</returns>
        public bool AddThread(string name, Thread thread)
        {
            if(!Map.ContainsKey(name))
            {
                Map.Add(name, new ThreadInfo(thread, new ManualResetEvent(true)));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Pause all the threads in the dictionary
        /// </summary>
        public void PauseAll()
        {
            foreach (var thread in Map)
            {
                thread.Value.Pause.Reset();
            }
        }

        /// <summary>
        /// Set the thread priority
        /// </summary>
        /// <param name="name">Name of the thread</param>
        /// <param name="priority">Boolean used to set the priority</param>
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
