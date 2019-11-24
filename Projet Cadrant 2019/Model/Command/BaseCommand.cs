using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EasySave.Model.Command
{
    public abstract class BaseCommand : ICommand
    {
        public static event ICommand.CmdStateHandler CmdState;

        public Type Type { get; }
        public State State { get; private set; }

        public string Name { get; }
        public string Description { get; }
        public Dictionary<string, string> Options { get; protected set; }

        public BaseCommand(Type type, string name, string description)
        {
            this.Type = type;
            this.Name = name;
            this.Description = description;
        }

        protected void updateCmdState(State state, string input)
        {
            this.State = state;
            CmdState(state, input);
        }

        protected void checkOptionsValidity(Dictionary<string, string> options)
        {
            foreach (KeyValuePair<string, string> option in options)
            {
                if (this.Options.ContainsKey(option.Key))
                {
                    Regex regex = new Regex(this.Options[option.Key]);
                    if(!regex.IsMatch(option.Value))
                        updateCmdState(State.Warning, "-" + option.Key + " doesn't accept '" + option.Value + "'");
                }
                else
                    updateCmdState(State.Warning, "Option '" + option.Key + "' doesn't exist.");
            }
        }

        public abstract void Execute(Dictionary<string, string> Options);

    }
}