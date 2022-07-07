using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class NamedlocationGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class NamedlocationGetResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/namedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<NamedlocationGetResponse> NamedlocationGetAsync()
        {
            var p = new NamedlocationGetParameter();
            return await this.SendAsync<NamedlocationGetParameter, NamedlocationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/namedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<NamedlocationGetResponse> NamedlocationGetAsync(CancellationToken cancellationToken)
        {
            var p = new NamedlocationGetParameter();
            return await this.SendAsync<NamedlocationGetParameter, NamedlocationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/namedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<NamedlocationGetResponse> NamedlocationGetAsync(NamedlocationGetParameter parameter)
        {
            return await this.SendAsync<NamedlocationGetParameter, NamedlocationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/namedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<NamedlocationGetResponse> NamedlocationGetAsync(NamedlocationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<NamedlocationGetParameter, NamedlocationGetResponse>(parameter, cancellationToken);
        }
    }
}
