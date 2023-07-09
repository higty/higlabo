using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/notebooklinks?view=graph-rest-1.0
    /// </summary>
    public partial class NotebookLinks
    {
        public ExternalLink? OneNoteClientUrl { get; set; }
        public ExternalLink? OneNoteWebUrl { get; set; }
    }
}
