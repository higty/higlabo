using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/subscribedsku?view=graph-rest-1.0
    /// </summary>
    public partial class SubscribedSku
    {
        public string AppliesTo { get; set; }
        public string CapabilityStatus { get; set; }
        public Int32? ConsumedUnits { get; set; }
        public string Id { get; set; }
        public LicenseUnitsDetail? PrepaidUnits { get; set; }
        public ServicePlanInfo[] ServicePlans { get; set; }
        public Guid? SkuId { get; set; }
        public string SkuPartNumber { get; set; }
    }
}
