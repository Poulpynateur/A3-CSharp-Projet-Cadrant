using EasySave.Model.Command.Specialisation;
using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    public sealed class CommandManager
    {
        public List<ICommand> Map { get; }

        private static readonly Lazy<CommandManager> lazy = new Lazy<CommandManager>(() => new CommandManager());
        public static CommandManager Instance { get { return lazy.Value; } }

        private CommandManager()
        {
            Map = new List<ICommand>()
            {
                new TestCommand()
            };
        }

        public ICommand getCmdByName(string name)
        {
            return Map.Find(command => command.Name == name);
        }
    }
}
