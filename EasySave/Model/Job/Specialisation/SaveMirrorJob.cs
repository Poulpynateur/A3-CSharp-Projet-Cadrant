using EasySave.Helpers;
using EasySave.Helpers.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace EasySave.Model.Job.Specialisation
{
    /// <summary>
    /// Create a mirror save from a source to a target folder.
    /// </summary>
    public class SaveMirrorJob : BaseJob
    {
        public SaveMirrorJob()
            : base("save-mirror", "Create a mirror save from a source to a target folder.")
        {
            this.Options = new List<Option>
            {
                new Option("name", "Name of the save", @"^((?![\*\.\/\\\[\]:;\|,]).)*$"),
                new Option("encrypt", "Encrypt special files", @"yes|no"),
                new Option("source", "Source folder", @".*"),
                new Option("target", "Target folder", @".*")
            };
        }

        private int SaveFilesPriority(SaveJob saveJob, List<string> priority)
        {
            if (priority.Count > 0)
                management.Threads.SetThreadPriority(saveJob.Name, true);

            FilesHelper.CopyDirectoryTree(saveJob.Source, saveJob.Target);
            foreach (string path in priority)
            {
                management.Threads.Map[saveJob.Name].ManualResetEvent.WaitOne();

                saveJob.CheckAndCopy(path);
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

        private int SaveFilesOthers(SaveJob saveJob, List<string> others)
        {
            foreach (string path in others)
            {
                management.Threads.Priority.WaitOne();
                //Pause
                management.Threads.Map[saveJob.Name].ManualResetEvent.WaitOne();

                saveJob.CheckAndCopy(path);
                if (saveJob.CheckIfStopped(path))
                    return -1;

                saveJob.CheckERP();
            }
            return 0;
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

            List<string> priority = new List<string>();
            List<string> others = new List<string>();
            saveJob.GetPriorityFiles(files, priority, others);

            saveJob.Target = Path.Combine(saveJob.Target, saveJob.Name, FilesHelper.GenerateName("mirror"));
            FilesHelper.CopyDirectoryTree(saveJob.Source, saveJob.Target);

            if (SaveFilesPriority(saveJob, priority) < 0)
                return -1;

            if (SaveFilesOthers(saveJob, others) < 0)
                return -1;

            return saveJob.Progress.FilesDone;
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// <see cref="BaseCommand.CheckOptions(Dictionary{string, string})"/>
        /// Launch the mirro save. Check if the folders exists beforewise.
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