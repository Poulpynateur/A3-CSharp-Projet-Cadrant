using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    public class CommandManager : ICommandManager
    {
        public List<Command> Commands { get; }
        
        public CommandManager()
        {
            Commands = new List<Command>();

            //Add all commands there
            Commands.Add(new TestCommand());
        }

        public void ExecuteCommand(string name, Dictionary<string, string> options)
        {
            Command command = Commands.Find(command => command.Name == name);
            
            if(command != null)
                command.Execute(options);
        }
    }
}
