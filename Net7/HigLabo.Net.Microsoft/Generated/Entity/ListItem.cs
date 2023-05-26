using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/listitem?view=graph-rest-1.0
    /// </summary>
    public partial class ListItem
    {
        public ContentTypeInfo? ContentType { get; set; }
        public ItemActivity[]? Activities { get; set; }
        public ItemAnalytics? Analytics { get; set; }
        public DocumentSetVersion[]? DocumentSetVersions { get; set; }
        public DriveItem? DriveItem { get; set; }
        public FieldValueSet? Fields { get; set; }
        public ListItemVersion[]? Versions { get; set; }
    }
}
