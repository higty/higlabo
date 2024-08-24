using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/admin?view=graph-rest-1.0
    /// </summary>
    public partial class Admin
    {
        public Edge? Edge { get; set; }
        public AdminMicrosoft365Apps? Microsoft365Apps { get; set; }
        public PeopleAdminSettings? People { get; set; }
        public AdminReportSettings? ReportSettings { get; set; }
        public ServiceAnnouncement? ServiceAnnouncement { get; set; }
        public SharepointSettings? SharepointSettings { get; set; }
    }
}
