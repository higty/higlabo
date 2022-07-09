using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/itemactivity?view=graph-rest-1.0
    /// </summary>
    public partial class ItemActivity
    {
        public string? Id { get; set; }
        public AccessAction? Access { get; set; }
        public IdentitySet? Actor { get; set; }
        public DateTimeOffset? ActivityDateTime { get; set; }
        public DriveItem? DriveItem { get; set; }
        public ListItem? ListItem { get; set; }
    }
}
