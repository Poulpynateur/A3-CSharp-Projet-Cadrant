using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command.Specialisation
{
    /// <summary>
    /// Display all commands and their descriptions.
    /// </summary>
    class HelpCommand : BaseCommand
    {
        private ICommandManager commands;

        public HelpCommand(ICommandManager commands)
            : base("help", "Show command's descriptions and avaible options.")
        {
            this.commands = commands;
            this.Options = new Dictionary<string, string>();
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// Show commands informations use the <see cref="BaseCommand.ToString"/> function of each commands.
        /// </summary>
        public override string Execute(Dictionary<string, string> options)
        {
            string str = "";

            foreach(BaseCommand command in commands.Map)
            {
                str += "\n\n" + command.ToString();
            }

            return str;
        }

        /// <summary>
        /// <see cref="BaseCommand.ToString"/>
        /// </summary>
        public override string ToString()
        {
            return "Name :" + Name + "\nDescription : " + Description;
        }
    }
}
