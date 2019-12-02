using EasySave.Helpers.Files;
using EasySave.Model.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EasySave.Model.Command.Specialisation
{
    /// <summary>
    /// Create a mirror save from a source to a target folder.
    /// </summary>
    public class SaveMirrorCommand : BaseCommand
    {
        private ILogger logger;

        public object Date { get; private set; }

        public SaveMirrorCommand(ILogger logger)
            : base("save-mirror", "Create a mirror save from a source to a target folder.")
        {
            this.logger = logger;

            this.Options = new Dictionary<string, string> 
            {
                { "name", @"^((?![\*\.\/\\\[\]:;\|,]).)*$" },
                { "source", ".*" },
                { "target", ".*" }
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
            target = Path.Combine(target, name);
            target = Path.Combine(target, FilesManager.GenerateName("save"));

            Progress progress = new Progress();

            progress.FeedProgress(files.Length, FilesManager.GetFilesSize(files));
            logger.WriteProgress(progress);

            FilesManager.CopyDirectoryTree(source, target);

            foreach (string newPath in files)
            {
                progress.FilesDone += 1;
                progress.RemainingFilesSize -= new FileInfo(newPath).Length;
                
                File.Copy(newPath, newPath.Replace(source, target), true);
                
                progress.RefreshProgress(newPath);
                logger.WriteProgress(progress);
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