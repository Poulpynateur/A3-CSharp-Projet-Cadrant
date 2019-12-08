using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasySave.Model.Output
{
    public class Encrypt
    {
        private const string FOLDER_NAME = "CryptoSoft";
        private string cryptosoftPath;

        private List<string> cryptFormat;

        public Encrypt(List<string> cryptFormat)
        {
            this.cryptFormat = cryptFormat;
            this.cryptosoftPath = Path.Combine(Directory.GetCurrentDirectory(), FOLDER_NAME, "CryptoSoft.exe");
        }

        public bool IsEncryptTarget(string filePath)
        {
            string[] separators = { "." };
            string[] splits = filePath.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string extension = splits[splits.Length - 1];

            if (cryptFormat.Find(format => format == extension) != null)
                return true;
            return false;
        }

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
