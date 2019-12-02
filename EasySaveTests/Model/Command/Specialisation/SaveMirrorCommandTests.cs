using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasySave.Model.Command.Specialisation;
using System;
using System.Collections.Generic;
using System.Text;
using EasySave.Model.Config;

namespace EasySave.Model.Command.Specialisation.Tests
{
    [TestClass()]
    public class SaveMirrorCommandTests
    {
        [TestMethod()]
        [ExpectedException(typeof(Exception),"Source folder doesn't exists")]
        public void ExecuteTestSourceFalse()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            keyValuePairs.Add("name", "unNomDeSave");
            keyValuePairs.Add("source", "sourcePath");
            keyValuePairs.Add("target", "C:\\tmp\\");

            ConfigManager cm = ConfigManager.Instance;
            SaveMirrorCommand mirrorCmd = new SaveMirrorCommand(cm);

            mirrorCmd.Execute(keyValuePairs);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Target folder doesn't exists")]
        public void ExecuteTestTargetFalse()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            keyValuePairs.Add("name", "unNomDeSave");
            keyValuePairs.Add("source", "C:\\tmp\\");
            keyValuePairs.Add("target", "targetPath");

            ConfigManager cm = ConfigManager.Instance;
            SaveMirrorCommand mirrorCmd = new SaveMirrorCommand(cm);

            mirrorCmd.Execute(keyValuePairs);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Options missing or invalid")]
        public void ExecuteTestOptionsNull()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            keyValuePairs.Add("", "unNomDeSave");
            keyValuePairs.Add("", "sourcePath");
            keyValuePairs.Add("", "targetPath");

            ConfigManager cm = ConfigManager.Instance;
            SaveMirrorCommand mirrorCmd = new SaveMirrorCommand(cm);

            mirrorCmd.Execute(keyValuePairs);
        }
    }
}