using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-attributemappingsource?view=graph-rest-1.0
/// </summary>
public partial class AttributeMappingSource
{
    public enum AttributeMappingSourceAttributeMappingSourceType
    {
        Attribute,
        Constant,
        Function,
    }

    public string? Expression { get; set; }
    public string? Name { get; set; }
    public StringKeyAttributeMappingSourceValuePair[]? Parameters { get; set; }
    public AttributeMappingSourceAttributeMappingSourceType Type { get; set; }
}
