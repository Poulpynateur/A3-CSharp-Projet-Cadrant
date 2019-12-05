using EasySave.Helpers.Files;
using System;
using System.Collections.Generic;
using System.IO;

namespace EasySave.Model.Job.Specialisation
{
    /// <summary>
    /// Create a mirror save from a source to a target folder.
    /// </summary>
    public class SaveMirrorJob : BaseJob
    {
        private Progress progress;

        public object Date { get; private set; }

        public SaveMirrorJob()
            : base("save-mirror", "Create a mirror save from a source to a target folder.")
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
        /// Save files from a source folder to a target folder.
        /// </summary>
        /// <param name="source">Source folder path</param>
        /// <param name="target">Target folder path</param>
        /// <returns>Success message, otherwise throw an error</returns>
        private string SaveFiles(string name , string source, string target)
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
                progress.FilesDone += 1;
                progress.RemainingFilesSize -= new FileInfo(newPath).Length;

                File.Copy(newPath, newPath.Replace(source, target), true);

                Output.Logger.WriteProgress(
                    progress.RefreshProgress(newPath)
                );
            }

            return progress.FilesDone + " file(s) save !";
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// <see cref="BaseCommand.CheckOptions(Dictionary{string, string})"/>
        /// Launch the mirro save. Check if the folders exists beforewise.
        /// </summary>
        public override string Execute(Dictionary<string, string> options)
        {
            this.CheckOptions(options);

            string name = options["name"];
            string source = options["source"];
            string target = options["target"];

            if(!Directory.Exists(source))
                throw new Exception("Source folder doesn't exist : " + source );
            if(!Directory.Exists(target))
                throw new Exception("Target folder doesn't exist : " + target);

            return SaveFiles(name, source, target);
        }
    }
}