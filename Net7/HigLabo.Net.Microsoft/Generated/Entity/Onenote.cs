using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/onenote?view=graph-rest-1.0
    /// </summary>
    public partial class Onenote
    {
        public Notebook[]? Notebooks { get; set; }
        public OnenoteOperation[]? Operations { get; set; }
        public Page[]? Pages { get; set; }
        public OneNoteResource[]? Resources { get; set; }
        public SectionGroup[]? SectionGroups { get; set; }
        public Section[]? Sections { get; set; }
    }
}
