using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EasySave.Model.Command
{
    public class TestCommand : BaseCommand
    {
        public TestCommand() : base(Type.Standard, "test", "Test command.")
        {
            this.Options = new Dictionary<string, string>
            {
                { "o", "success|warning|error" }
            };
        }

        public override void Execute(Dictionary<string, string> options)
        {
            this.checkOptionsValidity(options);

            updateCmdState(State.Processing, "I am on my way ...");
            updateCmdState(State.Processing, "Hang in there ...");

            updateCmdState(State.Success, "Done.");
        }
    }
}
