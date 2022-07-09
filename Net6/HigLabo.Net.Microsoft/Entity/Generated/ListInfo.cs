using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/listinfo?view=graph-rest-1.0
    /// </summary>
    public partial class ListInfo
    {
        public bool? ContentTypesEnabled { get; set; }
        public bool? Hidden { get; set; }
        public string? Template { get; set; }
    }
}
