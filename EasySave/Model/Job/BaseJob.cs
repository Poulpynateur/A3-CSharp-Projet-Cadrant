using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EasySave.Model.Job
{
    /// <summary>
    /// Base command class (other command must inherit from this class).
    /// </summary>
    public abstract class BaseJob
    {
        protected Management.Management management;

        /// <summary>
        /// Information about an option
        /// </summary>
        public Option Info { get; }

        /// <summary>
        /// Options of the command :
        /// - Key are the option name
        /// - Value is a regex to validate the option value
        /// </summary>
        public List<Option> Options { protected set; get; }

        /// <summary>
        /// BaseCommand constructor.
        /// </summary>
        /// <param name="name">Name of the command</param>
        /// <param name="description">Description of the command</param>
        public BaseJob(string name, string description)
        {
            this.management = Management.Management.Instance;
            this.Info = new Option(name, description, "");
        }

        /// <summary>
        /// Check if options :
        /// - are present
        /// - are valid (regex match)
        /// </summary>
        /// <param name="options">Options to check</param>
        protected void CheckOptions(Dictionary<string, string> options)
        {
            foreach (Option Option in this.Options)
            {
                Regex regex = new Regex(Option.ValidationRegex);
                
                if(options.ContainsKey(Option.Name))
                {
                    if (!regex.IsMatch(options[Option.Name]))
                    {
                        throw new Exception(management.Lang.Translate("Field not valid : ") + Option.Name);
                    }
                }
                else
                {
                    throw new Exception(management.Lang.Translate("Field missing : ") + Option.Name);
                }
            }
        }

        /// <summary>
        /// Display the commands informations, used by <see cref="Specialisation.HelpCommand"/>.
        /// </summary>
        /// <returns>String that describe the command and his options.</returns>
        public override string ToString()
        {
            string str = "Name : " + Info.Name + "\nDescription : " + Info.Description ;

            if(Options != null)
            {
                str += "\nOptions :";
                foreach (Option option in this.Options)
                {
                    str += "\n    -" + option.Name + " : " + option.Description;
                }
            }

            return str;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="options">Options to execute from</param>
        /// <returns>A message if success (otherwise will throw error)</returns>
        public abstract void Execute(Dictionary<string, string> options);
    }
}
