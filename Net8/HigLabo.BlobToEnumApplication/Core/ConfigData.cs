using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HigLabo.Core;

namespace BlobToEnumApplication
{
    public class BlobContainerSetting
    {
        public string ConnectionString { get; set; } = "";
        public string ContainerName { get; set; } = "";
        public string RootNamespaceName { get; init; } = "";
        public string OutputFileName { get; set; } = "";
        public string Extension { get; set; } = "";
    }
    public class ConfigData
    {
        public static ConfigData Current { get; set; } = new ConfigData();

        public static String SettingFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\HigLabo\\BlobToEnumApplication";
        public static String SettingFilePath
        {
            get { return SettingFolderPath + "\\Config.json"; }
        }

        public ObservableCollection<BlobContainerSetting> ContainerList { get; init; } = new();

        public ConfigData() { }

        public void Save()
        {
            File.WriteAllText(SettingFilePath, JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true }));
        }
        private static void EnsureFileExists()
        {
            if (Directory.Exists(SettingFolderPath) == false)
            {
                Directory.CreateDirectory(SettingFolderPath);
            }
            var path = SettingFilePath;
            if (File.Exists(path) == false)
            {
                var data = new ConfigData();
                File.WriteAllText(path, JsonSerializer.Serialize(data));
            }
        }
        public static ConfigData Load()
        {
            EnsureFileExists();
            var path = SettingFilePath;
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<ConfigData>(json)!;
        }
    }
}
