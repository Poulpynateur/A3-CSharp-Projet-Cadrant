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

        /// <summary>
        /// HelpJob constructor
        /// </summary>
        /// <param name="commands"></param>
        public HelpJob(IJobManager commands)
            : base("help", "Show command's descriptions and avaible options.")
        {
            this.jobs = commands;
        }
        
        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// Show commands informations use the <see cref="BaseCommand.ToString"/> function of each commands.
        /// </summary>
        /// <param name="options">Don't have any options (only present because of the Override)</param>
        public override void Execute(Dictionary<string, string> options)
        {
            foreach(BaseJob command in jobs.Map)
            {
                management.Display.DisplayText(Helpers.Statut.INFO, "\n" + command.ToString());
            }
        }
    }
}
