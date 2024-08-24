using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/cloudpcusersettingassignment?view=graph-rest-1.0
    /// </summary>
    public partial class CloudPcUserSettingAssignment
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public CloudPcManagementAssignmentTarget? Target { get; set; }
    }
}
