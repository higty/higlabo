using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/inferenceclassification?view=graph-rest-1.0
/// </summary>
public partial class InferenceClassification
{
    public string? Id { get; set; }
    public InferenceClassificationOverride[]? Overrides { get; set; }
}
