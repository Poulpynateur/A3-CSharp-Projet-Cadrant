using EasySave.Model.Task;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Command
{
    public class CommandManager : ICommandManager
    {
        public List<ICommand> Map { get; }

        //Bubble cmd event for controller and config
        public event ICommand.CmdStateHandler CmdState
        {
            add { BaseCommand.CmdState += value; }
            remove { BaseCommand.CmdState -= value; }
        }

        public CommandManager(ITaskManager taskManager)
        {
            Map = new List<ICommand>()
            {
                new TestCommand(),
                new TaskAddCommand(taskManager),
                new TaskShowCommand(taskManager)
            };
        }

        public ICommand getCmdByName(string name)
        {
            return Map.Find(command => command.Name == name);
        }

        public bool isCmdName(string name)
        {
            ICommand command = Map.Find(command => command.Name == name);
            return (command != null) ? true : false;
        }
    }
}
