using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-post-namedlocations?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessRootPostNamedLocationsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_ConditionalAccess_NamedLocations: return $"/identity/conditionalAccess/namedLocations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Identity_ConditionalAccess_NamedLocations,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public IpRange[]? IpRanges { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public bool? IsTrusted { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
    }
    public partial class ConditionalAccessRootPostNamedLocationsResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public IpRange[]? IpRanges { get; set; }
        public bool? IsTrusted { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-post-namedlocations?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-post-namedlocations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessRootPostNamedLocationsResponse> ConditionalAccessRootPostNamedLocationsAsync()
        {
            var p = new ConditionalAccessRootPostNamedLocationsParameter();
            return await this.SendAsync<ConditionalAccessRootPostNamedLocationsParameter, ConditionalAccessRootPostNamedLocationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-post-namedlocations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessRootPostNamedLocationsResponse> ConditionalAccessRootPostNamedLocationsAsync(CancellationToken cancellationToken)
        {
            var p = new ConditionalAccessRootPostNamedLocationsParameter();
            return await this.SendAsync<ConditionalAccessRootPostNamedLocationsParameter, ConditionalAccessRootPostNamedLocationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-post-namedlocations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessRootPostNamedLocationsResponse> ConditionalAccessRootPostNamedLocationsAsync(ConditionalAccessRootPostNamedLocationsParameter parameter)
        {
            return await this.SendAsync<ConditionalAccessRootPostNamedLocationsParameter, ConditionalAccessRootPostNamedLocationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-post-namedlocations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessRootPostNamedLocationsResponse> ConditionalAccessRootPostNamedLocationsAsync(ConditionalAccessRootPostNamedLocationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConditionalAccessRootPostNamedLocationsParameter, ConditionalAccessRootPostNamedLocationsResponse>(parameter, cancellationToken);
        }
    }
}
