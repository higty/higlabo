using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Json;

namespace HigLabo.Web.TagHelpers;

public class ImportMapPathList
{
    private readonly Dictionary<string, string> _pathDictionary = new();

    public IReadOnlyDictionary<string, string> PathDictionary => this._pathDictionary;

    public void AddImportsPath(string key, string value)
    {
        if (key.IsNullOrEmpty() || value.IsNullOrEmpty()) { return; }

        this._pathDictionary[key] = value;
    }

    public void AddImportsPathFromDirectory(string physicalDirectoryPath, string requestPathPrefix, Func<string, string> convertValue)
    {
        if (Directory.Exists(physicalDirectoryPath) == false) { return; }

        var prefix = requestPathPrefix.TrimEnd('/');
        foreach (var filePath in Directory.GetFiles(physicalDirectoryPath, "*.js", SearchOption.AllDirectories))
        {
            var relativePath = Path.GetRelativePath(physicalDirectoryPath, filePath).Replace('\\', '/');
            var key = $"{prefix}/{relativePath}";
            this.AddImportsPath(key, convertValue(key));
        }
    }
}

[HtmlTargetElement("import-map")]
public class ImportMapTagHelper : TagHelper
{
    public ImportMapPathList PathList { get; set; } = new();

    public void AddImportsPath(string key, string value)
    {
        this.PathList.AddImportsPath(key, value);
    }

    public void AddImportsPathFromDirectory(string physicalDirectoryPath, string requestPathPrefix, Func<string, string> convertValue)
    {
        this.PathList.AddImportsPathFromDirectory(physicalDirectoryPath, requestPathPrefix, convertValue);
    }

    public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "script";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Attributes.SetAttribute("type", "importmap");

        var json = JsonSerializer.Serialize(new
        {
            imports = this.PathList.PathDictionary,
        });
        output.Content.SetHtmlContent(json);

        return base.ProcessAsync(context, output);
    }
}
