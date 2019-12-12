﻿using System;
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
        public string Name { get; }
        public bool Encrypt { get; }
        public string Source { get; }
        public string Target { get; set; }

        public Progress Progress { get; }

        private Management.Management management;

        public SaveJob(Management.Management management, string name, string source, string target, bool encrypt)
        {
            this.management = management;
            this.Progress = new Progress();
            this.Name = name;
            this.Source = source;
            this.Target = target;
            this.Encrypt = encrypt;
        }

        public void CopyTargetFile(string path)
        {
            Thread.Sleep(500);

            string newPath = path.Replace(Source, Target);
            File.Copy(path, newPath, true);
            if (Encrypt && management.Encrypt.IsEncryptTarget(path))
            {
                Progress.EncryptionTimeMs = management.Encrypt.EncryptFileCryptoSoft(path, newPath);
                if (Progress.EncryptionTimeMs < 0)
                    throw new Exception("Encryption error on " + path);
            }
        }

        public void CheckERP()
        {
            if (management.CheckErpRunning())
            {
                Progress.IsPaused = true;
                management.Display.DisplayProgress(Name, Progress);
            }
        }

        public void CheckAndCopy(string path)
        {
            management.Threads.FileSizeLimit.WaitOne();
            long fileSize = new FileInfo(path).Length;

            if (fileSize > management.MaxBytesFileSize)
                management.Threads.FileSizeLimit.Reset();

            this.CopyTargetFile(path);

            if (fileSize > management.MaxBytesFileSize)
                management.Threads.FileSizeLimit.Set();
        }

        public string[] GetFiles()
        {
            string[] files = Directory.GetFiles(Source, "*", SearchOption.AllDirectories);
            Progress.FeedProgress(files.Length, FilesHelper.GetFilesSize(files));
            return files;
        }

        public void CheckIfFoldersExist()
        {
            if (!Directory.Exists(Source))
                throw new Exception("Source folder doesn't exist : " + Source);
            if (!Directory.Exists(Target))
                throw new Exception("Target folder doesn't exist : " + Target);
        }

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

        public void StartIfNotExist(Thread thread)
        {
            if (management.Threads.AddThread(Name, thread))
                thread.Start();
            else
                management.Display.DisplayText(Statut.WARNING, Name + " is already started.");
        }

        public void SaveEnd(int result)
        {
            if (result < 0)
                management.Display.DisplayText(Statut.INFO, Name + " stopped.");
            else
                management.Display.DisplayText(Statut.SUCCESS, Name + " finish successfully.");

            management.Threads.Map.Remove(Name);
        }

        public Tuple<string[], string[]> GetPriorityFiles(string[] files, List<string> priority, List<string> others)
        {
            foreach (var file in files)
            {
                if (management.PriorityExtension.Find(x => x == FilesHelper.GetFileExtension(file)) != null)
                    priority.Add(file);
                else
                    others.Add(file);
            }
            return new Tuple<string[], string[]>(priority.ToArray(), others.ToArray());
        }
    }
}