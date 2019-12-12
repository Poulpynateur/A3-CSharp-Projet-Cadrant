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
        public bool IsStoped { get; set; }
        public bool IsPriority { get; set; }
        public Thread Thread { get; }
        public ManualResetEvent Pause { get; }

        public ThreadInfo(Thread thread, ManualResetEvent manualResetEvent)
        {
            IsStoped = false;
            IsPriority = false;
            Thread = thread;
            Pause = manualResetEvent;
        }
    }
}
