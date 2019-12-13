using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Job
{

    /// <summary>
    /// All the informations about a quick-save or a task.
    /// </summary>
    public class Option
    {
        /// <summary>
        /// Name of the quick-save/task
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Description of the quick-save/task
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Regex validation of the quick-save/task
        /// </summary>
        public string ValidationRegex { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the quick-save/task</param>
        /// <param name="description">Description of the quick-save/task</param>
        /// <param name="validationRegex">Regex validation of the quick-save/task</param>
        public Option(string name, string description, string validationRegex)
        {
            Name = name;
            Description = description;
            ValidationRegex = validationRegex;
        }
    }
}
