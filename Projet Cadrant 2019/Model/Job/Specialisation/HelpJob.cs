using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Job.Specialisation
{
    /// <summary>
    /// Display all commands and their descriptions.
    /// </summary>
    class HelpJob : BaseJob
    {
        private IJobManager jobs;

        public HelpJob(IJobManager commands)
            : base("help", "Show command's descriptions and avaible options.")
        {
            this.jobs = commands;
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// Show commands informations use the <see cref="BaseCommand.ToString"/> function of each commands.
        /// </summary>
        public override void Execute(Dictionary<string, string> options)
        {
            foreach(BaseJob command in jobs.Map)
            {
                Output.Display.DisplayText(Helpers.Statut.INFO, "\n" + command.ToString());
            }
        }
    }
}
