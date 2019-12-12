using EasySave.Model.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave.Controller
{
    class ThreadsManagement
    {
        private Threads threads;

        public ThreadsManagement(Threads threads)
        {
            this.threads = threads;
        }

        public void PauseThread(string name, bool pause)
        {
            if (pause)
                threads.Map[name].ManualResetEvent.Reset();
            else
                threads.Map[name].ManualResetEvent.Set();
        }

        public void StopThread(string name)
        {
            threads.Map[name].IsStoped = true;
        }

        public void StopAllThread()
        {
            foreach(var thread in threads.Map)
            {
                thread.Value.IsStoped = true;
            }
        }
    }
}
