using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/documentsetcontent?view=graph-rest-1.0
    /// </summary>
    public partial class DocumentSetContent
    {
        public ContentTypeInfo? ContentType { get; set; }
        public String? FileName { get; set; }
        public String? FolderName { get; set; }
    }
}
