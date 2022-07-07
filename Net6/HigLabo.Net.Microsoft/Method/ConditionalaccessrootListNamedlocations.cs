using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConditionalaccessrootListNamedlocationsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class ConditionalaccessrootListNamedlocationsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/namedlocation?view=graph-rest-1.0
        /// </summary>
        public partial class NamedLocation
        {
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public DateTimeOffset? ModifiedDateTime { get; set; }
        }

        public NamedLocation[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-list-namedlocations?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccessrootListNamedlocationsResponse> ConditionalaccessrootListNamedlocationsAsync()
        {
            var p = new ConditionalaccessrootListNamedlocationsParameter();
            return await this.SendAsync<ConditionalaccessrootListNamedlocationsParameter, ConditionalaccessrootListNamedlocationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-list-namedlocations?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccessrootListNamedlocationsResponse> ConditionalaccessrootListNamedlocationsAsync(CancellationToken cancellationToken)
        {
            var p = new ConditionalaccessrootListNamedlocationsParameter();
            return await this.SendAsync<ConditionalaccessrootListNamedlocationsParameter, ConditionalaccessrootListNamedlocationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-list-namedlocations?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccessrootListNamedlocationsResponse> ConditionalaccessrootListNamedlocationsAsync(ConditionalaccessrootListNamedlocationsParameter parameter)
        {
            return await this.SendAsync<ConditionalaccessrootListNamedlocationsParameter, ConditionalaccessrootListNamedlocationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-list-namedlocations?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccessrootListNamedlocationsResponse> ConditionalaccessrootListNamedlocationsAsync(ConditionalaccessrootListNamedlocationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConditionalaccessrootListNamedlocationsParameter, ConditionalaccessrootListNamedlocationsResponse>(parameter, cancellationToken);
        }
    }
}
