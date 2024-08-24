using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/serverprocessedcontent?view=graph-rest-1.0
    /// </summary>
    public partial class ServerProcessedContent
    {
        public MetaDataKeyStringPair[]? ComponentDependencies { get; set; }
        public MetaDataKeyValuePair[]? CustomMetadata { get; set; }
        public MetaDataKeyStringPair[]? HtmlStrings { get; set; }
        public MetaDataKeyStringPair[]? ImageSources { get; set; }
        public MetaDataKeyStringPair[]? Links { get; set; }
        public MetaDataKeyStringPair[]? SearchablePlainTexts { get; set; }
    }
}
