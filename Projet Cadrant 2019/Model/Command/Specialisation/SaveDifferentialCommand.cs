using EasySave.Helpers.Files;
using EasySave.Model.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EasySave.Model.Command.Specialisation
{
    class SaveDifferentialCommand : BaseCommand
    {
        private ILogger logger;
        private JsonManager json;

        public SaveDifferentialCommand(ILogger logger)
        : base("save-differential", "Create a differential save from a source to a target folder.")
        {
            this.logger = logger;
            this.json = new JsonManager();

            this.Options = new Dictionary<string, string>
            {
                { "source", ".*" },
                { "target", ".*" }
            };
        }

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

        private Dictionary<string, string> loadDiffConfig(string target)
        {
            Dictionary<string, string> fileHistory = new Dictionary<string, string>();

            if (File.Exists(target))
            {
                fileHistory = json.ReadJson<Dictionary<string, string>>(target);
            }

            return fileHistory;
        }

        private string SaveFiles(string source, string target)
        {
            string[] files = Directory.GetFiles(source, "*", SearchOption.AllDirectories);
            target = Path.Combine(target, "save_differential");
            string confPath = Path.Combine(target, "conf.json");
            target = Path.Combine(target, FilesManager.GetNameWithTime("save"));

            Progress progress = new Progress();
            progress.FeedProgress(files.Length, FilesManager.GetFilesSize(files));
            logger.WriteProgress(progress);

            Dictionary<string, string> fileHistory = loadDiffConfig(confPath);

            FilesManager.CopyDirectoryTree(source, target);

            foreach (string newPath in files)
            {
                progress.RemainingFiles -= 1;
                progress.RemainingFilesSize -= new FileInfo(newPath).Length;

                if (!fileHistory.ContainsKey(newPath) || fileHistory[newPath] != CalculateMD5(newPath))
                {
                    File.Copy(newPath, newPath.Replace(source, target), true);
                    fileHistory[newPath] = CalculateMD5(newPath);
                }

                progress.RefreshProgress(newPath);
                logger.WriteProgress(progress);
            }

            json.WriteJson(fileHistory, confPath);

            return progress.FilesNumber + " file(s) save successfully !";
        }

        public override string Execute(Dictionary<string, string> options)
        {
            this.CheckOptions(options);

            string source = options["source"];
            string target = options["target"];

            if (!Directory.Exists(source))
                throw new Exception("Source folder doesn't exist : " + source);
            if (!Directory.Exists(target))
                throw new Exception("Target folder doesn't exist : " + target);

            return SaveFiles(source, target);
        }
    }
}
