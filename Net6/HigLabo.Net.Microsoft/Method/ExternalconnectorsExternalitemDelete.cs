using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalConnectorsExternalitemDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ConnectionsId { get; set; }
            public string? ExternalItemId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.External_Connections_ConnectionsId_Items_ExternalItemId: return $"/external/connections/{ConnectionsId}/items/{ExternalItemId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            External_Connections_ConnectionsId_Items_ExternalItemId,
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
    public partial class ExternalConnectorsExternalitemDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalitemDeleteResponse> ExternalConnectorsExternalitemDeleteAsync()
        {
            var p = new ExternalConnectorsExternalitemDeleteParameter();
            return await this.SendAsync<ExternalConnectorsExternalitemDeleteParameter, ExternalConnectorsExternalitemDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalitemDeleteResponse> ExternalConnectorsExternalitemDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalitemDeleteParameter();
            return await this.SendAsync<ExternalConnectorsExternalitemDeleteParameter, ExternalConnectorsExternalitemDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalitemDeleteResponse> ExternalConnectorsExternalitemDeleteAsync(ExternalConnectorsExternalitemDeleteParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalitemDeleteParameter, ExternalConnectorsExternalitemDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalitem-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalitemDeleteResponse> ExternalConnectorsExternalitemDeleteAsync(ExternalConnectorsExternalitemDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalitemDeleteParameter, ExternalConnectorsExternalitemDeleteResponse>(parameter, cancellationToken);
        }
    }
}
