using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConditionalaccessrootPostNamedlocationsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Identity_ConditionalAccess_NamedLocations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_ConditionalAccess_NamedLocations: return $"/identity/conditionalAccess/namedLocations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public IpRange[]? IpRanges { get; set; }
    }
    public partial class ConditionalaccessrootPostNamedlocationsResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public IpRange[]? IpRanges { get; set; }
        public bool? IsTrusted { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-post-namedlocations?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccessrootPostNamedlocationsResponse> ConditionalaccessrootPostNamedlocationsAsync()
        {
            var p = new ConditionalaccessrootPostNamedlocationsParameter();
            return await this.SendAsync<ConditionalaccessrootPostNamedlocationsParameter, ConditionalaccessrootPostNamedlocationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-post-namedlocations?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccessrootPostNamedlocationsResponse> ConditionalaccessrootPostNamedlocationsAsync(CancellationToken cancellationToken)
        {
            var p = new ConditionalaccessrootPostNamedlocationsParameter();
            return await this.SendAsync<ConditionalaccessrootPostNamedlocationsParameter, ConditionalaccessrootPostNamedlocationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-post-namedlocations?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccessrootPostNamedlocationsResponse> ConditionalaccessrootPostNamedlocationsAsync(ConditionalaccessrootPostNamedlocationsParameter parameter)
        {
            return await this.SendAsync<ConditionalaccessrootPostNamedlocationsParameter, ConditionalaccessrootPostNamedlocationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-post-namedlocations?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccessrootPostNamedlocationsResponse> ConditionalaccessrootPostNamedlocationsAsync(ConditionalaccessrootPostNamedlocationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConditionalaccessrootPostNamedlocationsParameter, ConditionalaccessrootPostNamedlocationsResponse>(parameter, cancellationToken);
        }
    }
}
