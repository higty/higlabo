using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss;

public class RssCloud
{
    public string Domain { get; set; } = "";
    public string Port { get; set; } = "";
    public string Path { get; set; } = "";
    public string RegisterProcedure { get; set; } = "";
    public string Protocol { get; set; } = "";

    public RssCloud()
    {
        
    }
    public RssCloud(XElement element)
    {
        if (element != null)
        {
            Parse(element);
        }
    }
    protected void Parse(XElement element)
    {
        Domain = element.CastAttributeToString("domain") ?? "";
        Port = element.CastAttributeToString("port") ?? "";
        Path = element.CastAttributeToString("path") ?? "";
        RegisterProcedure = element.CastAttributeToString("registerProcedure") ?? "";
        Protocol = element.CastAttributeToString("protocol") ?? "";
    }
}