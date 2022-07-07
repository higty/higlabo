using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalconnectorsExternalitemGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            External_Connections_ConnectionsId_Items_ExternalItemId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.External_Connections_ConnectionsId_Items_ExternalItemId: return $"/external/connections/{ConnectionsId}/items/{ExternalItemId}";
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
        public string ConnectionsId { get; set; }
        public string ExternalItemId { get; set; }
    }
    public partial class ExternalconnectorsExternalitemGetResponse : RestApiResponse
    {
        public Acl[]? Acl { get; set; }
        public ExternalItemContent? Content { get; set; }
        public string? Id { get; set; }
        public Properties? Properties { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalitemGetResponse> ExternalconnectorsExternalitemGetAsync()
        {
            var p = new ExternalconnectorsExternalitemGetParameter();
            return await this.SendAsync<ExternalconnectorsExternalitemGetParameter, ExternalconnectorsExternalitemGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalitemGetResponse> ExternalconnectorsExternalitemGetAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalconnectorsExternalitemGetParameter();
            return await this.SendAsync<ExternalconnectorsExternalitemGetParameter, ExternalconnectorsExternalitemGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalitemGetResponse> ExternalconnectorsExternalitemGetAsync(ExternalconnectorsExternalitemGetParameter parameter)
        {
            return await this.SendAsync<ExternalconnectorsExternalitemGetParameter, ExternalconnectorsExternalitemGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalitemGetResponse> ExternalconnectorsExternalitemGetAsync(ExternalconnectorsExternalitemGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalconnectorsExternalitemGetParameter, ExternalconnectorsExternalitemGetResponse>(parameter, cancellationToken);
        }
    }
}
