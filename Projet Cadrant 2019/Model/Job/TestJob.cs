using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EasySave.Model.Job
{
    public class TestJob : Job
    {
        public TestJob() : base("test", "Test command.")
        {
            this.Options = new Dictionary<string, string>
            {
                { "o", "success|warning|error" }
            };
        }

        public override void Execute(Dictionary<string, string> options)
        {
            this.checkOptionsValidity(options);

            updateJobState(State.Processing, "I am on my way ...");
            updateJobState(State.Processing, "Hang in there ...");

            updateJobState(State.Success, "Done.");
        }
    }
}
