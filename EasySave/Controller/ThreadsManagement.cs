using EasySave.Model.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave.Controller
{
    /// <summary>
    /// Manage the Threads and their states
    /// </summary>
    class ThreadsManagement
    {
        /// <summary>
        /// Managed Threads
        /// </summary>
        private Threads threads;

        /// <summary>
        /// Constructor of the class taking a parameter
        /// </summary>
        /// <param name="threads">Instance of a Threads</param>
        public ThreadsManagement(Threads threads)
        {
            this.threads = threads;
        }

        /// <summary>
        /// Pause the thread if the boolean is true, else make it resume
        /// </summary>
        /// <param name="name">Name of the ThreadInfo to interact with</param>
        /// <param name="pause">Boolean to either stop the ThreadInfo or resume it</param>
        public void PauseThread(string name, bool pause)
        {
            if (pause)
                threads.Map[name].Pause.Reset();
            else
                threads.Map[name].Pause.Set();
        }

        /// <summary>
        /// Stop the thread corresponding to the ThreadInfo name in the parameters
        /// </summary>
        /// <param name="name">Name of the </param>
        public void StopThread(string name)
        {
            threads.Map[name].IsStoped = true;
        }

        /// <summary>
        /// Stop all the threads in the Dictionnary of the Threads field
        /// </summary>
        public void StopAllThread()
        {
            foreach(var thread in threads.Map)
            {
                thread.Value.IsStoped = true;
            }
        }
    }
}
