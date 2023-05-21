using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/driverecipient?view=graph-rest-1.0
    /// </summary>
    public partial class DriveRecipient
    {
        public string? Alias { get; set; }
        public string? Email { get; set; }
        public string? ObjectId { get; set; }
    }
}
