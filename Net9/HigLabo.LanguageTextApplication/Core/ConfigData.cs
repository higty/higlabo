using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HigLabo.Core;

namespace LanguageTextApplication.Core;

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

    public static String SettingFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\HigLabo\\LanguageTextApplication";
    public static String SettingFilePath
    {
        get { return SettingFolderPath + "\\Config.json"; }
    }

    public ObservableCollection<FolderSetting> FolderList { get; init; } = new();

    public ConfigData() { }

    public void Save()
    {
        File.WriteAllText(SettingFilePath, JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true }));
    }
    private static void EnsureFileExists()
    {
        var path = SettingFilePath;
        if (Directory.Exists(SettingFolderPath) == false)
        {
            Directory.CreateDirectory(SettingFolderPath);
        }
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
