using EasySave.Helpers;
using EasySave.Helpers.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace EasySave.Model.Job.Specialisation
{
    /// <summary>
    /// Create a differential save from a source to a target folder.
    /// </summary>
    class SaveDifferentialJob : BaseJob
    {
        private Progress progress;

        public SaveDifferentialJob()
        : base("save-differential", "Create a differential save from a source to a target folder.")
        {
            this.progress = new Progress();
            this.Options = new List<Option>
            {
                new Option("name", "Name of the save", @"^((?![\*\.\/\\\[\]:;\|,]).)*$"),
                new Option("source", "Source folder", @".*"),
                new Option("target", "Target folder", @".*")
            };
        }

        /// <summary>
        /// Calculate the MD5 checksum of a file.
        /// </summary>
        /// <param name="filename">Path to the file</param>
        /// <returns>MD5 checksum to string format</returns>
        private string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }


        /// <summary>
        /// Save files from a source folder to a target folder.
        /// </summary>
        /// <param name="source">Source folder path</param>
        /// <param name="target">Target folder path</param>
        /// <returns>Success message, otherwise throw an error</returns>
        private int SaveFiles(string name, string source, string target)
        {
            string[] files = Directory.GetFiles(source, "*", SearchOption.AllDirectories);
            string rootSavePath = Path.Combine(target, name);
            Dictionary<string, string> fileHistory = Output.Config.LoadDiffSaveConfig(rootSavePath);
            
            target = Path.Combine(target, name, FilesHelper.GenerateName("differential"));

            progress.FeedProgress(files.Length, FilesHelper.GetFilesSize(files));
            Output.Logger.WriteProgress(progress);

            FilesHelper.CopyDirectoryTree(source, target);
            foreach (string newPath in files)
            {
                if (!fileHistory.ContainsKey(newPath) || fileHistory[newPath] != CalculateMD5(newPath))
                {
                    progress.EncryptionTimeMs = 0;
                    progress.FilesDone += 1;
                    progress.RemainingFilesSize -= new FileInfo(newPath).Length;

                    File.Copy(newPath, newPath.Replace(source, target), true);
                    if (Output.Encrypt.IsEncryptTarget(newPath))
                    {
                        progress.EncryptionTimeMs = Output.Encrypt.EncryptFileCryptoSoft(newPath, newPath.Replace(source, target));
                        if (progress.EncryptionTimeMs < 0)
                            throw new Exception("Encryption error on " + newPath);
                    }

                    fileHistory[newPath] = CalculateMD5(newPath);
                }

                Output.Logger.WriteProgress(
                    progress.RefreshProgress(newPath)
                );
                Output.Display.DisplayText(Statut.INFO, newPath + " file copied.");
            }

            Output.Config.SaveDiffSaveConfig(fileHistory, rootSavePath);

            return progress.FilesDone;
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// <see cref="BaseCommand.CheckOptions(Dictionary{string, string})"/>
        /// Launch the differential save. Check if the folders exists beforewise.
        /// </summary>
        public override void Execute(Dictionary<string, string> options)
        {
            Output.CheckErpRunning();
            this.CheckOptions(options);

            string name = options["name"];
            string source = options["source"];
            string target = options["target"];

            if (!Directory.Exists(source))
                throw new Exception("Source folder doesn't exist : " + source);
            if (!Directory.Exists(target))
                throw new Exception("Target folder doesn't exist : " + target);

            Output.Display.DisplayText(
                Statut.SUCCESS,
                SaveFiles(name, source, target) + " file(s) saved !"
            );
        }
    }
}
