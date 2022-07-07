using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalconnectorsExternalconnectionListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            External_Connections,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.External_Connections: return $"/external/connections";
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
    public partial class ExternalconnectorsExternalconnectionListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/externalconnectors-externalconnection?view=graph-rest-1.0
        /// </summary>
        public partial class ExternalConnection
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

        public ExternalConnection[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalconnectionListResponse> ExternalconnectorsExternalconnectionListAsync()
        {
            var p = new ExternalconnectorsExternalconnectionListParameter();
            return await this.SendAsync<ExternalconnectorsExternalconnectionListParameter, ExternalconnectorsExternalconnectionListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalconnectionListResponse> ExternalconnectorsExternalconnectionListAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalconnectorsExternalconnectionListParameter();
            return await this.SendAsync<ExternalconnectorsExternalconnectionListParameter, ExternalconnectorsExternalconnectionListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalconnectionListResponse> ExternalconnectorsExternalconnectionListAsync(ExternalconnectorsExternalconnectionListParameter parameter)
        {
            return await this.SendAsync<ExternalconnectorsExternalconnectionListParameter, ExternalconnectorsExternalconnectionListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalconnectionListResponse> ExternalconnectorsExternalconnectionListAsync(ExternalconnectorsExternalconnectionListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalconnectorsExternalconnectionListParameter, ExternalconnectorsExternalconnectionListResponse>(parameter, cancellationToken);
        }
    }
}
