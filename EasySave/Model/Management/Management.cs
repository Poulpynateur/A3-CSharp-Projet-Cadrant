using EasySave.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Windows;

namespace EasySave.Model.Management
{
    /// <summary>
    /// Class used to instanciate other classes that might output files
    /// </summary>
    public class Management
    {
        /// <summary>
        /// Lazy class used for thread-safe
        /// </summary>
        private static readonly Lazy<Management> lazy = new Lazy<Management>(() => new Management());

        /// <summary>
        /// Instance for the singleton
        /// </summary>
        public static Management Instance { get { return lazy.Value; } }

        /// <summary>
        /// List of the blacklisted ERP
        /// </summary>
        public List<string> ErpBlacklist { get; set; }

        /// <summary>
        /// List of the priority extensions
        /// </summary>
        public List<string> PriorityExtension { get; set; }

        /// <summary>
        /// Maximum size of files to transfer in byte
        /// </summary>
        public long MaxBytesFileSize { get; set; }

        /// <summary>
        /// Management of threads
        /// </summary>
        public Threads Threads { get; }

        /// <summary>
        /// Manage Language
        /// </summary>
        public Lang Lang { get; }

        /// <summary>
        /// Manage Encryption (currently call to an external programm)
        /// </summary>
        public Encrypt Encrypt { get; }

        /// <summary>
        /// Output to file (managed by model)
        /// </summary>
        public Logger Logger { get; }

        /// <summary>
        /// Configuration to get
        /// </summary>
        public Config Config { get; }

        /// <summary>
        /// Output to view
        /// </summary>
        public Displayable Display { get; }

        /// <summary>
        /// Constructor 
        /// </summary>
        private Management()
        {
            this.MaxBytesFileSize = 2048;
            this.Threads = new Threads();

            this.Logger = new Logger();
            this.Config = new Config();

            this.Lang = new Lang(Config.LoadLang());

            this.Display = new Displayable();

            this.Encrypt = new Encrypt(Config.LoadEncryptFormat());
            this.ErpBlacklist = Config.LoadErpBlackList();
            this.PriorityExtension = Config.LoadPriorityExtension();
        }

        /// <summary>
        /// Check if another process is running
        /// </summary>
        /// <returns>Boolean returning true if an ERP is running, false if not</returns>
        public bool CheckErpRunning()
        {
            foreach (var name in ErpBlacklist)
            {
                Process[] process = Process.GetProcessesByName(name);
                if (process.Length != 0)
                {
                    Threads.PauseAll();
                    MessageBox.Show("ERP softaware detected, close it : " + name, "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return true;
                }
            }
            return false;
        }
    }
}
