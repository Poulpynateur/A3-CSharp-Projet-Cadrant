using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave.Model.Config
{
    public sealed class ConfigManager : JsonManager
    {
        private ConfigManager()
        {
        }
        private static readonly Lazy<ConfigManager> lazy = new Lazy<ConfigManager>(() => new ConfigManager());
        public static ConfigManager Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        
    }
}
