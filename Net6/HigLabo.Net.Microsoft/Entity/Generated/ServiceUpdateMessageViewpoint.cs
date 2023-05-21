using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/serviceupdatemessageviewpoint?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceUpdateMessageViewpoint
    {
        public bool? IsArchived { get; set; }
        public bool? IsFavorited { get; set; }
        public bool? IsRead { get; set; }
    }
}
