using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/addin?view=graph-rest-1.0
/// </summary>
public partial class AddIn
{
    public Guid? Id { get; set; }
    public KeyValue[]? Properties { get; set; }
    public string? Type { get; set; }
}
