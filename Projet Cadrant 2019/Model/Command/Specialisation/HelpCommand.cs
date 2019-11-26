using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command.Specialisation
{
    class HelpCommand : BaseCommand
    {
        private ICommandManager commands;

        public HelpCommand(ICommandManager commands)
            : base("help", "Show commands descriptions and avaible options.")
        {
            this.commands = commands;
            this.Options = new Dictionary<string, string>();
        }


        public override string Execute(Dictionary<string, string> options)
        {
            string str = "";

            foreach(BaseCommand command in commands.Map)
            {
                str += command.ToString() + "\n\n";
            }

            return str;
        }

        public override string ToString()
        {
            return "Name :" + Name + "\nDescription : " + Description;
        }
    }
}
