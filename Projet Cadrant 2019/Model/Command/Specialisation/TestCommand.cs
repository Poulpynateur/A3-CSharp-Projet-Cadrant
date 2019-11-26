using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace EasySave.Model.Command.Specialisation
{
    public class TestCommand : ICommand
    {
        public string Name { get; }
        public string Description { get; }
        public Dictionary<string, string> Options { get; }

        public TestCommand()
        {
            this.Name = "test";
            this.Description = "Test function.";

            this.Options = new Dictionary<string, string>
            {
                { "o", "success|error" }
            };
        }

        private void CheckOptions(Dictionary<string, string> options)
        {
            foreach (KeyValuePair<string, string> option in this.Options)
            {
                Regex regex = new Regex(option.Value);
                if (!options.ContainsKey(option.Key) || !regex.IsMatch(options[option.Key]))
                {
                    throw new Exception("Option missing or invalid : -" + option.Key);
                }
            }
        }

        public string Execute(Dictionary<string, string> options)
        {
            this.CheckOptions(options);

            if (options["o"] == "error")
                throw new Exception("You ask for it.");

            return "Test done successfully !";
        }

        public string toString()
        {
            return Name;
        }
    }
}
