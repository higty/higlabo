using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/listitemversion?view=graph-rest-1.0
    /// </summary>
    public partial class ListItemVersion
    {
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public TimeStamp? LastModifiedDateTime { get; set; }
        public PublicationFacet? Published { get; set; }
        public FieldValueSet? Fields { get; set; }
    }
}
