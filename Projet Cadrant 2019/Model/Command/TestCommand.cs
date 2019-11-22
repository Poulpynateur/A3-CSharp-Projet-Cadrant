using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    public class TestCommand : Command
    {
        public TestCommand() : base("Test", "This is a test command.")
        {
            this.Options = new Dictionary<string, string>();
        }

        public override void Execute(Dictionary<string, string> Options)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Some text in a test.");
            Console.ResetColor();
        }
    }
}
