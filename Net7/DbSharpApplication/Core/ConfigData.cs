using HigLabo.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ObservableCollection<GenerateSetting> GenerateSettingList { get; init; } = new();


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
            this.Save(SettingFilePath);
        }
        public void Save(String filePath)
        {
            var cv = new XmlConverter();
            File.WriteAllText(filePath, cv.Serialize(this));
        }
        public static ConfigData Load()
        {
            return Load(SettingFilePath);
        }
        public static ConfigData Load(String filePath)
        {
            if (File.Exists(filePath) == true)
            {
                var xmlText = File.ReadAllText(filePath);
                try
                {
                    var cv = new XmlConverter();
                    return cv.Deserialize<ConfigData>(xmlText);
                }
                catch
                {
                    return new ConfigData();
                }
            }
            else
            {
                return new ConfigData();
            }
        }

    }
}
