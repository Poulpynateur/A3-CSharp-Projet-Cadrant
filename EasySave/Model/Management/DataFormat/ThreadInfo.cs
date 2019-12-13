using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasySave.Model.Management.DataFormat
{
    public class ThreadInfo
    {
        /// <summary>
        /// Boolean to check whether the ThreadInfo is stopped
        /// </summary>
        public bool IsStoped { get; set; }

        /// <summary>
        /// Boolean to check whether the ThreadInfo is priority
        /// </summary>
        public bool IsPriority { get; set; }

        /// <summary>
        /// Thread object
        /// </summary>
        public Thread Thread { get; }

        /// <summary>
        /// ManualResetEvent object to communicate to other threads
        /// </summary>
        public ManualResetEvent Pause { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="thread">Thread object</param>
        /// <param name="manualResetEvent">ManualResetEvent object</param>
        public ThreadInfo(Thread thread, ManualResetEvent manualResetEvent)
        {
            IsStoped = false;
            IsPriority = false;
            Thread = thread;
            Pause = manualResetEvent;
        }
    }
}
