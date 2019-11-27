using EasySave.Helpers.Files;
using EasySave.Model.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EasySave.Model.Command.Specialisation
{
    class SaveMirrorCommand : BaseCommand
    {
        private ILogger logger;

        public object Date { get; private set; }

        public SaveMirrorCommand(ILogger logger)
            : base("save-mirror", "Create a mirror save from a source to a target folder.")
        {
            this.logger = logger;

            this.Options = new Dictionary<string, string> 
            {
                { "source", ".*" },
                { "target", ".*" }
            };
        }

        private string SaveFiles(string source, string target)
        {
            string[] files = Directory.GetFiles(source, "*", SearchOption.AllDirectories);
            target = Path.Combine(target, FilesManager.GetNameWithTime("mirror_save"));

            Progress progress = new Progress();

            progress.FeedProgress(files.Length, FilesManager.GetFilesSize(files));
            logger.WriteProgress(progress);

            FilesManager.CopyDirectoryTree(source, target);

            foreach (string newPath in files)
            {
                progress.RemainingFiles -= 1;
                progress.RemainingFilesSize -= new FileInfo(newPath).Length;
                
                File.Copy(newPath, newPath.Replace(source, target), true);
                
                progress.RefreshProgress(newPath);
                logger.WriteProgress(progress);
            }

            return progress.FilesNumber + " file(s) save successfully !";
        } 

        public override string Execute(Dictionary<string, string> options)
        {
            this.CheckOptions(options);

            string source = options["source"];
            string target = options["target"];

            if(!Directory.Exists(source))
                throw new Exception("Source folder doesn't exist : " + source );
            if(!Directory.Exists(target))
                throw new Exception("Target folder doesn't exist : " + target);

            return SaveFiles(source, target);
        }
    }
}