using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-update?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsExternalconnectionUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public ExternalConnectorsConfiguration? Configuration { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
    }
    public partial class ExternalConnectorsExternalconnectionUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionUpdateResponse> ExternalConnectorsExternalconnectionUpdateAsync()
        {
            var p = new ExternalConnectorsExternalconnectionUpdateParameter();
            return await this.SendAsync<ExternalConnectorsExternalconnectionUpdateParameter, ExternalConnectorsExternalconnectionUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionUpdateResponse> ExternalConnectorsExternalconnectionUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalconnectionUpdateParameter();
            return await this.SendAsync<ExternalConnectorsExternalconnectionUpdateParameter, ExternalConnectorsExternalconnectionUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionUpdateResponse> ExternalConnectorsExternalconnectionUpdateAsync(ExternalConnectorsExternalconnectionUpdateParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalconnectionUpdateParameter, ExternalConnectorsExternalconnectionUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionUpdateResponse> ExternalConnectorsExternalconnectionUpdateAsync(ExternalConnectorsExternalconnectionUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalconnectionUpdateParameter, ExternalConnectorsExternalconnectionUpdateResponse>(parameter, cancellationToken);
        }
    }
}
