using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalConnectorsExternalGroupDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ConnectionsId { get; set; }
            public string ExternalGroupId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.External_Connections_ConnectionsId_Groups_ExternalGroupId: return $"/external/connections/{ConnectionsId}/groups/{ExternalGroupId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            External_Connections_ConnectionsId_Groups_ExternalGroupId,
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
    public partial class ExternalConnectorsExternalGroupDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalGroupDeleteResponse> ExternalConnectorsExternalGroupDeleteAsync()
        {
            var p = new ExternalConnectorsExternalGroupDeleteParameter();
            return await this.SendAsync<ExternalConnectorsExternalGroupDeleteParameter, ExternalConnectorsExternalGroupDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalGroupDeleteResponse> ExternalConnectorsExternalGroupDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalGroupDeleteParameter();
            return await this.SendAsync<ExternalConnectorsExternalGroupDeleteParameter, ExternalConnectorsExternalGroupDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalGroupDeleteResponse> ExternalConnectorsExternalGroupDeleteAsync(ExternalConnectorsExternalGroupDeleteParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalGroupDeleteParameter, ExternalConnectorsExternalGroupDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalConnectorsExternalGroupDeleteResponse> ExternalConnectorsExternalGroupDeleteAsync(ExternalConnectorsExternalGroupDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalGroupDeleteParameter, ExternalConnectorsExternalGroupDeleteResponse>(parameter, cancellationToken);
        }
    }
}
