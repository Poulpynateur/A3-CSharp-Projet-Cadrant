using System;
using System.Collections.Generic;
using System.Text;
using Projet_Cadrant_2019.Model;

namespace EasySave.Model.Config
{
    public sealed class ConfigManager : JsonManager
    {
        private static readonly Lazy<ConfigManager> lazy =
            new Lazy<ConfigManager>(() => new ConfigManager());

        public static ConfigManager Instance { get { return lazy.Value; } }

        private ConfigManager()
        {
        }
    }
}
