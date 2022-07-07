using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IpnamedlocationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_ConditionalAccess_NamedLocations_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_ConditionalAccess_NamedLocations_Id: return $"/identity/conditionalAccess/namedLocations/{Id}";
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
        public string Id { get; set; }
    }
    public partial class IpnamedlocationGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/ipnamedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IpnamedlocationGetResponse> IpnamedlocationGetAsync()
        {
            var p = new IpnamedlocationGetParameter();
            return await this.SendAsync<IpnamedlocationGetParameter, IpnamedlocationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/ipnamedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IpnamedlocationGetResponse> IpnamedlocationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IpnamedlocationGetParameter();
            return await this.SendAsync<IpnamedlocationGetParameter, IpnamedlocationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/ipnamedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IpnamedlocationGetResponse> IpnamedlocationGetAsync(IpnamedlocationGetParameter parameter)
        {
            return await this.SendAsync<IpnamedlocationGetParameter, IpnamedlocationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/ipnamedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IpnamedlocationGetResponse> IpnamedlocationGetAsync(IpnamedlocationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IpnamedlocationGetParameter, IpnamedlocationGetResponse>(parameter, cancellationToken);
        }
    }
}
