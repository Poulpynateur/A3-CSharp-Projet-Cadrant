using EasySave.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;

namespace EasySave.Model.Output
{
    /// <summary>
    /// Class used to instanciate other classes that might output files
    /// </summary>
    public class Output
    {
        public List<string> ErpBlacklist { get; set; }
        
        //Manage Encryption (currently call to an external programm)
        public Encrypt Encrypt { get; }

        //Output to file (managed by model)
        public Logger Logger { get; }
        public Config Config { get; }

        //Output to view
        public Displayable Display { get; }

        /// <summary>
        /// Output constructor 
        /// </summary>
        public Output()
        {
            this.Logger = new Logger();
            this.Config = new Config();

            this.Display = new Displayable();

            this.Encrypt = new Encrypt(Config.LoadCryptFormat());
            ErpBlacklist = Config.LoadErpBlackList();
        }

        /// <summary>
        /// Check if another process is running
        /// </summary>
        public void CheckErpRunning()
        {
            foreach (var name in ErpBlacklist)
            {
                Process[] process = Process.GetProcessesByName(name);
                if (process.Length != 0)
                {
                    throw new Exception("ERP detected, close it before saving : " + name);
                }
            }
        }
    }
}
