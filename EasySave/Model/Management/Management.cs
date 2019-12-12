using EasySave.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;

namespace EasySave.Model.Management
{
    /// <summary>
    /// Class used to instanciate other classes that might output files
    /// </summary>
    public class Management
    {
        private static readonly Lazy<Management> lazy = new Lazy<Management>(() => new Management());
        public static Management Instance { get { return lazy.Value; } }

        public List<string> ErpBlacklist { get; set; }

        //Management of threads
        public Threads Threads { get; }

        //Manage Language
        public Lang Lang { get; }

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
        private Management()
        {
            this.Threads = new Threads();

            this.Logger = new Logger();
            this.Config = new Config();

            this.Lang = new Lang(Config.LoadLang());

            this.Display = new Displayable();

            this.Encrypt = new Encrypt(Config.LoadEncryptFormat());
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
