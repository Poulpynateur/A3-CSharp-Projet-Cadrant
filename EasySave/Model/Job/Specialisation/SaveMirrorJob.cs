using EasySave.Helpers;
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
                new Option("encrypt", "Encrypt special files", @"yes|no"),
                new Option("source", "Source folder", @".*"),
                new Option("target", "Target folder", @".*")
            };
        }

        private string[] InitiSave(string source)
        {
            string[] files = Directory.GetFiles(source, "*", SearchOption.AllDirectories);

            progress.FeedProgress(files.Length, FilesHelper.GetFilesSize(files));
            output.Logger.WriteProgress(progress);

            return files;
        }

        private void OutputDisplayAndLog(string newPath)
        {
            output.Logger.WriteProgress(
                progress.RefreshFileProgress(newPath, new FileInfo(newPath).Length)
            );
            output.Display.DisplayText(Statut.INFO, newPath + " file copied.");
        }

        private void CopyTargetFile(string path, string newPath, bool encrypt)
        {
            File.Copy(path, newPath, true);
            if (encrypt && output.Encrypt.IsEncryptTarget(path))
            {
                progress.EncryptionTimeMs = output.Encrypt.EncryptFileCryptoSoft(path, newPath);
                if (progress.EncryptionTimeMs < 0)
                    throw new Exception("Encryption error on " + path);
            }
        }

        /// <summary>
        /// Save files from a source folder to a target folder.
        /// </summary>
        /// <param name="source">Source folder path</param>
        /// <param name="target">Target folder path</param>
        /// <returns>Success message, otherwise throw an error</returns>
        private int SaveFiles(string name , string source, string target, bool encrypt)
        {
            string[] files = InitiSave(source);
            target = Path.Combine(target, name, FilesHelper.GenerateName("mirror"));

            //Boucle to check priority + progress here
            //Barrier there

            FilesHelper.CopyDirectoryTree(source, target);
            foreach (string path in files)
            {
                //Monitor for disk
                CopyTargetFile(path, path.Replace(source, target), encrypt);
                //Monitor for output
                OutputDisplayAndLog(path);
            }

            return progress.FilesDone;
        }

        /// <summary>
        /// <see cref="BaseCommand.Execute(Dictionary{string, string})"/>
        /// <see cref="BaseCommand.CheckOptions(Dictionary{string, string})"/>
        /// Launch the mirro save. Check if the folders exists beforewise.
        /// </summary>
        public override void Execute(Dictionary<string, string> options)
        {
            output.CheckErpRunning();
            this.CheckOptions(options);

            string name = options["name"];
            bool encrypt = (options["encrypt"].Equals("yes")) ? true : false;
            string source = options["source"];
            string target = options["target"];

            if(!Directory.Exists(source))
                throw new Exception("Source folder doesn't exist : " + source );
            if(!Directory.Exists(target))
                throw new Exception("Target folder doesn't exist : " + target);

            output.Display.DisplayText(
                Statut.SUCCESS,
                SaveFiles(name, source, target, encrypt) + " file(s) saved !"
            );
        }
    }
}