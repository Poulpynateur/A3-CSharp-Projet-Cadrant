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

        /// <summary>
        /// Save files from a source folder to a target folder.
        /// </summary>
        /// <param name="source">Source folder path</param>
        /// <param name="target">Target folder path</param>
        /// <returns>Success message, otherwise throw an error</returns>
        private int SaveFiles(SaveJob saveJob)
        {
            string[] files = saveJob.GetFiles();
            saveJob.Target = Path.Combine(saveJob.Target, saveJob.Name, FilesHelper.GenerateName("mirror"));

            //Boucle to check priority + progress here
            //Barrier there

            FilesHelper.CopyDirectoryTree(saveJob.Name, saveJob.Target);
            foreach (string path in files)
            {
                //Pause
                management.Threads.Map[saveJob.Name].ManualResetEvent.WaitOne();

                //Monitor for disk
                saveJob.CopyTargetFile(path);
                //Monitor for output
                if (saveJob.CheckIfStopped(path))
                    return -1;
            }

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
                management.CheckErpRunning();
                this.CheckOptions(options);

                saveJob.CheckIfFoldersExist();
                saveJob.SaveEnd(SaveFiles(saveJob));
            }));

            saveJob.StartIfNotExist(thread);
        }
    }
}