using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/companysubscription?view=graph-rest-1.0
    /// </summary>
    public partial class CompanySubscription
    {
        public string? CommerceSubscriptionId { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public bool? IsTrial { get; set; }
        public DateTimeOffset? NextLifecycleDateTime { get; set; }
        public string? OwnerId { get; set; }
        public string? OwnerTenantId { get; set; }
        public string? OwnerType { get; set; }
        public ServicePlanInfo[]? ServiceStatus { get; set; }
        public string? SkuId { get; set; }
        public string? SkuPartNumber { get; set; }
        public string? Status { get; set; }
        public Int32? TotalLicenses { get; set; }
    }
}
