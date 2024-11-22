using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/traininglanguagedetail?view=graph-rest-1.0
/// </summary>
public partial class TrainingLanguageDetail
{
    public string? Content { get; set; }
    public EmailIdentity? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public bool? IsDefaultLangauge { get; set; }
    public EmailIdentity? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public string? Locale { get; set; }
}
