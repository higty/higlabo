using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/presence?view=graph-rest-1.0
    /// </summary>
    public partial class Presence
    {
        public String? Id { get; set; }
        public Presencestring Availability { get; set; }
        public Presencestring Activity { get; set; }
    }
}
