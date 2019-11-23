using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EasySave.Model.Job
{
    public abstract class Job
    {
        public enum State { Error, Warning, Processing, Success };

        public delegate void JobStateHandler(State state, string input);
        static public event JobStateHandler JobState;

        public string Name { get; }
        public string Description { get; }
        public Dictionary<string, string> Options { get; protected set; }

        public Job(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        //Because you can't call an event from a child class
        protected void updateJobState(State state, string input)
        {
            JobState(state, input);
        }

        protected void checkOptionsValidity(Dictionary<string, string> options)
        {
            foreach (KeyValuePair<string, string> option in options)
            {
                if (this.Options.ContainsKey(option.Key))
                {
                    Regex regex = new Regex(this.Options[option.Key]);
                    if(!regex.IsMatch(option.Value))
                        JobState(State.Warning, "-" + option.Key + " doesn't accept '" + option.Value + "'");
                }
                else
                    JobState(State.Warning, "Option '" + option.Key + "' doesn't exist.");
            }
        }

        public abstract void Execute(Dictionary<string, string> Options);

    }
}
