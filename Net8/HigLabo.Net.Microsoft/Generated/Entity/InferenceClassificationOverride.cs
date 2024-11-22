using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/inferenceclassificationoverride?view=graph-rest-1.0
/// </summary>
public partial class InferenceClassificationOverride
{
    public enum InferenceClassificationOverrideInferenceClassificationType
    {
        Focused,
        Other,
    }

    public InferenceClassificationOverrideInferenceClassificationType ClassifyAs { get; set; }
    public string? Id { get; set; }
    public EmailAddress? SenderEmailAddress { get; set; }
}
