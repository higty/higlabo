using HigLabo.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Resources;
using System.Xml.Serialization;

namespace DbSharpApplication
{
    public class SchemeData
    {
        public static LanguageText<HigLaboText> Text { get; set; } = new();
        public static SchemeData Current = new SchemeData();

        public string FileName { get; set; } = "";
        public ObservableCollection<GenerateSetting> GenerateSettingList { get; init; } = new();
    }
}
