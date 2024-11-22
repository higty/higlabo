using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/documentsetversion?view=graph-rest-1.0
/// </summary>
public partial class DocumentSetVersion
{
    public string? Comment { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public DocumentSetVersionItem[]? Items { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public TimeStamp? LastModifiedDateTime { get; set; }
    public PublicationFacet? Published { get; set; }
    public bool? ShouldCaptureMinorVersion { get; set; }
    public FieldValueSet? Fields { get; set; }
}
