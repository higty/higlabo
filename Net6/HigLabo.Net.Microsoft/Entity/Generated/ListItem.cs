using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/listitem?view=graph-rest-1.0
    /// </summary>
    public partial class ListItem
    {
        public ContentTypeInfo? ContentType { get; set; }
    }
}
