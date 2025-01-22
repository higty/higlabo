using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/printtaskdefinition?view=graph-rest-1.0
/// </summary>
public partial class PrintTaskDefinition
{
    public AppIdentity? CreatedBy { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public PrintTask[]? Tasks { get; set; }
}
