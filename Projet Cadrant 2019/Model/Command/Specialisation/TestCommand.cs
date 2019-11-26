using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace EasySave.Model.Command.Specialisation
{
    public class TestCommand : BaseCommand
    {
        public TestCommand()
        : base("test", "Test function.")
        {
            this.Options = new Dictionary<string, string>
            {
                { "o", "success|error" }
            };
        }


        public override string Execute(Dictionary<string, string> options)
        {
            this.CheckOptions(options);

            if (options["o"] == "error")
                throw new Exception("You ask for it.");

            return "Test done successfully !";
        }
    }
}
