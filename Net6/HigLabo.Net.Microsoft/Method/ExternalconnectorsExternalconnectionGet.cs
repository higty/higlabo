using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalconnectorsExternalconnectionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            External_Connections_ConnectionsId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.External_Connections_ConnectionsId: return $"/external/connections/{ConnectionsId}";
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
    }
    public partial class ExternalconnectorsExternalconnectionGetResponse : RestApiResponse
    {
        public enum ExternalConnectionExternalConnectorsConnectionState
        {
            Draft,
            Ready,
            Obsolete,
            LimitExceeded,
            UnknownFutureValue,
        }

        public Configuration? Configuration { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public ExternalConnectionExternalConnectorsConnectionState State { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalconnectionGetResponse> ExternalconnectorsExternalconnectionGetAsync()
        {
            var p = new ExternalconnectorsExternalconnectionGetParameter();
            return await this.SendAsync<ExternalconnectorsExternalconnectionGetParameter, ExternalconnectorsExternalconnectionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalconnectionGetResponse> ExternalconnectorsExternalconnectionGetAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalconnectorsExternalconnectionGetParameter();
            return await this.SendAsync<ExternalconnectorsExternalconnectionGetParameter, ExternalconnectorsExternalconnectionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalconnectionGetResponse> ExternalconnectorsExternalconnectionGetAsync(ExternalconnectorsExternalconnectionGetParameter parameter)
        {
            return await this.SendAsync<ExternalconnectorsExternalconnectionGetParameter, ExternalconnectorsExternalconnectionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalconnectionGetResponse> ExternalconnectorsExternalconnectionGetAsync(ExternalconnectorsExternalconnectionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalconnectorsExternalconnectionGetParameter, ExternalconnectorsExternalconnectionGetResponse>(parameter, cancellationToken);
        }
    }
}
