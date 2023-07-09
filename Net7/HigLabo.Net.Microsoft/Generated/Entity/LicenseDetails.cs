using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/licensedetails?view=graph-rest-1.0
    /// </summary>
    public partial class LicenseDetails
    {
        public string? Id { get; set; }
        public ServicePlanInfo[]? ServicePlans { get; set; }
        public Guid? SkuId { get; set; }
        public string? SkuPartNumber { get; set; }
    }
}
