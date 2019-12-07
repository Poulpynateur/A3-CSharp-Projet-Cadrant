using EasySave.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Output
{
    public class Output
    {
        //Output to file (managed by model)
        public Logger Logger { get; }
        public Config Config { get; }

        //Output to view
        public Displayable Display { get; }

        public Output()
        {
            this.Logger = new Logger();
            this.Config = new Config();

            this.Display = new Displayable();
        }
    }
}
