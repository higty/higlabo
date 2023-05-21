using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/folder?view=graph-rest-1.0
    /// </summary>
    public partial class Folder
    {
        public Int32? ChildCount { get; set; }
        public FolderView? View { get; set; }
    }
}
