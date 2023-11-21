using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HigLabo.Core;

namespace LanguageTextApplication.Core
{
    public class FolderSetting
    {
        public String SourceFolderPath { get; set; } = "";
        public String CSharpFileName { get; set; } = "";
        public String RootNamespaceName { get; init; } = "";
        public String ClassName { get; init; } = "";
        public String CopyFilePath { get; set; } = "";
    }
    public class ConfigData
    {
        public static ConfigData Current { get; set; } = new ConfigData();

        public ObservableCollection<FolderSetting> FolderList { get; init; } = new();

        public ConfigData() { }

        public void Save()
        {
            var path = System.IO.Path.Combine(Environment.CurrentDirectory, "Config.json");
            File.WriteAllText(path, JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true }));
        }
        public static ConfigData Load()
        {
            var path = System.IO.Path.Combine(Environment.CurrentDirectory, "Config.json");
            if (File.Exists(path) == false)
            {
                var data = new ConfigData();
                File.WriteAllText(path, JsonSerializer.Serialize(data));
                return data;
            }
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<ConfigData>(json)!;
        }
    }
}
