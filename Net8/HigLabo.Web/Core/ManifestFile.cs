using HigLabo.Newtonsoft;
using Newtonsoft.Json;

namespace HigLabo.Web;

public class ManifestFile
{
    public class Icon
    {
        public string Src { get; set; } = "";
        public string Type { get; set; } = "";
        public string Sizes { get; set; } = "";

        public Icon() { }
        public Icon(string src, string type, string sizes)
        {
            Src = src;
            Type = type;
            Sizes = sizes;
        }
    }
    public string Name { get; set; } = "";
    public string Short_Name { get; set; } = "";
    public string Start_Url { get; set; } = "./";
    public string Display { get; set; } = "standalone";
    public string Background_Color { get; set; } = "#ffffff";
    public string Theme_Color { get; set; } = "";
    public bool prefer_related_applications { get; set; } = false;

    public List<Icon> Icons { get; init; } = new();

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { ContractResolver = new LowercaseContractResolver() });
    }
}
