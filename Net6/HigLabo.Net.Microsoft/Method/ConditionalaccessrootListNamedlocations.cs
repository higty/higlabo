using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConditionalAccessRootListNamedLocationsParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            CreatedDateTime,
            DisplayName,
            Id,
            ModifiedDateTime,
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class ConditionalAccessRootListNamedLocationsResponse : RestApiResponse
    {
        public NamedLocation[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-list-namedlocations?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalAccessRootListNamedLocationsResponse> ConditionalAccessRootListNamedLocationsAsync()
        {
            var p = new ConditionalAccessRootListNamedLocationsParameter();
            return await this.SendAsync<ConditionalAccessRootListNamedLocationsParameter, ConditionalAccessRootListNamedLocationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-list-namedlocations?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalAccessRootListNamedLocationsResponse> ConditionalAccessRootListNamedLocationsAsync(CancellationToken cancellationToken)
        {
            var p = new ConditionalAccessRootListNamedLocationsParameter();
            return await this.SendAsync<ConditionalAccessRootListNamedLocationsParameter, ConditionalAccessRootListNamedLocationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-list-namedlocations?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalAccessRootListNamedLocationsResponse> ConditionalAccessRootListNamedLocationsAsync(ConditionalAccessRootListNamedLocationsParameter parameter)
        {
            return await this.SendAsync<ConditionalAccessRootListNamedLocationsParameter, ConditionalAccessRootListNamedLocationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-list-namedlocations?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalAccessRootListNamedLocationsResponse> ConditionalAccessRootListNamedLocationsAsync(ConditionalAccessRootListNamedLocationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConditionalAccessRootListNamedLocationsParameter, ConditionalAccessRootListNamedLocationsResponse>(parameter, cancellationToken);
        }
    }
}
