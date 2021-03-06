﻿using EasySave.Helpers.Files;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasySave.Model.Management
{
    /// <summary>
    /// Encrypt the save.
    /// </summary>
    public class Encrypt
    {
        /// <summary>
        /// Folder name
        /// </summary>
        private const string FOLDER_NAME = "CryptoSoft";

        /// <summary>
        /// Path where is stored the folder name
        /// </summary>
        private string cryptosoftPath;

        /// <summary>
        /// List containing the file formats to encrypt
        /// </summary>
        public List<string> CryptFormat { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cryptFormat">List which contains the file formats to encrypt</param>
        public Encrypt(List<string> cryptFormat)
        {
            this.CryptFormat = cryptFormat;
            this.cryptosoftPath = Path.Combine(Directory.GetCurrentDirectory(), FOLDER_NAME, "CryptoSoft.exe");
        }

        /// <summary>
        /// Check if the target need to be encrypted with the given format.
        /// </summary>
        /// <param name="filePath">Given path by the user</param>
        /// <returns>The file crypted format</returns>
        public bool IsEncryptTarget(string filePath)
        {
            string extension = FilesHelper.GetFileExtension(filePath);

            if (CryptFormat.Find(format => format == extension) != null)
                return true;
            return false;
        }

        /// <summary>
        /// Encrypt all the files.
        /// </summary>
        /// <param name="pathFrom">Entered source path from the user</param>
        /// <param name="pathTo">Entered target path from the user</param>
        /// <returns>The exit code of the process</returns>
        public int EncryptFileCryptoSoft(string pathFrom, string pathTo)
        {
            string password = ConfigurationManager.AppSettings["CryptoSoftPassword"];

            ProcessStartInfo start = new ProcessStartInfo();
            start.Arguments = "encrypt " + password + " \"" + pathFrom + "\" \"" + pathTo + "\"";
            // Enter the executable to run, including the complete path
            start.FileName = cryptosoftPath;
            // Do you want to show a console window?
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;

            // Run the external process & wait for it to finish
            using (Process proc = Process.Start(start))
            {
                proc.WaitForExit();

                // Retrieve the app's exit code
                return proc.ExitCode;
            }
        }
    }
}
