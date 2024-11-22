using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-property?view=graph-rest-1.0
/// </summary>
public partial class ExternalConnectorsProperty
{
    public enum ExternalConnectorsPropertyExternalConnectorsLabel
    {
        Title,
        Url,
        CreatedBy,
        LastModifiedBy,
        Authors,
        CreatedDateTime,
        LastModifiedDateTime,
        FileName,
        FileExtension,
        UnknownFutureValue,
    }
    public enum ExternalConnectorsPropertyExternalConnectorsPropertyType
    {
        String,
        Int64,
        Double,
        DateTime,
        Boolean,
        StringCollection,
        Int64Collection,
        DoubleCollection,
        DateTimeCollection,
        UnknownFutureValue,
    }

    public String[]? Aliases { get; set; }
    public bool? IsQueryable { get; set; }
    public bool? IsRefinable { get; set; }
    public bool? IsRetrievable { get; set; }
    public bool? IsSearchable { get; set; }
    public ExternalConnectorsPropertyExternalConnectorsLabel Labels { get; set; }
    public string? Name { get; set; }
    public ExternalConnectorsPropertyExternalConnectorsPropertyType Type { get; set; }
}
