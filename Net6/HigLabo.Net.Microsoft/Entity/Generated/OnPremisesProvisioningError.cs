using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/onpremisesprovisioningerror?view=graph-rest-1.0
    /// </summary>
    public partial class OnPremisesProvisioningError
    {
        public string Category { get; set; }
        public DateTimeOffset OccurredDateTime { get; set; }
        public string PropertyCausingError { get; set; }
        public string Value { get; set; }
    }
}
