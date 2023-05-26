using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/contenttypeorder?view=graph-rest-1.0
    /// </summary>
    public partial class ContentTypeOrder
    {
        public bool? Default { get; set; }
        public Int32? Position { get; set; }
    }
}
