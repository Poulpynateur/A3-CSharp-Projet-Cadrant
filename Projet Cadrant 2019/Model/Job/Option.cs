using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Job
{
    public class Option
    {
        public string Name { get; }
        public string Description { get; }
        public string ValidationRegex { get; }

        public Option(string name, string description, string validationRegex)
        {
            Name = name;
            Description = description;
            ValidationRegex = validationRegex;
        }
    }
}
