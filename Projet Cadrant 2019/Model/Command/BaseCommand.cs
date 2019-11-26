using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EasySave.Model.Command
{
    public abstract class BaseCommand
    {
        public string Name { get; }
        public string Description { get; }
        public Dictionary<string, string> Options { protected set; get; }

        public BaseCommand(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        protected void CheckOptions(Dictionary<string, string> options)
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

        public override string ToString()
        {
            string str = "Name : " + Name + "\nDescription : " + Description + "\nOptions :\n";

            foreach (KeyValuePair<string, string> option in this.Options)
            {
                str += "    -" + option.Key + " [" + option.Value + "]\n";
            }

            return str;
        }

        public abstract string Execute(Dictionary<string, string> options);
    }
}
