using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasySave.Helpers;
using EasySave.Helpers.Files;
using EasySave.Model.Management;

namespace EasySave.Model.Job.Specialisation
{
    /// <summary>
    /// Everything in commun between save differential and save mirror
    /// </summary>
    class SaveJob
    {
        /// <summary>
        /// Name of the job
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Is the job is encrypted
        /// </summary>
        public bool Encrypt { get; }
        /// <summary>
        /// Source folder of the save
        /// </summary>
        public string Source { get; }
        /// <summary>
        /// Target folder of the save
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Information on the progress of the save
        /// </summary>
        public Progress Progress { get; }

        /// <summary>
        /// <see cref="Management.Management"/>
        /// </summary>
        private Management.Management management;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="management"><see cref="Management.Management"/></param>
        /// <param name="name">Name of the save</param>
        /// <param name="source">Source folder</param>
        /// <param name="target">Target folder</param>
        /// <param name="encrypt">Is encrypted</param>
        public SaveJob(Management.Management management, string name, string source, string target, bool encrypt)
        {
            this.management = management;
            this.Progress = new Progress();
            this.Name = name;
            this.Source = source;
            this.Target = target;
            this.Encrypt = encrypt;
        }

        /// <summary>
        /// Copy a file from the source path to the target path
        /// </summary>
        /// <param name="path">Path of the file to copy</param>
        public void CopyTargetFile(string path)
        {
            //To make pause easier during test
            Thread.Sleep(500);

            string newPath = path.Replace(Source, Target);
            File.Copy(path, newPath, true);

            //If the file is a encrypt target we rewrite the file
            if (Encrypt && management.Encrypt.IsEncryptTarget(path))
            {
                Progress.EncryptionTimeMs = management.Encrypt.EncryptFileCryptoSoft(path, newPath);
                if (Progress.EncryptionTimeMs < 0)
                    throw new Exception("Encryption error on " + path);
            }
        }

        /// <summary>
        /// Check if a ERP is running, if so we pause the tasks (<see cref="Management.Management.CheckErpRunning"/>)
        /// </summary>
        public void CheckERP()
        {
            if (management.CheckErpRunning())
            {
                Progress.IsPaused = true;
                management.Display.DisplayProgress(Name, Progress);
            }
        }

        /// <summary>
        /// Check if we have the hand to copy (priority and file size) and launch <see cref="SaveJob.CopyTargetFile(string)"/>
        /// </summary>
        /// <param name="path"></param>
        public void CheckAndCopy(string path)
        {
            management.Threads.FileSizeLimit.WaitOne();
            long fileSize = new FileInfo(path).Length;

            //Pause other threads
            if (fileSize > management.MaxBytesFileSize)
                management.Threads.FileSizeLimit.Reset();

            this.CopyTargetFile(path);

            //Free other threads
            if (fileSize > management.MaxBytesFileSize)
                management.Threads.FileSizeLimit.Set();
        }

        /// <summary>
        /// Get the files from the source folder
        /// </summary>
        /// <returns>Array of path</returns>
        public string[] GetFiles()
        {
            string[] files = Directory.GetFiles(Source, "*", SearchOption.AllDirectories);
            Progress.FeedProgress(Name, files.Length, FilesHelper.GetFilesSize(files));
            return files;
        }

        /// <summary>
        /// Check if target and source folders exists
        /// </summary>
        public void CheckIfFoldersExist()
        {
            if (!Directory.Exists(Source))
                throw new Exception("Source folder doesn't exist : " + Source);
            if (!Directory.Exists(Target))
                throw new Exception("Target folder doesn't exist : " + Target);
        }

        /// <summary>
        /// Output the progress to the interface and files socket
        /// </summary>
        /// <param name="newPath">Path of the file copied</param>
        private void OutputProgress(string newPath)
        {
            lock(management.Logger)
            {
                management.Logger.WriteProgress(
                    Progress.RefreshFileProgress(newPath, new FileInfo(newPath).Length)
                );              
            }
            management.Display.DisplayProgress(Name, Progress);
        }

        /// <summary>
        /// Check if the job have been stoped
        /// </summary>
        /// <param name="path">Path to launch output if we don't stop</param>
        /// <returns>True if we stop and false otherwise</returns>
        public bool CheckIfStopped(string path)
        {
            if (management.Threads.Map[Name].IsStoped)
            {
                management.Threads.Map.Remove(Name);
                return true;
            }
            OutputProgress(path);
            return false;
        }

        /// <summary>
        /// Start the thread if the name doesn't already exist (otherwise show warning)
        /// </summary>
        /// <param name="thread"></param>
        public void StartIfNotExist(Thread thread)
        {
            if (management.Threads.AddThread(Name, thread))
                thread.Start();
            else
                management.Display.DisplayText(Statut.WARNING, Name + " is already started.");
        }

        /// <summary>
        /// End of the save, remove the thread from the list and display state
        /// </summary>
        /// <param name="result"></param>
        public void SaveEnd(int result)
        {
            if (result < 0)
                management.Display.DisplayText(Statut.INFO, Name + " stopped.");
            else
                management.Display.DisplayText(Statut.SUCCESS, Name + " finish successfully.");

            management.Threads.Map.Remove(Name);
        }

        /// <summary>
        /// Get priority file into a special list
        /// </summary>
        /// <param name="files">All files path</param>
        /// <param name="priority">List to store priority files path</param>
        /// <param name="others">List to store the others</param>
        public void GetPriorityFiles(string[] files, List<string> priority, List<string> others)
        {
            foreach (var file in files)
            {
                if (management.PriorityExtension.Find(x => x == FilesHelper.GetFileExtension(file)) != null)
                    priority.Add(file);
                else
                    others.Add(file);
            }
        }
    }
}