using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/sectionlinks?view=graph-rest-1.0
    /// </summary>
    public partial class SectionLinks
    {
        public ExternalLink? OneNoteClientUrl { get; set; }
        public ExternalLink? OneNoteWebUrl { get; set; }
    }
}
