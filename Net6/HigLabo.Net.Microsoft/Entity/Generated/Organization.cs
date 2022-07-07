using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-organization?view=graph-rest-1.0
    /// </summary>
    public partial class Organization
    {
        public enum OrganizationMdmAuthority
        {
            Unknown,
            Intune,
            Sccm,
            Office365,
        }

        public string? Id { get; set; }
        public MdmAuthority? MobileDeviceManagementAuthority { get; set; }
    }
}
