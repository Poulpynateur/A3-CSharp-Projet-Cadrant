﻿using System;
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
        public Thread Thread { get; }
        public ManualResetEvent ManualResetEvent { get; }

        public ThreadInfo(Thread thread, ManualResetEvent manualResetEvent)
        {
            IsStoped = false;
            Thread = thread;
            ManualResetEvent = manualResetEvent;
        }
    }
}