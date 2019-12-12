using EasySave.Helpers;
using EasySave.Helpers.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;

namespace EasySave.Model.Job.Specialisation
{
    /// <summary>
    /// Create a differential save from a source to a target folder.
    /// </summary>
    class SaveDifferentialJob : BaseJob
    {
        public SaveDifferentialJob()
        : base("save-differential", "Create a differential save from a source to a target folder.")
        {
            this.Options = new List<Option>
            {
                new Option("name", "Name of the save", @"^((?![\*\.\/\\\[\]:;\|,]).)*$"),
                new Option("encrypt", "Encrypt special files", @"yes|no"),
                new Option("source", "Source folder", @".*"),
                new Option("target", "Target folder", @".*")
            };
        }

        /// <summary>
        /// Get the number of files to modify
        /// </summary>
        /// <returns>Count of the number of files to modifiy</returns>
        private int GetNbDiffFiles(string[] files, Dictionary<string, string> fileHistory)
        {
            int count = 0;
            foreach (string file in files)
            {
                if (!fileHistory.ContainsKey(file) || fileHistory[file] != FilesHelper.CalculateMD5(file))
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Save files from a source folder to a target folder.
        /// </summary>
        /// <param name="source">Source folder path</param>
        /// <param name="target">Target folder path</param>
        /// <returns>Success message, otherwise throw an error</returns>
        private int SaveFiles(SaveJob saveJob)
        {
            string[] files = saveJob.GetFiles();

            string rootSavePath = Path.Combine(saveJob.Target, saveJob.Name);
            Dictionary<string, string> fileHistory = management.Config.LoadDiffSaveConfig(rootSavePath);

            saveJob.Target = Path.Combine(saveJob.Target, saveJob.Name, FilesHelper.GenerateName("differential"));
            saveJob.Progress.FilesNumber = GetNbDiffFiles(files, fileHistory);

            FilesHelper.CopyDirectoryTree(saveJob.Source, saveJob.Target);
            foreach (string path in files)
            {
                //Pause
                management.Threads.Map[saveJob.Name].ManualResetEvent.WaitOne();

                if (!fileHistory.ContainsKey(path) || fileHistory[path] != FilesHelper.CalculateMD5(path))
                {
                    saveJob.CopyTargetFile(path);
                    fileHistory[path] = FilesHelper.CalculateMD5(path);
                }

                if (saveJob.CheckIfStopped(path))
                    return -1;
            }
            management.Config.SaveDiffSaveConfig(fileHistory, rootSavePath);

            return saveJob.Progress.FilesDone;
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// <see cref="BaseCommand.CheckOptions(Dictionary{string, string})"/>
        /// Launch the differential save. Check if the folders exists beforewise.
        /// </summary>
        public override void Execute(Dictionary<string, string> options)
        {
            SaveJob saveJob = new SaveJob(
                management,
                options["name"],
                options["source"],
                options["target"],
                (options["encrypt"].Equals("yes")) ? true : false
            );

            Thread thread = new Thread(new ThreadStart(() =>
            {
                CheckOptions(options);

                saveJob.CheckIfFoldersExist();
                saveJob.SaveEnd(SaveFiles(saveJob));
            }));

            saveJob.StartIfNotExist(thread);
        }
    }
}
