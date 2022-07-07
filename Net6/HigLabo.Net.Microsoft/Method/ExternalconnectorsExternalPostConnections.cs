using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalconnectorsExternalPostConnectionsParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Configuration? Configuration { get; set; }
    }
    public partial class ExternalconnectorsExternalPostConnectionsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-external-post-connections?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalPostConnectionsResponse> ExternalconnectorsExternalPostConnectionsAsync()
        {
            var p = new ExternalconnectorsExternalPostConnectionsParameter();
            return await this.SendAsync<ExternalconnectorsExternalPostConnectionsParameter, ExternalconnectorsExternalPostConnectionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-external-post-connections?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalPostConnectionsResponse> ExternalconnectorsExternalPostConnectionsAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalconnectorsExternalPostConnectionsParameter();
            return await this.SendAsync<ExternalconnectorsExternalPostConnectionsParameter, ExternalconnectorsExternalPostConnectionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-external-post-connections?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalPostConnectionsResponse> ExternalconnectorsExternalPostConnectionsAsync(ExternalconnectorsExternalPostConnectionsParameter parameter)
        {
            return await this.SendAsync<ExternalconnectorsExternalPostConnectionsParameter, ExternalconnectorsExternalPostConnectionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-external-post-connections?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalPostConnectionsResponse> ExternalconnectorsExternalPostConnectionsAsync(ExternalconnectorsExternalPostConnectionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalconnectorsExternalPostConnectionsParameter, ExternalconnectorsExternalPostConnectionsResponse>(parameter, cancellationToken);
        }
    }
}
