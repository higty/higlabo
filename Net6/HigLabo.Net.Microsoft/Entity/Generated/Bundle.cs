using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/bundle?view=graph-rest-1.0
    /// </summary>
    public partial class Bundle
    {
        public Int32? ChildCount { get; set; }
        public Album? Album { get; set; }
    }
}
