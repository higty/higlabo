using HigLabo.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace DbSharpApplication
{
    public class ConfigData
    {
        public static LanguageText<HigLaboText> Text { get; set; } = new();
        public static ConfigData Current = new ConfigData();

        public static String SettingFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\HigLabo\\DbSharpApplication";
        public static String SettingFilePath
        {
            get { return SettingFolderPath + "\\ConfigData.xml"; }
        }

        public string SchemeFilePath { get; set; } = "";
        public List<string> SchemeFilePathList { get; init; } = new();

        public void EnsureFileExists()
        {
            Directory.CreateDirectory(SettingFolderPath);
            if (File.Exists(SettingFilePath) == false)
            {
                File.WriteAllText(SettingFilePath, "");
            }

        }
  
        public void Save()
        {
            var cv = new XmlConverter();
            File.WriteAllText(SettingFilePath, cv.Serialize(this));
            File.WriteAllText(GetSchemeFilePath(), cv.Serialize(SchemeData.Current));
        }
        public static void Load()
        {
            if (File.Exists(SettingFilePath) == true)
            {
                var xmlText = File.ReadAllText(SettingFilePath);
                try
                {
                    var cv = new XmlConverter();
                    ConfigData.Current = cv.Deserialize<ConfigData>(xmlText)!;
                    if (ConfigData.Current.SchemeFilePathList.Count == 0)
                    {
                        var schemeFilePath = Path.Combine(SettingFolderPath, "SchemeData.xml");
                        ConfigData.Current.SchemeFilePathList.Add(schemeFilePath);
                    }
                }
                catch
                {
                    ConfigData.Current = new ConfigData();
                }
            }
            else
            {
                ConfigData.Current = new ConfigData();
            }
            ConfigData.Current.LoadSchemeFile(ConfigData.Current.GetSchemeFilePath());
        }

        public string GetSchemeFilePath()
        {
            if (this.SchemeFilePath.IsNullOrEmpty())
            {
                return Path.Combine(SettingFolderPath, "SchemeData.xml");
            }
            return this.SchemeFilePath;
        }
        public void LoadSchemeFile(string filePath)
        {
            try
            {
                var xmlText = File.ReadAllText(filePath);
                var cv = new XmlConverter();
                SchemeData.Current = cv.Deserialize<SchemeData>(xmlText)!;
            }
            catch
            {
                MessageBox.Show("File not found." + Environment.NewLine + filePath);
            }
        }
    }
}
