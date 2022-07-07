using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalconnectorsExternalconnectionDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ConnectionsId { get; set; }
    }
    public partial class ExternalconnectorsExternalconnectionDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalconnectionDeleteResponse> ExternalconnectorsExternalconnectionDeleteAsync()
        {
            var p = new ExternalconnectorsExternalconnectionDeleteParameter();
            return await this.SendAsync<ExternalconnectorsExternalconnectionDeleteParameter, ExternalconnectorsExternalconnectionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalconnectionDeleteResponse> ExternalconnectorsExternalconnectionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalconnectorsExternalconnectionDeleteParameter();
            return await this.SendAsync<ExternalconnectorsExternalconnectionDeleteParameter, ExternalconnectorsExternalconnectionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalconnectionDeleteResponse> ExternalconnectorsExternalconnectionDeleteAsync(ExternalconnectorsExternalconnectionDeleteParameter parameter)
        {
            return await this.SendAsync<ExternalconnectorsExternalconnectionDeleteParameter, ExternalconnectorsExternalconnectionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalconnectionDeleteResponse> ExternalconnectorsExternalconnectionDeleteAsync(ExternalconnectorsExternalconnectionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalconnectorsExternalconnectionDeleteParameter, ExternalconnectorsExternalconnectionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
