using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/bundle?view=graph-rest-1.0
    /// </summary>
    public partial class Bundle
    {
        public Album? Album { get; set; }
        public Int32? ChildCount { get; set; }
    }
}
