using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EasySave.Model.Command
{
    /// <summary>
    /// Base command class (other command must inherit from this class).
    /// </summary>
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

        /// <summary>
        /// Check if options :
        /// - are present
        /// - are valid (regex match)
        /// </summary>
        /// <param name="options">Options to check</param>
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

        /// <summary>
        /// Display the commands informations, used by <see cref="Specialisation.HelpCommand">.
        /// </summary>
        /// <returns>String that describe the command and his options.</returns>
        public override string ToString()
        {
            string str = "Name : " + Name + "\nDescription : " + Description ;

            if(Options.Count > 0)
            {
                str += "\nOptions :";
                foreach (KeyValuePair<string, string> option in this.Options)
                {
                    str += "\n    -" + option.Key + " [" + option.Value + "]";
                }
            }

            return str;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="options">Options to execute from</param>
        /// <returns>A message if success (otherwise will throw error)</returns>
        public abstract string Execute(Dictionary<string, string> options);
    }
}
