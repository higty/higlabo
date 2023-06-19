using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-delete?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsExternalconnectionDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ConnectionsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.External_Connections_ConnectionsId: return $"/external/connections/{ConnectionsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            External_Connections_ConnectionsId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class ExternalConnectorsExternalconnectionDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionDeleteResponse> ExternalConnectorsExternalconnectionDeleteAsync()
        {
            var p = new ExternalConnectorsExternalconnectionDeleteParameter();
            return await this.SendAsync<ExternalConnectorsExternalconnectionDeleteParameter, ExternalConnectorsExternalconnectionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionDeleteResponse> ExternalConnectorsExternalconnectionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalconnectionDeleteParameter();
            return await this.SendAsync<ExternalConnectorsExternalconnectionDeleteParameter, ExternalConnectorsExternalconnectionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionDeleteResponse> ExternalConnectorsExternalconnectionDeleteAsync(ExternalConnectorsExternalconnectionDeleteParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalconnectionDeleteParameter, ExternalConnectorsExternalconnectionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionDeleteResponse> ExternalConnectorsExternalconnectionDeleteAsync(ExternalConnectorsExternalconnectionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalconnectionDeleteParameter, ExternalConnectorsExternalconnectionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
