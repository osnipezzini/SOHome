using SOHome.Common.Models;

using System;
using System.IO;
using System.Text.Json;

namespace SOHome.Common
{
    public class AppSettings
    {
        public const string AppName = "SOHome";
        public const string Secret = "90a3f7438c6e2e5c794ea47f3bd8da1c";
        public const string AuthToken = "authToken";
        private static Setting setting;
        
        private static readonly string _dataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SOHome");

        private static readonly string _configFile = Path.Combine(_dataFolder, "config.db");
        public static Setting Settings
        {
            get
            {
                if (setting == null)
                    Load();
                return setting;
            }
        }

        public static void Save()
        {
            var json = JsonSerializer.Serialize(Settings);
            File.WriteAllText(_configFile, json);
        }

        public static void Load()
        {
            if (!Directory.Exists(_dataFolder))
                Directory.CreateDirectory(_dataFolder);
            if (File.Exists(_configFile))
            {
                var json = File.ReadAllText(_configFile);
                try
                {
                    setting = JsonSerializer.Deserialize<Setting>(json);
                }
                catch (Exception ex)
                {
                    setting = new Setting();
                }
            }
            else
                setting = new Setting();
        }
    }
}
