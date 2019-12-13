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
        /// <summary>
        /// Constructor
        /// </summary>
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
        /// <param name="files">Array of files</param>
        /// <param name="fileHistory">Dictionary of the config of the differential save</param>
        /// <returns>Array of the files to modifiy</returns>
        private string[] GetDiffFiles(string[] files, Dictionary<string, string> fileHistory)
        {
            List<string> diffFiles = new List<string>();
            foreach (string file in files)
            {
                if (!fileHistory.ContainsKey(file) || fileHistory[file] != FilesHelper.CalculateMD5(file))
                    diffFiles.Add(file);
            }
            return diffFiles.ToArray();
        }

        /// <summary>
        /// Save the priority files
        /// </summary>
        /// <param name="saveJob">SaveJob object <see cref="SaveJob"/></param>
        /// <param name="priority">List of path to priority files</param>
        /// <param name="fileHistory">Dictionary of the config of the differential save</param>
        /// <returns>Number of file copied or -1 if error</returns>
        private int SaveFilesPriority(SaveJob saveJob, List<string> priority, Dictionary<string, string> fileHistory)
        {
            if (priority.Count > 0)
                management.Threads.SetThreadPriority(saveJob.Name, true);

            FilesHelper.CopyDirectoryTree(saveJob.Source, saveJob.Target);
            foreach (string path in priority)
            {
                management.Threads.Map[saveJob.Name].Pause.WaitOne();

                saveJob.CheckAndCopy(path);
                fileHistory[path] = FilesHelper.CalculateMD5(path);
                if (saveJob.CheckIfStopped(path))
                {
                    management.Threads.SetThreadPriority(saveJob.Name, false);
                    return -1;
                }
                saveJob.CheckERP();
            }
            management.Threads.SetThreadPriority(saveJob.Name, false);
            return 0;
        }

        /// <summary>
        /// Save the files that are not prioritary
        /// </summary>
        /// <param name="saveJob">SaveJob object <see cref="SaveJob"/></param>
        /// <param name="others">List of path to non prioritary files</param>
        /// <param name="fileHistory">Dictionary of the config of the differential save</param>
        /// <returns>Number of file copied or -1 if error</returns>
        private int SaveFilesOthers(SaveJob saveJob, List<string> others, Dictionary<string, string> fileHistory)
        {
            foreach (string path in others)
            {
                management.Threads.Priority.WaitOne();
                //Pause
                management.Threads.Map[saveJob.Name].Pause.WaitOne();

                saveJob.CheckAndCopy(path);
                fileHistory[path] = FilesHelper.CalculateMD5(path);
                if (saveJob.CheckIfStopped(path))
                    return -1;

                saveJob.CheckERP();
            }
            return 0;
        }

        /// <summary>
        /// Save files from a source folder to a target folder.
        /// </summary>
        /// <param name="saveJob">SaveJob object</param>
        /// <returns>Success message, otherwise throw an error</returns>
        private int SaveFiles(SaveJob saveJob)
        {
            string rootSavePath = Path.Combine(saveJob.Target, saveJob.Name);
            Dictionary<string, string> fileHistory = management.Config.LoadDiffSaveConfig(rootSavePath);

            string[] files = GetDiffFiles(saveJob.GetFiles(), fileHistory);

            List<string> priority = new List<string>();
            List<string> others = new List<string>();
            saveJob.GetPriorityFiles(files, priority, others);

            saveJob.Target = Path.Combine(saveJob.Target, saveJob.Name, FilesHelper.GenerateName("differential"));
            saveJob.Progress.FilesNumber = files.Length;

            FilesHelper.CopyDirectoryTree(saveJob.Source, saveJob.Target);

            if (SaveFilesPriority(saveJob, priority, fileHistory) < 0)
                return -1;

            if (SaveFilesOthers(saveJob, others, fileHistory) < 0)
                return -1;

            management.Config.SaveDiffSaveConfig(fileHistory, rootSavePath);

            return saveJob.Progress.FilesDone;
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// <see cref="BaseCommand.CheckOptions(Dictionary{string, string})"/>
        /// Launch the differential save. Check if the folders exists beforewise.
        /// </summary>
        /// <param name="options">Dictionary of options needed to execute the differential job</param>
        public override void Execute(Dictionary<string, string> options)
        {
            SaveJob saveJob = new SaveJob(
                management,
                options["name"],
                options["source"],
                options["target"],
                (options["encrypt"].Equals("yes")) ? true : false
            );
            management.Display.DisplayText(Statut.INFO, management.Lang.Translate("Job started : ") + saveJob.Name + " ...");
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
