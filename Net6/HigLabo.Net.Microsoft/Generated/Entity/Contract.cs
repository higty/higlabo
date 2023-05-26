using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/contract?view=graph-rest-1.0
    /// </summary>
    public partial class Contract
    {
        public string? ContractType { get; set; }
        public Guid? CustomerId { get; set; }
        public string? DefaultDomainName { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
    }
}
